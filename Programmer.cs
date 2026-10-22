namespace MIP_Felmero1
{
    public class Programmer : Employee
    {
        public Seniority Seniority { get; set; }

        public Programmer(int id, string name, int monthlySalary, Seniority seniority)
            : base(id, name, monthlySalary)
        {
            Seniority = seniority;
        }

        public override string GetRoleName()
        {
            return $"{Seniority} Programmer";
        }
    }
}
