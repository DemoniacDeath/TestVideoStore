using System.Collections.Generic;

namespace Example.Domain
{
    public class Customer
    {
        public string Name { get; private set; }

        private readonly IList<Rental> _rentals;

        public Customer(string name)
        {
            Name = name;
            _rentals = new List<Rental>();
        }

        public void AddRental(Rental rental)
        {
            this._rentals.Add(rental);
        }

        public string GetStatement(IStatementBuilder statementBuilder = null)
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            if (statementBuilder == null)
                statementBuilder = new TextStatementBuilder();

            statementBuilder.AppendTitleWithName("Учет аренды для {0}", Name);
            foreach (var rental in _rentals)
            {
                double thisAmount = 0;

                // вычислить сумму для каждой строки
                switch (rental.Movie.Type)
                {
                    case MovieType.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        break;
                    case MovieType.NewRelease:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case MovieType.ForChildren:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5;
                        break;
                }

                // добавить очки для активного арендатора
                frequentRenterPoints++;
                // бонус за аренду новинки на два дня
                if (rental.Movie.Type == MovieType.NewRelease && rental.DaysRented > 1)
                    frequentRenterPoints++;

                // показать результат для этой аренды
                statementBuilder.AppendRentalWithTitleAndCost(" {0} {1}", rental.Movie.Title, thisAmount);
                totalAmount += thisAmount;
            }

            // добавить нижний колонтитул
            statementBuilder.AppendFooterWithTotalCost("Сумма задолженности составляет {0}", totalAmount);
            statementBuilder.AppendFooterWithPointsEarned("Вы заработали {0} очков за активность.", frequentRenterPoints);

            return statementBuilder.ToStatement();
        }
    }
}