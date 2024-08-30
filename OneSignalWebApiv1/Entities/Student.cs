using OneSignalWebApiv1.Entities.Abstract;

namespace OneSignalWebApiv1.Entities
{
    public class Student : BaseEntity
    {
        public string StudentName { get; set; }

        public ICollection<StudentHomeworkMV> StudentHomeworkMVs { get; set; } = new HashSet<StudentHomeworkMV>();
    }
}
