using System.Globalization;

namespace Com.Hp.SRA.Proofing.Chart.Model
{
    public class ColorDTO
    {
        /// <summary>
        /// Gets or sets the row id.
        /// </summary>
        /// <value>
        /// The row id.
        /// </value>
        public long RowId { get; set; }

        /// <summary>
        /// Gets or sets the name of the sample.
        /// </summary>
        /// <value>
        /// The name of the sample.
        /// </value>
        public string SampleName { get; set; }

        /// <summary>
        /// Gets or sets the L.
        /// </summary>
        /// <value>
        /// The L.
        /// </value>
        public double L { get; set; }

        /// <summary>
        /// Gets or sets the A.
        /// </summary>
        /// <value>
        /// The A.
        /// </value>
        public double A { get; set; }

        /// <summary>
        /// Gets or sets the B.
        /// </summary>
        /// <value>
        /// The B.
        /// </value>
        public double B { get; set; }

        // <summary>
        /// Gets or sets the C.
        /// </summary>
        /// <value>
        /// The C.
        /// </value>
        public double? C { get; set; }

        /// <summary>
        /// Gets or sets the M.
        /// </summary>
        /// <value>
        /// The M.
        /// </value>
        public double? M { get; set; }

        /// <summary>
        /// Gets or sets the Y.
        /// </summary>
        /// <value>
        /// The Y.
        /// </value>
        public double? Y { get; set; }

        /// <summary>
        /// Gets or sets the K.
        /// </summary>
        /// <value>
        /// The K.
        /// </value>
        public double? K { get; set; }

        /// <summary>
        /// Gets or sets the spectral 380.
        /// </summary>
        /// <value>
        /// The spectral 380.
        /// </value>
        public virtual double Spectral380 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 390.
        /// </summary>
        /// <value>
        /// The spectral 390.
        /// </value>
        public virtual double Spectral390 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 400.
        /// </summary>
        /// <value>
        /// The spectral 400.
        /// </value>
        public virtual double Spectral400 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 410.
        /// </summary>
        /// <value>
        /// The spectral 410.
        /// </value>
        public virtual double Spectral410 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 420.
        /// </summary>
        /// <value>
        /// The spectral 420.
        /// </value>
        public virtual double Spectral420 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 430.
        /// </summary>
        /// <value>
        /// The spectral 430.
        /// </value>
        public virtual double Spectral430 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 440.
        /// </summary>
        /// <value>
        /// The spectral 440.
        /// </value>
        public virtual double Spectral440 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 450.
        /// </summary>
        /// <value>
        /// The spectral 450.
        /// </value>
        public virtual double Spectral450 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 460.
        /// </summary>
        /// <value>
        /// The spectral 460.
        /// </value>
        public virtual double Spectral460 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 470.
        /// </summary>
        /// <value>
        /// The spectral 470.
        /// </value>
        public virtual double Spectral470 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 480.
        /// </summary>
        /// <value>
        /// The spectral 480.
        /// </value>
        public virtual double Spectral480 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 490.
        /// </summary>
        /// <value>
        /// The spectral 490.
        /// </value>
        public virtual double Spectral490 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 500.
        /// </summary>
        /// <value>
        /// The spectral 500.
        /// </value>
        public virtual double Spectral500 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 510.
        /// </summary>
        /// <value>
        /// The spectral 510.
        /// </value>
        public virtual double Spectral510 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 520.
        /// </summary>
        /// <value>
        /// The spectral 520.
        /// </value>
        public virtual double Spectral520 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 530.
        /// </summary>
        /// <value>
        /// The spectral 530.
        /// </value>
        public virtual double Spectral530 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 540.
        /// </summary>
        /// <value>
        /// The spectral 540.
        /// </value>
        public virtual double Spectral540 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 550.
        /// </summary>
        /// <value>
        /// The spectral 550.
        /// </value>
        public virtual double Spectral550 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 560.
        /// </summary>
        /// <value>
        /// The spectral 560.
        /// </value>
        public virtual double Spectral560 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 570.
        /// </summary>
        /// <value>
        /// The spectral 570.
        /// </value>
        public virtual double Spectral570 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 580.
        /// </summary>
        /// <value>
        /// The spectral 580.
        /// </value>
        public virtual double Spectral580 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 590.
        /// </summary>
        /// <value>
        /// The spectral 590.
        /// </value>
        public virtual double Spectral590 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 600.
        /// </summary>
        /// <value>
        /// The spectral 600.
        /// </value>
        public virtual double Spectral600 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 610.
        /// </summary>
        /// <value>
        /// The spectral 610.
        /// </value>
        public virtual double Spectral610 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 620.
        /// </summary>
        /// <value>
        /// The spectral 620.
        /// </value>
        public virtual double Spectral620 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 630.
        /// </summary>
        /// <value>
        /// The spectral 630.
        /// </value>
        public virtual double Spectral630 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 640.
        /// </summary>
        /// <value>
        /// The spectral 640.
        /// </value>
        public virtual double Spectral640 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 650.
        /// </summary>
        /// <value>
        /// The spectral 650.
        /// </value>
        public virtual double Spectral650 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 660.
        /// </summary>
        /// <value>
        /// The spectral 660.
        /// </value>
        public virtual double Spectral660 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 670.
        /// </summary>
        /// <value>
        /// The spectral 670.
        /// </value>
        public virtual double Spectral670 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 680.
        /// </summary>
        /// <value>
        /// The spectral 680.
        /// </value>
        public virtual double Spectral680 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 690.
        /// </summary>
        /// <value>
        /// The spectral 690.
        /// </value>
        public virtual double Spectral690 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 700.
        /// </summary>
        /// <value>
        /// The spectral 700.
        /// </value>
        public virtual double Spectral700 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 710.
        /// </summary>
        /// <value>
        /// The spectral 710.
        /// </value>
        public virtual double Spectral710 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 720.
        /// </summary>
        /// <value>
        /// The spectral 720.
        /// </value>
        public virtual double Spectral720 { get; set; }

