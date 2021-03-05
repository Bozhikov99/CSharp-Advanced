using System.Text;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp)
        : base(id, firstName, lastName, salary)
    {
        this.Corp = corp;
    }

    public string Corp { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
            .Append($"Corps: {this.Corp}");
        return sb.ToString();
    }
}