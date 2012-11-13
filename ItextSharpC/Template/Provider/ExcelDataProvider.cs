using System.Data;
using Excel;

namespace Com.Hp.SRA.Proofing.Chart.Template.Provider
{
    public class ExcelDataProvider : IDataProvider
    {
        private const string XlsxExtension = ".xlsx";
        private const string XlsExtension = ".xls";

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>
        /// The data source.
        /// </value>
          protected string DataSource { get; set; }

          /// <summary>
          /// Initializes a new instance of the <see cref="ExcelDataProvider" /> class.
          /// </summary>
          /// <param name="dataSource">The data source.</param>
          public ExcelDataProvider(string dataSource) 
          {
              DataSource = dataSource;
          }
          /// <summary>
          /// Gets the data reader.
          /// </summary>
          /// <returns></returns>
          public IDataReader GetDataReader()
          {
              System.IO.FileStream stream = System.IO.File.Open(DataSource, System.IO.FileMode.Open, System.IO.FileAccess.Read);

              IExcelDataReader excelReader = null;
              if (IsXlsDataSource())
              {
                  //Reading from a binary Excel file ('97-2003 format; *.xls)
                  excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
              }
              else if (IsXlsxDataSource())
              {
                  //Reading from a  Excel file ('2007 format; *.xlsx)
                  excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
              }
              stream.Close();
              return excelReader;
          }

        private bool IsXlsxDataSource()
        {
            return DataSource.EndsWith(XlsxExtension);
        }

        private bool IsXlsDataSource()
        {
            return DataSource.EndsWith(XlsExtension);
        }
    }
}
