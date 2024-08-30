using OneSignalWebApiv1.Entities.Abstract;

namespace OneSignalWebApiv1.Entities
{
    public class LiveLesson : BaseEntity
    {
        public string TeacherName { get; set; }
        public string NAME { get; set; }
        public DateTime STARTDATE { get; set; }
        public string STUDENTIDS { get; set; } //nvarcahr formatında, csv ile ayrılmış

    }
}
