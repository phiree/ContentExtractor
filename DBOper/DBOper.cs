﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CE.Domain.Entity;
using System.Data;

namespace DBOper
{
    public class DBOper : IDBOper
    {
        DB.Helper.DBHelper dbhelper = new DB.Helper.DBHelper();

        public bool Persistence2DB(CE.Domain.Entity.ScenicEntity se)
        {
            String sql1=string.Empty;
            string sql2 = string.Empty;
            //分解
            if (!IfExistScenic(se.name))
            {
                 sql1 = "insert into Scenic values('" + se.name + "','" + se.level + "','" + se.address + "','" + se.seoname + "','" + se.areaid + "','" + se.topic
                    + "','" + se.topicseo + "','" + se.trafficintro + "','" + se.bookintro + "','" + se.scenicdetail + "','" + se.scenicintro + "')";
                foreach (var item in se.ticketlist)
                {
                    sql2 += "insert into TicketPrice values('" + item.scenicname + "','" + item.ticketname + "','" + item.orgprice + "','" + item.olprice + "');";
                }
            }
            else
            {
                sql1 = "update Scenic set Sname='" + se.name + "',Slevel='" + se.level + "',Saddress='" + se.address 
                    + "',Sseoname='" + se.seoname + "',Sarea='" + se.areaid + "',Stopic='" + se.topic
                   + "',Stopicseo='" + se.topicseo + "',Strafficintro='" + se.trafficintro + "',Sbookintro='" 
                   + se.bookintro + "',Sscenicdetail='" + se.scenicdetail + "',Sscenicintro='" + se.scenicintro + "' "
                   + "where Sname='"+ se.name + "'";
                sql2 += "delete from TicketPrice where Tscenic='" + se.name + "';";
                foreach (var item in se.ticketlist)
                {
                    sql2 += "insert into TicketPrice values('" + item.scenicname + "','" + item.ticketname + "','" + item.orgprice + "','" + item.olprice + "');";
                }
            }
            return dbhelper.ExecSql(sql1) && dbhelper.ExecSql(sql2);
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
Strafficintro,Sbookintro,Sscenicdetail,Sscenicintro from Scenic where Sname='" + name + "'";
            DataSet ds = dbhelper.ReturnDataSet(sql);
            if (ds == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
