using AngloSDET.TestAutomation.UI.Models;

namespace AngloSDET.TestAutomation.UI.Interfaces
{
    public interface IHomePage
    {
        void AddProduct(string name);
        Cart GetShoppingCart();
    }
}
