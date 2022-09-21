using System;
using System.Collections.Generic;
using System.Text;

namespace DTSMCC01.Models
{
    public class Cuti
    {
        public int IdCuti { get; set; }
        public int EmployeeId { get; set; }
        public int IdJenisCuti { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
    }
}
