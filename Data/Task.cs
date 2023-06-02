using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTask.Data
{

    //The record model
    [Table("Task")]
    public record Task(int Id, string Activity, string Status)
    {
    }
}
