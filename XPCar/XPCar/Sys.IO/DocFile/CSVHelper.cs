using System;
using System.Collections.Generic;
using System.IO;
using XPCar.Common;

namespace XPCar.Sys.IO.DocFile
{
    public class CSVHelper
    {
        public bool CreateFile(string path)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                fi.Directory.Create();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }


        }
        public void WriteLine(string path, string line)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(path);
                if (!fi.Directory.Exists)
                {
                    return;
                }

                fs = new FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

                sw.WriteLine(line);

                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (fs != null)
                    fs.Close();
            }
        }
        public void AppendLine(string path, List<string> lists)
        {
            FileStream fs;
            StreamWriter sw;
            try
            {
                fs = new FileStream(path, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

                foreach (string line in lists)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }


        }
    }
}
