using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrEmployeeDB.Shared
{
    public class Department
    {
        public override string ToString()
        {
            return Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
