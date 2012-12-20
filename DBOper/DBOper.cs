using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBOper.Entity;
using System.Data;

namespace DBOper
{
    public class DBOper : IDBOper
    {
        DB.Helper.DBHelper dbhelper = new DB.Helper.DBHelper();

        public bool Persistence2DB(ScenicEntity se)
        {
            String sql1 = string.Empty;
            string sql2 = string.Empty;
            //分解
            if (!IfExistScenic(se.name))
            {
                sql1 = "insert into Scenic(Sname,Slevel,Saddress,Sarea,Stopic,Stopicseo,Strafficintro,Sbookintro,Sscenicdetail,Sscenicintro,Smainimg) " +
                    "values('" + se.name + "','" + se.level + "','" + se.address + "','" + se.areaid + "','" + se.topic
                   + "','" + se.topicseo + "','" + se.trafficintro + "','" + se.bookintro + "','" + se.scenicdetail + "','" + se.scenicintro + "','" + se.mainimg + "')";
                foreach (var item in se.ticketlist)
                {
                    sql2 += "insert into TicketPrice values('" + item.scenicname + "','" + item.ticketname + "','" + item.orgprice + "','" + item.olprice + "');";
                }
            }
            else
            {
                sql1 = "update Scenic set Sname='" + se.name + "',Slevel='" + se.level + "',Saddress='" + se.address
                    + "',Sarea='" + se.areaid + "',Stopic='" + se.topic
                   + "',Stopicseo='" + se.topicseo + "',Strafficintro='" + se.trafficintro + "',Sbookintro='"
                   + se.bookintro + "',Sscenicdetail='" + se.scenicdetail + "',Sscenicintro='" + se.scenicintro + "', Smainimg='" + se.mainimg + "' "
                   + " where Sname='" + se.name + "'";
                sql2 += "delete from TicketPrice where Tscenic='" + se.name + "';";
                foreach (var item in se.ticketlist)
                {
                    sql2 += "insert into TicketPrice values('" + item.scenicname + "','" + item.ticketname + "','" + item.orgprice + "','" + item.olprice + "');";
                }
            }
            return dbhelper.ExecSql(sql1) && dbhelper.ExecSql(sql2);
        }

        public bool Persistence2DB(IList<ExcelOpr.Entity.PriceEntity> pricelist)
        {
            var sql = string.Empty;
            foreach (var item in pricelist)
            {
                sql += "insert into TicketPrice values('" + item.scenicname + "','" + item.ticketname + "','" + item.orgprice + "','" + item.olprice + "');";
            }
            return dbhelper.ExecSql(sql);
        }

        public bool Persistence2DB4topic(ScenicEntity se)
        {
            String sql1 = string.Empty;
            sql1 = "update Scenic set Stopic='" + se.topic
               + "' where Sname='" + se.name + "'";
            return dbhelper.ExecSql(sql1);
        }

        public DataSet GetScenic()
        {
            string sql = "select * from Scenic";
            return dbhelper.ReturnDataSet(sql);
        }

        public System.Data.DataSet GetTiketprice()
        {
            string sql = "select * from TicketPrice";
            return dbhelper.ReturnDataSet(sql);
        }

        public bool IfExistScenic(string name)
        {
            string sql = @"select Sname,Slevel,Saddress,Sseoname,Sarea,Stopic,Stopicseo,
Strafficintro,Sbookintro,Sscenicdetail,Sscenicintro,Smainimg from Scenic where Sname='" + name + "'";
            DataSet ds = dbhelper.ReturnDataSet(sql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        public bool PersistenceCity2DB(IList<ExcelOpr.ExcelOpr.Webentity> websitelist)
        {
            var sql = string.Empty;
            foreach (var item in websitelist)
            {
                if (!string.IsNullOrEmpty(item.City))
                {
                    sql += "update Scenic set Sarea=(select top 1 Name from Area where name like '%" + item.City
                        + "%' and id>1018) where Sname like '%" + item.ScenicName + "%';";
                }
            }
            return dbhelper.ExecSql(sql);
        }

        public bool PersistenceSeo2DB(IList<ExcelOpr.ExcelOpr.Webentity> websitelist)
        {
            var sql = string.Empty;
            foreach (var item in websitelist)
            {
                if (!string.IsNullOrEmpty(item.City))
                {
                    sql += "update Scenic set Sseoname='" + item.Seoname + "' where Sname like '%" + item.ScenicName + "%';";
                }
            }
            return dbhelper.ExecSql(sql);
        }
    }
}
