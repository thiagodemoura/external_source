using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ItextSharpCv10
{
    class PdfMergeUtil
    {
        public static void MergeFiles(string destinationFile, List<string> files, bool removeMergedFiles)
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
                    var i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        var page = writer.GetImportedPage(reader, i);
                        var rotation = reader.GetPageRotation(i);
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
                if (removeMergedFiles)
                {
                    DeleteMergedFiles(files);
                }
            }
            catch (Exception e)
            {
                var strOb = e.Message;
            }
        }

        private static void DeleteMergedFiles(IEnumerable<string> files)
        {
            foreach (var filename in
                files.Select(filename => new {filename, fileExists = File.Exists(filename)})
                     .Where(@t => @t.fileExists)
                     .Select(@t => @t.filename))
            {
                File.Delete(filename);
            }
        }

        public int CountPageNo(string strFileName)
        {
            var reader = new PdfReader(strFileName);
            return reader.NumberOfPages;
        }
    }
}
