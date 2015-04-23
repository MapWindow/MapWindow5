using System.Collections.Generic;

namespace MW5.Api.Interfaces
{
    public interface IVectorDatasource: IDatasource
    {
        bool Open(string connectionString);

        IEnumerable<string> GetShemas();
    }
}
