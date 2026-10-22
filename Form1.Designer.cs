namespace MIP_Felmero1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageEmployees = new System.Windows.Forms.TabPage();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.buttonGenerateEmployees = new System.Windows.Forms.Button();

            this.tabPageProjects = new System.Windows.Forms.TabPage();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.textBoxProjectName = new System.Windows.Forms.TextBox();
            this.labelEstimatedBudget = new System.Windows.Forms.Label();
            this.textBoxEstimatedBudget = new System.Windows.Forms.TextBox();
            this.labelPM = new System.Windows.Forms.Label();
            this.comboBoxPM = new System.Windows.Forms.ComboBox();
            this.labelProgrammers = new System.Windows.Forms.Label();
            this.checkedListBoxProgrammers = new System.Windows.Forms.CheckedListBox();
            this.labelAllocatedHours = new System.Windows.Forms.Label();
            this.textBoxAllocatedHours = new System.Windows.Forms.TextBox();
            this.buttonAddTeamMember = new System.Windows.Forms.Button();
            this.labelTeam = new System.Windows.Forms.Label();
            this.dataGridViewTeam = new System.Windows.Forms.DataGridView();
            this.buttonRemoveTeamMember = new System.Windows.Forms.Button();
            this.labelCostSummary = new System.Windows.Forms.Label();
            this.buttonAcceptProject = new System.Windows.Forms.Button();
            this.labelAcceptedProjects = new System.Windows.Forms.Label();
            this.dataGridViewProjects = new System.Windows.Forms.DataGridView();

            this.tabControlMain.SuspendLayout();
            this.tabPageEmployees.SuspendLayout();
            this.tabPageProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).BeginInit();
            this.SuspendLayout();

            // tabControlMain
            this.tabControlMain.Controls.Add(this.tabPageEmployees);
            this.tabControlMain.Controls.Add(this.tabPageProjects);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1024, 650);
            this.tabControlMain.TabIndex = 0;

            // tabPageEmployees
            this.tabPageEmployees.Controls.Add(this.dataGridViewEmployees);
            this.tabPageEmployees.Controls.Add(this.buttonGenerateEmployees);
            this.tabPageEmployees.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmployees.Size = new System.Drawing.Size(1016, 624);
            this.tabPageEmployees.TabIndex = 0;
            this.tabPageEmployees.Text = "Employees";
            this.tabPageEmployees.UseVisualStyleBackColor = true;

            // dataGridViewEmployees
            this.dataGridViewEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(6, 40);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(1004, 578);
            this.dataGridViewEmployees.TabIndex = 0;

            // buttonGenerateEmployees
            this.buttonGenerateEmployees.Location = new System.Drawing.Point(6, 6);
            this.buttonGenerateEmployees.Name = "buttonGenerateEmployees";
            this.buttonGenerateEmployees.Size = new System.Drawing.Size(150, 28);
            this.buttonGenerateEmployees.TabIndex = 1;
            this.buttonGenerateEmployees.Text = "Generate Employees";
            this.buttonGenerateEmployees.UseVisualStyleBackColor = true;
            this.buttonGenerateEmployees.Click += new System.EventHandler(this.ButtonGenerateEmployees_Click);

            // tabPageProjects
            this.tabPageProjects.AutoScroll = true;
            this.tabPageProjects.Controls.Add(this.labelProjectName);
            this.tabPageProjects.Controls.Add(this.textBoxProjectName);
            this.tabPageProjects.Controls.Add(this.labelEstimatedBudget);
            this.tabPageProjects.Controls.Add(this.textBoxEstimatedBudget);
            this.tabPageProjects.Controls.Add(this.labelPM);
            this.tabPageProjects.Controls.Add(this.comboBoxPM);
            this.tabPageProjects.Controls.Add(this.labelProgrammers);
            this.tabPageProjects.Controls.Add(this.checkedListBoxProgrammers);
            this.tabPageProjects.Controls.Add(this.labelAllocatedHours);
            this.tabPageProjects.Controls.Add(this.textBoxAllocatedHours);
            this.tabPageProjects.Controls.Add(this.buttonAddTeamMember);
            this.tabPageProjects.Controls.Add(this.labelTeam);
            this.tabPageProjects.Controls.Add(this.dataGridViewTeam);
            this.tabPageProjects.Controls.Add(this.buttonRemoveTeamMember);
            this.tabPageProjects.Controls.Add(this.labelCostSummary);
            this.tabPageProjects.Controls.Add(this.buttonAcceptProject);
            this.tabPageProjects.Controls.Add(this.labelAcceptedProjects);
            this.tabPageProjects.Controls.Add(this.dataGridViewProjects);
            this.tabPageProjects.Location = new System.Drawing.Point(4, 22);
            this.tabPageProjects.Name = "tabPageProjects";
            this.tabPageProjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjects.Size = new System.Drawing.Size(1016, 624);
            this.tabPageProjects.TabIndex = 1;
            this.tabPageProjects.Text = "Projects";
            this.tabPageProjects.UseVisualStyleBackColor = true;

            // labelProjectName
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Location = new System.Drawing.Point(6, 9);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(82, 13);
            this.labelProjectName.TabIndex = 0;
            this.labelProjectName.Text = "Project Name:";

            // textBoxProjectName
            this.textBoxProjectName.Location = new System.Drawing.Point(94, 6);
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.Size = new System.Drawing.Size(200, 20);
            this.textBoxProjectName.TabIndex = 1;

            // labelEstimatedBudget
            this.labelEstimatedBudget.AutoSize = true;
            this.labelEstimatedBudget.Location = new System.Drawing.Point(6, 35);
            this.labelEstimatedBudget.Name = "labelEstimatedBudget";
            this.labelEstimatedBudget.Size = new System.Drawing.Size(107, 13);
            this.labelEstimatedBudget.TabIndex = 2;
            this.labelEstimatedBudget.Text = "Estimated Budget (RON):";

            // textBoxEstimatedBudget
            this.textBoxEstimatedBudget.Location = new System.Drawing.Point(119, 32);
            this.textBoxEstimatedBudget.Name = "textBoxEstimatedBudget";
            this.textBoxEstimatedBudget.Size = new System.Drawing.Size(100, 20);
            this.textBoxEstimatedBudget.TabIndex = 3;

            // labelPM
            this.labelPM.AutoSize = true;
            this.labelPM.Location = new System.Drawing.Point(6, 61);
            this.labelPM.Name = "labelPM";
            this.labelPM.Size = new System.Drawing.Size(93, 13);
            this.labelPM.TabIndex = 4;
            this.labelPM.Text = "Project Manager:";

            // comboBoxPM
            this.comboBoxPM.FormattingEnabled = true;
            this.comboBoxPM.Location = new System.Drawing.Point(105, 58);
            this.comboBoxPM.Name = "comboBoxPM";
            this.comboBoxPM.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPM.TabIndex = 5;
            this.comboBoxPM.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPM_SelectedIndexChanged);

            // labelProgrammers
            this.labelProgrammers.AutoSize = true;
            this.labelProgrammers.Location = new System.Drawing.Point(6, 87);
            this.labelProgrammers.Name = "labelProgrammers";
            this.labelProgrammers.Size = new System.Drawing.Size(70, 13);
            this.labelProgrammers.TabIndex = 6;
            this.labelProgrammers.Text = "Programmers:";

            // checkedListBoxProgrammers
            this.checkedListBoxProgrammers.FormattingEnabled = true;
            this.checkedListBoxProgrammers.Location = new System.Drawing.Point(6, 103);
            this.checkedListBoxProgrammers.Name = "checkedListBoxProgrammers";
            this.checkedListBoxProgrammers.Size = new System.Drawing.Size(299, 94);
            this.checkedListBoxProgrammers.TabIndex = 7;

            // labelAllocatedHours
            this.labelAllocatedHours.AutoSize = true;
            this.labelAllocatedHours.Location = new System.Drawing.Point(6, 204);
            this.labelAllocatedHours.Name = "labelAllocatedHours";
            this.labelAllocatedHours.Size = new System.Drawing.Size(87, 13);
            this.labelAllocatedHours.TabIndex = 8;
            this.labelAllocatedHours.Text = "Allocated Hours:";

            // textBoxAllocatedHours
            this.textBoxAllocatedHours.Location = new System.Drawing.Point(99, 201);
            this.textBoxAllocatedHours.Name = "textBoxAllocatedHours";
            this.textBoxAllocatedHours.Size = new System.Drawing.Size(100, 20);
            this.textBoxAllocatedHours.TabIndex = 9;

            // buttonAddTeamMember
            this.buttonAddTeamMember.Location = new System.Drawing.Point(205, 201);
            this.buttonAddTeamMember.Name = "buttonAddTeamMember";
            this.buttonAddTeamMember.Size = new System.Drawing.Size(100, 23);
            this.buttonAddTeamMember.TabIndex = 10;
            this.buttonAddTeamMember.Text = "Add Team Member";
            this.buttonAddTeamMember.UseVisualStyleBackColor = true;
            this.buttonAddTeamMember.Click += new System.EventHandler(this.ButtonAddTeamMember_Click);

            // labelTeam
            this.labelTeam.AutoSize = true;
            this.labelTeam.Location = new System.Drawing.Point(6, 230);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(69, 13);
            this.labelTeam.TabIndex = 11;
            this.labelTeam.Text = "Team (Cost):";

            // dataGridViewTeam
            this.dataGridViewTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTeam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTeam.Location = new System.Drawing.Point(6, 246);
            this.dataGridViewTeam.Name = "dataGridViewTeam";
            this.dataGridViewTeam.ReadOnly = true;
            this.dataGridViewTeam.Size = new System.Drawing.Size(1004, 100);
            this.dataGridViewTeam.TabIndex = 12;

            // buttonRemoveTeamMember
            this.buttonRemoveTeamMember.Location = new System.Drawing.Point(6, 352);
            this.buttonRemoveTeamMember.Name = "buttonRemoveTeamMember";
            this.buttonRemoveTeamMember.Size = new System.Drawing.Size(150, 23);
            this.buttonRemoveTeamMember.TabIndex = 13;
            this.buttonRemoveTeamMember.Text = "Remove Team Member";
            this.buttonRemoveTeamMember.UseVisualStyleBackColor = true;
            this.buttonRemoveTeamMember.Click += new System.EventHandler(this.ButtonRemoveTeamMember_Click);

            // labelCostSummary
            this.labelCostSummary.AutoSize = true;
            this.labelCostSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelCostSummary.Location = new System.Drawing.Point(6, 381);
            this.labelCostSummary.Name = "labelCostSummary";
            this.labelCostSummary.Size = new System.Drawing.Size(150, 17);
            this.labelCostSummary.TabIndex = 14;
            this.labelCostSummary.Text = "Cost Summary: -";

            // buttonAcceptProject
            this.buttonAcceptProject.Location = new System.Drawing.Point(6, 401);
            this.buttonAcceptProject.Name = "buttonAcceptProject";
            this.buttonAcceptProject.Size = new System.Drawing.Size(150, 23);
            this.buttonAcceptProject.TabIndex = 15;
            this.buttonAcceptProject.Text = "Accept Project";
            this.buttonAcceptProject.UseVisualStyleBackColor = true;
            this.buttonAcceptProject.Click += new System.EventHandler(this.ButtonAcceptProject_Click);

            // labelAcceptedProjects
            this.labelAcceptedProjects.AutoSize = true;
            this.labelAcceptedProjects.Location = new System.Drawing.Point(6, 430);
            this.labelAcceptedProjects.Name = "labelAcceptedProjects";
            this.labelAcceptedProjects.Size = new System.Drawing.Size(100, 13);
            this.labelAcceptedProjects.TabIndex = 16;
            this.labelAcceptedProjects.Text = "Accepted Projects:";

            // dataGridViewProjects
            this.dataGridViewProjects.AllowUserToAddRows = false;
            this.dataGridViewProjects.AllowUserToDeleteRows = false;
            this.dataGridViewProjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjects.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewProjects.Location = new System.Drawing.Point(6, 446);
            this.dataGridViewProjects.Name = "dataGridViewProjects";
            this.dataGridViewProjects.ReadOnly = true;
            this.dataGridViewProjects.Size = new System.Drawing.Size(1004, 172);
            this.dataGridViewProjects.TabIndex = 17;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 650);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Personnel Manager - Agency";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.tabControlMain.ResumeLayout(false);
            this.tabPageEmployees.ResumeLayout(false);
            this.tabPageProjects.ResumeLayout(false);
            this.tabPageProjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageEmployees;
        private System.Windows.Forms.TabPage tabPageProjects;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.Button buttonGenerateEmployees;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.TextBox textBoxProjectName;
        private System.Windows.Forms.Label labelEstimatedBudget;
        private System.Windows.Forms.TextBox textBoxEstimatedBudget;
        private System.Windows.Forms.Label labelPM;
        private System.Windows.Forms.ComboBox comboBoxPM;
        private System.Windows.Forms.Label labelProgrammers;
        private System.Windows.Forms.CheckedListBox checkedListBoxProgrammers;
        private System.Windows.Forms.Label labelAllocatedHours;
        private System.Windows.Forms.TextBox textBoxAllocatedHours;
        private System.Windows.Forms.Button buttonAddTeamMember;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.DataGridView dataGridViewTeam;
        private System.Windows.Forms.Button buttonRemoveTeamMember;
        private System.Windows.Forms.Label labelCostSummary;
        private System.Windows.Forms.Button buttonAcceptProject;
        private System.Windows.Forms.Label labelAcceptedProjects;
        private System.Windows.Forms.DataGridView dataGridViewProjects;
    }
}

