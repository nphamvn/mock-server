using System.Text;
using MockServer.Core.Interfaces;
using MockServer.Core.Services;

namespace MockServer.ReverseProxyServer.Extentions;

public static class ApplicationBuilderExtentions
{
    public static IApplicationBuilder MapTestPaths(this IApplicationBuilder app)
    {
        app.Map("/dev/print-request", app =>
        {
            app.Run(async context =>
            {
                var request = await HttpContextExtentions.GetRequestDictionary(context);
                await context.Response.WriteAsJsonAsync(new
                {
                    request = request
                });
            });
        });

        app.Map("/dev/render-handlebars-template", app =>
        {
            app.Run(async context =>
            {
                var request = await HttpContextExtentions.GetRequestDictionary(context);
                IHandlebarsTemplateRenderer renderService = new HandlebarsTemplateRenderer();
                var ctx = new
                {
                    request = request
                };
                var result = renderService.Render(ctx, context.Request.Headers["template"]);
                await context.Response.WriteAsync(result);
            });
        });

        app.Map("/dev/render-expression-template", app =>
        {
            app.Run(async context =>
            {
                var request = await HttpContextExtentions.GetRequestDictionary(context);
                IExpressionTemplateWithScriptRenderer renderService = new ExpressionTemplateWithScriptRenderer();
                var ctx = new
                {
                    request = request
                };
                string template =
                        """
                        {
                            "message": "the sum of @{a} and @{b} is @{add(a, b)}"
                        }
                        """;
                string script =
                        """
                        const a = parseInt(ctx.request.query.a);
                        const b = parseInt(ctx.request.query.b);
                        const add = function(a, b) {
                            return a + b;
                        }
                        """;
                var result = renderService.Render(ctx, template, script);
                context.Response.StatusCode = 200;
                var data = Encoding.UTF8.GetBytes(result);
                context.Response.Headers["content-type"] = "application/json; charset=utf-8";
                await context.Response.Body.WriteAsync(data, 0, data.Length);
            });
        });
        return app;
    }
}
