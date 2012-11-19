using Com.Hp.SRA.Proofing.Chart;
using NUnit.Framework;
using iTextSharp.text;

namespace ItextSharpCv10.Test
{
    class ProgramTest
    {
        private readonly Rectangle _pageRect = new Rectangle(120, 120, 120, 120);
        private readonly Program _program = new Program();

        [Test]
        public void ShouldCalculateTotalPatchesPerPage()
        {
            var contentInfoDto = _program.CalculateTotalPatchesPerPage(_pageRect);
            Assert.That(contentInfoDto.ColumnNumber, Is.EqualTo(2.0d));
            Assert.That(contentInfoDto.RowNumber, Is.EqualTo(-7.0d));
        }

    }
}
