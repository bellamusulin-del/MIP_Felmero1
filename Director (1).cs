using System;

namespace PersonnelVault.Models
{
    public class Director : Employee
    {
        private static bool _seatIsTaken = false;

        public string Company { get; set; }

        public Director(
            string name,
            string department,
            decimal salary,
            string company)
            : base(name, department, salary)
        {
            if (_seatIsTaken)
            {
                throw new InvalidOperationException(
                    "Ebből a cégből csak egyetlen Director lehet - a hely már foglalt."
                );
            }

            Company = company;
            _seatIsTaken = true;
        }

        public override string DescribeRole()
        {
            return $"Director of {Company}";
        }
    }
}
// A cégnek csak EGY igazgatója (Director) lehet - ezt kódszinten is kikényszerítjük,
// nem csak "megbeszéljük", hogy ne hozzunk létre kettőt.
// Ez rokon a Singleton mintával, csak itt üzleti szabályként alkalmazzuk egy Person-leszármazottra:
// ha valaki mégis megpróbál másodikat létrehozni, a program kivételt (exception) dob.
/* public class Director : Person
 {
     private static bool _seatIsTaken = false; // jelzi, hogy foglalt-e már az igazgatói "szék"

     public string Company { get; set; }

     public Director(string name, string company)
         : base(name)
     {
         if (_seatIsTaken)
         {
             throw new InvalidOperationException(
                 "Ebből a cégből csak egyetlen Director lehet - a hely már foglalt.");
         }

         Company = company;
         _seatIsTaken = true;
     }

     public override string DescribeRole() => $"Director of {Company}";
 }
}
*/