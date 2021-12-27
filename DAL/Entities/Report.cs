using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ReportGraphic
    {
        public int Total_completion { get; set; }
        public int Total_expectation { get; set; }
        public int Total_cancellation { get; set; }
        public int date { get; set; }
    }
}
