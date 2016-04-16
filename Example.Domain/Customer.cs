using System.Collections.Generic;
using System.Text;

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

        public string GetStatement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            var result = new StringBuilder();

            result.AppendFormat("Учет аренды для {0}", Name);
            result.AppendLine();
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
                result.AppendFormat(" {0} {1:C}", rental.Movie.Title, thisAmount);
                result.AppendLine();
                totalAmount += thisAmount;
            }

            // добавить нижний колонтитул
            result.AppendFormat("Сумма задолженности составляет {0:C}", totalAmount);
            result.AppendLine();
            result.AppendFormat("Вы заработали {0} очков за активность.", frequentRenterPoints);

            return result.ToString();
        }
    }
}