        /// <summary>
        /// Gets or sets the spectral 730.
        /// </summary>
        /// <value>
        /// The spectral 730.
        /// </value>
        public virtual double Spectral730 { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Join("\t",
                               new object[]
                                   {
                                       RowId,
                                       SampleName,
                                       DoubleToStringUs(L),
                                       DoubleToStringUs(A),
                                       DoubleToStringUs(B),
                                       DoubleToStringUs(Spectral380),
                                       DoubleToStringUs(Spectral390),
                                       DoubleToStringUs(Spectral400),
                                       DoubleToStringUs(Spectral410),
                                       DoubleToStringUs(Spectral420),
                                       DoubleToStringUs(Spectral430),
                                       DoubleToStringUs(Spectral440),
                                       DoubleToStringUs(Spectral450),
                                       DoubleToStringUs(Spectral460),
                                       DoubleToStringUs(Spectral470),
                                       DoubleToStringUs(Spectral480),
                                       DoubleToStringUs(Spectral490),
                                       DoubleToStringUs(Spectral500),
                                       DoubleToStringUs(Spectral510),
                                       DoubleToStringUs(Spectral520),
                                       DoubleToStringUs(Spectral530),
                                       DoubleToStringUs(Spectral540),
                                       DoubleToStringUs(Spectral550),
                                       DoubleToStringUs(Spectral560),
                                       DoubleToStringUs(Spectral570),
                                       DoubleToStringUs(Spectral580),
                                       DoubleToStringUs(Spectral590),
                                       DoubleToStringUs(Spectral600),
                                       DoubleToStringUs(Spectral610),
                                       DoubleToStringUs(Spectral620),
                                       DoubleToStringUs(Spectral630),
                                       DoubleToStringUs(Spectral640),
                                       DoubleToStringUs(Spectral650),
                                       DoubleToStringUs(Spectral660),
                                       DoubleToStringUs(Spectral670),
                                       DoubleToStringUs(Spectral680),
                                       DoubleToStringUs(Spectral690),
                                       DoubleToStringUs(Spectral700),
                                       DoubleToStringUs(Spectral710),
                                       DoubleToStringUs(Spectral720),
                                       DoubleToStringUs(Spectral730)
                                   });
        }

