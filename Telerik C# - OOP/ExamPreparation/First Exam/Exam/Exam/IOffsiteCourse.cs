using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

}
