using FluentAssertions;
using NUnit.Framework;

namespace HarryPotterKata
{
    [TestFixture]
    public class KataTests
    {
        private PriceCalculator calculator;
        
        [SetUp]
        public void SetUp()
        {
            calculator = new PriceCalculator();
        }

        private decimal Calculate(params HarryPotterAndThe[] books)
        {
            return calculator.Calculate(books);
        }

        [Test]
        public void if_one_book_then_return_regular_price()
        {
            decimal price = Calculate(HarryPotterAndThe.ChamberOfSecrets);
            price.Should().Be(8);
        }
        
        [Test]
        public void if_buy_two_the_same_books_return_total_prices()
        {
            decimal price = Calculate(HarryPotterAndThe.GobletOfFire, HarryPotterAndThe.GobletOfFire);
            price.Should().Be(16);
        }

        [Test]
        public void if_buy_two_different_books_get_5percent_discount()
        {
            decimal price = Calculate(HarryPotterAndThe.ChamberOfSecrets, HarryPotterAndThe.DeathlyHallows);
            price.Should().Be(15.2m);
        }
    }
}
