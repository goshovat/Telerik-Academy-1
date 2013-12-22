using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

}
