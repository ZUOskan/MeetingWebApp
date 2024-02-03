using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.DataAccess.DataContext
{
    public interface IDapperOrmHelper
    {
        IDbConnection GetDapperContextHelper();
    }
}
