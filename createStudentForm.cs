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
    public partial class createStudentForm : Form
    {
        private studentManagement Business;

        public createStudentForm()
        {
            InitializeComponent();
            this.Business = new studentManagement();
            this.btnSave.Click += btnSave_Click;
            this.btnCancel.Click += btnCancel_Click;

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
            if(radbtnMale.Checked == true)
            {
                gender = false;
            }
            else
            {
                gender = true;
            }
            var homeplace = this.rtxtHometown.Text;
            this.Business.AddStudent(code,name,gender,homeplace);
            MessageBox.Show("Add new student successfully");
            this.Close();
            //throw new NotImplementedException();
        }
    }
}
