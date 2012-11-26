using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using CE.Crawler.Common;

namespace CE.Crawler
{
    public class PageRank
    {
        //阻尼因数为0.85
        private const Double d = 0.85;
        private static Double pr_rank = 1 - d;
        private static string strQuery = "select pr_rank,blob_resource,outer_links from repository";
        private static string strHtml = "";
        /// <summary>
        /// Calculate page rank
        /// PR(A) = (1-d) + d(PR(t1)/C(t1) + ... + PR(tn)/C(tn))
        /// </summary>
        /// <param name="strUrl"></param>
        /// <returns></returns>
        public static Double calcPageRank(string strUrl)
        {
            //DataTable dt = SQLiteUtility.GetDataTable(strQuery);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    strHtml = Encoding.UTF8.GetString((byte[])dt.Rows[i]["blob_resource"]);
            //    if (strHtml.Contains(strUrl))
            //    {
            //        pr_rank = pr_rank + Double.Parse(dt.Rows[i]["pr_rank"].ToString()) / Double.Parse(dt.Rows[i]["outer_links"].ToString());
            //    }
            //}
            //return pr_rank;
            return 0.0d;
        }
    }
}