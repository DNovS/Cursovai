using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepositoryReport
    {
        List<Entities.ReportGraphic> graphics();
    }
}
