namespace NKH_Tution
{
    partial class Class_Sec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Class_Sec));
            ClassShowPanel = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            panel3 = new Panel();
            DashbordForm = new Label();
            UserForm = new Label();
            panel4 = new Panel();
            LogoutBtn = new Label();
            PaymentForm = new Label();
            AttendenceForm = new Label();
            StudentForm = new Label();
            panel2 = new Panel();
            SectionBox = new ComboBox();
            label18 = new Label();
            label2 = new Label();
            NameBox = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            DeleteBtn = new Button();
            AddClassBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ClassShowPanel
            // 
            ClassShowPanel.BackColor = Color.GhostWhite;
            ClassShowPanel.Location = new Point(540, 490);
            ClassShowPanel.Name = "ClassShowPanel";
            ClassShowPanel.Size = new Size(1070, 375);
            ClassShowPanel.TabIndex = 137;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Red;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(165, 71);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 141);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 116;
            pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.LightCoral;
            panel5.Location = new Point(75, 29);
            panel5.Name = "panel5";
            panel5.Size = new Size(223, 141);
            panel5.TabIndex = 75;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkBlue;
            panel3.Controls.Add(DashbordForm);
            panel3.Controls.Add(UserForm);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(PaymentForm);
            panel3.Controls.Add(AttendenceForm);
            panel3.Controls.Add(StudentForm);
            panel3.Location = new Point(165, 120);
            panel3.Name = "panel3";
            panel3.Size = new Size(223, 780);
            panel3.TabIndex = 118;
            // 
            // DashbordForm
            // 
            DashbordForm.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DashbordForm.ForeColor = SystemColors.ControlLightLight;
            DashbordForm.Location = new Point(33, 227);
            DashbordForm.Name = "DashbordForm";
            DashbordForm.Size = new Size(190, 30);
            DashbordForm.TabIndex = 144;
            DashbordForm.Text = "Dashbord";
            DashbordForm.Click += DashbordForm_Click;
            DashbordForm.MouseEnter += Control_MouseEnter;
            DashbordForm.MouseLeave += Control_MouseLeave;
            // 
            // UserForm
            // 
            UserForm.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserForm.ForeColor = SystemColors.ControlLightLight;
            UserForm.Location = new Point(33, 434);
            UserForm.Name = "UserForm";
            UserForm.Size = new Size(125, 28);
            UserForm.TabIndex = 142;
            UserForm.Text = "User";
            UserForm.Click += UserForm_Click;
            UserForm.MouseEnter += Control_MouseEnter;
            UserForm.MouseLeave += Control_MouseLeave;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Red;
            panel4.Controls.Add(LogoutBtn);
            panel4.Location = new Point(0, 722);
            panel4.Name = "panel4";
            panel4.Size = new Size(223, 58);
            panel4.TabIndex = 17;
            // 
            // LogoutBtn
            // 
            LogoutBtn.Anchor = AnchorStyles.None;
            LogoutBtn.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogoutBtn.ForeColor = Color.White;
            LogoutBtn.Location = new Point(63, 11);
            LogoutBtn.Name = "LogoutBtn";
            LogoutBtn.Size = new Size(125, 33);
            LogoutBtn.TabIndex = 18;
            LogoutBtn.Text = "Logout";
            LogoutBtn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PaymentForm
            // 
            PaymentForm.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PaymentForm.ForeColor = SystemColors.ControlLightLight;
            PaymentForm.Location = new Point(33, 334);
            PaymentForm.Name = "PaymentForm";
            PaymentForm.Size = new Size(190, 28);
            PaymentForm.TabIndex = 141;
            PaymentForm.Text = "Payment";
            PaymentForm.Click += PaymentForm_Click;
            PaymentForm.MouseEnter += Control_MouseEnter;
            PaymentForm.MouseLeave += Control_MouseLeave;
            // 
            // AttendenceForm
            // 
            AttendenceForm.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AttendenceForm.ForeColor = SystemColors.ControlLightLight;
            AttendenceForm.Location = new Point(33, 384);
            AttendenceForm.Name = "AttendenceForm";
            AttendenceForm.Size = new Size(190, 28);
            AttendenceForm.TabIndex = 140;
            AttendenceForm.Text = "Attendence";
            AttendenceForm.Click += AttendenceForm_Click;
            AttendenceForm.MouseEnter += Control_MouseEnter;
            AttendenceForm.MouseLeave += Control_MouseLeave;
            // 
            // StudentForm
            // 
            StudentForm.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StudentForm.ForeColor = SystemColors.ControlLightLight;
            StudentForm.Location = new Point(33, 275);
            StudentForm.Name = "StudentForm";
            StudentForm.Size = new Size(190, 30);
            StudentForm.TabIndex = 138;
            StudentForm.Text = "Student";
            StudentForm.Click += StudentForm_Click;
            StudentForm.MouseEnter += Control_MouseEnter;
            StudentForm.MouseLeave += Control_MouseLeave;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientInactiveCaption;
            panel2.Location = new Point(220, 59);
            panel2.Name = "panel2";
            panel2.Size = new Size(1564, 813);
            panel2.TabIndex = 1;
            // 
            // SectionBox
            // 
            SectionBox.FormattingEnabled = true;
            SectionBox.Items.AddRange(new object[] { "Male", "Female" });
            SectionBox.Location = new Point(622, 273);
            SectionBox.Name = "SectionBox";
            SectionBox.Size = new Size(239, 33);
            SectionBox.TabIndex = 133;
            // 
            // label18
            // 
            label18.Font = new Font("Elephant", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = SystemColors.ControlLightLight;
            label18.Location = new Point(617, 238);
            label18.Name = "label18";
            label18.Size = new Size(148, 32);
            label18.TabIndex = 132;
            label18.Text = "Section";
            // 
            // label2
            // 
            label2.Font = new Font("Elephant", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(612, 146);
            label2.Name = "label2";
            label2.Size = new Size(150, 32);
            label2.TabIndex = 121;
            label2.Text = "Name";
            // 
            // NameBox
            // 
            NameBox.Location = new Point(617, 181);
            NameBox.Name = "NameBox";
            NameBox.Size = new Size(336, 31);
            NameBox.TabIndex = 120;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(777, 57);
            label1.Name = "label1";
            label1.Size = new Size(415, 41);
            label1.TabIndex = 119;
            label1.Text = "CLASS AND SECTION";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel5);
            panel1.Location = new Point(90, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 891);
            panel1.TabIndex = 117;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = Color.Red;
            DeleteBtn.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DeleteBtn.ForeColor = SystemColors.ControlLightLight;
            DeleteBtn.Location = new Point(907, 371);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(128, 47);
            DeleteBtn.TabIndex = 129;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = false;
            // 
            // AddClassBtn
            // 
            AddClassBtn.BackColor = Color.Red;
            AddClassBtn.Font = new Font("Elephant", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddClassBtn.ForeColor = SystemColors.ControlLightLight;
            AddClassBtn.Location = new Point(622, 371);
            AddClassBtn.Name = "AddClassBtn";
            AddClassBtn.Size = new Size(129, 47);
            AddClassBtn.TabIndex = 128;
            AddClassBtn.Text = "Add";
            AddClassBtn.UseVisualStyleBackColor = false;
            AddClassBtn.Click += button1_Click;
            // 
            // Class_Sec
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1718, 974);
            Controls.Add(ClassShowPanel);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(SectionBox);
            Controls.Add(label18);
            Controls.Add(label2);
            Controls.Add(NameBox);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(DeleteBtn);
            Controls.Add(AddClassBtn);
            Name = "Class_Sec";
            Text = "Class_Sec";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel ClassShowPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox1;
        private Panel panel5;
        private Panel panel3;
        private Panel panel4;
        private Label LogoutBtn;
        private Panel panel2;
        private ComboBox SectionBox;
        private Label label18;
        private Label label2;
        private TextBox NameBox;
        private Label label1;
        private Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Button DeleteBtn;
        private Button AddClassBtn;
        private Label UserForm;
        private Label PaymentForm;
        private Label AttendenceForm;
        private Label StudentForm;
        private Label DashbordForm;
    }
}