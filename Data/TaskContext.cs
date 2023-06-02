using System.Data;

namespace ApiTask.Data
{

    //Context
    public class TaskContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
