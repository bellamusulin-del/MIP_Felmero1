using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace MIP_Felmero1
{
    public class EmployeeDataService
    {
        private readonly string _connectionString;
        private readonly string _databasePath;

        public EmployeeDataService(string databasePath = "employees_100.db")
        {
            _databasePath = databasePath;
            _connectionString = $"Data Source={_databasePath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(_databasePath))
            {
                SQLiteConnection.CreateFile(_databasePath);
            }

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Employees (
                        Id INTEGER PRIMARY KEY,
                        Name TEXT NOT NULL,
                        Role TEXT NOT NULL,
                        MonthlyGrossSalaryRON INTEGER NOT NULL,
                        Seniority TEXT NOT NULL
                    )";
                command.ExecuteNonQuery();
            }
        }

        public void ImportFromCsv(string csvPath)
        {
            var lines = File.ReadAllLines(csvPath).Skip(1);

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split(',');
                    if (parts.Length < 5) continue;

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO Employees (Id, Name, Role, MonthlyGrossSalaryRON, Seniority)
                        VALUES (@id, @name, @role, @salary, @seniority)";

                    command.Parameters.AddWithValue("@id", int.Parse(parts[0].Trim()));
                    command.Parameters.AddWithValue("@name", parts[1].Trim());
                    command.Parameters.AddWithValue("@role", parts[2].Trim());
                    command.Parameters.AddWithValue("@salary", int.Parse(parts[3].Trim()));
                    command.Parameters.AddWithValue("@seniority", parts[4].Trim());

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Person> GetAllEmployees()
        {
            var employees = new List<Person>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Role, MonthlyGrossSalaryRON, Seniority FROM Employees";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string role = reader.GetString(2);
                        int salary = reader.GetInt32(3);
                        string seniority = reader.GetString(4);

                        Person person = CreatePersonByRole(id, name, role, salary, seniority);
                        if (person != null)
                        {
                            employees.Add(person);
                        }
                    }
                }
            }

            return employees;
        }

        private Person CreatePersonByRole(int id, string name, string role, int salary, string seniority)
        {
            switch (role.ToLower())
            {
                case "director":
                    return new Director(id, name, role, salary, seniority, "Default Company");
                case "manager":
                    return new Manager(id, name, role, salary, seniority, 0);
                case "employee":
                default:
                    return new Employee(id, name, role, salary, seniority);
            }
        }

        public int GetEmployeeCount()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Employees";
                return (int)(long)command.ExecuteScalar();
            }
        }
    }
}