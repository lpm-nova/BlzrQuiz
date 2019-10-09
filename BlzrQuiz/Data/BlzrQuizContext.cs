using BlzrQuiz.Data.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlzrQuiz.Core;

namespace BlzrQuiz.Data
{
    public class BlzrQuizContext : IdentityDbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        //public DbSet<Tag> Tags { get; set; }

        public BlzrQuizContext(DbContextOptions<BlzrQuizContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuring a one-to-many question -> answer relationship that is friendly for serialisation
            //modelBuilder.Entity<QuestionAnswer>().HasKey(qa => new { qa.QuestionId, qa.AnswerId });
            //modelBuilder.Entity<QuestionAnswer>().HasOne<Question>().WithMany(q => q.Answers);

            // Configuring a many-to-many question -> tag relationship that is friendly for serialisation
            modelBuilder.Entity<QuestionTags>().HasKey(qt => new { qt.QuestionId, qt.TagId });
            //modelBuilder.Entity<QuestionTags>().HasOne<Question>().WithMany(t => t.Tags);
            modelBuilder.Entity<QuestionTags>().HasOne(t => t.Tag).WithMany();

            modelBuilder.Entity<Question>().HasKey(q => q.QuestionId);
            //modelBuilder.Entity<Question>().Property<int>("QuestionId").ValueGeneratedOnAdd();
            modelBuilder.Entity<Question>().HasOne(c => c.Certification);
            modelBuilder.Entity<Question>().HasMany(q => q.Answers).WithOne(q => q.Question).HasForeignKey(q => q.QuestionId);
            modelBuilder.Entity<Question>().Ignore(q => q.Result);
            modelBuilder.Entity<Question>().HasOne(e => e.Explanation).WithOne();
            modelBuilder.Entity<Answer>().HasKey(q => q.AnswerId);
            modelBuilder.Entity<Answer>().Property<int>("AnswerId").ValueGeneratedOnAdd();
            modelBuilder.Entity<Question>().HasOne(c => c.Explanation);
            //modelBuilder.Entity<Answer>().HasOne(q => q.Question).WithMany(q => q.Answers).HasForeignKey(q => q.QuestionId);

            modelBuilder.Entity<Quiz>().HasKey(q => q.QuizId);
            modelBuilder.Entity<Quiz>().HasOne(c => c.Certification).WithMany().HasForeignKey(x => x.CertificationId);
            modelBuilder.Entity<Tag>().Property<int>("TagId").ValueGeneratedOnAdd();
            modelBuilder.Entity<Explanation>().HasKey(e => e.ExplanationId);
            modelBuilder.Entity<Explanation>().Property<int>("ExplanationId").ValueGeneratedOnAdd();


            //// Configuring a one-to-many question -> answer relationship that is friendly for serialisation
            modelBuilder.Entity<QuizQuestion>().HasKey(qa => new { qa.QuizId, qa.QuestionId });
            //modelBuilder.Entity<QuizQuestion>().HasOne(qe => qe.Question).WithMany(q => q.Answers).HasForeignKey(qe => qe.QuestionId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<QuizQuestion>().HasOne(qz => qz.Quiz).WithMany(qe => qe.QuizQuestions).HasForeignKey(qz => qz.QuizId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<QuestionAnswer>().HasKey(qa => new { qa.AnswerId, qa.QuestionId });
            modelBuilder.Entity<QuestionAnswer>().HasOne(qe => qe.Question).WithMany(qz => qz.QuestionAnswers).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<QuestionAnswer>().HasOne(qz => qz.Answer).WithMany(qe => qe.QuestionAnswers).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<QuizQuestion>().HasOne<Quiz>().WithMany(q => q.Questions);
            DataInjector.Inject(modelBuilder);
        }
    }
}