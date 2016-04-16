using NUnit.Framework;

namespace Example.Domain.Tests
{
    [TestFixture]
    public class CustomerStatementTests
    {
        [Test]
        public void Statement_has_correct_header()
        {
            var customer = new Customer("Вася Пупкин");
            string statement = customer.GetStatement();

            Assert.IsTrue(statement.StartsWith(string.Format("Учет аренды для {0}", customer.Name)));
        }

        [Test]
        public void Statement_returns_zero_numbers_for_customer_with_no_rentals()
        {
            var customer = new Customer("Вася Пупкин");
            string statement = customer.GetStatement();

            TotalAmountIs(statement, 0);
            FrequentRaterPointsAre(statement, 0);
        }

        [Test]
        public void Statement_returns_correct_numbers_for_regular_movie_rented_for_2_days()
        {
            var customer = new Customer("Вася Пупкин");
            var movie = new Movie("The Rock", MovieType.Regular);
            customer.AddRental(new Rental(movie, 2));
            string statement = customer.GetStatement();

            Assert.IsTrue(statement.Contains(string.Format(" {0} {1:C}", movie.Title, 2)));
            TotalAmountIs(statement, 2);
            FrequentRaterPointsAre(statement, 1);
        }

        [Test]
        public void Statement_returns_correct_numbers_for_regular_movie_rented_more_than_2_days()
        {
            var customer = new Customer("Вася Пупкин");
            var movie = new Movie("The Rock", MovieType.Regular);
            customer.AddRental(new Rental(movie, 3));
            string statement = customer.GetStatement();

            Assert.IsTrue(statement.Contains(string.Format(" {0} {1:C}", movie.Title, 3.5)));
            TotalAmountIs(statement, 3.5);
            FrequentRaterPointsAre(statement, 1);
        }

        [Test]
        public void Statement_returns_correct_numbers_for_newrelease_rented_for_1_day()
        {
            var customer = new Customer("Вася Пупкин");
            var movie = new Movie("The Rock", MovieType.NewRelease);
            customer.AddRental(new Rental(movie, 1));
            string statement = customer.GetStatement();

            Assert.IsTrue(statement.Contains(string.Format(" {0} {1:C}", movie.Title, 3)));
            TotalAmountIs(statement, 3);
            FrequentRaterPointsAre(statement, 1);
        }

        [Test]
        public void Statement_returns_correct_numbers_for_newrelease_rented_more_than_1_day()
        {
            var customer = new Customer("Вася Пупкин");
            var movie = new Movie("The Rock", MovieType.NewRelease);
            customer.AddRental(new Rental(movie, 2));
            string statement = customer.GetStatement();

            Assert.IsTrue(statement.Contains(string.Format(" {0} {1:C}", movie.Title, 6)));
            TotalAmountIs(statement, 6);
            FrequentRaterPointsAre(statement, 2);
        }

        [Test]
        public void Statement_returns_correct_numbers_for_child_movie_rented_for_3_days()
        {
            var customer = new Customer("Вася Пупкин");
            var movie = new Movie("VALL-E", MovieType.ForChildren);
            customer.AddRental(new Rental(movie, 3));
            string statement = customer.GetStatement();

            Assert.IsTrue(statement.Contains(string.Format(" {0} {1:C}", movie.Title, 1.5)));
            TotalAmountIs(statement, 1.5);
            FrequentRaterPointsAre(statement, 1);
        }

        [Test]
        public void Statement_returns_correct_numbers_for_child_movie_rented_more_than_3_days()
        {
            var customer = new Customer("Вася Пупкин");
            var movie = new Movie("VALL-E", MovieType.ForChildren);
            customer.AddRental(new Rental(movie, 4));
            string statement = customer.GetStatement();

            Assert.IsTrue(statement.Contains(string.Format(" {0} {1:C}", movie.Title, 3)));
            TotalAmountIs(statement, 3);
            FrequentRaterPointsAre(statement, 1);
        }

        [Test]
        public void Statement_correctly_reflects_total_amount_and_points()
        {
            var customer = new Customer("Вася Пупкин");
            customer.AddRental(new Rental(new Movie("VALL-E", MovieType.ForChildren), 4));
            customer.AddRental(new Rental(new Movie("The Rock", MovieType.Regular), 4));
            customer.AddRental(new Rental(new Movie("Kick Ass", MovieType.NewRelease), 2));
            string statement = customer.GetStatement();

            TotalAmountIs(statement, 14);
            FrequentRaterPointsAre(statement, 4);
        }

        private void FrequentRaterPointsAre(string statement, int points)
        {
            Assert.IsTrue(statement.Contains(string.Format("Вы заработали {0} очков за активность.", points)));
        }

        private void TotalAmountIs(string statement, double amount)
        {
            Assert.IsTrue(statement.Contains(string.Format("Сумма задолженности составляет {0:C}", amount)));
        }
    }
}
