
namespace CE.Crawler
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class Settings
    {
        private static string ConfigurationFilePath;
        private static string folder;

        static Settings()
        {
            folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ConfigurationFilePath = Path.Combine(folder, "config.ini");
        }

        public static int ThreadCount
        {
            get
            {
                return Convert.ToInt32(GetValue("ThreadCount", 10));
            }
            set
            {
                SetValue("ThreadCount", value);
            }
        }

        public static int ThreadSleepTimeWhenQueueIsEmpty
        {
            get
            {
                return Convert.ToInt32(GetValue("ThreadSleepTimeWhenQueueIsEmpty", 2));
            }
            set
            {
                SetValue("ThreadSleepTimeWhenQueueIsEmpty", value);
            }
        }

        public static int ConnectionTimeout
        {
            get
            {
                return Convert.ToInt32(GetValue("ConnectionTimeout", 20));
            }
            set
            {
                SetValue("ConnectionTimeout", value);
            }
        }

        public static string DataStoreMode
        {
            get
            {
                return Convert.ToString(GetValue("DataStoreMode", "1"));
            }
            set
            {
                SetValue("DataStoreMode", value);
            }            
        }

        public static string SQLiteDBFolder
        {
            get
            {
                return Convert.ToString(GetValue("SQLiteDBFolder", "crawlerdb.s3db"));
            }
            set
            {
                SetValue("SQLiteDBFolder", value);
            }
        }

        public static string FileSystemFolder
        {
            get
            {
                return Convert.ToString(GetValue("FileSystemFolder", folder));
            }
            set
            {
                SetValue("FileSystemFolder", value);
            }
        }

        public static bool AllowAllMimeTypes
        {
            get
            {
                return Convert.ToBoolean(GetValue("AllowAllMimeTypes", true));
            }
            set
            {
                SetValue("AllowAllMimeTypes", value);
            }
        }

        public static string FileMatches
        {
            get
            {
                return Convert.ToString(GetValue("FileMatches", ""));
            }
            set
            {
                SetValue("FileMatches", value);
            }            
        }

        public static string HighPriority
        {
            get
            {
                return Convert.ToString(GetValue("HighPriority", ""));
            }
            set
            {
                SetValue("HighPriority", value);
            }
        }

        public static string Language
        {
            get
            {
                return Convert.ToString(GetValue("Language", ""));
            }
            set
            {
                SetValue("Language", value);
            }
        }

        static void SetValue(string keyName, object value)
        {
            NativeMethods.WritePrivateProfileString("Crawler", keyName, value.ToString(), ConfigurationFilePath);
        }

        static object GetValue(string keyName, object defaultValue)
        {
            StringBuilder retVal = new StringBuilder(1024);
            NativeMethods.GetPrivateProfileString("Crawler", keyName, defaultValue.ToString(), retVal, 1024, ConfigurationFilePath);
            return retVal.ToString();
        }
    }

    class NativeMethods
    {
        [DllImport("kernel32")]
        internal static extern long WritePrivateProfileString(
            string appName,
            string keyName, 
            string value, 
            string fileName);
        
        [DllImport("kernel32")]
        internal static extern int GetPrivateProfileString(
            string appName,
            string keyName, 
            string _default, 
            StringBuilder returnedValue,
            int size, 
            string fileName);       

    }
}
