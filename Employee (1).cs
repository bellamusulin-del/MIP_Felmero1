namespace PersonnelVault.Models
{
    // Egy sima beosztott alkalmazott. Van osztálya (department) és fizetése.
    public class Employee : Person
    {
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, string department, decimal salary)
            : base(name)
        {
            Department = department;
            Salary = salary;
        }

        public override string DescribeRole() => $"Employee @ {Department} ({Salary:0} RON)";
    }
}
