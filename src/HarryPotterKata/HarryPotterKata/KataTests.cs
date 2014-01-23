using System.Collections;
using System.Collections.Generic;
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

        private decimal Calculate(IList<HarryPotterAndThe> books)
        {
            return calculator.Calculate(books);
        }

        [Test]
        public void if_one_book_then_return_regular_price()
        {
            var books = new List<HarryPotterAndThe>
            {
                HarryPotterAndThe.ChamberOfSecrets
            };

            decimal price = Calculate(books);
            price.Should().Be(8);
        }
        
        [Test]
        public void if_buy_two_the_same_books_return_total_prices()
        {
            var books = new List<HarryPotterAndThe>
            {
                HarryPotterAndThe.GobletOfFire,
                HarryPotterAndThe.GobletOfFire
            };

            decimal price = Calculate(books);
            price.Should().Be(16);
        }

        [Test]
        public void if_buy_two_different_books_get_5percent_discount()
        {
            var books = new List<HarryPotterAndThe>
            {
               HarryPotterAndThe.ChamberOfSecrets,
               HarryPotterAndThe.DeathlyHallows
            };

            decimal price = Calculate(books);
            price.Should().Be(15.2m);
        }

        [Test]
        public void if_buy_two_the_same_and_one_different_then_get_5precent_discount()
        {
            var books = new List<HarryPotterAndThe>
            {
                HarryPotterAndThe.ChamberOfSecrets,
                HarryPotterAndThe.DeathlyHallows,
                HarryPotterAndThe.DeathlyHallows
            };

            decimal price = Calculate(books);
            price.Should().Be(22.8m);
        }

        [Test]
        public void if_buy_three_different_books_then_get_10percent_discount()
        {
            var books = new List<HarryPotterAndThe>
            {
                HarryPotterAndThe.ChamberOfSecrets,
                HarryPotterAndThe.DeathlyHallows,
                HarryPotterAndThe.HalfBloodPrince
            };

            decimal price = Calculate(books);
            price.Should().Be(21.6m);
        }

        [Test]
        public void if_buy_four_books_then_get_20percent_discount()
        {
            var books = new List<HarryPotterAndThe>
            {
                HarryPotterAndThe.ChamberOfSecrets,
                HarryPotterAndThe.DeathlyHallows,
                HarryPotterAndThe.HalfBloodPrince,
                HarryPotterAndThe.PrisonerOfAzkaban
            };

            decimal price = Calculate(books);
            price.Should().Be(25.6m);
        }

        [Test]
        public void if_buy_five_books_then_get_25percent_discount()
        {
            var books = new List<HarryPotterAndThe>
            {
                HarryPotterAndThe.PhilosopherStone, 
                HarryPotterAndThe.ChamberOfSecrets,
                HarryPotterAndThe.PrisonerOfAzkaban, 
                HarryPotterAndThe.GobletOfFire, 
                HarryPotterAndThe.HalfBloodPrince
            };

            decimal price = Calculate(books);
            price.Should().Be(30);
        }


        [Test]
        public void calculate_complex_case_for_discount()
        {
            var books = new List<HarryPotterAndThe>
            {
                HarryPotterAndThe.PhilosopherStone, 
                HarryPotterAndThe.PhilosopherStone, 
                
                HarryPotterAndThe.ChamberOfSecrets,
                HarryPotterAndThe.ChamberOfSecrets,

                HarryPotterAndThe.PrisonerOfAzkaban, 
                HarryPotterAndThe.PrisonerOfAzkaban, 
                
                HarryPotterAndThe.GobletOfFire, 
                HarryPotterAndThe.HalfBloodPrince
            };

            decimal price = Calculate(books);
            price.Should().Be(48);
        }

        [Test]
        public void if_distinct_books_more_then_five()
        {
            var books = new List<HarryPotterAndThe>
            {
                HarryPotterAndThe.PhilosopherStone, 
                HarryPotterAndThe.PhilosopherStone, 
                HarryPotterAndThe.ChamberOfSecrets,
                HarryPotterAndThe.ChamberOfSecrets,
                HarryPotterAndThe.PrisonerOfAzkaban, 
                HarryPotterAndThe.PrisonerOfAzkaban, 
                HarryPotterAndThe.GobletOfFire, 
                HarryPotterAndThe.HalfBloodPrince,

                HarryPotterAndThe.OrderOfThePhoenix,
                HarryPotterAndThe.PrisonerOfAzkaban
            };

            decimal price = Calculate(books);
            price.Should().Be(60);
        }
    }
}
