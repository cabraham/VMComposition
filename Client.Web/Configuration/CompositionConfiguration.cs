using FluentAssemblyScanner;
using VMC.Framework.Composition;
using VMC.Framework.Registration;

namespace Client.Web.Configuration
{
    public static class CompositionConfiguration
    {
        public static void RegisterCompositionHandlers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IComposer, Composer>();
            serviceCollection.AddSingleton<CompositionHandlerRegistry>();
            serviceCollection.AddSingleton<CompositionHandlerLookup>();


        }

        public static void ConfigureHandlers(this IApplicationBuilder app)
        {
            var types = AssemblyScanner.FromAssemblyInThisApplicationDirectory()
                .BasedOn<IHandleCompositionRequest>()
                .Filter()
                .Classes()
                .Scan();

            if (!types.Any())
                return;

            var registry = app.ApplicationServices.GetRequiredService<CompositionHandlerRegistry>();
            foreach (var type in types)
            {
                registry.Add(type);
            }
        }
    }
}
