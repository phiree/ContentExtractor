﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace ExcelOpr
{
    /// <summary>
    /// Excel操作类 
    /// <!--说明程序约定3条-->
    /// 1.将excel放在d盘下, 文件名为"2012年浙江省A级旅游景区汇总统计表.xls"
    /// 2.在d盘下创建scenicimg文件夹, 并确保是空.
    /// 3.将各景区图片放在以景区命名的文件夹中, 并将此文件夹放到d盘的图片文件夹中.
    /// </summary>
    public class ExcelOpr
    {
        public BLL.BLLArea bllarea = new BLL.BLLArea();
        public BLL.BLLTopic blltopic = new BLL.BLLTopic();
        public BLL.BLLTicket bllticket = new BLL.BLLTicket();

        public void Run()
        {
            BLL.BLLScenic bllscenic = new BLL.BLLScenic();
            List<Entity.ScenicEntity> newslist = getSceniclist();

            //收集景区topic,及topicseo
            string temptp = string.Empty;
            string temptseo = string.Empty;
            foreach (var tstring in newslist)
            {
                temptp += tstring.topic + ",";
                temptseo += tstring.topicseo + ",";
            }
            List<string> topicc1 = temptp.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> topics1 = temptseo.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> topicc2 = topicc1.Distinct().ToList<string>();
            List<string> topics2 = topics1.Distinct().ToList<string>();
            blltopic.SaveTopic(topicc2, topics2);

            List<Model.Scenic> orgslist = bllscenic.GetScenic().ToList<Model.Scenic>();
            bllscenic.DeleteScenicimg();
            //循环景区
            foreach (Entity.ScenicEntity item in newslist)
            {
                if (string.IsNullOrWhiteSpace(item.name)) break;
                //组装scenic
                List<Model.Scenic> ss = orgslist.Where<Model.Scenic>(x => x.Name == item.name).ToList();
                Model.Scenic s;
                if (ss.Count == 1)//已经存在该景区
                {
                    s = ss.First();
                    s.Address = item.address;
                    s.Level = item.level;
                    s.SeoName = item.seoname;
                    s.Area = bllarea.GetAreaByAreaid(int.Parse(item.areaid));
                    //处理topic字符串
                    var temptopic = item.topic.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                    blltopic.SaveScenictopic(temptopic, s.Id);
                    s.Trafficintro = item.trafficintro;
                    s.BookNote = item.bookintro;
                    s.ScenicDetail = item.scenicdetail;
                    s.Desec = item.scenicintro;
                    //组装tickets
                    List<Entity.TicketEntity> newtlist = getTicketslist().Where(x => x.scenicname == s.Name).ToList<Entity.TicketEntity>();
                    IList<Model.Ticket> tickets = bllticket.GetTicketByscId(s.Id);
                    Model.Ticket t;
                    foreach (var te in newtlist)
                    {
                        var tmp = tickets.Where(x => x.Name == te.ticketname);
                        if (tmp.Count() == 1)//已经存在该票
                        {
                            t = tmp.First();
                            t.Name = te.ticketname;
                            t.Scenic = s;
                            t.IsMain = true;
                            //new会产生很多垃圾数据,改为一下.   SST
                            //t.TicketPrice = new List<Model.TicketPrice>() { 
                            //new Model.TicketPrice() { Price=decimal.Parse(te.orgprice),PriceType=Model.PriceType.Normal,Ticket=t},
                            //new Model.TicketPrice(){Price=decimal.Parse(te.olprice),PriceType=Model.PriceType.PayOnline,Ticket=t},
                            //new Model.TicketPrice(){Price=decimal.Parse(te.orgprice)*(decimal)0.95,PriceType=Model.PriceType.PreOrder,Ticket=t}};
                            var tpnormal = t.TicketPrice.Where(x => x.PriceType == Model.PriceType.Normal);
                            if (tpnormal.Count() > 0)
                                t.TicketPrice.Where(x => x.PriceType == Model.PriceType.Normal).First().Price = decimal.Parse(te.orgprice);
                            var tpol = t.TicketPrice.Where(x => x.PriceType == Model.PriceType.PayOnline);
                            if (tpol.Count() > 0)
                                t.TicketPrice.Where(x => x.PriceType == Model.PriceType.PayOnline).First().Price = decimal.Parse(te.olprice);
                            var tppre = t.TicketPrice.Where(x => x.PriceType == Model.PriceType.PreOrder);
                            if (tppre.Count() > 0)
                                t.TicketPrice.Where(x => x.PriceType == Model.PriceType.PreOrder).First().Price = decimal.Parse(te.orgprice) * (decimal)0.95;
                        }
                        else//不存在该票
                        {
                            t = new Model.Ticket();
                            t.Name = te.ticketname;
                            t.Scenic = s;
                            t.IsMain = true;
                            t.TicketPrice = new List<Model.TicketPrice>() { 
                            new Model.TicketPrice() { Price=decimal.Parse(te.orgprice),PriceType=Model.PriceType.Normal,Ticket=t},
                            new Model.TicketPrice(){Price=decimal.Parse(te.olprice),PriceType=Model.PriceType.PayOnline,Ticket=t},
                            new Model.TicketPrice(){Price=decimal.Parse(te.orgprice)*(decimal)0.95,PriceType=Model.PriceType.PreOrder,Ticket=t}};
                            tickets.Add(t);
                        }
                    };
                    s.Tickets = tickets;
                    bllscenic.UpdateScenicInfo(s);
                    List<Model.ScenicImg> silist = CopyFile(s);
                    if (silist != null)
                    {
                        bllscenic.SaveScenicimg(silist);
                    }
                }
                else//不存在该景区
                {
                    s = new Model.Scenic();
                    s.Name = item.name;
                    s.Address = item.address;
                    s.Area = bllarea.GetAreaByAreaid(int.Parse(item.areaid));
                    s.BookNote = item.bookintro;
                    s.Level = item.level;
                    //处理topic字符串
                    var temptopic = item.topic.Split(new char[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                    s.ScenicDetail = item.scenicdetail;
                    s.SeoName = item.seoname;
                    s.Trafficintro = item.trafficintro;
                    s.Desec = item.scenicintro;
                    //组装tickets
                    List<Entity.TicketEntity> newtlist = getTicketslist().Where(x => x.scenicname == s.Name).ToList<Entity.TicketEntity>();
                    List<Model.Ticket> tickets = new List<Model.Ticket>();
                    Model.Ticket t;
                    foreach (var te in newtlist)
                    {
                        t = new Model.Ticket();
                        t.Name = te.ticketname;
                        t.Scenic = s;
                        t.IsMain = true;
                        t.TicketPrice = new List<Model.TicketPrice>() { 
                            new Model.TicketPrice() { Price=decimal.Parse(te.orgprice),PriceType=Model.PriceType.Normal,Ticket=t},
                            new Model.TicketPrice(){Price=decimal.Parse(te.olprice),PriceType=Model.PriceType.PayOnline,Ticket=t},
                            new Model.TicketPrice(){Price=decimal.Parse(te.orgprice)*(decimal)0.95,PriceType=Model.PriceType.PreOrder,Ticket=t}
                        };
                        tickets.Add(t);
                    }
                    s.Tickets = tickets;
                    bllscenic.UpdateScenicInfo(s);
                    blltopic.SaveScenictopic(temptopic, bllscenic.GetScenicBySeoName(item.seoname).Id);
                    List<Model.ScenicImg> silist = CopyFile(s);
                    if (silist != null)
                    {
                        bllscenic.SaveScenicimg(silist);
                    }
                }
            }
            //bllscenic.UpdateScenicInfo(orgslist);
        }

        /// <summary>
        /// 获取-景区表-内容
        /// </summary>
        /// <returns></returns>
        private List<Entity.ScenicEntity> getSceniclist()
        {
            try
            {
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= d:\景区表格式.xls;Extended Properties=Excel 8.0;";
                //Sheet1为excel中表的名字
                string sql = "select 名称,seoname,区域,景区主题,交通指南,订票说明,景区详情,等级,景区地址,topicseo,景区简介 from [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ad.Fill(dt);
                List<Entity.ScenicEntity> slist = new List<Entity.ScenicEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果excel中的某行为空,跳过
                    if (string.IsNullOrEmpty(dt.Rows[i][1].ToString())) continue;

                    //对景区详情处理
                    string[] srclist = GetPiclist(dt.Rows[i][0].ToString().Replace("\n", "").Trim()).Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                    string scdetail = dt.Rows[i][6].ToString().Replace("\n", "").Trim();
                    for (int j = 0; j < srclist.Length / 2; j++)
                    {
                        scdetail = scdetail.Replace(srclist[j], srclist[j + srclist.Length / 2]);
                    }

                    //如果excel中的行不为空,添加
                    slist.Add(new Entity.ScenicEntity()
                    {
                        name = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        seoname = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        areaid = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        topic = dt.Rows[i][3].ToString().Replace("\n", "").Trim(),
                        trafficintro = dt.Rows[i][4].ToString().Replace("\n", "").Trim(),
                        bookintro = dt.Rows[i][5].ToString().Replace("\n", "").Trim(),
                        scenicdetail = scdetail,
                        level = dt.Rows[i][7].ToString().Replace("\n", "").Trim(),
                        address = dt.Rows[i][8].ToString().Replace("\n", "").Trim(),
                        topicseo = dt.Rows[i][9].ToString().Replace("\n", "").Trim(),
                        scenicintro = dt.Rows[i][10].ToString().Replace("\n", "").Trim()
                    });
                }
                return slist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 获取-价格表-内容
        /// </summary>
        /// <returns></returns>
        private List<Entity.TicketEntity> getTicketslist()
        {
            try
            {
                //path即是excel文档的路径。
                string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= d:\价格表格式.xls;Extended Properties=Excel 8.0;";
                //Sheet1为excel中表的名字
                string sql = "select 景区名称,门票名称,原价,在线支付价 from [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ad.Fill(dt);
                List<Entity.TicketEntity> tlist = new List<Entity.TicketEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tlist.Add(new Entity.TicketEntity()
                    {
                        scenicname = dt.Rows[i][0].ToString().Replace("\n", "").Trim(),
                        ticketname = dt.Rows[i][1].ToString().Replace("\n", "").Trim(),
                        orgprice = dt.Rows[i][2].ToString().Replace("\n", "").Trim(),
                        olprice = dt.Rows[i][3].ToString().Replace("\n", "").Trim()
                    });
                }
                return tlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 拷贝图片文件.
        /// </summary>
        /// <param name="scenic"></param>
        /// <returns></returns>
        private List<Model.ScenicImg> CopyFile(Model.Scenic scenic)
        {
            string sourcePath = @"d:\图片\" + scenic.Name.Trim();
            if (!Directory.Exists(sourcePath)) return null;
            string destPath = @"d:\scenicimg";
            DirectoryInfo TheFolder = new DirectoryInfo(sourcePath);
            List<Model.ScenicImg> silist = new List<Model.ScenicImg>();
            bool firstone = true;
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                string guidname = Guid.NewGuid().ToString() + NextFile.Extension;
                string filepath = destPath + @"\" + guidname;
                //FileInfo myfile = new FileInfo(filepath);
                //myfile.Create();
                //创建两个文件流 一个是源文件相关，另一个是要写入的文件
                FileStream fs = new FileStream(NextFile.FullName, FileMode.Open);
                FileStream fs2 = new FileStream(filepath, FileMode.Create);
                byte[] data = new byte[1024];
                BufferedStream bs = new BufferedStream(fs);
                BufferedStream bs2 = new BufferedStream(fs2);
                while (fs.Read(data, 0, data.Length) > 0)
                {
                    fs2.Write(data, 0, data.Length);
                    fs2.Flush();
                }
                fs.Close();
                fs2.Close();
                silist.Add(new Model.ScenicImg()
                {
                    Name = guidname,
                    Scenic = scenic,
                    Title = NextFile.Name.Replace(NextFile.Extension, ""),
                    ImgType = firstone ? Model.ImgType.主图 : Model.ImgType.辅图
                });
                firstone = false;
            }
            return silist;
        }

        private string GetPiclist(string scenicname)
        {
            try
            {
                string result = string.Empty;
                string line = string.Empty;
                System.IO.StreamReader file = new System.IO.StreamReader(string.Format(@"d:\scenicfile\{0}.txt", scenicname));
                while ((line = file.ReadLine()) != null)
                {
                    result += line + "$";
                }
                file.Close();
                return result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        #region 老版本

        //public void Run()
        //{
        //    BLL.BLLScenic bllscenic = new BLL.BLLScenic();
        //    List<Entity.ExcelEntity> eelist = getEelist();
        //    List<Model.Scenic> slist = bllscenic.GetScenic().ToList<Model.Scenic>();
        //    bllscenic.DeleteScenicimg();
        //    foreach (Entity.ExcelEntity item in eelist)
        //    {
        //        if (string.IsNullOrWhiteSpace(item.name)) break;
        //        Model.Scenic s = slist.First<Model.Scenic>(x => x.Name == item.name);
        //        s.ActiveTime = item.opentime;
        //        s.Desec = item.descp;
        //        s.SeoName = item.seoname;
        //        List<Model.ScenicImg> silist = CopyFile(s);
        //        if (silist != null)
        //        {
        //            bllscenic.SaveScenicimg(silist);
        //        }
        //    }
        //    bllscenic.UpdateScenicInfo(slist);
        //}

        ///// <summary>
        ///// 获取excel表格内容
        ///// </summary>
        ///// <returns></returns>
        //private List<Entity.ExcelEntity> getEelist()
        //{
        //    try
        //    {
        //        //path即是excel文档的路径。
        //        string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= d:\2012年浙江省A级旅游景区汇总统计表.xls;Extended Properties=Excel 8.0;";
        //        //Sheet1为excel中表的名字
        //        string sql = "select 名称,办公地点,区域,门票名称,开园时间,价格说明,景区简介,seoname,景区门票 from [Sheet1$]";
        //        OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
        //        OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        ad.Fill(dt);
        //        List<Entity.ExcelEntity> eelist = new List<Entity.ExcelEntity>();
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            eelist.Add(new Entity.ExcelEntity()
        //            {
        //                name = dt.Rows[i][0].ToString(),
        //                address = dt.Rows[i][1].ToString(),
        //                areaid = dt.Rows[i][2].ToString(),
        //                price = decimal.Parse(dt.Rows[i][3].ToString() == "" ? "0" : dt.Rows[i][3].ToString()),
        //                opentime = dt.Rows[i][4].ToString(),
        //                pricedesc = dt.Rows[i][5].ToString(),
        //                descp = dt.Rows[i][6].ToString(),
        //                seoname = dt.Rows[i][7].ToString()
        //            });
        //        }
        //        return eelist;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// 拷贝图片文件.
        ///// </summary>
        ///// <param name="scenic"></param>
        ///// <returns></returns>
        //private List<Model.ScenicImg> CopyFile(Model.Scenic scenic)
        //{
        //    string sourcePath = @"d:\图片\" + scenic.Name;
        //    if (!Directory.Exists(sourcePath)) return null;
        //    string destPath = @"d:\scenicimg";
        //    DirectoryInfo TheFolder = new DirectoryInfo(sourcePath);
        //    List<Model.ScenicImg> silist = new List<Model.ScenicImg>();
        //    bool firstone = true;
        //    foreach (FileInfo NextFile in TheFolder.GetFiles())
        //    {
        //        string guidname = Guid.NewGuid().ToString() + NextFile.Extension;
        //        string filepath = destPath + @"\" + guidname;
        //        //FileInfo myfile = new FileInfo(filepath);
        //        //myfile.Create();
        //        //创建两个文件流 一个是源文件相关，另一个是要写入的文件
        //        FileStream fs = new FileStream(NextFile.FullName, FileMode.Open);
        //        FileStream fs2 = new FileStream(filepath, FileMode.Create);
        //        byte[] data = new byte[1024];
        //        BufferedStream bs = new BufferedStream(fs);
        //        BufferedStream bs2 = new BufferedStream(fs2);
        //        while (fs.Read(data, 0, data.Length) > 0)
        //        {
        //            fs2.Write(data, 0, data.Length);
        //            fs2.Flush();
        //        }
        //        fs.Close();
        //        fs2.Close();
        //        silist.Add(new Model.ScenicImg()
        //        {
        //            Name = guidname,
        //            Scenic = scenic,
        //            Title=NextFile.Name.Replace(NextFile.Extension,""),
        //            ImgType = firstone ? Model.ImgType.主图 : Model.ImgType.辅图
        //        });
        //        firstone = false;
        //    }
        //    return silist;
        //}

        //private DataTable getTable()
        //{
        //    try
        //    {
        //        //path即是excel文档的路径。
        //        string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= d:\test.xls;Extended Properties=Excel 8.0;";
        //        //Sheet1为excel中表的名字
        //        string sql = "select 市县区,序号,等级,名称,办公地点,区域,景区门票,价格说明,景区简介 from [Sheet1$]";
        //        OleDbCommand cmd = new OleDbCommand(sql, new OleDbConnection(conn));
        //        OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        ad.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion
    }
}
