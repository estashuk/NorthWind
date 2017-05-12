using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public void AddItem(Products product, int quantity)
        {
            CartLine line = _lineCollection.FirstOrDefault(x => x.Product.ProductID == product.ProductID);

            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Products product)
        {
            _lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(x => (decimal)x.Product.UnitPrice*x.Quantity);
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines => _lineCollection;
    }

    public class CartLine
    {
        public Products Product { get; set; }
        public int Quantity { get; set; }
    }
}