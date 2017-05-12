using System.Web.Mvc;
using Domain.Entities;

namespace Northwind.WebUI.Binders
{
    public class CartModelBinders
    {
        public class CartModelBinder : IModelBinder
        {
            private const string SessionKey = "Cart";
            public object BindModel(ControllerContext controllerContext, ModelBindingContext modelBindingContext)
            {
                Cart cart = (Cart)controllerContext.HttpContext.Session?[SessionKey];

                if (cart == null)
                {
                    cart = new Cart();
                    if (controllerContext.HttpContext.Session != null)
                        controllerContext.HttpContext.Session[SessionKey] = cart;
                }

                return cart;
            }
        }
    }
}