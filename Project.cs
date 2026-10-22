using System;
using System.Collections.Generic;

namespace MIP_Felmero1
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstimatedBudget { get; set; }
        public int CalculatedCost { get; set; }
        public int PmEmployeeId { get; set; }
        public decimal PmHours { get; set; }
        public List<ProjectAssignment> Assignments { get; set; }

        public Project()
        {
            Assignments = new List<ProjectAssignment>();
        }
    }
}
