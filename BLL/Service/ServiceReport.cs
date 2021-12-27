using BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ServiceReport : Interfaces.IServiceReport
    {

        private DAL.Interfaces.IRepositoryDB repositoryDB;
        public ServiceReport(DAL.Interfaces.IRepositoryDB dB)
        {
            this.repositoryDB = dB;
        }

        public List<ModelReport.ReportGraphic> Graphics(DateTime start_time, DateTime end_time) => repositoryDB.report.graphics(start_time, end_time)
                .Select(i => new ModelReport.ReportGraphic()
                {
                    date = i.date,
                    Total_cancellation = i.Total_cancellation,
                    Total_completion = i.Total_completion,
                    Total_expectation = i.Total_expectation
                })
                .ToList();
    }
}
