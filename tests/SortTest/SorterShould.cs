using System;
using System.Linq;
using Sort;
using Xunit;

namespace SortTest
{
    public class SorterShould
    {
        [Fact]
        public void Sort()
        {
            // Arrange
            Card[] cards = GetActual();

            var sorter = new Sorter();

            // Act
            var result = sorter.SortCard(cards).ToArray();

            // Assert
            Assert.NotEmpty(result);

            Assert.True(isEqual(result, GetExpected()));
        }

        private Card[] GetActual()
        {
            return new Card[]
            {
                new Card {Start ="��������", Finish="�����" },
                new Card { Start="������" , Finish="�����" },
                new Card { Start="�����" , Finish="������" },
                new Card { Start="�����" , Finish="�����" },
                new Card { Start="������" , Finish="������" },
                new Card { Start="�����" , Finish="������" }
            };
        }

        private Card[] GetExpected()
        {
            return new Card[]
             {
                new Card {Start = "��������", Finish = "�����"},
                new Card {Start = "�����", Finish = "������"},
                new Card {Start = "������", Finish = "�����"},
                new Card {Start = "�����", Finish = "�����"},
                new Card {Start = "�����", Finish = "������"},
                new Card {Start = "������", Finish = "������"}
             };
        }

        private bool isEqual(Card[] left, Card[] right)
        {
            if (left.Length != right.Length)
                return false;

            return left.Zip(right, (l, r) => l.Finish.Equals(r.Finish, StringComparison.Ordinal)
                                           && l.Start.Equals(r.Start, StringComparison.Ordinal))
                 .All(z => z);
        }
    }
}
