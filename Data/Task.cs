using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTask.Data
{
    [Table("Task")]
    public record Task(int Id, string Activity, string Status)
    {
    }
}
