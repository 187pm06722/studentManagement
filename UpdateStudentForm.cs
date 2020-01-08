using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studentManagament_
{
    public partial class UpdateStudentForm : Form
    {
        private int studentID;
        private studentManagement Business;

        public UpdateStudentForm(int id)
        {
            InitializeComponent();
            this.studentID = id;
            this.Business = new studentManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.Load += UpdateStudentForm_Load;
        }

        void UpdateStudentForm_Load(object sender, EventArgs e)
        {
            var oldStudent = this.Business.GetStudent(this.studentID);
            this.txtName.Text = oldStudent.Name;
            this.txtCode.Text = oldStudent.Code;
            if (oldStudent.Gender == true)
            {
                this.radbtnFemale.Checked = true;
            }
            else
            {
                this.radbtnMale.Checked = true;
            }
            this.rtxtHometown.Text = oldStudent.Hometown;
            
            //throw new NotImplementedException();
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            var code = this.txtCode.Text;
            var name = this.txtName.Text;
            bool gender = true; //female is true
            if (radbtnMale.Checked == true)
            {
                gender = false;
            }
            else
            {
                gender = true;
            }
            var homeplace = this.rtxtHometown.Text;
            this.Business.EditStudent(this.studentID,code, name, gender, homeplace);
            MessageBox.Show("Update student successfully");
            this.Close();
            
            
            //throw new NotImplementedException();
        }
    }
}
