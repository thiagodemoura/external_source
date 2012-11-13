using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Com.Hp.SRA.Proofing.Chart.Util;
using NUnit.Framework;

namespace ItextSharpCv10.Test
{
    public class ConvertUtilTest
    {
        [Test]
        public void ShouldConvertInchesToPixels()
        {
            double pixels = ConvertUtil.INToPdf(2);
            Assert.AreEqual(144, pixels, "Should be equal 144");
        }

        [Test]
        public void ShouldConvertInchesToPixelsWithHeight()
        {
            double pixels = ConvertUtil.INToPdfWithPreviousHeight(2, 3);
            Assert.AreEqual(432, pixels, "Should be equal 432");
        }

        [Test]
        public void ShouldConvertMilimetersToPixels()
        {
            double pixels = ConvertUtil.MMToPdf(60);
            Assert.AreEqual(170.07874128d, pixels, "Should be equal 1700.07874128d");
        }

        [Test]
        public void ShouldConvertMilimetersToPixelsFloat()
        {
            float pixels = ConvertUtil.MMToPdfFloat(60);
            Assert.AreEqual(170.078735f, pixels, "Should be equal 1700.078735f");
        }

        [Test]
        public void ShouldConvertPdfToMilimeter()
        {
            double pixels = ConvertUtil.PDFToMM(60);
            Assert.AreEqual(21.166666526966669d, pixels, "Should be equal 21.166666526966669d");
        }

        [Test]
        public void ShouldConvertPdfToMmUnit25()
        {
            double pixels = ConvertUtil.PdfToMMUnit25(6);
            Assert.AreEqual(0, pixels);
        }

        [Test]
        public void ShouldConvertPdfToMmUnit25WithNumberBiggerThenSix()
        {
            double pixels = ConvertUtil.PdfToMMUnit25(60);
            Assert.AreEqual(60.666666107866675d, pixels, "Should be equal 60.666666107866675d");
        }
    }
}