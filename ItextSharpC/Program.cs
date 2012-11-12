﻿using System;
﻿using System.Collections.Generic;
﻿using System.Drawing;
﻿using System.IO;
using Com.Hp.SRA.Proofing.Chart.Model;
using Com.Hp.SRA.Proofing.Chart.Template.Provider;
using Com.Hp.SRA.Proofing.Chart.Util;
using ItextSharpC;
using iTextSharp.text;
using iTextSharp.text.pdf;
﻿using Rectangle = iTextSharp.text.Rectangle;

namespace Com.Hp.SRA.Proofing.Chart
{
    internal class Program
    {
        /// <summary>
        /// Slide Border
        /// </summary>
        protected static float SideBorder = ConvertUtil.CMToPdfFloat(1.5);

        /// <summary>
        /// LEADER EDGE
        /// </summary>
        protected static float LeaderEdge = ConvertUtil.CMToPdfFloat(3.2);

        /// <summary>
        /// BAR HEIGHT
        /// </summary>
        protected static float BarHeight = ConvertUtil.MMToPdfFloat(5);

        /// <summary>
        /// POS_BAR_2_CHART
        /// </summary>
        protected static float PosBar2Chart = ConvertUtil.MMToPdfFloat(20);


        /// <summary>
        /// BORDER PAGE
        /// </summary>
        protected static float BorderPage = 0;


        /// <summary>
        /// PATCH_SIZE
        /// </summary>
        public static float TrailerEdge = ConvertUtil.CMToPdfFloat(2.5);

        /// <summary>
        /// The W pos marker
        /// </summary>
        public static float WPosMarker = ConvertUtil.MMToPdfFloat(5);

        /// <summary>
        /// The H pos marker
        /// </summary>
        public static float HPosMarker = ConvertUtil.MMToPdfFloat(2.5);

        /// <summary>
        /// The W pos marker mid
        /// </summary>
        public static float WPosMarkerMid = WPosMarker / 2;

        /// <summary>
        /// The H pos marker mid
        /// </summary>
        public static float HPosMarkerMid = HPosMarker / 2;

        /// <summary>
        /// The diamont dist1
        /// </summary>
        public static float DiamontDist1 = ConvertUtil.MMToPdfFloat(5);

        /// <summary>
        /// The diamont dist2
        /// </summary>
        public static float DiamontDist2 = ConvertUtil.MMToPdfFloat(5);

        /// <summary>
        /// The patch size
        /// </summary>
        public static float PatchSize = ConvertUtil.MMToPdfFloat(6);

        private const int BorderDifference = 35;

        /// <summary>
        /// Draws the diamont.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public static void DrawDiamont(PdfContentByte content, float x, float y)
        {
            content.SaveState();
            var state = new PdfGState();
            content.SetGState(state);
            content.SetColorFill(BaseColor.BLACK);
            content.MoveTo(x, y);
            var sPoint = new Point(x, y);
            var uMPoint = new Point(x + WPosMarkerMid, y + HPosMarkerMid);
            var rPoint = new Point(uMPoint.X + WPosMarkerMid, uMPoint.Y - HPosMarkerMid);
            var mPoint = new Point(rPoint.X - WPosMarkerMid, rPoint.Y - HPosMarkerMid);

            DrawLines(content, uMPoint, rPoint, mPoint, sPoint);

            content.ClosePathFillStroke();
            content.RestoreState();
        }

        private static void DrawLines(PdfContentByte content, params Point[] points)
        {
            foreach (var point in points)
            {
                content.LineTo(point.X, point.Y);
            }
        }

        public static Point DrawUpperRectangle(PdfContentByte content, Rectangle pageRect, float barSize)
        {

            content.SaveState();
            var state = new PdfGState { FillOpacity = 1f };
            content.SetGState(state);
            content.SetColorFill(BaseColor.BLACK);

            content.SetLineWidth(0);
            var result = new Point(SideBorder + BorderPage,
                              pageRect.Height - (BorderPage + LeaderEdge + BarHeight + 1));

            content.Rectangle(result.X, result.Y, barSize, BarHeight);
            content.ClosePathFillStroke();
            content.RestoreState();
            return result;
        }

        public static void DrawSquare(PdfContentByte content, Point point, System.Data.IDataReader reader)
        {
            content.SaveState();
            var state = new PdfGState { FillOpacity = 1f };
            content.SetGState(state);
            var color = new CMYKColor(reader.GetFloat(1), reader.GetFloat(2), reader.GetFloat(3), reader.GetFloat(4));
            content.SetColorFill(color);

            content.SetLineWidth(0);
            content.Rectangle(point.X, point.Y, PatchSize, PatchSize);
            content.Fill();
            content.RestoreState();
        }


        /// <summary>
        /// Creates the pre diamont.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="pageRect">The page rect.</param>
        /// <param name="point">The point.</param>
        protected void CreatePreDiamont(PdfContentByte content, Rectangle pageRect, Point point)
        {
            DrawDiamont(content, DiamontDist1 + BorderPage, point.Y + (PatchSize / 2));
        }


        /// <summary>
        /// Creates the pos diamont.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="pageRect">The page rect.</param>
        /// <param name="endUpBarPoint">The end up bar point.</param>
        /// <param name="point">The point.</param>
        protected void CreatePosDiamont(PdfContentByte content, Rectangle pageRect, Point endUpBarPoint, Point point)
        {
            DrawDiamont(content, endUpBarPoint.X + DiamontDist1, point.Y + (PatchSize / 2));
        }

