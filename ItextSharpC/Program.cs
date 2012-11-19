
using System;
using System.Collections.Generic;
using System.IO;
using Com.Hp.SRA.Proofing.Chart.Model;
using Com.Hp.SRA.Proofing.Chart.Template.Provider;
using Com.Hp.SRA.Proofing.Chart.Util;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Rectangle = iTextSharp.text.Rectangle;
using Com.Hp.SRA.Proofing.Chart.Util.Barcodes;
using Com.Hp.SRA.Proofing.Chart.Template;

namespace Com.Hp.SRA.Proofing.Chart
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {


        private static void Main(string[] args)
        {
            // Method that creates a single frame with BarCode
            /*   using (Stream stream = File.Create(@"c:\temp\text.pdf"))
               {
                   new PantoneIsisTemplate().GenerateChart(true, "asdasd", stream);
               }*/

            // Method that creates a single frame without BarCode
            /*using (Stream stream = File.Create(@"c:\temp\text.pdf"))
            {
                new Program().GenerateChart(false, "asdasd", stream);
            }*/

            ;
            // Method that inserts a barcode into a existing frame

            //new Program().InsertBarCode(@"C:\temp\text_w-out-barcode.pdf");

            //new Program().GenerateMultipleChart(@"C:\temp\merged.pdf", 6);

            using (Stream stream = File.Create(@"c:\temp\mtext"+DateTime.Now.Ticks+".pdf"))
            {
                using (Stream stream1 = File.OpenRead(@"c:\temp\text.pdf"))
                {
                    using (Stream stream2 = File.OpenRead(@"c:\temp\text.pdf"))
                    {
                        PdfMergeUtil.FileImposition((float)ConvertUtil.INToPdf(12.48),
                            (float)ConvertUtil.INToPdf(38.58), stream, 3, true, stream1,stream2);
                    }
                }

                //
            }
        }
    }
}