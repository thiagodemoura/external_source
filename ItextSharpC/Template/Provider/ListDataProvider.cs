using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Com.Hp.SRA.Proofing.Chart.Template.Provider
{
    public class ListDataProvider : IDataProvider
    {

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<object[]> Data { set; get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListDataProvider"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public ListDataProvider(List<object[]> data) {
            this.Data = data;
        }

        /// <summary>
        /// Gets the data reader.
        /// </summary>
        /// <returns></returns>
        public IDataReader GetDataReader()
        {
            throw new NotImplementedException();
        }
    }
}
