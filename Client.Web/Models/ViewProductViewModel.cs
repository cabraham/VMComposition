using VMC.Inventory.Composition;
using VMC.Sales.Composition;

namespace Client.Web.Models
{
    public class ViewProductViewModel : INeedToKnowProductPrice, INeedToKnowProductInventoryCount
    {
    }
}
