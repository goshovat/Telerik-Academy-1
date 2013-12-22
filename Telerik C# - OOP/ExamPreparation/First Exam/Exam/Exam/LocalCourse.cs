using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class LocalCourse : SoftwareAcademy.ILocalCourse
    {
        private string lab;
        private string name;

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                this.lab = value;
            }
        }

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

        public SoftwareAcademy.ITeacher Teacher
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void AddTopic(string topic)
        {
            throw new NotImplementedException();
        }
    }
}
