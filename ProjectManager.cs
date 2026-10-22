namespace MIP_Felmero1
{
    public class ProjectManager : Employee
    {
        public ProjectManager(int id, string name, int monthlySalary)
            : base(id, name, monthlySalary)
        {
        }

        public override string GetRoleName()
        {
            return "Project Manager";
        }
    }
}
