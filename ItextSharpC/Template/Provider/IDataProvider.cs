using System.Data;

namespace Com.Hp.SRA.Proofing.Chart.Template.Provider
{
    public interface IDataProvider
    {
        IDataReader GetDataReader();
    }
}
