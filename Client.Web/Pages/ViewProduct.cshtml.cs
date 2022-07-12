using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VMC.Framework.Composition;

namespace Client.Web.Pages
{
    public class ViewProductModel : PageModel
    {
        private readonly IComposer composer;

        public ViewProductModel(IComposer composer)
        {
            this.composer = composer;
        }


        public int Value { get; set; }

        public void OnGet(int id)
        {
            Value = composer.Get();
        }
    }
}
