using System.Data;
using Excel;

namespace Com.Hp.SRA.Proofing.Chart.Template.Provider
{
    public class ExcelDataProvider : IDataProvider
    {
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
              if (DataSource.EndsWith(".xls"))
              {
                  //Reading from a binary Excel file ('97-2003 format; *.xls)
                  excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
              }
              else if (DataSource.EndsWith(".xlsx"))
              {
                  //Reading from a  Excel file ('2007 format; *.xlsx)
                  excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
              }
              stream.Close();
              return excelReader;
          }
    }
}
