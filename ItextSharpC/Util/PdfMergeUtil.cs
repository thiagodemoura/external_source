using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using Com.Hp.SRA.Proofing.Chart.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Com.Hp.SRA.Proofing.Chart.Util
{
    class PdfMergeUtil
    {
        public static void FileImposition(float width, float height,
            Stream exitStream, int numberDocOfPages, bool rotateSeconds, params Stream[] fileStreams)
        {
            Point currentPoint = null;
            var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            //http://forums.asp.net/t/1692347.aspx/1
            using (var document = new Document(new Rectangle(width, height)))
            {
                var writer = PdfWriter.GetInstance(document, exitStream);
                {
                    document.Open();
                    var content = writer.DirectContent;
                    document.NewPage();
                    var fileCount = 1;
                    foreach (var fileStream in fileStreams)
                    {
                        var reader = new PdfReader(fileStream);
                        var numberOfPages = reader.NumberOfPages;
                        var isSecond = (fileCount % 2 == 0);
                        if (numberOfPages > 0)
                        {
                            var page = writer.GetImportedPage(reader, 1);
                            var pageRect = reader.GetPageSizeWithRotation(1);
                            var matrix = new Matrix();
                            if (currentPoint == null)
                            {
                                currentPoint = new Point(0, pageRect.Height);
                            }
                            matrix.Translate(currentPoint.X, currentPoint.Y);
                            matrix.Rotate(-90);

                            currentPoint.Y += pageRect.Height;
                            
                            content.AddTemplate(page, matrix);
                            content.BeginText();
                            content.SetFontAndSize(baseFont, 9);
                            content.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Data", currentPoint.X, currentPoint.Y,0);
                            content.EndText();
                            currentPoint.Y += 100;

                        }

                        fileCount++;
                    }


                }
            }
        }
        /// <summary>
        /// Merges the files.
        /// </summary>
        /// <param name="destinationFile">The destination file.</param>
        /// <param name="files">The files.</param>
        /// <param name="removeMergedFiles">if set to <c>true</c> [remove merged files].</param>
        public static void MergeFiles(string destinationFile, List<string> files, bool removeMergedFiles)
        {
            try
            {
                var f = 0;
                var reader = new PdfReader(files.First());
                var numberOfPages = reader.NumberOfPages;
                var document = new Document(reader.GetPageSizeWithRotation(1));
                var writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
                document.Open();
                var content = writer.DirectContent;
                while (f < files.Count)
                {
                    var i = 0;
                    while (i < numberOfPages)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        var page = writer.GetImportedPage(reader, i);
                        var rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270)
                            content.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        else
                            content.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                    }
                    f++;
                    if (f < files.Count)
                    {
                        reader = new PdfReader(files[f]);
                        numberOfPages = reader.NumberOfPages;
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
                files.Select(filename => new { filename, fileExists = File.Exists(filename) })
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
