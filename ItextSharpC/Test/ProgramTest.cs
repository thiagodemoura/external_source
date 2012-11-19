using Com.Hp.SRA.Proofing.Chart;
using NUnit.Framework;
using iTextSharp.text;
using Com.Hp.SRA.Proofing.Chart.Template;

namespace ItextSharpCv10.Test
{
    class ProgramTest
    {
        private readonly Rectangle _pageRect = new Rectangle(120, 120, 120, 120);
        private readonly PantoneIsisTemplate _program = new PantoneIsisTemplate();

        [Test]
        public void ShouldCalculateTotalPatchesPerPage()
        {
            var contentInfoDto = _program.CalculateTotalPatchesPerPage(_pageRect);
            Assert.That(contentInfoDto.ColumnNumber, Is.EqualTo(2.0d));
            Assert.That(contentInfoDto.RowNumber, Is.EqualTo(-7.0d));
        }

    }
}
