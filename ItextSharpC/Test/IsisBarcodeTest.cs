using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Hp.SRA.Proofing.Chart.Util;
using ItextSharpC;
using NUnit.Framework;

namespace ItextSharpCv10.Test
{
    class IsisBarcodeTest
    {
        [Test]
        public void ShouldGetCode39Ex()
        {
            var barcode39 = IsisBarcode.GetCode39Ex("abc123defg12312313");
            Assert.AreEqual("+A+B+C123+D+E+F+G12312313", barcode39, "Should be equal +A+B+C123+D+E+F+G12312313");
        }
    }
}
