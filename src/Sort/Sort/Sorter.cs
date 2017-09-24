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
}