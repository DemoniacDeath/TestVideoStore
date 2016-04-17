using System;
using System.Text;

namespace Example.Domain
{
    class TextStatementBuilder : IStatementBuilder
    {
        StringBuilder stringBuilder;

        public TextStatementBuilder()
        {
            stringBuilder = new StringBuilder();
        }

        public IStatementBuilder AppendTitleWithName(string format, object name)
        {
            stringBuilder.AppendFormat(format, name);
            stringBuilder.AppendLine();
            return this;
        }
        public IStatementBuilder AppendRentalWithTitleAndCost(string format, object title, object cost)
        {
            stringBuilder.AppendFormat(format, title, String.Format("{0:C}", cost));
            stringBuilder.AppendLine();
            return this;
        }
        public IStatementBuilder AppendFooterWithTotalCost(string format, object totalCost)
        {
            stringBuilder.AppendFormat(format, String.Format("{0:C}", totalCost));
            stringBuilder.AppendLine();
            return this;
        }
        public IStatementBuilder AppendFooterWithPointsEarned(string format, object points)
        {
            stringBuilder.AppendFormat(format, points);
            stringBuilder.AppendLine();
            return this;
        }
        public string ToStatement()
        {
            return stringBuilder.ToString();
        }
    }
}
