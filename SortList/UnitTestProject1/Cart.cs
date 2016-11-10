using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Sort()
        {
            // Arrange
            Cart[] m = new Cart[]
            {
                new Cart {Start ="Мельбурн", Finish="Кельн" },
                new Cart { Start="Москва" , Finish="Париж" },
                 new Cart { Start="Кельн" , Finish="Москва" }
            };

            // Act
            var c = Cart.SortCart(m);

            // Assert
            Assert.IsNotNull(c);
            Assert.IsTrue( isEqual( c.ToArray(), new Cart[]
            {
                new Cart {Start ="Мельбурн", Finish="Кельн" },

                 new Cart { Start="Кельн" , Finish="Москва" },
                new Cart { Start="Москва" , Finish="Париж" }
            }));

            //Assert.AreEqual(c.ToArray(), new Cart[]
            //{
            //    new Cart {Start ="Мельбурн", Finish="Кельн" },

            //     new Cart { Start="Кельн" , Finish="Москва" },
            //    new Cart { Start="Москва" , Finish="Париж" }
            //});
        }
        /// <summary>
        /// Метод для проверки равенства двух массивов
        /// </summary>
        /// <param name="x"> Левый массив для сравнения</param>
        /// <param name="y">Правый массив для сравнения</param>
        /// <returns> true если массивы равны false если они не равны</returns>
        public bool isEqual(Cart[] x, Cart[] y)
        {
            if (x.Length != y.Length)
                return false;
            if (x.Zip(y, (l, r) => l.Finish.Equals(r.Finish, StringComparison.InvariantCultureIgnoreCase)
              && l.Start.Equals(r.Start, StringComparison.InvariantCultureIgnoreCase))
              .All(z => z))
                return true;
            return false;
        }
    }
}
