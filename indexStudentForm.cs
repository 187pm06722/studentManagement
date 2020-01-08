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
    public partial class indexStudentForm : Form
    {
        private studentManagement Business;
        public indexStudentForm()
        {
            InitializeComponent();
            this.Business = new studentManagement();
            this.Load += indexStudentForm_Load;
            this.btnAddStn.Click += btnAddStn_Click;
            this.btnDeleteStn.Click += btnDeleteStn_Click;
            this.grdStudents.DoubleClick += grdStudents_DoubleClick;
        }
        private void LoadAllClasses()
        {
            var students = this.Business.GetStudents();
            //this.grdStudents.DataSource = students;
            this.viewAllStudents();
        }

        void grdStudents_DoubleClick(object sender, EventArgs e)
        {
            if(this.grdStudents.SelectedRows.Count == 1)
            {
                var student = (ViewStudent)this.grdStudents.SelectedRows[0].DataBoundItem;
                var updateform = new UpdateStudentForm(student.id);
                updateform.ShowDialog();
                this.viewAllStudents();

            }
            // throw new NotImplementedException();
        }

        void btnDeleteStn_Click(object sender, EventArgs e)
        {
            if(this.grdStudents.SelectedRows.Count == 1)
            {
                if(MessageBox.Show("Do you want to delete this? ","Confirm",
                   MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
                {
                    var student = (ViewStudent)this.grdStudents.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteStudent(student.id);
                    MessageBox.Show("Delete class successfully");
                    this.viewAllStudents();

                }
            }
            
            
            //throw new NotImplementedException();
        }

        void btnAddStn_Click(object sender, EventArgs e)
        {
            var createform = new createStudentForm();
            createform.ShowDialog();
            this.viewAllStudents();

            
            //throw new NotImplementedException();
        }
        private void viewAllStudents()
        {
            var db = new OOPCSEntities();
            var students = db.PM06722.ToArray();
            var studentView = new ViewStudent[students.Length];
            for (int i = 0; i<students.Length; i++)
            {
                studentView[i] = new ViewStudent(students[i]);
            }
            this.grdStudents.DataSource = studentView;
        }

        void indexStudentForm_Load(object sender, EventArgs e)
        {
            this.viewAllStudents();
            //this.LoadAllClasses();
            //throw new NotImplementedException();
        }
    }
}
