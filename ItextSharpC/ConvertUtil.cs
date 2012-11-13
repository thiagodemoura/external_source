using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hp.SRA.Proofing.Chart.Util
{
    public abstract class ConvertUtil
    {
        /// <summary>
        /// 1 millimeter = 0.0393700787 inches
        /// </summary>
        public const double MM_1 = 0.039370079;

        /// <summary>
        /// 1 centimeter = 0.393700787 inches
        /// </summary>
        public const double CM_1 = 0.393700787;

        /// <summary>
        /// 1 millimeter = 2.834645669 point
        /// </summary>
        public const double MMTRANSP = 11.65181631;

        /// <summary>
        /// PDFDPI
        /// </summary>
        public const double PDF_DPI = 72;

        /// <summary>
        /// INs to PDF.
        /// </summary>
        /// <param name="inches">The inches.</param>
        /// <returns></returns>
        public static double INToPdf(double inches)
        {
            return inches * PDF_DPI;
        }

        /// <summary>
        /// INs to PDF with previous height.
        /// </summary>
        /// <param name="inches">The inches.</param>
        /// <returns></returns>
        public static double INToPdfWithPreviousHeight(double inches, double previousHeight)
        {
            return (inches*PDF_DPI)*previousHeight;
        }

        /// <summary>
        /// MMs to PDF.
        /// </summary>
        /// <param name="mm">The mm.</param>
        /// <returns></returns>
        public static double MMToPdf(double mm)
        {
            return MM_1 * mm * PDF_DPI;
        }

        /// <summary>
        /// MMs to PDF.
        /// </summary>
        /// <param name="mm">The mm.</param>
        /// <returns></returns>
        public static float MMToPdfFloat(double mm)
        {
            return (float) MMToPdf(mm);
        }

        /// <summary>
        /// MMs to PDF.
        /// </summary>
        /// <param name="pdf">The PDF.</param>
        /// <returns></returns>
        public static double PDFToMM(double pdf)
        {
            return (pdf / PDF_DPI) / MM_1;
        }

        /// <summary>
        /// CMs to PDF.
        /// </summary>
        /// <param name="cm">The cm.</param>
        /// <returns></returns>
        public static double CMToPdf(double cm)
        {
            return CM_1 * cm * PDF_DPI;
        }

        /// <summary>
        /// CMs to PDF.
        /// </summary>
        /// <param name="cm">The cm.</param>
        /// <returns></returns>
        public static float CMToPdfFloat(double cm)
        {
            return (float) CMToPdf(cm);
        }

        /// <summary>
        /// PDFs to MM unit25.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static double PdfToMMUnit25(double size)
        {
            if (size.Equals(6))
            {
                return 0;
            }
            size = PDFToMM(size);
            size = (size - 6)/0.25;
            return size;
        }

        public static double MM2TransLate(double mm)
        {
            return mm*MMTRANSP;
        }
    }
}