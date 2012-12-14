using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBOper.Entity;

namespace DBOper
{
    public interface IDBOper
    {
        bool Persistence2DB(ScenicEntity se);
        bool Persistence2DB(IList<ExcelOpr.Entity.PriceEntity> pricelist);
         bool Persistence2DB4topic(ScenicEntity se);
         DataSet GetScenic();
         DataSet GetTiketprice();
    }
}
