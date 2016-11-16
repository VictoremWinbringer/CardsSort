﻿using System;
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

        /// <summary>
        /// Сортирует карточки за O(n)
        /// </summary>
        /// <param name="carts">Список карточек</param>
        /// <returns>Отсортированные карточки или InvalidOperationExecption если список зациклен</returns>
        public static IEnumerable<Cart> SortCart(IEnumerable<Cart> carts)
        {
            var dictionary = carts.ToDictionary(x => x.Start);
            var linkedList = new LinkedList<Cart>(carts);

            var toarr = dictionary.Select(x => x.Value.Finish);
            string start = dictionary.Keys.Except(toarr).Single();

            var firstCard = dictionary[start];
            yield return firstCard;

            string next = firstCard.Finish;
            linkedList.Remove(firstCard);

            while (linkedList.Count > 0)
            {
                var nextCard = dictionary[next];
                next = nextCard.Finish;
                linkedList.Remove(nextCard);
                yield return nextCard;
            }
            yield break;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Cart[] m = new Cart[]
            {
               new Cart {Start ="B", Finish="C" },
                new Cart { Start="A" , Finish="B" },
                 new Cart { Start="J" , Finish="K" },
                 new Cart { Start="C" , Finish="D" },
                 new Cart { Start="I" , Finish="J" },
                 new Cart { Start="D" , Finish="E" },
                 new Cart { Start="H" , Finish="I" },
                 new Cart { Start="E" , Finish="F" },
                 new Cart { Start="G" , Finish="H" },
                 new Cart { Start="F" , Finish="G" }
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
