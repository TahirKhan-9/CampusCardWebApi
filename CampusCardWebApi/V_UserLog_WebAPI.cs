using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UsmanCodeBlocks.Data.Sql;
using System.ComponentModel.DataAnnotations;

namespace CampusCardWebApi
{
  
    public class V_UserLog_WebAPI
    {
        
        public string EmpCode { get; set; }
        public string Email { get; set; }
        [Key]
        public string AccountName { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public string Section { get; set; }
        public DateTime Date { get; set; }




        //public IConfiguration _configuration;
        //public tbl_Attendance(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public static DataTable GetAllTimes(IConfiguration _Configuration)
        {
            try
            {
                return DBFactory.GetAll(_Configuration.GetConnectionString("FasConString").ToString(), "V_UserLog_WebAPI");
            }
            catch (Exception ex)
            {
                //Globals.ShowException("Process Failure:\n\r" + ex.Message);
                return null;
            }
        }
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            if (dt == null)
                return null;
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        if (!dr.IsNull(column.ColumnName))
                            pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
        public static SqlConnection ConnectionString(IConfiguration _Configuration)
        {

            return new SqlConnection();

        }
    }
}
