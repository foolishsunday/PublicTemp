using SQLiteSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Database
{
    public class DbContext 
    {
        public static string ConnectionString
        {
            get
            {
                string reval = "DataSource=" + System.AppDomain.CurrentDomain.BaseDirectory + "Db\\saiterAP.sqlite"; ; //这里可以动态根据cookies或session实现多库切换
                //string reval = "DataSource=" + @"D:\Github\Work\Work\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\DataBase\saiter.sqlite";
                return reval;
            }
        }
        public static SqlSugarClient GetInstance()
        {

            var db = new SqlSugarClient(ConnectionString);
            db.IsEnableLogEvent = true;//启用日志事件
            db.LogEventStarting = (sql, par) => { Console.WriteLine(sql + " " + par + "\r\n"); };
            return db;
        }
    }
}
