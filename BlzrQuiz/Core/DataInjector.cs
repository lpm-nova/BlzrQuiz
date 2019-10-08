using BlzrQuiz.Data.EfClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Core
{
    public class DataInjector
    {
        private readonly ModelBuilder modelBuilder;
        public DataInjector(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public static void Inject(ModelBuilder modelBuilder)
        {
            var di = new DataInjector(modelBuilder);
            di.AddCertifications();
            di.AddQuestions();
        }

        private void AddQuestions()
        {

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 3,
                    CertificationId = 3,
                    IsMultiple = false,
                    Text = "Which of the following is a benefit of Amazon ElasticCompute Cloud (Amazon EC2) over physicalservers?"
                },
                new Question
                {
                    QuestionId = 4,
                    CertificationId = 3,
                    IsMultiple = false,
                    Text = "Which AWS service provides infrastructure securityoptimization recommendations?"
                }
            );
            modelBuilder.Entity<Explanation>().HasData(
                 new Explanation
                 {
                     ExplanationId = 3,
                     Text = "One of the advantages of EC2 Instances is the persecond billing concept. This is given in the AWSdocumentation also With per-second billing, you pay foronly what you use. It takes cost of unused minutes andseconds in an hour off of the bill, so you can focus onimproving your applications instead of maximizing usageto the hour. Especially, if you manage instances runningfor irregular periods of time, such as dev/testing, dataprocessing, analytics, batch processing and gamingapplications, can benefit. For more information on EC2Pricing, please refer to the below URL:https://aws.amazon.com/e02/pricing/",
                 },
                new Explanation
                {
                    ExplanationId = 4,
                    Text = "The AWS documentation mentions the following Anonline resource to help you reduce cost, increaseperformance, and improve security by optimizing yourAWS environment, Trusted Advisor provides real timeguidance to help you provision your resources followingAWS best practices For more information on the AWSTrusted Advisor, please refer to the below URL:https://aws.amazon.com/premiumsupport/trustedadvisor/",

                }
            );
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    AnswerId = 10,
                    QuestionId = 3,
                    Text = "Automated backup",
                    IsCorrect = false
                },
                new Answer
                {
                    AnswerId = 11,
                    QuestionId = 3,
                    Text = "Paying only for what you use",
                    IsCorrect = true
                },
                new Answer
                {
                    AnswerId = 12,
                    QuestionId = 3,
                    Text = "The ability to choose hardware vendors",
                    IsCorrect = false
                },
                new Answer
                {
                    AnswerId = 13,
                    QuestionId = 3,
                    Text = "Root/administrator access",
                    IsCorrect = false
                },
                new Answer
                {
                    AnswerId = 14,
                    QuestionId = 4,
                    Text = "AWS Price List Application Programming Interface (API)",
                    IsCorrect = false
                },
                new Answer
                {
                    AnswerId = 15,
                    QuestionId = 4,
                    Text = "Reserved Instances",
                    IsCorrect = false
                },
                new Answer
                {
                    AnswerId = 16,
                    QuestionId = 4,
                    Text = "AWS Trusted Advisor",
                    IsCorrect = true
                },
                new Answer
                {
                    AnswerId = 17,
                    QuestionId = 4,
                    Text = "Amazon Elastic Compute Cloud (Amazon EC2)",
                    IsCorrect = false
                }
            );
        }

        public void AddCertifications()
        {
            modelBuilder.Entity<Certification>().HasData(
           new Certification
           {
               CertificationId = 1,
               Name = "AZ-900",
               Description = "Microsoft Azure Fundamentals"
           },
           new Certification
           {
               CertificationId = 2,
               Name = "SY0-501",
               Description = "CompTIA Security+"
           },
           new Certification
           {
               CertificationId = 3,
               Name = "AWS-CCP",
               Description = "AWS Cloud Practitioner"
           });
        }
    }
}
