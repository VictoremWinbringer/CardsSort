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
            Card[] m = new Card[]
            {
                new Card {Start ="Мельбурн", Finish="Кельн" },
                new Card { Start="Москва" , Finish="Париж" },
                 new Card { Start="Кельн" , Finish="Москва" }
            };

            // Act
            var c = m.SortCard();

            // Assert
            Assert.IsNotNull(c);
            Assert.IsTrue( isEqual( c.ToArray(), new Card[]
            {
                new Card {Start ="Мельбурн", Finish="Кельн" },

                 new Card { Start="Кельн" , Finish="Москва" },
                new Card { Start="Москва" , Finish="Париж" }
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
        public bool isEqual(Card[] x, Card[] y)
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
