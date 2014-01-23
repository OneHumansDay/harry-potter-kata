using System.Collections.Generic;
using System.Linq;

namespace HarryPotterKata
{
    public class PriceCalculator
    {
        private const decimal RegularPrice = 8;
        private const decimal TwoBooksDiscount = 0.05m;
        private const decimal ThreeBooksDiscount = 0.10m;
        private const decimal FourBooksDiscount = 0.20m;
        private const decimal FiveBooksDiscount = 0.25m;
        private const int MaxBooksForDicount = 5;
        
        public decimal Calculate(IList<HarryPotterAndThe> books)
        {
            var distinctBooks = new HashSet<HarryPotterAndThe>(books);
            
            decimal fullPrice = books.Count() * RegularPrice;
            decimal discount = CalculateDiscount(distinctBooks);
            
            return fullPrice - fullPrice * discount;
        }

        private static decimal CalculateDiscount(HashSet<HarryPotterAndThe> distinctBooks)
        {
            decimal discount = 0;

            if (distinctBooks.Count == 2)
            {
                discount = TwoBooksDiscount;
            }

            if (distinctBooks.Count == 3)
            {
                discount = ThreeBooksDiscount;
            }

            if (distinctBooks.Count == 4)
            {
                discount = FourBooksDiscount;
            }

            if (distinctBooks.Count >= 5)
            {
                discount = FiveBooksDiscount;
            }
            return discount;
        }
    }
}