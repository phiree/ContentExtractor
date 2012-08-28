using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CE.Domain.Entity;

namespace DBOper
{
    public interface IDBOper
    {
         bool Persistence2DB(ScenicEntity se);
         DataSet GetScenic();
         DataSet GetTiketprice();
    }
}
