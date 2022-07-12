using Microsoft.AspNetCore.Mvc.RazorPages;
using VMC.Framework.Registration;

namespace Client.Web.Pages
{
    public class CompositionRegistryModel : PageModel
    {
        private readonly CompositionHandlerRegistry handlerRegistry;
        public List<string> HandlerTypes { get; set; }

        public CompositionRegistryModel(CompositionHandlerRegistry handlerRegistry)
        {
            this.handlerRegistry = handlerRegistry;
        }
        public void OnGet()
        {
            var handlerTypes = handlerRegistry.GetHandlerTypes().Select(t => t.FullName).ToList();
            HandlerTypes = handlerTypes;

        }
    }
}
