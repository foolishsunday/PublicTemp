using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XPCar.Sys.IO.DocFile
{
    public class AsposeHelper
    {
        private Document _WordDoc;
        private string _TemplatePath;


        public AsposeHelper()
        { }
        public AsposeHelper(string dotPath)
        {
            _TemplatePath = dotPath;
        }
        public void CreateDocByTemplate()
        {
            _WordDoc = new Document(_TemplatePath);

        }
        public void WriteDataToBookname(string bookmarkId, string Content)
        {

            if (_WordDoc.Range.Bookmarks[bookmarkId] != null)
            {
                _WordDoc.Range.Bookmarks[bookmarkId].Text = Content;
            }
        }
        public void SaveDoc(string fileName)
        {
            _WordDoc.Save(fileName);
        }
    }
}
