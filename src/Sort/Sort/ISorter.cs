using System.Collections.Generic;

namespace Sort
{
    public interface ISorter
    {
        IEnumerable<Card> SortCard(IEnumerable<Card> cards);
    }
}