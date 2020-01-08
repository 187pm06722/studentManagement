using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManagament_
{
    public class ViewStudent
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string hometown { get; set; }

        public ViewStudent(PM06722 student)
        {
            this.id = student.id;
            this.code = student.Code;
            this.name = student.Name;
            this.gender = student.Gender == true ? "Nu" : "Nam";
            this.hometown = student.Hometown;
        }

    }
}
