using  BlzrQuiz.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BlzrQuiz.Core;
using System.ComponentModel.DataAnnotations;

namespace BlzrQuiz.Data
{
    public class BlzrQuizContext : IdentityDbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<UserQuiz> UserQuizes { get; set; }
        public DbSet<UserQuizQuestionAnswer> UserQuizQuestionAnswers { get; set; }

        public BlzrQuizContext(DbContextOptions<BlzrQuizContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuring a one-to-many question -> answer relationship that is friendly for serialisation
            //modelBuilder.Entity<QuestionAnswer>().HasKey(qa => new { qa.QuestionId, qa.AnswerId });
            //modelBuilder.Entity<QuestionAnswer>().HasOne<Question>().WithMany(q => q.Answers);

            // Configuring a many-to-many question -> tag relationship that is friendly for serialisation
            modelBuilder.Entity<QuestionTags>().HasKey(qt => new { qt.QuestionId, qt.TagId });
            modelBuilder.Entity<QuestionTags>().HasOne(t => t.Tag).WithMany();

            modelBuilder.Entity<Question>().HasKey(q => q.QuestionId);
            modelBuilder.Entity<Question>().HasOne(c => c.Certification);
            modelBuilder.Entity<Question>().HasMany(q => q.Answers).WithOne(q => q.Question).HasForeignKey(q => q.QuestionId);
            //modelBuilder.Entity<Question>().Ignore(q => q.Result);
            modelBuilder.Entity<Answer>().HasKey(q => q.AnswerId);
            modelBuilder.Entity<Answer>().Property<int>("AnswerId").ValueGeneratedOnAdd();

            modelBuilder.Entity<Quiz>().HasKey(q => q.QuizId);
            modelBuilder.Entity<Quiz>().HasOne(c => c.Certification).WithMany().HasForeignKey(x => x.CertificationId);
            modelBuilder.Entity<Tag>().Property<int>("TagId").ValueGeneratedOnAdd();
            modelBuilder.Entity<Explanation>().HasKey(e => e.ExplanationId);
            modelBuilder.Entity<Explanation>().HasOne(q => q.Question);
            modelBuilder.Entity<Explanation>().Property<int>("ExplanationId").ValueGeneratedOnAdd();

            modelBuilder.Entity<UserQuiz>().HasKey(x => x.UserQuizId);
            modelBuilder.Entity<UserQuiz>().HasOne(x => x.Quiz);
            //modelBuilder.Entity<UserQuiz>().HasOne(x => x.UserId);
            modelBuilder.Entity<UserQuiz>().Property(x => x.Score).HasDefaultValue(0);

            modelBuilder.Entity<UserQuizQuestionAnswer>().HasKey(x => x.UserQuizQuestionAnswerId);
            modelBuilder.Entity<UserQuizQuestionAnswer>().HasOne(x => x.UserQuiz).WithMany(x => x.UserQuizQuestionAnswers).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserQuizQuestionAnswer>().HasOne(x => x.QuizQuestion).WithMany(x => x.UserQuizQuestionAnswers).OnDelete(DeleteBehavior.NoAction);
            //// Configuring a one-to-many question -> answer relationship that is friendly for serialisation
            modelBuilder.Entity<QuizQuestion>().HasKey(qa => new { qa.QuizId, qa.QuestionId });
            modelBuilder.Entity<QuizQuestion>().HasOne(qz => qz.Quiz).WithMany(qe => qe.QuizQuestions).HasForeignKey(qz => qz.QuizId).OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<QuestionAnswer>().HasKey(qa => new { qa.AnswerId, qa.QuestionId });
            //modelBuilder.Entity<QuestionAnswer>().HasOne(qe => qe.Question).WithMany(qz => qz.QuestionAnswers).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<QuestionAnswer>().HasOne(qz => qz.Answer).WithMany(qe => qe.QuestionAnswers).OnDelete(DeleteBehavior.NoAction);
            DataInjector.Inject(modelBuilder);
        }
    }
}