using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Order
    {
        public BonusProvider Bonus { get; set; }


        private List<Product> _products = new List<Product>();

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }

        public double GetValueOfProducts()
        {
            double productsSum = _products.Sum(p => p.Value);
            return productsSum;
        }

        //// using Where()
        //public double GetValueOfProducts(DateTime date)
        //{
        //    double productsSum = _products.Where(p => date >= p.AvailableFrom && date <= p.AvailableTo)
        //                                  .Sum(p => p.Value);

        //    return productsSum;
        //}

        public double GetValueOfProducts(DateTime date)
        {
            double productsSum = _products.Sum(p => date >= p.AvailableFrom && date <= p.AvailableTo ? p.Value : 0);

            return productsSum;
        }

        public List<Product> SortProductOrderBy(Func<Product, object> keySelector)
        {
            List<Product> sortedProducts = _products.OrderBy(keySelector).ToList();

            return sortedProducts;
        }

        public List<Product> SortProductOrderByAvailableTo()
        {
            List<Product> sortedProducts = _products.OrderBy(p => p.AvailableTo).ToList();

            return sortedProducts;
        }

        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }

        public double GetBonus(Func<double, double> bonus)
        {
            return bonus(GetValueOfProducts());
        }
        public double GetBonus(DateTime date, Func<double, double> bonus)
        {
            return bonus(GetValueOfProducts(date));
        }

        //Func<int, int> compareTo = other => CompareTo(other)

        public double GetTotalPrice()
        {
            return GetValueOfProducts() - GetBonus();
        }
        public double GetTotalPrice(Func<double, double> amount)
        {
            return GetValueOfProducts() - GetBonus(amount);
        }
        public double GetTotalPrice(DateTime date, Func<double, double> amount)
        {
            return GetValueOfProducts(date) - GetBonus(date, amount);
        }



    }
}
