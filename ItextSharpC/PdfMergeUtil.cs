using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ItextSharpCv10
{
    class PdfMergeUtil
    {
        public static void MergeFiles(string destinationFile, List<string> files)
        {
            try
            {
                var f = 0;
                var reader = new PdfReader(files[f]);
                var n = reader.NumberOfPages;
                var document = new Document(reader.GetPageSizeWithRotation(1));
                var writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
                document.Open();
                var cb = writer.DirectContent;
                while (f < files.Count)
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        int rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        }
                        else
                        {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }
                    }
                    f++;
                    if (f < files.Count)
                    {
                        reader = new PdfReader(files[f]);
                        n = reader.NumberOfPages;
                    }
                }
                document.Close();
            }
            catch (Exception e)
            {
                string strOb = e.Message;
            }
        }

        public int CountPageNo(string strFileName)
        {
            // we create a reader for a certain document
            PdfReader reader = new PdfReader(strFileName);
            // we retrieve the total number of pages
            return reader.NumberOfPages;
        }
    }
}
