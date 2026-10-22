namespace MIP_Felmero1
{
    public class HrDirector : Director
    {
        public HrDirector(int id, string name, int monthlySalary)
            : base(id, name, monthlySalary)
        {
        }

        public override string GetRoleName()
        {
            return "HR Director";
        }
    }
}
