using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Teacher : SoftwareAcademy.ITeacher
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public void AddCourse(SoftwareAcademy.ICourse course)
        {
            throw new NotImplementedException();
        }
    }
}
