namespace PersonnelVault.Models
{
    // Egy csapatot vezető személy. Nincs saját fizetés-mezője a feladat szerint,
    // helyette a csapatméret (TeamSize) a rá jellemző plusz adat.
    public class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(
            string name,
            string department,
            decimal salary,
            int teamSize)
            : base(name, department, salary)
        {
            TeamSize = teamSize;
        }

        public override string DescribeRole()
        {
            return $"Manager of {TeamSize} people @ {Department}";
        }
    }
}

/*{
    public string Department { get; set; }
    public int TeamSize { get; set; }

    public Manager(string name, string department, int teamSize)
        : base(name)
    {
        Department = department;
        TeamSize = teamSize;
    }

    public override string DescribeRole() => $"Manager of {TeamSize} people @ {Department}";
}
}*/
