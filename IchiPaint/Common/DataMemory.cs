using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace IchiPaint.Common
{
    public class DataMemory
    {
       public static PhongThuy PhongThuy { get; set; }
    }

    public class ConfigInfo
    {
        public static string BaseUrl { get; set; }
        public static string BaseDir { get; set; }
        public static string ConnectString { get; set; }

        public static int RecordOnPage = 10;

        public static int RecordOnPageIndex = 5;
        public static string ProductTemplate { get; set; }
        public static void GetConfig()
        {
            try
            {
                BaseDir = ConfigurationManager.AppSettings.Get("BaseDir");
                BaseUrl = ConfigurationManager.AppSettings.Get("BaseUrl");
                RecordOnPage = Convert.ToInt32(ConfigurationManager.AppSettings.Get("RecordOnPage")) ;
                RecordOnPageIndex = Convert.ToInt32(ConfigurationManager.AppSettings.Get("RecordOnPageIndex"));
                ConnectString = ConfigurationManager.AppSettings.Get("ConnectString");

                var fileTemplate = HttpRuntime.AppDomainAppPath + "\\Template\\Product.html";
                ProductTemplate = File.ReadAllText(fileTemplate);

                fileTemplate = HttpRuntime.AppDomainAppPath + "\\Template\\Menh.xls";
                DataMemory.PhongThuy = new PhongThuy(fileTemplate);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString());
                throw;
            }
        }
    }

    public class Logger
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}