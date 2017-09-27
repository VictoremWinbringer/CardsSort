using System.Collections.Generic;
using System.Linq;

namespace Sort
{
    public sealed class Sorter : ISorter
    {
        /// <summary>
        /// Sorts the cards for the O (n)
        /// </summary>
        /// <param name="cards"><see cref="Card"/> list</param>
        /// <returns>sorted cards</returns>
        public IEnumerable<Card> SortCard(IEnumerable<Card> cards)
        {
            var dictionary = cards.ToDictionary(x => x.Start);

            string currentCity = FindStartingCity(dictionary.Values);

            int cardsCount = dictionary.Count;

            for (int currentCount = 0; currentCount < cardsCount; ++currentCount)
            {
                var currentCard = dictionary[currentCity];

                currentCity = currentCard.Finish;

                yield return currentCard;
            }
        }

        private string FindStartingCity(IEnumerable<Card> cards)
        {
            return FindStartingCity(cards.Select(c => c.Start), cards.Select(c => c.Finish));
        }

        private string FindStartingCity(IEnumerable<string> starts, IEnumerable<string> finishes)
        {
            return starts.Except(finishes).Single();
        }
    }
}