using System.Linq;

namespace HarryPotterKata
{
    public class PriceCalculator
    {
        private const decimal RegularPrice = 8;
        private const decimal TwoBooksDiscount = 0.05m;
        
        public decimal Calculate(params HarryPotterAndThe[] chamberOfSecrets)
        {
            if (chamberOfSecrets.Length == 1)
            {
                return RegularPrice;
            }

            decimal fullPrice = chamberOfSecrets.Count() * RegularPrice;

            if (chamberOfSecrets[0] != chamberOfSecrets[1])
            {
                fullPrice = fullPrice - fullPrice * 0.05m;
            }
            
            return fullPrice;
        }
    }
}