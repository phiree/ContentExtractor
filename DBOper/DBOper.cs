using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DBOper
{
    public class DBOper:IDBOper
    {
        DB.Helper.DBHelper dbhelper = new DB.Helper.DBHelper();

        public bool Persistence2DB(CE.Domain.Entity.ScenicEntity se)
        {
            //分解
            String sql1 = "insert into Scenic values('"+se.level+"','"+se.address+"','"+se.seoname+"','"+se.areaid+"','"+se.topic
                +"','"+se.topicseo+"','"+se.trafficintro+"','"+se.bookintro+"','"+se.scenicdetail+"','"+se.scenicintro+"')";
            string sql2 = string.Empty;
            foreach (var item in se.ticketlist)
            {
                sql2 += "insert into TicketPrice values('" + item.scenicname + "','" + item.ticketname + "','" + item.orgprice + "','" + item.olprice+"');";
            }
            return dbhelper.ExecSql(sql1)&&dbhelper.ExecSql(sql2);
        }

        public System.Data.DataSet GetTiketprice(string sql)
        {
            return dbhelper.ReturnDataSet(sql);
        }
    }
}
