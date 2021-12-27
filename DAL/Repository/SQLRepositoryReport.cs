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

        public List<ReportGraphic> graphics(DateTime start_time, DateTime end_time)
        {
            var report = new List<ReportGraphic>(appliances.Order
                .Where(o => o.registration_date != null
                        && o.registration_date > start_time
                        && o.registration_date < end_time)

                .GroupBy(o => o.registration_date.Month)
                .OrderBy(o => o.Key)

                .Select(o => new ReportGraphic
                {
                    date = o.Key,
                    Total_expectation = appliances.Order
                                        .Where(k => k.registration_date != null
                                                && k.registration_date.Month == o.Key
                                                && k.id_state == 1)

                                        .ToList().Count,

                    Total_completion = appliances.Order
                                        .Where(k => k.registration_date != null
                                                && k.registration_date.Month == o.Key
                                                && k.id_state == 2)
                                        
                                        .ToList().Count,

                    Total_cancellation = appliances.Order
                                        .Where(k => k.registration_date != null
                                                && k.registration_date.Month == o.Key
                                                && k.id_state == 3)
                                        
                                        .ToList().Count,
                }));
            return report;
        }
    }
}
