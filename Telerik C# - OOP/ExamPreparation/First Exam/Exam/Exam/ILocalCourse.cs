using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

}