        /// <summary>
        /// Calculates the total patches per page.
        /// </summary>
        /// <param name="pageRect">The page rect.</param>
        /// <returns></returns>
        protected ContentInfoDTO CalculateTotalPatchesPerPage(Rectangle pageRect)
        {
            var result = new ContentInfoDTO();
            var usableXSpace = pageRect.Right - 2 * (BorderPage + WPosMarker + DiamontDist1 + DiamontDist2);
            result.ColumnNumber = Math.Floor(usableXSpace / PatchSize);
            var usableYSpace = pageRect.Top - (BorderPage + TrailerEdge + LeaderEdge + BarHeight + PosBar2Chart);
            result.RowNumber = Math.Floor(usableYSpace / PatchSize);
            return result;
        }


        public void GenerateChart(bool showBarCode, string extraData, Stream output)
        {
            var pageRect = new Rectangle((float)ConvertUtil.INToPdf(10.5), (float)ConvertUtil.INToPdf(12.48));
            var maxElements = CalculateTotalPatchesPerPage(pageRect);

            var barSize = (float)maxElements.ColumnNumber * PatchSize;

            var dataProvider = new ExcelDataProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\pe34483.xls"));
            bool firstPage = true;


            using (var pdfDoc = new Document(pageRect))
            {
                var writer = PdfWriter.GetInstance(pdfDoc, output);
                pdfDoc.Open();
                using (var reader = dataProvider.GetDataReader())
                {
                    if (!reader.Read()) return;

                    while (reader.Read())
                    {
                        if (!firstPage)
                        {
                            pdfDoc.NewPage();
                        }
                        var canvas = writer.DirectContent;
                        var upBarPoint = DrawUpperRectangle(canvas, pageRect, barSize);
                        var chartPoint = new Point(upBarPoint.X, (upBarPoint.Y - PosBar2Chart) + BarHeight);
                        var barCodePoint = new Point(upBarPoint.X, upBarPoint.Y - ConvertUtil.MMToPdfFloat(16.5));

                        var endUpBarPoint = new Point(upBarPoint.X + barSize, upBarPoint.Y);

                        var data = DrawPatches(pageRect, canvas, chartPoint, endUpBarPoint, maxElements, reader, barSize);
                        DrawPageBorder(writer, pageRect, pdfDoc, canvas);
                        firstPage = false;
                    }
                }
            }



        }

        private ContentInfoDTO DrawPatches(Rectangle pageRect, PdfContentByte canvas, Point chartPoint, Point endUpBarPoint, ContentInfoDTO maxElements, System.Data.IDataReader reader, float barSize)
        {
            var result = new ContentInfoDTO { RowNumber = 0, ColumnNumber = maxElements.ColumnNumber };
            var squarePoint = new Point(SideBorder + BorderPage, chartPoint.Y - ConvertUtil.MMToPdfFloat(6) - PatchSize);
            var maxColumnsPerRow = maxElements.ColumnNumber;
            var maxPatches = maxElements.ColumnNumber * maxElements.RowNumber;
            var countPacthes = 0;
            bool lastLineWasCompleted;
            do
            {
                var colorName = reader.GetString(0);

                if (!colorName.ToUpper().Equals("JUMP"))
                {
                    DrawSquare(canvas, squarePoint, reader);
                }
                countPacthes++;


                lastLineWasCompleted = false;
                if (countPacthes % maxColumnsPerRow == 0)
                {
                    CreatePreDiamont(canvas, pageRect, squarePoint);
                    CreatePosDiamont(canvas, pageRect, endUpBarPoint, squarePoint);
                    squarePoint = new Point(SideBorder + BorderPage, squarePoint.Y - PatchSize);
                    result.RowNumber++;
                    lastLineWasCompleted = true;
                }
                else
                {
                    squarePoint = new Point(squarePoint.X + PatchSize, squarePoint.Y);
                }



                if (countPacthes == maxPatches)
                {
                    break;
                }



            } while (reader.Read());

            if (!lastLineWasCompleted)
            {
                CreatePreDiamont(canvas, pageRect, squarePoint);
                CreatePosDiamont(canvas, pageRect, endUpBarPoint, squarePoint);
                result.RowNumber++;
            }
            return result;
        }

        /// <summary>
        /// Draws the page border.
        /// </summary>
        /// <param name="writer"> </param>
        /// <param name="pageRect"> </param>
        /// <param name="document"> </param>
        /// <param name="canvas"> </param>
        /// <param name="docpage">The docpage.</param>
        /// <returns></returns>
        protected void DrawPageBorder(PdfWriter writer, Rectangle pageRect, Document document, PdfContentByte canvas)
        {
            var pageBorderRect = new Rectangle(document.PageSize);
            var content = writer.DirectContent;

            pageBorderRect.Left += document.LeftMargin - BorderDifference;
            pageBorderRect.Right -= document.RightMargin - BorderDifference;
            pageBorderRect.Top -= document.TopMargin - BorderDifference;
            pageBorderRect.Bottom += document.BottomMargin - BorderDifference;
            content.SetColorStroke(BaseColor.BLACK);
            canvas.SetLineWidth(1f);
            canvas.SetRGBColorStroke(0, 0, 0);
            canvas.SetLineDash(6f, 6f, 0f);
            content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
            content.Stroke();
        }




        private static void Main(string[] args)
        {
            using (Stream stream = File.Create(@"c:\temp\text.pdf"))
            {
                new Program().GenerateChart(false, "asdasd", stream);
            }
        }
    }
}