using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortList
{
    /// <summary>
    /// Объектное представление карточки
    /// </summary>
   public class Cart
    {
        public string Start { get; set; }
        public string Finish { get; set; }

        public static IEnumerable<Cart> SortCart(Cart[] c)
        {
            Array.Sort(c, new Comparer());
            return c;
        }
    }

    /// <summary>
    /// Переопределения класса для сравнения объектов в массиве.
    /// </summary>
   public class Comparer : IComparer<Cart>
    {
        public int Compare(Cart x, Cart y)
        {
            if (string.Compare(x.Finish, y.Start, true) == 0)
                return -1;
            if (string.Compare(x.Start, y.Finish, true) == 0)
                return 1;
            return 0;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Cart[] m = new Cart[]
            {
                new Cart {Start ="Мельбурн", Finish="Кельн" },
                new Cart { Start="Москва" , Finish="Париж" },
                 new Cart { Start="Кельн" , Finish="Москва" }
            };
            foreach (var i in m)
            {
                Console.WriteLine($"{i.Start} -> {i.Finish}");
            }
            Console.WriteLine(new string('-', 30));
            var c = Cart.SortCart(m);
            foreach (var i in c)
            {
                Console.WriteLine($"{i.Start} -> {i.Finish}");
            }
            Console.ReadLine();
        }
    }
}
