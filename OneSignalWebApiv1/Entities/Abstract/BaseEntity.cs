using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneSignalWebApiv1.Entities.Abstract
{
    public class BaseEntity
    {
        [Key]
        public Guid GUID { get; set; } = Guid.NewGuid();
        [Column(TypeName = "date")] public DateTime CREATEDDATE { get; set; } = DateTime.Now.Date;
        [Column(TypeName = "time")] public TimeSpan CREATEDTIME { get; set; } = DateTime.Now.TimeOfDay;

    }
}
