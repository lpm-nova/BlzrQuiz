using BlzrQuiz.Data.EfClasses;
using Microsoft.EntityFrameworkCore;

namespace BlzrQuiz.Data
{
    public class BlzrQuizContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public BlzrQuizContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring a one-to-many question -> answer relationship that is friendly for serialisation
            modelBuilder.Entity<QuestionAnswer>().HasKey(qa => new { qa.QuestionId, qa.AnswerId });
            modelBuilder.Entity<QuestionAnswer>().HasOne<Question>().WithMany(q => q.Answers);

            // Configuring a many-to-many question -> tag relationship that is friendly for serialisation
            modelBuilder.Entity<QuestionTags>().HasKey(qt => new { qt.QuestionId, qt.TagId });
            modelBuilder.Entity<QuestionTags>().HasOne<Question>().WithMany(t => t.Tags);
            modelBuilder.Entity<QuestionTags>().HasOne(t => t.Tag).WithMany();
            modelBuilder.Entity<Question>().Ignore(q => q.Result);

        }
    }
}