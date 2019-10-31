using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Common;
using XPCar.Prj.Model;

namespace XPCar.Sys.IO.DocFile
{
    public class AsposeWordManager : AsposeHelper
    {
        private string _FilePath;
        private string _BooknameText1 = "TestText1_";
        private string _BooknameResult1 = "TestResult1_";
        //private string _BooknameText2 = "Text2_";
        //private string _BooknameResult2 = "Result2_";
        //private string _BooknameText3 = "Text3_";
        //private string _BooknameResult3 = "Result3_";
        //private string _BooknameText4 = "Text4_";
        //private string _BooknameResult4 = "Result4_";
        private string _BooknameSummary1 = "TestSummary_";
        private string _BooknameView = "TestItemsList_";

        private string _BooknameInterop = "Result_";
        private string _BooknameAC = "AC_";
        public AsposeWordManager(string path, string dotPath)
         : base(dotPath)
        {
            _FilePath = path;
        }
        public bool Save(List<TestItemsReport> lists)
        {
            try
            {
                CreateDocByTemplate();
                if (lists != null && lists.Count > 0)
                {
                    foreach (TestItemsReport report in lists)
                    {
                        WriteDataToBookname(_BooknameText1 + report.ItemId, report.TestText1);
                        //WriteDataToBookname(_BooknameText2 + report.ItemId, report.TestText2);
                        //WriteDataToBookname(_BooknameText3 + report.ItemId, report.TestText3);
                        //WriteDataToBookname(_BooknameText4 + report.ItemId, report.TestText4);

                        WriteDataToBookname(_BooknameResult1 + report.ItemId, report.TestResult1);
                        //WriteDataToBookname(_BooknameResult2 + report.ItemId, report.TestResult2);
                        //WriteDataToBookname(_BooknameResult3 + report.ItemId, report.TestResult3);
                        //WriteDataToBookname(_BooknameResult4 + report.ItemId, report.TestResult4);

                        WriteDataToBookname(_BooknameSummary1 + report.ItemId, report.TestSummary);

                        WriteDataToBookname(_BooknameView + report.ItemId, report.TestSummary);
                    }
                }
                SaveDoc(_FilePath);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }

        }

        public bool SaveInterop(List<TestInterop> lists)
        {
            try
            {
                CreateDocByTemplate();
                if (lists != null && lists.Count > 0)
                {
                    foreach (TestInterop report in lists)
                    {
                        WriteDataToBookname(_BooknameInterop + report.ObjectNo, report.TestResult);
                    }
                }
                SaveDoc(_FilePath);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
        public bool SaveTestAC(List<TestAC> lists)
        {
            try
            {
                CreateDocByTemplate();
                if (lists != null && lists.Count > 0)
                {
                    foreach (TestAC report in lists)
                    {
                        WriteDataToBookname(_BooknameAC + report.ObjectNo, report.TestResult);
                    }
                }
                SaveDoc(_FilePath);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
                return false;
            }
        }
    }
}
