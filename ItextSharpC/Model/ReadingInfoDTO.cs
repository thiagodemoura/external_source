using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Hp.SRA.Proofing.Chart.Model
{
    public class ReadingInfoDTO
    {
        /// <summary>
        /// Gets or sets the originator.
        /// </summary>
        /// <value>
        /// The originator.
        /// </value>
        public string Originator { get; set; }
        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>
        /// The manufacturer.
        /// </value>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets the instrumentation.
        /// </summary>
        /// <value>
        /// The instrumentation.
        /// </value>
        public string Instrumentation { get; set; }
        /// <summary>
        /// Gets or sets the measurement source.
        /// </summary>
        /// <value>
        /// The measurement source.
        /// </value>
        public string MeasurementSource { get; set; }
        /// <summary>
        /// Gets or sets the name of the illumination.
        /// </summary>
        /// <value>
        /// The name of the illumination.
        /// </value>
        public string IlluminationName { get; set; }
        /// <summary>
        /// Gets or sets the observer angle.
        /// </summary>
        /// <value>
        /// The observer angle.
        /// </value>
        public string ObserverAngle { get; set; }
        /// <summary>
        /// Gets or sets the number of fields.
        /// </summary>
        /// <value>
        /// The number of fields.
        /// </value>
        public int? NumberOfFields { get; set; }
        /// <summary>
        /// Gets or sets the lgorowlength.
        /// </summary>
        /// <value>
        /// The lgorowlength.
        /// </value>
        public int? Lgorowlength { get; set; }

        /// <summary>
        /// Gets or sets the header list.
        /// </summary>
        /// <value>
        /// The header list.
        /// </value>
        public List<string> HeaderList { get; set; }

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>
        /// The colors.
        /// </value>
        public List<ColorDTO> ColorList { get; set; }

        /// <summary>
        /// Gets or sets the descriptor.
        /// </summary>
        /// <value>
        /// The descriptor.
        /// </value>
        public string Descriptor { get; set; }

        /// <summary>
        /// Gets or sets the format version.
        /// </summary>
        /// <value>
        /// The format version.
        /// </value>
        public int? FormatVersion { get; set; }

        /// <summary>
        /// Gets or sets the weighting function.
        /// </summary>
        /// <value>
        /// The weighting function.
        /// </value>
        public List<string> WeightingFunction { get; set; }

        /// <summary>
        /// Gets or sets the number of sets.
        /// </summary>
        /// <value>
        /// The number of sets.
        /// </value>
        public int? NumberOfSets { get; set; }

        /// <summary>
        /// Appends the string if not empty.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="value">The value.</param>
        /// <param name="constants">The constants.</param>
        protected void AppendStringIfNotEmpty(StringBuilder result,string value, string constants)
        {
            if (!string.IsNullOrEmpty(value))
            {
                result.Append(constants).Append(" \"").Append(value).Append("\"").AppendLine();
            }
        }


        /// <summary>
        /// Prepares the header.
        /// </summary>
        /// <returns></returns>
        private StringBuilder PrepareHeader(IEnumerable<string> headerData)
        {
            var result = new StringBuilder();
            result.AppendLine("CGATS.17");
            AppendStringIfNotEmpty(result, Originator, AnsiITConstants.Originator);
            AppendStringIfNotEmpty(result, Descriptor, AnsiITConstants.Descriptor);
            result.Append(AnsiITConstants.Created).Append(" \"").Append(Created.ToShortDateString()).Append("\"").AppendLine();
            result.Append(AnsiITConstants.FormatVersion).Append("\t").Append(FormatVersion).AppendLine();
            AppendStringIfNotEmpty(result, Instrumentation, AnsiITConstants.Instrumentation);
            if (NumberOfFields > 0)
            {
                result.Append(AnsiITConstants.NumberOfFields).Append(" ").Append(NumberOfFields).AppendLine();
            }
            AppendStringIfNotEmpty(result, Manufacturer, AnsiITConstants.Manufacturer);
            AppendStringIfNotEmpty(result, MeasurementSource, AnsiITConstants.MeasurementSource);
            AppendStringIfNotEmpty(result, IlluminationName, AnsiITConstants.IlluminationName);


            AppendStringIfNotEmpty(result, ObserverAngle, AnsiITConstants.ObserverAngle);

            if (Lgorowlength > 0)
            {
                result.Append(AnsiITConstants.Lgorowlength).Append(" ").Append(Lgorowlength).AppendLine();
            }
            result.AppendLine(AnsiITConstants.BeginDataFormat);
            result.AppendLine(string.Join("\t", headerData));
            result.AppendLine(AnsiITConstants.EndDataFormat);
            if (NumberOfSets > 0)
            {
                result.Append(AnsiITConstants.NumberOfSets).Append(" ").Append(NumberOfSets).AppendLine();
            }
            return result;
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var result = PrepareHeader(HeaderList);
            
            result.AppendLine(AnsiITConstants.BeginData);
            foreach (var color in ColorList)
            {
                 result.AppendLine(color.ToString());
                
            }
            result.AppendLine(AnsiITConstants.EndData);

            return result.ToString();
        }

        /// <summary>
        /// To the string cmyk.
        /// </summary>
        /// <returns></returns>
        public string ToStringCmyk()
        {
            var headerData = new List<string>();
            if(HeaderList.Count==41)
            {
                headerData.Add("SampleID");
                headerData.Add("SAMPLE_NAME");
                {
                    headerData.Add("CMYK_C");
                    headerData.Add("CMYK_M");
                    headerData.Add("CMYK_Y");
                    headerData.Add("CMYK_K");
                }
                headerData.AddRange(HeaderList.Skip(5));

            }
            var result = PrepareHeader(headerData);

            result.AppendLine(AnsiITConstants.BeginData);
            foreach (var color in ColorList)
            {
                result.AppendLine(color.ToStringCmyk());

            }
            result.AppendLine(AnsiITConstants.EndData);

            return result.ToString();
        }

        
    }
}
