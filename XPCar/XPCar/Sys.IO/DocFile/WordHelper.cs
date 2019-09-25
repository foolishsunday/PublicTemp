using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using XPCar.Common;

namespace XPCar.Sys.IO.DocFile
{
    public class WordHelper
    {
        private _Application _WordApp;
        private _Document _WordDoc;
        private string _TemplatePath;

        public WordHelper()
        { }
        public WordHelper(string dotPath)
        {
            Object Nothing = System.Reflection.Missing.Value;
            _WordApp = new Microsoft.Office.Interop.Word.Application();
            _WordDoc = _WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            //AppDomain.CurrentDomain.SetupInformation.ApplicationBase + _MainController.Config.SkinPath;
            //_TemplatePath = System.Windows.Forms.Application.StartupPath + ".\Config\\template.dot";
            _TemplatePath = dotPath; 
        }

        protected void CreateDocByTemplate()
        {
            try
            {
                if (!File.Exists(_TemplatePath))
                    return;
                object missing = System.Reflection.Missing.Value;
                object templateName = _TemplatePath;
                _WordDoc = _WordApp.Documents.Open(ref templateName, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
                _WordDoc.Activate();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }

        }
        protected void WriteDataToBookname(string bookName, string text)
        {
            try
            {
                object bookmark = bookName;
                if (_WordApp.ActiveDocument.Bookmarks.Exists(bookName))
                {
                    Bookmark bm = _WordDoc.Bookmarks.get_Item(ref bookmark);//返回书签 
                    bm.Range.Text = text;//设置书签域的内容
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
        protected void SaveDoc(string path)
        {
            try
            {
                //保存格式
                object format = WdSaveFormat.wdFormatDocument;
                object miss = System.Reflection.Missing.Value;
                _WordDoc.SaveAs2(path, ref format, ref miss,
                                ref miss, ref miss, ref miss, ref miss,
                                ref miss, ref miss, ref miss, ref miss,
                                ref miss, ref miss, ref miss, ref miss,
                                ref miss);
                object saveChanges = WdSaveOptions.wdSaveChanges;
                object orginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
                object route = false;
                _WordDoc.Close(ref saveChanges, ref orginalFormat, ref route);
                _WordApp.Quit(ref saveChanges, ref orginalFormat, ref route);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + "()", ex);
            }
        }
    }
}
