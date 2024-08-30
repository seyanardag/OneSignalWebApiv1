namespace OneSignalWebApiv1.Entities
{
    public class StudentHomeworkMV
    {
       
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }

        public Guid HomeworkId { get; set; }
        public Homework? Homework { get; set; }
        
    }
}
