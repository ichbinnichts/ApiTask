using System.Data;

namespace ApiTask.Data
{
    public class TaskContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
