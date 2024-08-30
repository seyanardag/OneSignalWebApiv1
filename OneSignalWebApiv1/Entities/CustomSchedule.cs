using OneSignalWebApiv1.Entities.Abstract;

namespace OneSignalWebApiv1.Entities
{
    public class CustomSchedule: BaseEntity
    {
        public string LessonName { get; set; }
        public DateTime ScheduleDate { get; set; }
    }
}
