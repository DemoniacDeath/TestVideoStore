using Example.Domain;
using System;
using System.Text;

namespace Example.MVC.ViewModels
{
    public class HtmlStatementBuilder : IStatementBuilder
    {
        StringBuilder stringBuilder;

        public HtmlStatementBuilder()
        {
            stringBuilder = new StringBuilder();
        }

        public IStatementBuilder AppendTitleWithName(string format, object name)
        {
            stringBuilder.AppendFormat(format, String.Format("<span class=\"statement-name\">{0}</span>", name));
            stringBuilder.Append("<br/>");
            return this;
        }
        public IStatementBuilder AppendRentalWithTitleAndCost(string format, object title, object cost)
        {
            stringBuilder.AppendFormat(format, title, String.Format("<span class=\"statement-cost\">{0:C}</span>", cost));
            stringBuilder.Append("<br/>");
            return this;
        }
        public IStatementBuilder AppendFooterWithTotalCost(string format, object totalCost)
        {
            stringBuilder.AppendFormat(format, String.Format("<span class=\"statement-total-cost\">{0:C}</span>", totalCost));
            stringBuilder.Append("<br/>");
            return this;
        }
        public IStatementBuilder AppendFooterWithPointsEarned(string format, object points)
        {
            stringBuilder.AppendFormat(format, points);
            stringBuilder.Append("<br/>");
            return this;
        }
        public string ToStatement()
        {
            return stringBuilder.ToString();
        }
    }
}