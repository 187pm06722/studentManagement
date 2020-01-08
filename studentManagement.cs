using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagament_
{
    class studentManagement
    {
        public PM06722[] GetStudents()
        {
            var db = new OOPCSEntities();
            var Students = db.PM06722.ToArray();
            return Students;
        }

        public void AddStudent(string code, string name,bool gender, string birthPlace)
        {
            var student = new PM06722();
            //student.id = id;
            student.Code = code;
            student.Name = name;
            student.Gender = gender;
            student.Hometown = birthPlace;

            var db = new OOPCSEntities();
            db.PM06722.Add(student);
            db.SaveChanges();

        }

        public void EditStudent(int id,string newCode,string newName, bool newGender, string newBirthPlace )
        {
            var db = new OOPCSEntities();
            var oldStudent = db.PM06722.Find(id);
            oldStudent.Code = newCode;
            oldStudent.Name = newName;
            oldStudent.Gender = newGender;
            oldStudent.Hometown = newBirthPlace;

            db.Entry(oldStudent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var db = new OOPCSEntities();
            var studentToDelete = db.PM06722.Find(id);
            db.PM06722.Remove(studentToDelete);
            db.SaveChanges();
        }

        public PM06722 GetStudent(int id)
        {
            var db = new OOPCSEntities();
            var student = db.PM06722.Find(id);
            return student;
        }

    }
}
