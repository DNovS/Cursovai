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

        public List<ModelReport.ReportGraphic> Graphics => repositoryDB.report.graphics()
                .Select(i => new ModelReport.ReportGraphic() { date = i.date, Total = i.Total })
                .ToList();
    }
}
