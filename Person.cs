using System;

namespace MIP_Felmero1
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract string GetRoleName();

        public override string ToString()
        {
            return $"[{Id}] {Name} - {GetRoleName()}";
        }
    }
}