        public  string ToStringCmyk()
        {
            return string.Join("\t",
                               new object[]
                                   {
                                       RowId,
                                       SampleName,
                                       DoubleToStringUsNullable(C),
                                       DoubleToStringUsNullable(M),
                                       DoubleToStringUsNullable(Y),
                                       DoubleToStringUsNullable(K),
                                       DoubleToStringUs(Spectral380),
                                       DoubleToStringUs(Spectral390),
                                       DoubleToStringUs(Spectral400),
                                       DoubleToStringUs(Spectral410),
                                       DoubleToStringUs(Spectral420),
                                       DoubleToStringUs(Spectral430),
                                       DoubleToStringUs(Spectral440),
                                       DoubleToStringUs(Spectral450),
                                       DoubleToStringUs(Spectral460),
                                       DoubleToStringUs(Spectral470),
                                       DoubleToStringUs(Spectral480),
                                       DoubleToStringUs(Spectral490),
                                       DoubleToStringUs(Spectral500),
                                       DoubleToStringUs(Spectral510),
                                       DoubleToStringUs(Spectral520),
                                       DoubleToStringUs(Spectral530),
                                       DoubleToStringUs(Spectral540),
                                       DoubleToStringUs(Spectral550),
                                       DoubleToStringUs(Spectral560),
                                       DoubleToStringUs(Spectral570),
                                       DoubleToStringUs(Spectral580),
                                       DoubleToStringUs(Spectral590),
                                       DoubleToStringUs(Spectral600),
                                       DoubleToStringUs(Spectral610),
                                       DoubleToStringUs(Spectral620),
                                       DoubleToStringUs(Spectral630),
                                       DoubleToStringUs(Spectral640),
                                       DoubleToStringUs(Spectral650),
                                       DoubleToStringUs(Spectral660),
                                       DoubleToStringUs(Spectral670),
                                       DoubleToStringUs(Spectral680),
                                       DoubleToStringUs(Spectral690),
                                       DoubleToStringUs(Spectral700),
                                       DoubleToStringUs(Spectral710),
                                       DoubleToStringUs(Spectral720),
                                       DoubleToStringUs(Spectral730)
                                   });
        }
        /// <summary>
        /// To the string LAB.
        /// </summary>
        /// <returns></returns>
        public  string ToStringLab()
        {
            return string.Join("\t",
                               new object[]
                                   {
                                       RowId,
                                       DoubleToStringUs(L),
                                       DoubleToStringUs(A),
                                       DoubleToStringUs(B),
                                       DoubleToStringUs(Spectral380),
                                       DoubleToStringUs(Spectral390),
                                       DoubleToStringUs(Spectral400),
                                       DoubleToStringUs(Spectral410),
                                       DoubleToStringUs(Spectral420),
                                       DoubleToStringUs(Spectral430),
                                       DoubleToStringUs(Spectral440),
                                       DoubleToStringUs(Spectral450),
                                       DoubleToStringUs(Spectral460),
                                       DoubleToStringUs(Spectral470),
                                       DoubleToStringUs(Spectral480),
                                       DoubleToStringUs(Spectral490),
                                       DoubleToStringUs(Spectral500),
                                       DoubleToStringUs(Spectral510),
                                       DoubleToStringUs(Spectral520),
                                       DoubleToStringUs(Spectral530),
                                       DoubleToStringUs(Spectral540),
                                       DoubleToStringUs(Spectral550),
                                       DoubleToStringUs(Spectral560),
                                       DoubleToStringUs(Spectral570),
                                       DoubleToStringUs(Spectral580),
                                       DoubleToStringUs(Spectral590),
                                       DoubleToStringUs(Spectral600),
                                       DoubleToStringUs(Spectral610),
                                       DoubleToStringUs(Spectral620),
                                       DoubleToStringUs(Spectral630),
                                       DoubleToStringUs(Spectral640),
                                       DoubleToStringUs(Spectral650),
                                       DoubleToStringUs(Spectral660),
                                       DoubleToStringUs(Spectral670),
                                       DoubleToStringUs(Spectral680),
                                       DoubleToStringUs(Spectral690),
                                       DoubleToStringUs(Spectral700),
                                       DoubleToStringUs(Spectral710),
                                       DoubleToStringUs(Spectral720),
                                       DoubleToStringUs(Spectral730)
                                   });
        }

        /// <summary>
        /// Doubles to string us.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string DoubleToStringUs(double value)
        {
            return value.ToString(CultureInfo.GetCultureInfo("en-US"));
        }
        /// <summary>
        /// Doubles to string us nullable.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string DoubleToStringUsNullable(double? value)
        {
            return DoubleToStringUs(value ?? 0);
        }
    }
}