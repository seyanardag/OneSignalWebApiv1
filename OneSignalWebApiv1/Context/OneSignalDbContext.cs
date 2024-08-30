using Microsoft.EntityFrameworkCore;
using OneSignalWebApiv1.Entities;
using System;

namespace OneSignalWebApiv1.Context
{
    public class OneSignalDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.; Database=Fusion; Trusted_Connection = true; Encrypt=False;");
        }

        public DbSet <LiveLesson> LiveLessons { get; set; }
        public DbSet <Student> Students { get; set; }
        public DbSet <Homework> Homeworks { get; set; }
        public DbSet<StudentHomeworkMV> StudentHomeworkMVs { get; set; }
        public DbSet<CustomSchedule> CustomSchedules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentHomeworkMV>()
                .HasKey(x => new { x.StudentId, x.HomeworkId });

            modelBuilder.Entity<StudentHomeworkMV>()
                .HasOne(x=>x.Student)
                .WithMany(s=>s.StudentHomeworkMVs)
                .HasForeignKey(fk=>fk.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentHomeworkMV>()
                .HasOne(x=>x.Homework)
                .WithMany(h=>h.StudentHomeworkMVs)
                .HasForeignKey(fk=>fk.HomeworkId)
                .OnDelete(DeleteBehavior.Restrict);



            //DbSeed İşlemleri;
            modelBuilder.Entity<Student>().HasData(
                new Student { GUID = Guid.Parse("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"), StudentName = "Ali"},
                new Student { GUID = Guid.Parse("b25858ec-f3e6-4951-ac73-cd3518e3d78b"), StudentName = "Ayşe"},
                new Student { GUID = Guid.Parse("954089bb-6666-44dc-928e-d4effc12169a"), StudentName = "Ahmet"}
            );



            modelBuilder.Entity<Homework>().HasData(
                new Homework { GUID=Guid.Parse("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b"), HomeworkTitle="Matematik 5 soru çöz", CREATEDDATE=DateTime.Now.AddMinutes(5), CREATEDTIME = DateTime.Now.AddMinutes(5).TimeOfDay, },
                new Homework { GUID=Guid.Parse("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3"), HomeworkTitle="Tükçe 105-110 sayfalaro yap", CREATEDDATE=DateTime.Now.AddMinutes(10), CREATEDTIME = DateTime.Now.AddMinutes(5).TimeOfDay }
                );


            modelBuilder.Entity<StudentHomeworkMV>().HasData(
                // Ali'ye her iki ödev
                new StudentHomeworkMV { StudentId = Guid.Parse("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"), HomeworkId = Guid.Parse("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b") },
                new StudentHomeworkMV { StudentId = Guid.Parse("193c1ee9-f009-475b-8a5b-b83d4ee1ccec"), HomeworkId = Guid.Parse("d8a89b58-0db8-4f62-a6b5-dc5a2e3de0a3") },

                // Ayşe'ye sadece ilk ödev
                new StudentHomeworkMV { StudentId = Guid.Parse("b25858ec-f3e6-4951-ac73-cd3518e3d78b"), HomeworkId = Guid.Parse("e0f4c6a5-5a6b-4d6e-8c5d-ef33b40f6d4b") }
             );







        }

    }
}
