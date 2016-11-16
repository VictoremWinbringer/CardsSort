using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortList
{
    public static class CardSorter
    {
        /// <summary>
        /// Сортирует карточки за O(n) ВНИМАНИЕ: Имеет отложенное время выполнения.
        /// </summary>
        /// <param name="cards">Список карточек</param>
        /// <returns>Отсортированные карточки или InvalidOperationExecption если список зациклен</returns>
        public static IEnumerable<Card> SortCard(this IEnumerable<Card> cards)
        {
            int cardsCount = cards.Count();
            var dictionary = cards.ToDictionary(x => x.Start);

            var toarr = dictionary.Select(x => x.Value.Finish);
            string start = dictionary.Keys.Except(toarr).Single();

            var firstCard = dictionary[start];
            yield return firstCard;

            string next = firstCard.Finish;

            for (int currentCount = 1; currentCount < cardsCount; ++currentCount)
            {
                var nextCard = dictionary[next];
                next = nextCard.Finish;
                yield return nextCard;
            }
            yield break;
        }
    }
    /// <summary>
    /// Объектное представление карточки
    /// </summary>
    public class Card
    {
        public string Start { get; set; }
        public string Finish { get; set; }       
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Card[] m = new Card[]
            {
               new Card {Start ="B", Finish="C" },
                new Card { Start="A" , Finish="B" },
                 new Card { Start="J" , Finish="K" },
                 new Card { Start="C" , Finish="D" },
                 new Card { Start="I" , Finish="J" },
                 new Card { Start="D" , Finish="E" },
                 new Card { Start="H" , Finish="I" },
                 new Card { Start="E" , Finish="F" },
                 new Card { Start="G" , Finish="H" },
                 new Card { Start="F" , Finish="G" }
            };

            foreach (var i in m)
            {
                Console.WriteLine($"{i.Start} -> {i.Finish}");
            }

            Console.WriteLine(new string('-', 30));

            var c = m.SortCard();

            foreach (var i in c)
            {
                Console.WriteLine($"{i.Start} -> {i.Finish}");
            }

            Console.ReadLine();
        }
    }
}
