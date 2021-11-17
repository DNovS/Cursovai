using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SQLRepositoryReport : Interfaces.IRepositoryReport
    {
        Appliances appliances;

        public SQLRepositoryReport(Appliances appliances)
        {
            this.appliances = appliances;
        }

        public List<ReportGraphic> graphics()
        {
            var report = appliances.Order
                .Where(o => o.registration_date != null)
                .GroupBy(o => o.registration_date.Month)
                .OrderBy(o => o.Key)
                .Select(o => new ReportGraphic { date = o.Key, Total = o.Count() })
                .ToList();
            return report;
        }
    }
}
