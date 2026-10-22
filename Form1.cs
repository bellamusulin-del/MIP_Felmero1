using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MIP_Felmero1
{
    public partial class Form1 : Form
    {
        private EmployeeDataService _dataService;
        private List<Person> _employees;
        private List<Project> _projects;
        private Project _currentProject;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _dataService = new EmployeeDataService("agency.db");
            _currentProject = new Project();
            _employees = new List<Person>();
            _projects = new List<Project>();
            
            int empCount = _dataService.GetEmployeeCount();
            if (empCount == 0)
            {
                try
                {
                    string csvPath = @"C:\Users\musul\Desktop\Egyetem\MIP\MIP_Felmero1\employees_100.csv";
                    if (System.IO.File.Exists(csvPath))
                    {
                        _dataService.ImportFromCsv(csvPath);
                        MessageBox.Show("100 employees imported from CSV!", "Success");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error importing CSV: {0}", ex.Message), "Error");
                }
            }
            
            LoadEmployees();
            LoadProjects();
            InitializeProjectTab();
        }

        #region Employees Tab

        private void LoadEmployees()
        {
            try
            {
                _employees = _dataService.GetAllEmployees();
                DisplayEmployees();

                if (_employees.Count > 0)
                {
                    MessageBox.Show(string.Format("Loaded {0} employees!", _employees.Count), "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error loading employees: {0}", ex.Message), "Error");
            }
        }

        private void DisplayEmployees()
        {
            try
            {
                if (_employees == null || _employees.Count == 0)
                {
                    return;
                }

                var displayList = new List<dynamic>();

                foreach (var emp in _employees)
                {
                    if (emp is Employee employee)
                    {
                        string seniority = "-";
                        if (emp is Programmer programmer)
                        {
                            seniority = programmer.Seniority.ToString();
                        }

                        displayList.Add(new
                        {
                            emp.Id,
                            emp.Name,
                            Role = emp.GetRoleName(),
                            Salary = employee.MonthlySalary,
                            HourlyRate = employee.GetHourlyRate().ToString("F2"),
                            Seniority = seniority
                        });
                    }
                }

                var dgv = this.Controls.Find("dataGridViewEmployees", true).FirstOrDefault() as DataGridView;
                if (dgv != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = displayList;
                    dgv.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying employees: {ex.Message}", "Error");
            }
        }

        private void ButtonGenerateEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dataService.GetEmployeeCount() >= 100)
                {
                    MessageBox.Show(string.Format("Database already contains {0} employees.", _dataService.GetEmployeeCount()), "Info");
                    return;
                }

                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Select Employee CSV File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _dataService.ImportFromCsv(openFileDialog.FileName);
                    LoadEmployees();
                    InitializeProjectTab();
                    MessageBox.Show(string.Format("Successfully imported {0} employees!", _dataService.GetEmployeeCount()), "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error");
            }
        }

        #endregion

        #region Projects Tab

        private void InitializeProjectTab()
        {
            try
            {
                var projectManagers = _dataService.GetProjectManagers();
                var pmCombo = this.Controls.Find("comboBoxPM", true).FirstOrDefault() as ComboBox;
                if (pmCombo != null)
                {
                    pmCombo.DataSource = new List<ProjectManager>(projectManagers);
                    pmCombo.DisplayMember = "Name";
                    pmCombo.ValueMember = "Id";
                }

                var programmers = _dataService.GetProgrammers();
                var progList = this.Controls.Find("checkedListBoxProgrammers", true).FirstOrDefault() as CheckedListBox;
                if (progList != null)
                {
                    progList.DataSource = new List<Programmer>(programmers);
                    progList.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error initializing project tab: {0}", ex.Message), "Error");
            }
        }

        private void LoadProjects()
        {
            try
            {
                _projects = _dataService.GetAllProjects();
                DisplayProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error loading projects: {0}", ex.Message), "Error");
            }
        }

        private void DisplayProjects()
        {
            try
            {
                var displayList = new List<dynamic>();

                if (_projects != null && _projects.Count > 0)
                {
                    foreach (var proj in _projects)
                    {
                        bool isAcceptable = proj.CalculatedCost <= proj.EstimatedBudget;
                        displayList.Add(new
                        {
                            proj.Id,
                            proj.Name,
                            proj.EstimatedBudget,
                            proj.CalculatedCost,
                            Difference = proj.EstimatedBudget - proj.CalculatedCost,
                            Status = isAcceptable ? "OK" : "OVER BUDGET"
                        });
                    }
                }

                var dgv = this.Controls.Find("dataGridViewProjects", true).FirstOrDefault() as DataGridView;
                if (dgv != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = displayList;
                    dgv.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error displaying projects: {0}", ex.Message), "Error");
            }
        }

        private void ComboBoxPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateProjectCost();
        }

        private void ButtonAddTeamMember_Click(object sender, EventArgs e)
        {
            try
            {
                var progList = this.Controls.Find("checkedListBoxProgrammers", true).FirstOrDefault() as CheckedListBox;
                if (progList == null || progList.SelectedItem == null)
                {
                    MessageBox.Show("Please select a programmer", "Info");
                    return;
                }

                var programmer = progList.SelectedItem as Programmer;
                
                if (programmer == null || !(programmer is Programmer))
                {
                    MessageBox.Show("Only Programmers can be added to the team!", "Error");
                    return;
                }

                if (_currentProject.Assignments.Any(a => a.EmployeeId == programmer.Id))
                {
                    MessageBox.Show("This programmer is already added to the project", "Info");
                    return;
                }

                var hoursText = this.Controls.Find("textBoxAllocatedHours", true).FirstOrDefault() as TextBox;
                if (!int.TryParse(hoursText?.Text, out int hours) || hours <= 0)
                {
                    MessageBox.Show("Please enter valid allocated hours (must be positive)", "Error");
                    return;
                }

                _currentProject.Assignments.Add(new ProjectAssignment
                {
                    EmployeeId = programmer.Id,
                    AllocatedHours = hours
                });

                MessageBox.Show(string.Format("{0} ({1} Programmer) added with {2} hours", programmer.Name, programmer.Seniority, hours), "Success");
                CalculateProjectCost();
                DisplayTeamMembers();
                
                hoursText.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error");
            }
        }

        private void ButtonRemoveTeamMember_Click(object sender, EventArgs e)
        {
            try
            {
                var dgv = this.Controls.Find("dataGridViewTeam", true).FirstOrDefault() as DataGridView;
                if (dgv == null || dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a team member to remove", "Info");
                    return;
                }

                var selectedRow = dgv.SelectedRows[0];
                var employeeId = (int)selectedRow.Cells[0].Value;

                _currentProject.Assignments.RemoveAll(a => a.EmployeeId == employeeId);
                CalculateProjectCost();
                DisplayTeamMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error");
            }
        }

        private void DisplayTeamMembers()
        {
            try
            {
                var teamList = new List<dynamic>();

                foreach (var assignment in _currentProject.Assignments)
                {
                    var emp = _dataService.GetEmployeeById(assignment.EmployeeId);
                    
                    if (emp is Programmer programmer)
                    {
                        decimal hourlyRate = programmer.GetHourlyRate();
                        decimal cost = hourlyRate * assignment.AllocatedHours;

                        teamList.Add(new
                        {
                            EmployeeId = assignment.EmployeeId,
                            Name = emp.Name,
                            Seniority = programmer.Seniority,
                            MonthlySalary = programmer.MonthlySalary,
                            HourlyRate = hourlyRate.ToString("F2"),
                            AllocatedHours = assignment.AllocatedHours,
                            Cost = cost.ToString("F2")
                        });
                    }
                }

                var dgv = this.Controls.Find("dataGridViewTeam", true).FirstOrDefault() as DataGridView;
                if (dgv != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = teamList;
                    dgv.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error displaying team: {0}", ex.Message), "Error");
            }
        }

        private void CalculateProjectCost()
        {
            try
            {
                var pmCombo = this.Controls.Find("comboBoxPM", true).FirstOrDefault() as ComboBox;
                if (pmCombo == null || pmCombo.SelectedValue == null)
                {
                    return;
                }

                int pmId = (int)pmCombo.SelectedValue;
                var pm = _dataService.GetEmployeeById(pmId) as ProjectManager;

                if (pm == null)
                {
                    MessageBox.Show("Invalid Project Manager selected", "Error");
                    return;
                }

                int totalDeveloperHours = _currentProject.Assignments.Sum(a => a.AllocatedHours);
                decimal pmHours = totalDeveloperHours * 0.2m;
                _currentProject.PmHours = pmHours;
                _currentProject.PmEmployeeId = pmId;

                decimal developerCost = 0;
                foreach (var assignment in _currentProject.Assignments)
                {
                    var emp = _dataService.GetEmployeeById(assignment.EmployeeId) as Employee;
                    if (emp != null)
                    {
                        decimal hourlyRate = emp.GetHourlyRate();
                        developerCost += hourlyRate * assignment.AllocatedHours;
                    }
                }

                decimal pmCost = pm.GetHourlyRate() * pmHours;
                _currentProject.CalculatedCost = (int)(developerCost + pmCost);

                DisplayCostSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error calculating cost: {0}", ex.Message), "Error");
            }
        }

        private void DisplayCostSummary()
        {
            try
            {
                var labelControl = this.Controls.Find("labelCostSummary", true).FirstOrDefault() as Label;
                if (labelControl == null)
                    return;

                if (_currentProject.EstimatedBudget == 0)
                {
                    labelControl.ForeColor = System.Drawing.Color.Black;
                    labelControl.Text = string.Format("Calculated Cost: {0} RON", _currentProject.CalculatedCost);
                    return;
                }

                bool isAcceptable = _currentProject.CalculatedCost <= _currentProject.EstimatedBudget;
                int difference = _currentProject.EstimatedBudget - _currentProject.CalculatedCost;

                if (isAcceptable)
                {
                    labelControl.ForeColor = System.Drawing.Color.Green;
                    labelControl.Text = string.Format("Calculated Cost: {0} RON (Budget: {1} RON) - ACCEPTED", 
                        _currentProject.CalculatedCost, _currentProject.EstimatedBudget);
                }
                else
                {
                    labelControl.ForeColor = System.Drawing.Color.Red;
                    labelControl.Text = string.Format("Calculated Cost: {0} RON (Budget: {1} RON) - OVER BUDGET by {2} RON", 
                        _currentProject.CalculatedCost, _currentProject.EstimatedBudget, Math.Abs(difference));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error");
            }
        }

        private void ButtonAcceptProject_Click(object sender, EventArgs e)
        {
            try
            {
                var nameControl = this.Controls.Find("textBoxProjectName", true).FirstOrDefault() as TextBox;
                string projectName = nameControl?.Text;
                if (string.IsNullOrEmpty(projectName))
                {
                    MessageBox.Show("Please enter project name", "Error");
                    return;
                }

                var budgetControl = this.Controls.Find("textBoxEstimatedBudget", true).FirstOrDefault() as TextBox;
                if (!int.TryParse(budgetControl?.Text, out int budget) || budget <= 0)
                {
                    MessageBox.Show("Please enter valid estimated budget (must be positive)", "Error");
                    return;
                }

                if (_currentProject.Assignments.Count == 0)
                {
                    MessageBox.Show("Please add at least one programmer to the team", "Error");
                    return;
                }

                if (_currentProject.PmEmployeeId == 0)
                {
                    MessageBox.Show("Please select a Project Manager", "Error");
                    return;
                }

                _currentProject.Name = projectName;
                _currentProject.EstimatedBudget = budget;

                if (_currentProject.CalculatedCost > budget)
                {
                    MessageBox.Show(string.Format("Project exceeds budget!\nCalculated: {0} RON\nBudget: {1} RON\nOver by: {2} RON", 
                        _currentProject.CalculatedCost, budget, _currentProject.CalculatedCost - budget), "Error");
                    return;
                }

                _dataService.SaveProject(_currentProject);
                MessageBox.Show(string.Format("Project '{0}' accepted and saved successfully!\nCost: {1} RON / Budget: {2} RON", 
                    projectName, _currentProject.CalculatedCost, budget), "Success");

                ClearProjectForm();
                LoadProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error accepting project: {0}", ex.Message), "Error");
            }
        }

        private void ClearProjectForm()
        {
            _currentProject = new Project();

            var nameControl = this.Controls.Find("textBoxProjectName", true).FirstOrDefault() as TextBox;
            if (nameControl != null) nameControl.Clear();

            var budgetControl = this.Controls.Find("textBoxEstimatedBudget", true).FirstOrDefault() as TextBox;
            if (budgetControl != null) budgetControl.Clear();

            var hoursControl = this.Controls.Find("textBoxAllocatedHours", true).FirstOrDefault() as TextBox;
            if (hoursControl != null) hoursControl.Clear();

            var costLabel = this.Controls.Find("labelCostSummary", true).FirstOrDefault() as Label;
            if (costLabel != null) costLabel.Text = "Cost Summary: -";

            DisplayTeamMembers();
        }

        #endregion
    }
}
                                