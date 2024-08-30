using OneSignalWebApiv1.Entities.Abstract;

namespace OneSignalWebApiv1.Entities
{
    public class Homework : BaseEntity
    {
        public string HomeworkTitle { get; set; }


        public ICollection<StudentHomeworkMV> StudentHomeworkMVs { get; set; } = new HashSet<StudentHomeworkMV>();

    }
}
