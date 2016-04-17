namespace Example.Domain
{
    public interface IStatementBuilder
    {
        IStatementBuilder AppendTitleWithName(string format, object name);
        IStatementBuilder AppendRentalWithTitleAndCost(string format, object title, object cost);
        IStatementBuilder AppendFooterWithTotalCost(string format, object totalCost);
        IStatementBuilder AppendFooterWithPointsEarned(string format, object points);
        string ToStatement();
    }
}
