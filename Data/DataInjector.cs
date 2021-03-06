﻿using System;
using BlzrQuiz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

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
            di.AddIdentity();
            di.AddCertifications();
            di.AddQuestions();
            di.AddAnswers();
            di.AddExplanations();
            di.AddTags();
            //di.AddQuestionTags();
            di.AddCertificationTags();
        }

        private void AddAnswers()
        {
            modelBuilder.Entity<Answer>().HasData(
                new Answer { AnswerId = 1, QuestionId = 1, Text = "The Only Way To Win Is Not To Play", IsCorrect = false },
                new Answer { AnswerId = 10, QuestionId = 3, Text = "Automated backup", IsCorrect = false },
                new Answer { AnswerId = 11, QuestionId = 3, Text = "Paying only for what you use", IsCorrect = true },
                new Answer { AnswerId = 12, QuestionId = 3, Text = "The ability to choose hardware vendors", IsCorrect = false },
                new Answer { AnswerId = 13, QuestionId = 3, Text = "Root/administrator access", IsCorrect = false },
                new Answer { AnswerId = 14, QuestionId = 4, Text = "AWS Price List Application Programming Interface (API)", IsCorrect = false },
                new Answer { AnswerId = 15, QuestionId = 4, Text = "Reserved Instances", IsCorrect = false },
                new Answer { AnswerId = 16, QuestionId = 4, Text = "AWS Trusted Advisor", IsCorrect = true },
                new Answer { AnswerId = 17, QuestionId = 4, Text = "Amazon Elastic Compute Cloud (Amazon EC2)", IsCorrect = false },
                new Answer { AnswerId = 18, QuestionId = 5, Text = "Amazon CloudFront", IsCorrect = false },
                new Answer { AnswerId = 19, QuestionId = 5, Text = "Amazon CloudSearch", IsCorrect = false },
                new Answer { AnswerId = 20, QuestionId = 5, Text = "Amazon CloudWatch", IsCorrect = true },
                new Answer { AnswerId = 21, QuestionId = 5, Text = "Amazon Machine Learning (Amazon ML)", IsCorrect = false },
                new Answer { AnswerId = 22, QuestionId = 6, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 23, QuestionId = 6, Text = "Amazon EC2 instance usage report", IsCorrect = false },
                new Answer { AnswerId = 24, QuestionId = 6, Text = "Amazon CloudWatch", IsCorrect = false },
                new Answer { AnswerId = 25, QuestionId = 6, Text = "AWS Cloud Trail logs", IsCorrect = true },
                new Answer { AnswerId = 26, QuestionId = 7, Text = "Amazon Route 53", IsCorrect = true },
                new Answer { AnswerId = 27, QuestionId = 7, Text = "Amazon CloudFront", IsCorrect = false },
                new Answer { AnswerId = 28, QuestionId = 7, Text = "Elastic Load Balancing", IsCorrect = false },
                new Answer { AnswerId = 29, QuestionId = 7, Text = "Amazon Virtual Private Cloud (Amazon VPC)", IsCorrect = false },
                new Answer { AnswerId = 30, QuestionId = 8, Text = "Cloud resources can be managed programmatically", IsCorrect = true },
                new Answer { AnswerId = 31, QuestionId = 8, Text = "AWS infrastructure use will always be cost-optimized", IsCorrect = false },
                new Answer { AnswerId = 32, QuestionId = 8, Text = "All application testing is managed by AWS.", IsCorrect = false },
                new Answer { AnswerId = 33, QuestionId = 8, Text = "Customer -owned, on -premises infrastructure becomes programmable.", IsCorrect = false },
                new Answer { AnswerId = 34, QuestionId = 9, Text = "Adding an elastic load balancer in front of a single Amazon Elastic Compute Cloud (Amazon EC2) instance", IsCorrect = false },
                new Answer { AnswerId = 35, QuestionId = 9, Text = "Creating and deploying the most cost-effective solution", IsCorrect = false },
                new Answer { AnswerId = 36, QuestionId = 9, Text = "Deploying an application in multiple Availability Zones", IsCorrect = true },
                new Answer { AnswerId = 37, QuestionId = 9, Text = "Using Amazon CloudWatch alerts to monitor performance", IsCorrect = false },
                new Answer { AnswerId = 38, QuestionId = 10, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 39, QuestionId = 10, Text = "AWS Cloud Trail", IsCorrect = false },
                new Answer { AnswerId = 40, QuestionId = 10, Text = "AWS Key Management Service (AWS KMS)", IsCorrect = false },
                new Answer { AnswerId = 41, QuestionId = 10, Text = "AWS Identity and Access Management (IAM)", IsCorrect = true },
                new Answer { AnswerId = 42, QuestionId = 11, Text = "Amazon Redshift", IsCorrect = true },
                new Answer { AnswerId = 43, QuestionId = 11, Text = "Amazon DynamoDB", IsCorrect = false },
                new Answer { AnswerId = 44, QuestionId = 11, Text = "Amazon ElastiCache", IsCorrect = false },
                new Answer { AnswerId = 45, QuestionId = 11, Text = "Amazon Aurora", IsCorrect = false },
                new Answer { AnswerId = 46, QuestionId = 12, Text = "Managing AWS Identity and Access Management (IAM)", IsCorrect = true },
                new Answer { AnswerId = 47, QuestionId = 12, Text = "Securing edge locations", IsCorrect = false },
                new Answer { AnswerId = 48, QuestionId = 12, Text = "Monitoring physical device security", IsCorrect = false },
                new Answer { AnswerId = 49, QuestionId = 12, Text = "Implementing service organization Control (SOC) standards", IsCorrect = false },
                new Answer { AnswerId = 50, QuestionId = 13, Text = "Amazon EC2 dashboard", IsCorrect = false },
                new Answer { AnswerId = 51, QuestionId = 13, Text = "AWS Cost and Usage reports", IsCorrect = true },
                new Answer { AnswerId = 52, QuestionId = 13, Text = "AWS Trusted Advisor dashboard", IsCorrect = false },
                new Answer { AnswerId = 53, QuestionId = 13, Text = "AWS Cloud Trail logs stored in Amazon Simple Storage Service (Amazon S3)", IsCorrect = false },
                new Answer { AnswerId = 54, QuestionId = 14, Text = "AWS Support Team", IsCorrect = false },
                new Answer { AnswerId = 55, QuestionId = 14, Text = "AWS Account Owner", IsCorrect = true },
                new Answer { AnswerId = 56, QuestionId = 14, Text = "AWS Security Team", IsCorrect = false },
                new Answer { AnswerId = 57, QuestionId = 14, Text = "AWS Technical Account Manager (TAM)", IsCorrect = false },
                new Answer { AnswerId = 58, QuestionId = 15, Text = "Create a tightly integrated application", IsCorrect = false },
                new Answer { AnswerId = 59, QuestionId = 15, Text = "Reduce inter-dependencies so failures do not impact other components", IsCorrect = true },
                new Answer { AnswerId = 60, QuestionId = 15, Text = "Enable data synchronization across the web application layer.", IsCorrect = false },
                new Answer { AnswerId = 61, QuestionId = 15, Text = "Have the ability to execute automated bootstrapping actions.", IsCorrect = false },
                new Answer { AnswerId = 62, QuestionId = 16, Text = "Performance is improved over running in a single Availability Zone.", IsCorrect = false },
                new Answer { AnswerId = 63, QuestionId = 16, Text = "It is more secure than running in a single Availability Zone.", IsCorrect = false },
                new Answer { AnswerId = 64, QuestionId = 16, Text = "It significantly reduces the total cost of ownership versus running in a single Availability Zone.", IsCorrect = false },
                new Answer { AnswerId = 65, QuestionId = 16, Text = "It increases the availability of an application compared to running in a single Availability Zone.", IsCorrect = true },
                new Answer { AnswerId = 66, QuestionId = 17, Text = "Password Policies", IsCorrect = true },
                new Answer { AnswerId = 67, QuestionId = 17, Text = "User permissions", IsCorrect = true },
                new Answer { AnswerId = 68, QuestionId = 17, Text = "Physical security", IsCorrect = false },
                new Answer { AnswerId = 69, QuestionId = 17, Text = "Disk disposal", IsCorrect = false },
                new Answer { AnswerId = 70, QuestionId = 17, Text = "Hardware patching", IsCorrect = false },
                new Answer { AnswerId = 71, QuestionId = 18, Text = "Minimize storage requirements by reducing logging and auditing activities", IsCorrect = false },
                new Answer { AnswerId = 72, QuestionId = 18, Text = "Create systems that scale to the required capacity based on changes in demand", IsCorrect = true },
                new Answer { AnswerId = 73, QuestionId = 18, Text = "Enable AWS to automatically select the most cost-effective services.", IsCorrect = false },
                new Answer { AnswerId = 74, QuestionId = 18, Text = "Accelerate the design process because recovery from failure is automated, reducing the need for testing", IsCorrect = false },
                new Answer { AnswerId = 75, QuestionId = 19, Text = "Workloads that are only run in the morning and stopped at night", IsCorrect = false },
                new Answer { AnswerId = 76, QuestionId = 19, Text = "Workloads where the availability of the Amazon EC2 instances can be flexible", IsCorrect = true },
                new Answer { AnswerId = 77, QuestionId = 19, Text = "Workloads that need to run for long periods of time without interruption", IsCorrect = false },
                new Answer { AnswerId = 78, QuestionId = 19, Text = "Workloads that are critical and need Amazon EC2 instances with termination protection", IsCorrect = false },
                new Answer { AnswerId = 79, QuestionId = 20, Text = "AWS Management Console", IsCorrect = true },
                new Answer { AnswerId = 80, QuestionId = 20, Text = "AWS Application Programming Interface (API)", IsCorrect = false },
                new Answer { AnswerId = 81, QuestionId = 20, Text = "AWS Software Development Kit (SDK)", IsCorrect = false },
                new Answer { AnswerId = 82, QuestionId = 20, Text = "Amazon CloudWatch", IsCorrect = false },
                new Answer { AnswerId = 83, QuestionId = 21, Text = "AWS organizations", IsCorrect = false },
                new Answer { AnswerId = 84, QuestionId = 21, Text = "Amazon Dev Pay", IsCorrect = false },
                new Answer { AnswerId = 85, QuestionId = 21, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 86, QuestionId = 21, Text = "AWS Cost Explorer", IsCorrect = true },
                new Answer { AnswerId = 87, QuestionId = 22, Text = "Apply Multi-Factor Authentication (MFA)", IsCorrect = true },
                new Answer { AnswerId = 88, QuestionId = 22, Text = "Set up a secondary password", IsCorrect = false },
                new Answer { AnswerId = 89, QuestionId = 22, Text = "Request root access privileges", IsCorrect = false },
                new Answer { AnswerId = 90, QuestionId = 22, Text = "Disable AWS console access", IsCorrect = false },
                new Answer { AnswerId = 91, QuestionId = 23, Text = "AWS Identity and Access Management (IAM)", IsCorrect = true },
                new Answer { AnswerId = 92, QuestionId = 23, Text = "Amazon Elastic Compute Cloud (Amazon EC2)", IsCorrect = false },
                new Answer { AnswerId = 93, QuestionId = 23, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 94, QuestionId = 23, Text = "Amazon Inspector", IsCorrect = false },
                new Answer { AnswerId = 95, QuestionId = 24, Text = "Subnet", IsCorrect = false },
                new Answer { AnswerId = 96, QuestionId = 24, Text = "AWS Region", IsCorrect = true },
                new Answer { AnswerId = 97, QuestionId = 24, Text = "AWS edge location", IsCorrect = false },
                new Answer { AnswerId = 98, QuestionId = 24, Text = "Amazon Virtual Private Cloud (Amazon VPC)", IsCorrect = false },
                new Answer { AnswerId = 99, QuestionId = 25, Text = "The number of servers migrated to AWS", IsCorrect = true },
                new Answer { AnswerId = 100, QuestionId = 25, Text = "The number of users migrated to AWS", IsCorrect = false },
                new Answer { AnswerId = 101, QuestionId = 25, Text = "The number of passwords migrated to AWS", IsCorrect = false },
                new Answer { AnswerId = 102, QuestionId = 25, Text = "The number of keys migrated to AWS", IsCorrect = false },
                new Answer { AnswerId = 103, QuestionId = 26, Text = "Amazon SES", IsCorrect = false },
                new Answer { AnswerId = 104, QuestionId = 26, Text = "Amazon CloudTrail", IsCorrect = false },
                new Answer { AnswerId = 105, QuestionId = 26, Text = "Amazon CloudFront", IsCorrect = true },
                new Answer { AnswerId = 106, QuestionId = 26, Text = "Amazon S3", IsCorrect = false },
                new Answer { AnswerId = 107, QuestionId = 27, Text = "AWS RDS", IsCorrect = false },
                new Answer { AnswerId = 108, QuestionId = 27, Text = "AWS DynamoDB", IsCorrect = true },
                new Answer { AnswerId = 109, QuestionId = 27, Text = "AWS Redshift", IsCorrect = false },
                new Answer { AnswerId = 110, QuestionId = 27, Text = "AWS MongoDB", IsCorrect = false },
                new Answer { AnswerId = 111, QuestionId = 28, Text = "Amazon Storage Gateway", IsCorrect = false },
                new Answer { AnswerId = 112, QuestionId = 28, Text = "Amazon Glacier", IsCorrect = true },
                new Answer { AnswerId = 113, QuestionId = 28, Text = "Amazon EBS", IsCorrect = false },
                new Answer { AnswerId = 114, QuestionId = 28, Text = "Amazon S3", IsCorrect = false },
                new Answer { AnswerId = 115, QuestionId = 29, Text = "Reserved instances", IsCorrect = true },
                new Answer { AnswerId = 116, QuestionId = 29, Text = "On-demand instances", IsCorrect = false },
                new Answer { AnswerId = 117, QuestionId = 29, Text = "Spot instances", IsCorrect = false },
                new Answer { AnswerId = 118, QuestionId = 29, Text = "Regular instances", IsCorrect = false },
                new Answer { AnswerId = 119, QuestionId = 30, Text = "File Transfer", IsCorrect = false },
                new Answer { AnswerId = 120, QuestionId = 30, Text = "HTTP Transfer", IsCorrect = false },
                new Answer { AnswerId = 121, QuestionId = 30, Text = "Transfer Acceleration", IsCorrect = true },
                new Answer { AnswerId = 122, QuestionId = 30, Text = "S3 Acceleration", IsCorrect = false },
                new Answer { AnswerId = 123, QuestionId = 31, Text = "May be performed by AWS, and will be performed by AWS upon customer request.", IsCorrect = false },
                new Answer { AnswerId = 124, QuestionId = 31, Text = "May be performed by AWS, and is periodically performed by AWS.", IsCorrect = false },
                new Answer { AnswerId = 125, QuestionId = 31, Text = "Are expressly prohibited under all circumstances.", IsCorrect = false },
                new Answer { AnswerId = 126, QuestionId = 31, Text = "May be performed by the customer on their own instances with prior authorization from AWS.", IsCorrect = true },
                new Answer { AnswerId = 127, QuestionId = 31, Text = "May be performed by the customer on their own instances, only if performed from EC2 instances.", IsCorrect = false },
                new Answer { AnswerId = 128, QuestionId = 32, Text = "Security, fault tolerance, high availability, and connectivity", IsCorrect = false },
                new Answer { AnswerId = 129, QuestionId = 32, Text = "Security, access control, high availability, and performance", IsCorrect = false },
                new Answer { AnswerId = 130, QuestionId = 32, Text = "Performance, cost optimization, security, and fault tolerance", IsCorrect = true },
                new Answer { AnswerId = 131, QuestionId = 32, Text = "Performance, cost optimization, access control, and connectivity", IsCorrect = false },
                new Answer { AnswerId = 132, QuestionId = 33, Text = "Amazon EBS volume", IsCorrect = false },
                new Answer { AnswerId = 133, QuestionId = 33, Text = "Amazon S3", IsCorrect = true },
                new Answer { AnswerId = 134, QuestionId = 33, Text = "Amazon EC2 instance store", IsCorrect = false },
                new Answer { AnswerId = 135, QuestionId = 33, Text = "Amazon RDS instance", IsCorrect = false },
                new Answer { AnswerId = 136, QuestionId = 34, Text = "All users should have the same baseline permissions granted to them to use basic AWS services.", IsCorrect = false },
                new Answer { AnswerId = 137, QuestionId = 34, Text = "Users should be granted permission to access only resources they need to do their assigned job.", IsCorrect = true },
                new Answer { AnswerId = 138, QuestionId = 34, Text = "Users should submit all access request in written so that there is a paper trail of who needs access to different AWS resources.", IsCorrect = false },
                new Answer { AnswerId = 139, QuestionId = 34, Text = "Users should always have a little more access granted to them then they need, just in case they end up needed it in the future.", IsCorrect = false },
                new Answer { AnswerId = 140, QuestionId = 35, Text = "AWS IAM", IsCorrect = false },
                new Answer { AnswerId = 141, QuestionId = 35, Text = "AWS Server", IsCorrect = false },
                new Answer { AnswerId = 142, QuestionId = 35, Text = "AWS EC2", IsCorrect = true },
                new Answer { AnswerId = 143, QuestionId = 35, Text = "AWS Regions", IsCorrect = false },
                new Answer { AnswerId = 144, QuestionId = 36, Text = "Usage of Security Groups", IsCorrect = true },
                new Answer { AnswerId = 145, QuestionId = 36, Text = "Usage of AMIs", IsCorrect = false },
                new Answer { AnswerId = 146, QuestionId = 36, Text = "Usage of Network Access Control Lists", IsCorrect = true },
                new Answer { AnswerId = 147, QuestionId = 36, Text = "Usage of the Internet gateway", IsCorrect = false },
                new Answer { AnswerId = 148, QuestionId = 37, Text = "EBS Volumes", IsCorrect = false },
                new Answer { AnswerId = 149, QuestionId = 37, Text = "EBS Snapshots", IsCorrect = false },
                new Answer { AnswerId = 150, QuestionId = 37, Text = "Amazon Machine Images", IsCorrect = true },
                new Answer { AnswerId = 151, QuestionId = 37, Text = "EC2 Copies", IsCorrect = false },
                new Answer { AnswerId = 152, QuestionId = 38, Text = "Choose AWS services which are PCI Compliant", IsCorrect = true },
                new Answer { AnswerId = 153, QuestionId = 38, Text = "Ensure the right steps are taken during application development for PCI Compliance", IsCorrect = true },
                new Answer { AnswerId = 154, QuestionId = 38, Text = "Ensure the AWS Services are made PCI Compliant", IsCorrect = false },
                new Answer { AnswerId = 155, QuestionId = 38, Text = "Do an audit after the deployment of the application for PCI Compliance", IsCorrect = false },
                new Answer { AnswerId = 156, QuestionId = 39, Text = "AWS Glacier API", IsCorrect = true },
                new Answer { AnswerId = 157, QuestionId = 39, Text = "AWS Console", IsCorrect = false },
                new Answer { AnswerId = 158, QuestionId = 39, Text = "AWS Glacier SDK", IsCorrect = true },
                new Answer { AnswerId = 159, QuestionId = 39, Text = "AWS S3 Lifecycle policies", IsCorrect = true },
                new Answer { AnswerId = 160, QuestionId = 40, Text = "Basic", IsCorrect = false },
                new Answer { AnswerId = 161, QuestionId = 40, Text = "Developer", IsCorrect = false },
                new Answer { AnswerId = 162, QuestionId = 40, Text = "Business", IsCorrect = false },
                new Answer { AnswerId = 163, QuestionId = 40, Text = "Enterprise", IsCorrect = true },
                new Answer { AnswerId = 164, QuestionId = 41, Text = "Basic", IsCorrect = false },
                new Answer { AnswerId = 165, QuestionId = 41, Text = "Developer", IsCorrect = false },
                new Answer { AnswerId = 166, QuestionId = 41, Text = "Business", IsCorrect = false },
                new Answer { AnswerId = 167, QuestionId = 41, Text = "Enterprise", IsCorrect = true },
                new Answer { AnswerId = 168, QuestionId = 42, Text = "Distribute content to users", IsCorrect = false },
                new Answer { AnswerId = 169, QuestionId = 42, Text = "Cache common responses", IsCorrect = false },
                new Answer { AnswerId = 170, QuestionId = 42, Text = "Distribute load across multiple resources", IsCorrect = true },
                new Answer { AnswerId = 171, QuestionId = 42, Text = "Used in conjunction with the CloudFront service", IsCorrect = false },
                new Answer { AnswerId = 172, QuestionId = 43, Text = "Amazon S3", IsCorrect = true },
                new Answer { AnswerId = 173, QuestionId = 43, Text = "Amazon Glacier", IsCorrect = false },
                new Answer { AnswerId = 174, QuestionId = 43, Text = "Amazon Storage Gateway", IsCorrect = false },
                new Answer { AnswerId = 175, QuestionId = 43, Text = "Amazon EBS", IsCorrect = false },
                new Answer { AnswerId = 176, QuestionId = 44, Text = "Spot Instances", IsCorrect = false },
                new Answer { AnswerId = 177, QuestionId = 44, Text = "On-Demand", IsCorrect = false },
                new Answer { AnswerId = 178, QuestionId = 44, Text = "No Upfront costs Reserved", IsCorrect = false },
                new Answer { AnswerId = 179, QuestionId = 44, Text = "Partial Upfront costs Reserved", IsCorrect = true },
                new Answer { AnswerId = 180, QuestionId = 45, Text = "Spot Instances", IsCorrect = false },
                new Answer { AnswerId = 181, QuestionId = 45, Text = "On-Demand", IsCorrect = true },
                new Answer { AnswerId = 182, QuestionId = 45, Text = "No Upfront costs Reserved", IsCorrect = false },
                new Answer { AnswerId = 183, QuestionId = 45, Text = "Partial Upfront costs Reserved", IsCorrect = false },
                new Answer { AnswerId = 184, QuestionId = 46, Text = "Giving a name and description for the security group", IsCorrect = true },
                new Answer { AnswerId = 185, QuestionId = 46, Text = "Defining the rules as per the customer requirements", IsCorrect = true },
                new Answer { AnswerId = 186, QuestionId = 46, Text = "Ensure the rules are applied immediately", IsCorrect = false },
                new Answer { AnswerId = 187, QuestionId = 46, Text = "Ensure the security groups are linked to the Elastic Network interface", IsCorrect = false },
                new Answer { AnswerId = 188, QuestionId = 47, Text = "Having complete control over the physical infrastructure", IsCorrect = false },
                new Answer { AnswerId = 189, QuestionId = 47, Text = "Having the pay as you go model", IsCorrect = true },
                new Answer { AnswerId = 190, QuestionId = 47, Text = "No Upfront costs", IsCorrect = true },
                new Answer { AnswerId = 191, QuestionId = 47, Text = "Having no need to worry about security", IsCorrect = false },
                new Answer { AnswerId = 192, QuestionId = 48, Text = "AWS CloudWatch", IsCorrect = false },
                new Answer { AnswerId = 193, QuestionId = 48, Text = "AWS CloudTrail", IsCorrect = true },
                new Answer { AnswerId = 194, QuestionId = 48, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 195, QuestionId = 48, Text = "AWS SNS", IsCorrect = false },
                new Answer { AnswerId = 196, QuestionId = 49, Text = "Cross region replication", IsCorrect = false },
                new Answer { AnswerId = 197, QuestionId = 49, Text = "Creating Read Replicis", IsCorrect = true },
                new Answer { AnswerId = 198, QuestionId = 49, Text = "Using snapshots", IsCorrect = false },
                new Answer { AnswerId = 199, QuestionId = 49, Text = "Using Multi-AZ feature", IsCorrect = false },
                new Answer { AnswerId = 200, QuestionId = 50, Text = "In another Availability Zone", IsCorrect = false },
                new Answer { AnswerId = 201, QuestionId = 50, Text = "In another data center", IsCorrect = false },
                new Answer { AnswerId = 202, QuestionId = 50, Text = "In another Region", IsCorrect = true },
                new Answer { AnswerId = 203, QuestionId = 50, Text = "In another Edge location", IsCorrect = false },
                new Answer { AnswerId = 204, QuestionId = 51, Text = "Using the AWS DynamoDB service", IsCorrect = false },
                new Answer { AnswerId = 205, QuestionId = 51, Text = "Using the AWS RDS service", IsCorrect = false },
                new Answer { AnswerId = 206, QuestionId = 51, Text = "Hosting a database on an EC2 Instance", IsCorrect = true },
                new Answer { AnswerId = 207, QuestionId = 51, Text = "Using the Amazon Aurora service", IsCorrect = false },
                new Answer { AnswerId = 208, QuestionId = 52, Text = "Aurora", IsCorrect = true },
                new Answer { AnswerId = 209, QuestionId = 52, Text = "DynamoDB", IsCorrect = false },
                new Answer { AnswerId = 210, QuestionId = 52, Text = "RDS Microsoft SQL Server", IsCorrect = false },
                new Answer { AnswerId = 211, QuestionId = 52, Text = "RDS MySQL", IsCorrect = false },
                new Answer { AnswerId = 212, QuestionId = 53, Text = "Diverting traffic to instances based on the demand", IsCorrect = true },
                new Answer { AnswerId = 213, QuestionId = 53, Text = "Diverting traffic to instances with the least load", IsCorrect = true },
                new Answer { AnswerId = 214, QuestionId = 53, Text = "Diverting traffic across multiple regions", IsCorrect = false },
                new Answer { AnswerId = 215, QuestionId = 53, Text = "Diverting traffic to instances with higher capacity", IsCorrect = false },
                new Answer { AnswerId = 216, QuestionId = 54, Text = "To distribute traffic to multiple EC2 Instances", IsCorrect = true },
                new Answer { AnswerId = 217, QuestionId = 54, Text = "To scale up EC2 Instances", IsCorrect = false },
                new Answer { AnswerId = 218, QuestionId = 54, Text = "To distribute traffic to AWS resources across multiple regions", IsCorrect = false },
                new Answer { AnswerId = 219, QuestionId = 54, Text = "To increase the size of the EC2 Instance based on demand", IsCorrect = false },
                new Answer { AnswerId = 220, QuestionId = 55, Text = "To scale up resources based on demand", IsCorrect = true },
                new Answer { AnswerId = 221, QuestionId = 55, Text = "To distribute traffic to multiple EC2 Instances", IsCorrect = false },
                new Answer { AnswerId = 222, QuestionId = 55, Text = "To distribute traffic to AWS resources across multiple regions", IsCorrect = false },
                new Answer { AnswerId = 223, QuestionId = 55, Text = "To increase the size of the EC2 Instance based on demand", IsCorrect = false },
                new Answer { AnswerId = 224, QuestionId = 57, Text = "Deleting the data when the device is destroyed", IsCorrect = false },
                new Answer { AnswerId = 225, QuestionId = 57, Text = "Creating EBS snapshots", IsCorrect = true },
                new Answer { AnswerId = 226, QuestionId = 57, Text = "Attaching volumes to EC2 Instances", IsCorrect = false },
                new Answer { AnswerId = 227, QuestionId = 57, Text = "Creating copies of EBS Volumes", IsCorrect = false },
                new Answer { AnswerId = 228, QuestionId = 58, Text = "AWS SDK", IsCorrect = true },
                new Answer { AnswerId = 229, QuestionId = 58, Text = "AWS Console", IsCorrect = false },
                new Answer { AnswerId = 230, QuestionId = 58, Text = "AWS CLI", IsCorrect = false },
                new Answer { AnswerId = 231, QuestionId = 58, Text = "AWS IAM", IsCorrect = false },
                new Answer { AnswerId = 232, QuestionId = 59, Text = "IAM Users", IsCorrect = false },
                new Answer { AnswerId = 233, QuestionId = 59, Text = "IAM Roles", IsCorrect = true },
                new Answer { AnswerId = 234, QuestionId = 59, Text = "IAM Groups", IsCorrect = false },
                new Answer { AnswerId = 235, QuestionId = 59, Text = "IAM policies", IsCorrect = false },
                new Answer { AnswerId = 236, QuestionId = 60, Text = "Consolidating billing", IsCorrect = true },
                new Answer { AnswerId = 237, QuestionId = 60, Text = "AWS Organizations", IsCorrect = true },
                new Answer { AnswerId = 238, QuestionId = 60, Text = "Cost Explorer", IsCorrect = false },
                new Answer { AnswerId = 239, QuestionId = 60, Text = "IAM", IsCorrect = false },
                new Answer { AnswerId = 240, QuestionId = 61, Text = "CloudFront", IsCorrect = true },
                new Answer { AnswerId = 241, QuestionId = 61, Text = "AWS Shield", IsCorrect = true },
                new Answer { AnswerId = 242, QuestionId = 61, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 243, QuestionId = 61, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 244, QuestionId = 62, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 245, QuestionId = 62, Text = "AWS WAF", IsCorrect = true },
                new Answer { AnswerId = 246, QuestionId = 62, Text = "AWS Firewall", IsCorrect = false },
                new Answer { AnswerId = 247, QuestionId = 62, Text = "AWS Protection", IsCorrect = false },
                new Answer { AnswerId = 248, QuestionId = 63, Text = "Using Password Policies", IsCorrect = false },
                new Answer { AnswerId = 249, QuestionId = 63, Text = "Using a mix of user names", IsCorrect = false },
                new Answer { AnswerId = 250, QuestionId = 63, Text = "Using AWS WAF", IsCorrect = false },
                new Answer { AnswerId = 251, QuestionId = 63, Text = "Using MFA", IsCorrect = true },
                new Answer { AnswerId = 252, QuestionId = 64, Text = "Pilot light", IsCorrect = false },
                new Answer { AnswerId = 253, QuestionId = 64, Text = "Backup Restore", IsCorrect = false },
                new Answer { AnswerId = 254, QuestionId = 64, Text = "Devops", IsCorrect = false },
                new Answer { AnswerId = 255, QuestionId = 65, Text = "Amazon EBS", IsCorrect = false },
                new Answer { AnswerId = 256, QuestionId = 65, Text = "Amazon Storage gateway", IsCorrect = false },
                new Answer { AnswerId = 257, QuestionId = 65, Text = "Amazon S3", IsCorrect = true },
                new Answer { AnswerId = 258, QuestionId = 65, Text = "Amazon SQS", IsCorrect = false },
                new Answer { AnswerId = 259, QuestionId = 66, Text = "Amazon Glacier", IsCorrect = false },
                new Answer { AnswerId = 260, QuestionId = 66, Text = "Amazon EBS Volumes", IsCorrect = true },
                new Answer { AnswerId = 261, QuestionId = 66, Text = "Amazon EBS Snapshots", IsCorrect = false },
                new Answer { AnswerId = 262, QuestionId = 66, Text = "Amazon SQS", IsCorrect = false },
                new Answer { AnswerId = 263, QuestionId = 67, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 264, QuestionId = 67, Text = "AWS VPC", IsCorrect = true },
                new Answer { AnswerId = 265, QuestionId = 67, Text = "AWS Elastic Load Balancer", IsCorrect = false },
                new Answer { AnswerId = 266, QuestionId = 67, Text = "AWS Auto Scaling", IsCorrect = false },
                new Answer { AnswerId = 267, QuestionId = 68, Text = "AWS EBS Volumes", IsCorrect = false },
                new Answer { AnswerId = 268, QuestionId = 68, Text = "AWS EBS Snapshots", IsCorrect = false },
                new Answer { AnswerId = 269, QuestionId = 68, Text = "AWS Glacier", IsCorrect = false },
                new Answer { AnswerId = 270, QuestionId = 68, Text = "AWS SQS", IsCorrect = true },
                new Answer { AnswerId = 271, QuestionId = 69, Text = "Amazon VPC", IsCorrect = false },
                new Answer { AnswerId = 272, QuestionId = 69, Text = "Amazon Regions", IsCorrect = false },
                new Answer { AnswerId = 273, QuestionId = 69, Text = "Amazon Availability Zones", IsCorrect = false },
                new Answer { AnswerId = 274, QuestionId = 69, Text = "Amazon Edge locations", IsCorrect = true },
                new Answer { AnswerId = 275, QuestionId = 70, Text = "Having the ability of automated backups of the EC2 instance, so that you don't need to worry about the maintenance costs.", IsCorrect = false },
                new Answer { AnswerId = 276, QuestionId = 70, Text = "The ability to choose low cost AMrs to prepare the EC2 Instances", IsCorrect = false },
                new Answer { AnswerId = 277, QuestionId = 70, Text = "The ability to only pay for what you use", IsCorrect = true },
                new Answer { AnswerId = 278, QuestionId = 70, Text = "Ability to tag instances to reduce the overall cost", IsCorrect = false },
                new Answer { AnswerId = 279, QuestionId = 71, Text = "AWS InspectorB. AWS Trusted Advisor", IsCorrect = true },
                new Answer { AnswerId = 280, QuestionId = 71, Text = "AWS Support", IsCorrect = false },
                new Answer { AnswerId = 281, QuestionId = 71, Text = "AWS Kinesis", IsCorrect = false },
                new Answer { AnswerId = 282, QuestionId = 72, Text = "Amazon CloudFront", IsCorrect = false },
                new Answer { AnswerId = 283, QuestionId = 72, Text = "Amazon CloudSearch", IsCorrect = false },
                new Answer { AnswerId = 284, QuestionId = 72, Text = "Amazon CloudWatch", IsCorrect = true },
                new Answer { AnswerId = 285, QuestionId = 72, Text = "Amazon Config", IsCorrect = false },
                new Answer { AnswerId = 286, QuestionId = 73, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 287, QuestionId = 73, Text = "Amazon EC2 instance usage report", IsCorrect = false },
                new Answer { AnswerId = 288, QuestionId = 73, Text = "Amazon CloudWatch", IsCorrect = false },
                new Answer { AnswerId = 289, QuestionId = 73, Text = "AWS Cloud Trail logs", IsCorrect = true },
                new Answer { AnswerId = 290, QuestionId = 74, Text = "Amazon Route 53", IsCorrect = true },
                new Answer { AnswerId = 291, QuestionId = 74, Text = "Amazon SNS", IsCorrect = false },
                new Answer { AnswerId = 292, QuestionId = 74, Text = "Amazon SQS", IsCorrect = false },
                new Answer { AnswerId = 293, QuestionId = 74, Text = "Amazon Inspector", IsCorrect = false },
                new Answer { AnswerId = 294, QuestionId = 75, Text = "AWS Powershell", IsCorrect = false },
                new Answer { AnswerId = 295, QuestionId = 75, Text = "AWS Bash", IsCorrect = false },
                new Answer { AnswerId = 296, QuestionId = 75, Text = "AWS CLI", IsCorrect = true },
                new Answer { AnswerId = 297, QuestionId = 75, Text = "AWS Console", IsCorrect = false },
                new Answer { AnswerId = 298, QuestionId = 76, Text = "Availability Zones", IsCorrect = true },
                new Answer { AnswerId = 299, QuestionId = 76, Text = "Regions", IsCorrect = true },
                new Answer { AnswerId = 300, QuestionId = 76, Text = "Elastic Load Balancer", IsCorrect = true },
                new Answer { AnswerId = 301, QuestionId = 76, Text = "Pay as you go", IsCorrect = false },
                new Answer { AnswerId = 302, QuestionId = 77, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 303, QuestionId = 77, Text = "AWS Cloud Trail", IsCorrect = false },
                new Answer { AnswerId = 304, QuestionId = 77, Text = "AWS Key Management Service (AWS KMS)", IsCorrect = false },
                new Answer { AnswerId = 305, QuestionId = 77, Text = "AWS Identity and Access Management (IAM)", IsCorrect = true },
                new Answer { AnswerId = 306, QuestionId = 78, Text = "Using AWS Cloudformation", IsCorrect = true },
                new Answer { AnswerId = 307, QuestionId = 78, Text = "Using AWS Config", IsCorrect = false },
                new Answer { AnswerId = 308, QuestionId = 78, Text = "Using AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 309, QuestionId = 78, Text = "Using AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 310, QuestionId = 79, Text = "Amazon Redshift", IsCorrect = true },
                new Answer { AnswerId = 311, QuestionId = 79, Text = "Amazon DynamoDB", IsCorrect = false },
                new Answer { AnswerId = 312, QuestionId = 79, Text = "Amazon ElastiCache", IsCorrect = false },
                new Answer { AnswerId = 313, QuestionId = 79, Text = "Amazon Aurora", IsCorrect = false },
                new Answer { AnswerId = 314, QuestionId = 80, Text = "Managing AWS Identity and Access Management (IAM)", IsCorrect = false },
                new Answer { AnswerId = 315, QuestionId = 80, Text = "Securing edge locations", IsCorrect = true },
                new Answer { AnswerId = 316, QuestionId = 80, Text = "Monitoring physical device security", IsCorrect = true },
                new Answer { AnswerId = 317, QuestionId = 80, Text = "Implementing service organization Control (SOC)", IsCorrect = true },
                new Answer { AnswerId = 318, QuestionId = 81, Text = "By going to the Amazon EC2 dashboard. Here you can see the costs of the running EC2 resources.", IsCorrect = false },
                new Answer { AnswerId = 319, QuestionId = 81, Text = "By using the AWS Cost and Usage reports Explorer. Here you can see the running and forecast costs.", IsCorrect = true },
                new Answer { AnswerId = 320, QuestionId = 81, Text = "By using the AWS Trusted Advisor dashboard. This dashboard will give you all the costs.", IsCorrect = false },
                new Answer { AnswerId = 321, QuestionId = 81, Text = "By seeing the AWS Cloud Trail logs.", IsCorrect = false },
                new Answer { AnswerId = 322, QuestionId = 82, Text = "AWS Support Team", IsCorrect = false },
                new Answer { AnswerId = 323, QuestionId = 82, Text = "AWS Account Owner", IsCorrect = true },
                new Answer { AnswerId = 324, QuestionId = 82, Text = "AWS Security Team", IsCorrect = false },
                new Answer { AnswerId = 325, QuestionId = 82, Text = "AWS Technical Account Manager (TAM)", IsCorrect = false },
                new Answer { AnswerId = 326, QuestionId = 83, Text = "Integration", IsCorrect = false },
                new Answer { AnswerId = 327, QuestionId = 83, Text = "Decoupling", IsCorrect = true },
                new Answer { AnswerId = 328, QuestionId = 83, Text = "Aggregation", IsCorrect = false },
                new Answer { AnswerId = 329, QuestionId = 83, Text = "Segregation", IsCorrect = false },
                new Answer { AnswerId = 330, QuestionId = 84, Text = "Deploying resources across multiple edge locations", IsCorrect = false },
                new Answer { AnswerId = 331, QuestionId = 84, Text = "Deploying resources across multiple VPC'S", IsCorrect = false },
                new Answer { AnswerId = 332, QuestionId = 84, Text = "Deploying resources across multiple Availability Zones", IsCorrect = true },
                new Answer { AnswerId = 333, QuestionId = 84, Text = "Deploying resources across multiple AWS Accounts", IsCorrect = false },
                new Answer { AnswerId = 334, QuestionId = 85, Text = "Password Policies", IsCorrect = false },
                new Answer { AnswerId = 335, QuestionId = 85, Text = "User permissions", IsCorrect = false },
                new Answer { AnswerId = 336, QuestionId = 85, Text = "Physical security", IsCorrect = true },
                new Answer { AnswerId = 337, QuestionId = 85, Text = "Disk disposal", IsCorrect = true },
                new Answer { AnswerId = 338, QuestionId = 85, Text = "Hardware patching", IsCorrect = true },
                new Answer { AnswerId = 339, QuestionId = 86, Text = "Disaster Recovery", IsCorrect = false },
                new Answer { AnswerId = 340, QuestionId = 86, Text = "Elasticity", IsCorrect = true },
                new Answer { AnswerId = 341, QuestionId = 86, Text = "Decoupling", IsCorrect = false },
                new Answer { AnswerId = 342, QuestionId = 86, Text = "Aggregation", IsCorrect = false },
                new Answer { AnswerId = 343, QuestionId = 87, Text = "On-Demand", IsCorrect = false },
                new Answer { AnswerId = 344, QuestionId = 87, Text = "Spot", IsCorrect = true },
                new Answer { AnswerId = 345, QuestionId = 87, Text = "Full Upfront Reserved", IsCorrect = false },
                new Answer { AnswerId = 346, QuestionId = 87, Text = "Partial Upfront Reserved", IsCorrect = false },
                new Answer { AnswerId = 347, QuestionId = 88, Text = "AWS Management Console", IsCorrect = true },
                new Answer { AnswerId = 348, QuestionId = 88, Text = "AWS Application Programming Interface (API)", IsCorrect = false },
                new Answer { AnswerId = 349, QuestionId = 88, Text = "AWS Software Development Kit (SDK)", IsCorrect = false },
                new Answer { AnswerId = 350, QuestionId = 88, Text = "AWS CLI", IsCorrect = false },
                new Answer { AnswerId = 351, QuestionId = 89, Text = "AWS organizations", IsCorrect = true },
                new Answer { AnswerId = 352, QuestionId = 89, Text = "Amazon Dev Pay", IsCorrect = false },
                new Answer { AnswerId = 353, QuestionId = 89, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 354, QuestionId = 89, Text = "AWS Cost Explorer", IsCorrect = false },
                new Answer { AnswerId = 355, QuestionId = 90, Text = "Multi-Factor Authentication (MFA)", IsCorrect = true },
                new Answer { AnswerId = 356, QuestionId = 90, Text = "Secondary password", IsCorrect = false },
                new Answer { AnswerId = 357, QuestionId = 90, Text = "Root access privileges", IsCorrect = false },
                new Answer { AnswerId = 358, QuestionId = 90, Text = "Secondarv user name", IsCorrect = false },
                new Answer { AnswerId = 359, QuestionId = 91, Text = "AWS Elastic Beanstalk", IsCorrect = true },
                new Answer { AnswerId = 360, QuestionId = 91, Text = "AWS Elastic Compute Cloud (Amazon EC2)", IsCorrect = false },
                new Answer { AnswerId = 361, QuestionId = 91, Text = "AWS VPC", IsCorrect = false },
                new Answer { AnswerId = 362, QuestionId = 91, Text = "AWS SQS", IsCorrect = false },
                new Answer { AnswerId = 363, QuestionId = 92, Text = "Deploying the application across multiple VPC'S", IsCorrect = false },
                new Answer { AnswerId = 364, QuestionId = 92, Text = "Deploying the application across multiple Regions", IsCorrect = true },
                new Answer { AnswerId = 365, QuestionId = 92, Text = "Deploying the application across Edge locations", IsCorrect = false },
                new Answer { AnswerId = 366, QuestionId = 92, Text = "Deploying the application across multiple subnets", IsCorrect = false },
                new Answer { AnswerId = 367, QuestionId = 93, Text = "They decommission older hardware", IsCorrect = false },
                new Answer { AnswerId = 368, QuestionId = 93, Text = "They continually reduce the cost of cloud computing", IsCorrect = true },
                new Answer { AnswerId = 369, QuestionId = 93, Text = "They use better security mechanisms so you don't need to think about security at all", IsCorrect = false },
                new Answer { AnswerId = 370, QuestionId = 93, Text = "They allow deployment of multiple resources", IsCorrect = false },
                new Answer { AnswerId = 371, QuestionId = 94, Text = "Amazon SES", IsCorrect = false },
                new Answer { AnswerId = 372, QuestionId = 94, Text = "Amazon CloudTrail", IsCorrect = false },
                new Answer { AnswerId = 373, QuestionId = 94, Text = "Amazon CloudFront", IsCorrect = true },
                new Answer { AnswerId = 374, QuestionId = 94, Text = "Amazon S3", IsCorrect = false },
                new Answer { AnswerId = 375, QuestionId = 95, Text = "AWS DynamoDB", IsCorrect = true },
                new Answer { AnswerId = 376, QuestionId = 95, Text = "AWS RDS", IsCorrect = false },
                new Answer { AnswerId = 377, QuestionId = 95, Text = "AWS Redshift", IsCorrect = false },
                new Answer { AnswerId = 378, QuestionId = 95, Text = "AWS MongoDB", IsCorrect = false },
                new Answer { AnswerId = 379, QuestionId = 96, Text = "Amazon Storage Gateway", IsCorrect = false },
                new Answer { AnswerId = 380, QuestionId = 96, Text = "Amazon Glacier", IsCorrect = true },
                new Answer { AnswerId = 381, QuestionId = 96, Text = "Amazon EBS", IsCorrect = false },
                new Answer { AnswerId = 382, QuestionId = 96, Text = "Amazon S3", IsCorrect = false },
                new Answer { AnswerId = 383, QuestionId = 97, Text = "Reserved instances", IsCorrect = true },
                new Answer { AnswerId = 384, QuestionId = 97, Text = "On-demand instances", IsCorrect = false },
                new Answer { AnswerId = 385, QuestionId = 97, Text = "Spot instances", IsCorrect = false },
                new Answer { AnswerId = 386, QuestionId = 97, Text = "Regular instances", IsCorrect = false },
                new Answer { AnswerId = 387, QuestionId = 98, Text = "AWS VPC", IsCorrect = false },
                new Answer { AnswerId = 388, QuestionId = 98, Text = "AWS VPN", IsCorrect = false },
                new Answer { AnswerId = 389, QuestionId = 98, Text = "AWS Direct Connect", IsCorrect = true },
                new Answer { AnswerId = 390, QuestionId = 98, Text = "AWS Subnets", IsCorrect = false },
                new Answer { AnswerId = 391, QuestionId = 99, Text = "Security", IsCorrect = false },
                new Answer { AnswerId = 392, QuestionId = 99, Text = "High Availability", IsCorrect = true },
                new Answer { AnswerId = 393, QuestionId = 99, Text = "Cost Optimization", IsCorrect = false },
                new Answer { AnswerId = 394, QuestionId = 99, Text = "Performance", IsCorrect = false },
                new Answer { AnswerId = 395, QuestionId = 99, Text = "Fault tolerance", IsCorrect = false },
                new Answer { AnswerId = 396, QuestionId = 100, Text = "Amazon EBS volume", IsCorrect = false },
                new Answer { AnswerId = 397, QuestionId = 100, Text = "Amazon S3", IsCorrect = true },
                new Answer { AnswerId = 398, QuestionId = 100, Text = "Amazon EC2 instance store", IsCorrect = false },
                new Answer { AnswerId = 399, QuestionId = 100, Text = "Amazon RDS instance", IsCorrect = false },
                new Answer { AnswerId = 400, QuestionId = 101, Text = "Principle of least privilege", IsCorrect = true },
                new Answer { AnswerId = 401, QuestionId = 101, Text = "Principle of greatest privilege", IsCorrect = false },
                new Answer { AnswerId = 402, QuestionId = 101, Text = "Principle of most privilege", IsCorrect = false },
                new Answer { AnswerId = 403, QuestionId = 101, Text = "Principle of lower privilege", IsCorrect = false },
                new Answer { AnswerId = 404, QuestionId = 102, Text = "AWS IAM", IsCorrect = false },
                new Answer { AnswerId = 405, QuestionId = 102, Text = "AWS Server", IsCorrect = false },
                new Answer { AnswerId = 406, QuestionId = 102, Text = "AWS EC2", IsCorrect = true },
                new Answer { AnswerId = 407, QuestionId = 102, Text = "AWS Regions", IsCorrect = false },
                new Answer { AnswerId = 408, QuestionId = 103, Text = "Usage of Security Groups", IsCorrect = true },
                new Answer { AnswerId = 409, QuestionId = 103, Text = "Usage of AWS Config", IsCorrect = false },
                new Answer { AnswerId = 410, QuestionId = 103, Text = "Usage of Network Access Control Lists", IsCorrect = true },
                new Answer { AnswerId = 411, QuestionId = 103, Text = "Usage of the Internet gateway", IsCorrect = false },
                new Answer { AnswerId = 412, QuestionId = 104, Text = "EBS Volumes", IsCorrect = false },
                new Answer { AnswerId = 413, QuestionId = 104, Text = "EBS Snapshots", IsCorrect = false },
                new Answer { AnswerId = 414, QuestionId = 104, Text = "Amazon Machines Images", IsCorrect = true },
                new Answer { AnswerId = 415, QuestionId = 104, Text = "Amazon VMware", IsCorrect = false },
                new Answer { AnswerId = 416, QuestionId = 105, Text = "AWS Glacier API", IsCorrect = false },
                new Answer { AnswerId = 417, QuestionId = 105, Text = "AWS Console", IsCorrect = true },
                new Answer { AnswerId = 418, QuestionId = 105, Text = "AWS Glacier SDK", IsCorrect = false },
                new Answer { AnswerId = 419, QuestionId = 105, Text = "AWS S3 Lifecycle policies", IsCorrect = false },
                new Answer { AnswerId = 420, QuestionId = 106, Text = "Basic", IsCorrect = false },
                new Answer { AnswerId = 421, QuestionId = 106, Text = "Developer", IsCorrect = false },
                new Answer { AnswerId = 422, QuestionId = 106, Text = "Business", IsCorrect = false },
                new Answer { AnswerId = 423, QuestionId = 106, Text = "Enterprise", IsCorrect = true },
                new Answer { AnswerId = 424, QuestionId = 107, Text = "Distribute content to users", IsCorrect = true },
                new Answer { AnswerId = 425, QuestionId = 107, Text = "Cache common responses", IsCorrect = true },
                new Answer { AnswerId = 426, QuestionId = 107, Text = "Distribute load across multiple resources", IsCorrect = false },
                new Answer { AnswerId = 427, QuestionId = 107, Text = "Used in conjunction with the CloudFront service", IsCorrect = true },
                new Answer { AnswerId = 428, QuestionId = 108, Text = "Amazon S3", IsCorrect = true },
                new Answer { AnswerId = 429, QuestionId = 108, Text = "Amazon Glacier", IsCorrect = false },
                new Answer { AnswerId = 430, QuestionId = 108, Text = "Amazon Storage Gateway", IsCorrect = false },
                new Answer { AnswerId = 431, QuestionId = 108, Text = "Amazon EBS", IsCorrect = false },
                new Answer { AnswerId = 432, QuestionId = 109, Text = "VPC Peering", IsCorrect = false },
                new Answer { AnswerId = 433, QuestionId = 109, Text = "Multi-AZ", IsCorrect = true },
                new Answer { AnswerId = 434, QuestionId = 109, Text = "Read Replicas", IsCorrect = true },
                new Answer { AnswerId = 435, QuestionId = 109, Text = "Multi-Region", IsCorrect = false },
                new Answer { AnswerId = 436, QuestionId = 110, Text = "Spot Instances", IsCorrect = false },
                new Answer { AnswerId = 437, QuestionId = 110, Text = "On-Demand", IsCorrect = true },
                new Answer { AnswerId = 438, QuestionId = 110, Text = "No Upfront costs Reserved", IsCorrect = false },
                new Answer { AnswerId = 439, QuestionId = 110, Text = "Partial Upfront costs Reserved", IsCorrect = false },
                new Answer { AnswerId = 440, QuestionId = 111, Text = "AWS Import/Export", IsCorrect = false },
                new Answer { AnswerId = 441, QuestionId = 111, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 442, QuestionId = 111, Text = "AWS Snowball", IsCorrect = true },
                new Answer { AnswerId = 443, QuestionId = 111, Text = "AWS Transfer", IsCorrect = false },
                new Answer { AnswerId = 444, QuestionId = 112, Text = "Having complete control over the physical", IsCorrect = false },
                new Answer { AnswerId = 445, QuestionId = 112, Text = "Having the pay as you go model, so you don't need to worry if you are burning costs for non-running resources.", IsCorrect = true },
                new Answer { AnswerId = 446, QuestionId = 112, Text = "No Upfront costs", IsCorrect = true },
                new Answer { AnswerId = 447, QuestionId = 112, Text = "Having no need to worry about security", IsCorrect = false },
                new Answer { AnswerId = 448, QuestionId = 113, Text = "AWS Database Migration Service", IsCorrect = true },
                new Answer { AnswerId = 449, QuestionId = 113, Text = "AWS VM Migration Service", IsCorrect = false },
                new Answer { AnswerId = 450, QuestionId = 113, Text = "AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 451, QuestionId = 113, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 452, QuestionId = 114, Text = "Cross region replication", IsCorrect = false },
                new Answer { AnswerId = 453, QuestionId = 114, Text = "Creating Read Replicas", IsCorrect = true },
                new Answer { AnswerId = 454, QuestionId = 114, Text = "Using snapshots", IsCorrect = false },
                new Answer { AnswerId = 455, QuestionId = 114, Text = "Using Multi-AZ feature", IsCorrect = false },
                new Answer { AnswerId = 456, QuestionId = 115, Text = "Availability Zone", IsCorrect = false },
                new Answer { AnswerId = 457, QuestionId = 115, Text = "Data center", IsCorrect = false },
                new Answer { AnswerId = 458, QuestionId = 115, Text = "Region", IsCorrect = true },
                new Answer { AnswerId = 459, QuestionId = 115, Text = "Edge location", IsCorrect = false },
                new Answer { AnswerId = 460, QuestionId = 116, Text = "Using the AWS DynamoDB service", IsCorrect = false },
                new Answer { AnswerId = 461, QuestionId = 116, Text = "Using the AWS RDS service", IsCorrect = false },
                new Answer { AnswerId = 462, QuestionId = 116, Text = "Hosting on the database on an EC2 Instance", IsCorrect = true },
                new Answer { AnswerId = 463, QuestionId = 116, Text = "Using the Amazon Aurora service", IsCorrect = false },
                new Answer { AnswerId = 464, QuestionId = 117, Text = "Aurora", IsCorrect = true },
                new Answer { AnswerId = 465, QuestionId = 117, Text = "DynamoDB", IsCorrect = false },
                new Answer { AnswerId = 466, QuestionId = 117, Text = "An EC2 instance with MySQL installed.", IsCorrect = false },
                new Answer { AnswerId = 467, QuestionId = 117, Text = "An EC2 instance with Aurora installed.", IsCorrect = false },
                new Answer { AnswerId = 468, QuestionId = 118, Text = "Diverting traffic to instances based on the demand", IsCorrect = false },
                new Answer { AnswerId = 469, QuestionId = 118, Text = "Diverting traffic to instances with the least load", IsCorrect = false },
                new Answer { AnswerId = 470, QuestionId = 118, Text = "Diverting traffic across multiple regions", IsCorrect = true },
                new Answer { AnswerId = 471, QuestionId = 118, Text = "Diverting traffic to instances with higher capacity", IsCorrect = true },
                new Answer { AnswerId = 472, QuestionId = 119, Text = "AutoScaling", IsCorrect = false },
                new Answer { AnswerId = 473, QuestionId = 119, Text = "Elastic Load Balancer", IsCorrect = true },
                new Answer { AnswerId = 474, QuestionId = 119, Text = "VPC", IsCorrect = false },
                new Answer { AnswerId = 475, QuestionId = 119, Text = "Subnets", IsCorrect = false },
                new Answer { AnswerId = 476, QuestionId = 120, Text = "AutoScaling", IsCorrect = true },
                new Answer { AnswerId = 477, QuestionId = 120, Text = "Elastic Load Balancer", IsCorrect = false },
                new Answer { AnswerId = 478, QuestionId = 120, Text = "VPC", IsCorrect = false },
                new Answer { AnswerId = 479, QuestionId = 120, Text = "Subnet", IsCorrect = false },
                new Answer { AnswerId = 480, QuestionId = 121, Text = "AWS TCO calculator", IsCorrect = true },
                new Answer { AnswerId = 481, QuestionId = 121, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 482, QuestionId = 121, Text = "AWS Cost Explorer", IsCorrect = false },
                new Answer { AnswerId = 483, QuestionId = 121, Text = "AWS Consolidating billing", IsCorrect = false },
                new Answer { AnswerId = 484, QuestionId = 122, Text = "Replication of the volume across Availability Zones", IsCorrect = false },
                new Answer { AnswerId = 485, QuestionId = 122, Text = "Replication of the volume in the same Availability Zone", IsCorrect = true },
                new Answer { AnswerId = 486, QuestionId = 122, Text = "Replication of the volume across Regions", IsCorrect = false },
                new Answer { AnswerId = 487, QuestionId = 122, Text = "Replication of the volume across Edge locations", IsCorrect = false },
                new Answer { AnswerId = 488, QuestionId = 123, Text = "AWS SDK", IsCorrect = true },
                new Answer { AnswerId = 489, QuestionId = 123, Text = "AWS Console", IsCorrect = false },
                new Answer { AnswerId = 490, QuestionId = 123, Text = "AWS CLI", IsCorrect = false },
                new Answer { AnswerId = 491, QuestionId = 123, Text = "AWS IAM", IsCorrect = false },
                new Answer { AnswerId = 492, QuestionId = 124, Text = "IAM Users", IsCorrect = false },
                new Answer { AnswerId = 493, QuestionId = 124, Text = "IAM Roles", IsCorrect = true },
                new Answer { AnswerId = 494, QuestionId = 124, Text = "IAM Groups", IsCorrect = false },
                new Answer { AnswerId = 495, QuestionId = 124, Text = "IAM policies", IsCorrect = false },
                new Answer { AnswerId = 496, QuestionId = 125, Text = "Consolidating billing", IsCorrect = true },
                new Answer { AnswerId = 497, QuestionId = 125, Text = "Combined Billing", IsCorrect = false },
                new Answer { AnswerId = 498, QuestionId = 125, Text = "Cost Explorer", IsCorrect = false },
                new Answer { AnswerId = 499, QuestionId = 125, Text = "IAM", IsCorrect = false },
                new Answer { AnswerId = 500, QuestionId = 126, Text = "CloudFront", IsCorrect = true },
                new Answer { AnswerId = 501, QuestionId = 126, Text = "AWS Shield", IsCorrect = true },
                new Answer { AnswerId = 502, QuestionId = 126, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 503, QuestionId = 126, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 504, QuestionId = 127, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 505, QuestionId = 127, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 506, QuestionId = 127, Text = "AWS Lambda", IsCorrect = true },
                new Answer { AnswerId = 507, QuestionId = 127, Text = "AWS Opswork", IsCorrect = false },
                new Answer { AnswerId = 508, QuestionId = 128, Text = "DynamoDB", IsCorrect = true },
                new Answer { AnswerId = 509, QuestionId = 128, Text = "EC2", IsCorrect = false },
                new Answer { AnswerId = 510, QuestionId = 128, Text = "Simple Storage Service", IsCorrect = true },
                new Answer { AnswerId = 511, QuestionId = 128, Text = "AWS Auto Scaling", IsCorrect = false },
                new Answer { AnswerId = 512, QuestionId = 129, Text = "Pilot light", IsCorrect = false },
                new Answer { AnswerId = 513, QuestionId = 129, Text = "Warm standby", IsCorrect = false },
                new Answer { AnswerId = 514, QuestionId = 129, Text = "Multi Site", IsCorrect = false },
                new Answer { AnswerId = 515, QuestionId = 129, Text = "Backup and Restore", IsCorrect = true },
                new Answer { AnswerId = 516, QuestionId = 130, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 517, QuestionId = 130, Text = "AWS Inspector", IsCorrect = true },
                new Answer { AnswerId = 518, QuestionId = 130, Text = "AWS WAF", IsCorrect = false },
                new Answer { AnswerId = 519, QuestionId = 130, Text = "AWS Shield", IsCorrect = false },
                new Answer { AnswerId = 520, QuestionId = 131, Text = "Amazon Glacier", IsCorrect = false },
                new Answer { AnswerId = 521, QuestionId = 131, Text = "Amazon EBS Volumes", IsCorrect = false },
                new Answer { AnswerId = 522, QuestionId = 131, Text = "Amazon EBS Snapshots.", IsCorrect = true },
                new Answer { AnswerId = 523, QuestionId = 132, Text = "EMR", IsCorrect = true },
                new Answer { AnswerId = 524, QuestionId = 132, Text = "S3", IsCorrect = false },
                new Answer { AnswerId = 525, QuestionId = 132, Text = "Glacier1", IsCorrect = false },
                new Answer { AnswerId = 526, QuestionId = 132, Text = "Storage gateway", IsCorrect = false },
                new Answer { AnswerId = 527, QuestionId = 133, Text = "24/7 access to customer support", IsCorrect = true },
                new Answer { AnswerId = 528, QuestionId = 133, Text = "Access to all features in the Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 529, QuestionId = 133, Text = "A technical Account Manager", IsCorrect = false },
                new Answer { AnswerId = 530, QuestionId = 133, Text = "A dedicated support person", IsCorrect = false },
                new Answer { AnswerId = 531, QuestionId = 134, Text = "Using a scalable system", IsCorrect = false },
                new Answer { AnswerId = 532, QuestionId = 134, Text = "Using an elastic system", IsCorrect = false },
                new Answer { AnswerId = 533, QuestionId = 134, Text = "Using a regional system", IsCorrect = false },
                new Answer { AnswerId = 534, QuestionId = 134, Text = "Using a fault tolerant system", IsCorrect = true },
                new Answer { AnswerId = 535, QuestionId = 135, Text = "Having access to Free and Unlimited Storage", IsCorrect = false },
                new Answer { AnswerId = 536, QuestionId = 135, Text = "Having access to Unlimited Physical servers", IsCorrect = false },
                new Answer { AnswerId = 537, QuestionId = 135, Text = "Having a highly available infrastructure", IsCorrect = true },
                new Answer { AnswerId = 538, QuestionId = 135, Text = "Ability to use resources on demand", IsCorrect = true },
                new Answer { AnswerId = 539, QuestionId = 136, Text = "CloudTrail", IsCorrect = false },
                new Answer { AnswerId = 540, QuestionId = 136, Text = "EC2", IsCorrect = false },
                new Answer { AnswerId = 541, QuestionId = 136, Text = "CloudFront", IsCorrect = true },
                new Answer { AnswerId = 542, QuestionId = 136, Text = "CloudWatch", IsCorrect = false },
                new Answer { AnswerId = 543, QuestionId = 137, Text = "No Reserved and 3 on-demand", IsCorrect = false },
                new Answer { AnswerId = 544, QuestionId = 137, Text = "One Reserved and 2 on-demand", IsCorrect = true },
                new Answer { AnswerId = 545, QuestionId = 137, Text = "Two Reserved and 1 on-demand", IsCorrect = false },
                new Answer { AnswerId = 546, QuestionId = 137, Text = "Three Reserved and no on-demand", IsCorrect = false },
                new Answer { AnswerId = 547, QuestionId = 138, Text = "Build Tightly-coupled components", IsCorrect = false },
                new Answer { AnswerId = 548, QuestionId = 138, Text = "Build loosely-coupled components", IsCorrect = true },
                new Answer { AnswerId = 549, QuestionId = 138, Text = "Assume everything will fail", IsCorrect = true },
                new Answer { AnswerId = 550, QuestionId = 138, Text = "Use as many services as possible", IsCorrect = false },
                new Answer { AnswerId = 551, QuestionId = 139, Text = "AWS Shield", IsCorrect = false },
                new Answer { AnswerId = 552, QuestionId = 139, Text = "AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 553, QuestionId = 139, Text = "AWS WAF", IsCorrect = false },
                new Answer { AnswerId = 554, QuestionId = 139, Text = "AWS Trusted Advisor", IsCorrect = true },
                new Answer { AnswerId = 555, QuestionId = 140, Text = "1 TB", IsCorrect = false },
                new Answer { AnswerId = 556, QuestionId = 140, Text = "5 TB", IsCorrect = false },
                new Answer { AnswerId = 557, QuestionId = 140, Text = "1 PB", IsCorrect = false },
                new Answer { AnswerId = 558, QuestionId = 140, Text = "Virtually unlimited storage", IsCorrect = true },
                new Answer { AnswerId = 559, QuestionId = 141, Text = "Amazon EC2", IsCorrect = true },
                new Answer { AnswerId = 560, QuestionId = 141, Text = "Amazon S3", IsCorrect = false },
                new Answer { AnswerId = 561, QuestionId = 141, Text = "Amazon LambdaD. Amazon DynamoDB", IsCorrect = false },
                new Answer { AnswerId = 562, QuestionId = 142, Text = "AWS Lambda", IsCorrect = false },
                new Answer { AnswerId = 563, QuestionId = 142, Text = "AWS Storage gateway", IsCorrect = false },
                new Answer { AnswerId = 564, QuestionId = 142, Text = "AWS DMS", IsCorrect = true },
                new Answer { AnswerId = 565, QuestionId = 142, Text = "AWS Snowball", IsCorrect = false },
                new Answer { AnswerId = 566, QuestionId = 143, Text = "Deployment to multiple edge locations", IsCorrect = false },
                new Answer { AnswerId = 567, QuestionId = 143, Text = "Deployment to multiple Availability Zones", IsCorrect = false },
                new Answer { AnswerId = 568, QuestionId = 143, Text = "Deployment to multiple Data Centers", IsCorrect = false },
                new Answer { AnswerId = 569, QuestionId = 143, Text = "Deployment to multiple Regions", IsCorrect = true },
                new Answer { AnswerId = 570, QuestionId = 144, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 571, QuestionId = 144, Text = "AWS ELB", IsCorrect = false },
                new Answer { AnswerId = 572, QuestionId = 144, Text = "AWS Shield", IsCorrect = true },
                new Answer { AnswerId = 573, QuestionId = 144, Text = "AWS Shield Advanced", IsCorrect = true },
                new Answer { AnswerId = 574, QuestionId = 145, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 575, QuestionId = 145, Text = "AWS Lambda", IsCorrect = true },
                new Answer { AnswerId = 576, QuestionId = 145, Text = "AWS SNS", IsCorrect = false },
                new Answer { AnswerId = 577, QuestionId = 145, Text = "AWS SQS", IsCorrect = false },
                new Answer { AnswerId = 578, QuestionId = 146, Text = "AWS Subnets", IsCorrect = false },
                new Answer { AnswerId = 579, QuestionId = 146, Text = "AWS VPC", IsCorrect = true },
                new Answer { AnswerId = 580, QuestionId = 146, Text = "AWS Regions", IsCorrect = false },
                new Answer { AnswerId = 581, QuestionId = 146, Text = "AWS Availability Zones", IsCorrect = false },
                new Answer { AnswerId = 582, QuestionId = 147, Text = "AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 583, QuestionId = 147, Text = "AWS TCO", IsCorrect = true },
                new Answer { AnswerId = 584, QuestionId = 147, Text = "AWS WAF", IsCorrect = false },
                new Answer { AnswerId = 585, QuestionId = 147, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 586, QuestionId = 148, Text = "It is a collection of Edge locations", IsCorrect = false },
                new Answer { AnswerId = 587, QuestionId = 148, Text = "It is a collection of Compute capacity", IsCorrect = false },
                new Answer { AnswerId = 588, QuestionId = 148, Text = "It is a geographical area divided into Availability Zones", IsCorrect = true },
                new Answer { AnswerId = 589, QuestionId = 148, Text = "It is the same as an Availability Zone", IsCorrect = false },
                new Answer { AnswerId = 590, QuestionId = 149, Text = "Security Group and ACL (Access Control List) settings", IsCorrect = true },
                new Answer { AnswerId = 591, QuestionId = 149, Text = "Decommissioning storage devices", IsCorrect = false },
                new Answer { AnswerId = 592, QuestionId = 149, Text = "Patch management on the EC2 instance's operating system", IsCorrect = true },
                new Answer { AnswerId = 593, QuestionId = 149, Text = "Life-cycle management of IAM credentials", IsCorrect = true },
                new Answer { AnswerId = 594, QuestionId = 149, Text = "Controlling physical access to compute resources", IsCorrect = false },
                new Answer { AnswerId = 595, QuestionId = 149, Text = "Encryption of EBS (Elastic Block Storage) volumes", IsCorrect = true },
                new Answer { AnswerId = 596, QuestionId = 150, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 597, QuestionId = 150, Text = "AWS IAM", IsCorrect = true },
                new Answer { AnswerId = 598, QuestionId = 150, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 599, QuestionId = 150, Text = "AWS", IsCorrect = false },
                new Answer { AnswerId = 600, QuestionId = 151, Text = "Ensure the least privilege access is used", IsCorrect = true },
                new Answer { AnswerId = 601, QuestionId = 151, Text = "Use the root account credentials", IsCorrect = false },
                new Answer { AnswerId = 602, QuestionId = 151, Text = "Don't use IAM users and groups", IsCorrect = false },
                new Answer { AnswerId = 603, QuestionId = 151, Text = "Ensure the highest privilege access is used", IsCorrect = false },
                new Answer { AnswerId = 604, QuestionId = 152, Text = "File Transfer", IsCorrect = false },
                new Answer { AnswerId = 605, QuestionId = 152, Text = "HTTP Transfer", IsCorrect = false },
                new Answer { AnswerId = 606, QuestionId = 152, Text = "S3 Acceleration", IsCorrect = false },
                new Answer { AnswerId = 607, QuestionId = 152, Text = "Transfer Acceleration", IsCorrect = true },
                new Answer { AnswerId = 608, QuestionId = 153, Text = "Instance Type", IsCorrect = true },
                new Answer { AnswerId = 609, QuestionId = 153, Text = "AMI Type", IsCorrect = true },
                new Answer { AnswerId = 610, QuestionId = 153, Text = "Region", IsCorrect = true },
                new Answer { AnswerId = 611, QuestionId = 153, Text = "Edge location", IsCorrect = false },
                new Answer { AnswerId = 612, QuestionId = 154, Text = "AWS Glacier", IsCorrect = true },
                new Answer { AnswerId = 613, QuestionId = 154, Text = "AWS S3 Reduced Redundancy Storage", IsCorrect = false },
                new Answer { AnswerId = 614, QuestionId = 154, Text = "EBS backed storage connected to EC2", IsCorrect = false },
                new Answer { AnswerId = 615, QuestionId = 154, Text = "AWS CloudFront", IsCorrect = false },
                new Answer { AnswerId = 616, QuestionId = 155, Text = "S3 allows you to store objects of virtually unlimited size.", IsCorrect = false },
                new Answer { AnswerId = 617, QuestionId = 155, Text = "S3 allows you to store unlimited amounts of data.", IsCorrect = true },
                new Answer { AnswerId = 618, QuestionId = 155, Text = "S3 should be used to host a relational database.", IsCorrect = false },
                new Answer { AnswerId = 619, QuestionId = 155, Text = "Objects are directly accessible via a URL.", IsCorrect = true },
                new Answer { AnswerId = 620, QuestionId = 156, Text = "AWS RDS", IsCorrect = false },
                new Answer { AnswerId = 621, QuestionId = 156, Text = "DynamoDB", IsCorrect = true },
                new Answer { AnswerId = 622, QuestionId = 156, Text = "Oracle RDS", IsCorrect = false },
                new Answer { AnswerId = 623, QuestionId = 156, Text = "Elastic Map Reduce", IsCorrect = false },
                new Answer { AnswerId = 624, QuestionId = 157, Text = "AWS CloudTrail", IsCorrect = false },
                new Answer { AnswerId = 625, QuestionId = 157, Text = "AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 626, QuestionId = 157, Text = "AWS Trusted Advisor", IsCorrect = false },
                new Answer { AnswerId = 627, QuestionId = 157, Text = "AWS CloudWatch", IsCorrect = true },
                new Answer { AnswerId = 628, QuestionId = 158, Text = "Amazon EBS volume", IsCorrect = false },
                new Answer { AnswerId = 629, QuestionId = 158, Text = "Amazon S3", IsCorrect = true },
                new Answer { AnswerId = 630, QuestionId = 158, Text = "Amazon EC2 instance store", IsCorrect = false },
                new Answer { AnswerId = 631, QuestionId = 158, Text = "Amazon RDS instance", IsCorrect = false },
                new Answer { AnswerId = 632, QuestionId = 159, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 633, QuestionId = 159, Text = "AWS Auto Scaling", IsCorrect = false },
                new Answer { AnswerId = 634, QuestionId = 159, Text = "AWS ELB", IsCorrect = true },
                new Answer { AnswerId = 635, QuestionId = 159, Text = "AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 636, QuestionId = 160, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 637, QuestionId = 160, Text = "AWS Auto Scaling", IsCorrect = true },
                new Answer { AnswerId = 638, QuestionId = 160, Text = "AWS ELB", IsCorrect = false },
                new Answer { AnswerId = 639, QuestionId = 160, Text = "AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 640, QuestionId = 161, Text = "MariaDB", IsCorrect = false },
                new Answer { AnswerId = 641, QuestionId = 161, Text = "Aurora", IsCorrect = true },
                new Answer { AnswerId = 642, QuestionId = 161, Text = "PostgreSQL", IsCorrect = false },
                new Answer { AnswerId = 643, QuestionId = 161, Text = "DynamoDB", IsCorrect = false },
                new Answer { AnswerId = 644, QuestionId = 162, Text = "AWS Snowball", IsCorrect = false },
                new Answer { AnswerId = 645, QuestionId = 162, Text = "AWS Storage Gateway", IsCorrect = false },
                new Answer { AnswerId = 646, QuestionId = 162, Text = "AWS EMR", IsCorrect = false },
                new Answer { AnswerId = 647, QuestionId = 162, Text = "AWS Redshift", IsCorrect = true },
                new Answer { AnswerId = 648, QuestionId = 163, Text = "AWS Config", IsCorrect = false },
                new Answer { AnswerId = 649, QuestionId = 163, Text = "AWS CloudTrail", IsCorrect = true },
                new Answer { AnswerId = 650, QuestionId = 163, Text = "AWS CloudWatch", IsCorrect = false },
                new Answer { AnswerId = 651, QuestionId = 163, Text = "AWS SNS", IsCorrect = false },
                new Answer { AnswerId = 652, QuestionId = 164, Text = "You pay no upfront costs for the instance", IsCorrect = false },
                new Answer { AnswerId = 653, QuestionId = 164, Text = "You are charged per second based on the hourly rate", IsCorrect = false },
                new Answer { AnswerId = 654, QuestionId = 164, Text = "You have to pay the termination fees if you terminate the instance", IsCorrect = true },
                new Answer { AnswerId = 655, QuestionId = 164, Text = "You pay for much you use.", IsCorrect = false },
                new Answer { AnswerId = 656, QuestionId = 165, Text = "Cached session data", IsCorrect = false },
                new Answer { AnswerId = 657, QuestionId = 165, Text = "Infrequently accessed data", IsCorrect = true },
                new Answer { AnswerId = 658, QuestionId = 165, Text = "Data archives", IsCorrect = true },
                new Answer { AnswerId = 659, QuestionId = 165, Text = "Active database storage", IsCorrect = false },
                new Answer { AnswerId = 660, QuestionId = 166, Text = "Aurora", IsCorrect = false },
                new Answer { AnswerId = 661, QuestionId = 166, Text = "MariaDB", IsCorrect = false },
                new Answer { AnswerId = 662, QuestionId = 166, Text = "MySQL", IsCorrect = false },
                new Answer { AnswerId = 663, QuestionId = 166, Text = "DB2", IsCorrect = true },
                new Answer { AnswerId = 664, QuestionId = 167, Text = "Amazon Snowball", IsCorrect = true },
                new Answer { AnswerId = 665, QuestionId = 167, Text = "Amazon Direct Connect", IsCorrect = false },
                new Answer { AnswerId = 666, QuestionId = 167, Text = "Amazon S3 MultiPart Upload", IsCorrect = false },
                new Answer { AnswerId = 667, QuestionId = 167, Text = "Amazon S3 Connector", IsCorrect = false },
                new Answer { AnswerId = 668, QuestionId = 168, Text = "An availability zone is a grouping of AWS resources in a specific region; an edge location is a specific resource within the AWS region", IsCorrect = false },
                new Answer { AnswerId = 669, QuestionId = 168, Text = "An availability zone is an Amazon resource within an AWS region, whereas an edge location will deliver cached content to the closest location to reduce latency", IsCorrect = true },
                new Answer { AnswerId = 670, QuestionId = 168, Text = "Edge locations are used as control stations for AWS resources", IsCorrect = false },
                new Answer { AnswerId = 671, QuestionId = 168, Text = "None of the above", IsCorrect = false },
                new Answer { AnswerId = 672, QuestionId = 169, Text = "AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 673, QuestionId = 169, Text = "Subnet Groups", IsCorrect = false },
                new Answer { AnswerId = 674, QuestionId = 169, Text = "Security Groups", IsCorrect = false },
                new Answer { AnswerId = 675, QuestionId = 169, Text = "NACL", IsCorrect = true },
                new Answer { AnswerId = 676, QuestionId = 170, Text = "Combined billing", IsCorrect = false },
                new Answer { AnswerId = 677, QuestionId = 170, Text = "Consolidated billing", IsCorrect = true },
                new Answer { AnswerId = 678, QuestionId = 170, Text = "Costs are automatically reduced for multiple accounts by AWS.", IsCorrect = false },
                new Answer { AnswerId = 679, QuestionId = 170, Text = "It is not possible to reduce costs with multiple accounts", IsCorrect = false },
                new Answer { AnswerId = 680, QuestionId = 171, Text = "AWS SES", IsCorrect = false },
                new Answer { AnswerId = 681, QuestionId = 171, Text = "AWS SNS", IsCorrect = true },
                new Answer { AnswerId = 682, QuestionId = 171, Text = "AWS SQS", IsCorrect = false },
                new Answer { AnswerId = 683, QuestionId = 171, Text = "AWS EC2", IsCorrect = false },
                new Answer { AnswerId = 684, QuestionId = 172, Text = "Policy", IsCorrect = true },
                new Answer { AnswerId = 685, QuestionId = 172, Text = "Permission", IsCorrect = false },
                new Answer { AnswerId = 686, QuestionId = 172, Text = "Role", IsCorrect = false },
                new Answer { AnswerId = 687, QuestionId = 172, Text = "Resource", IsCorrect = false },
                new Answer { AnswerId = 688, QuestionId = 173, Text = "Security group", IsCorrect = true },
                new Answer { AnswerId = 689, QuestionId = 173, Text = "ACL", IsCorrect = false },
                new Answer { AnswerId = 690, QuestionId = 173, Text = "IAM", IsCorrect = false },
                new Answer { AnswerId = 691, QuestionId = 173, Text = "IAM", IsCorrect = false },
                new Answer { AnswerId = 692, QuestionId = 174, Text = "Automated patches and backups", IsCorrect = true },
                new Answer { AnswerId = 693, QuestionId = 174, Text = "You can resize the capacity accordingly", IsCorrect = true },
                new Answer { AnswerId = 694, QuestionId = 174, Text = "It allows you to store unstructured data", IsCorrect = false },
                new Answer { AnswerId = 695, QuestionId = 174, Text = "It allows you to store NoSQL data", IsCorrect = false },
                new Answer { AnswerId = 696, QuestionId = 175, Text = "AWS SNSB", IsCorrect = false },
                new Answer { AnswerId = 697, QuestionId = 175, Text = "AWS SQS", IsCorrect = false },
                new Answer { AnswerId = 698, QuestionId = 175, Text = "AWS CloudFront", IsCorrect = true },
                new Answer { AnswerId = 699, QuestionId = 175, Text = "AWS Inspector", IsCorrect = false },
                new Answer { AnswerId = 700, QuestionId = 176, Text = "Amazon Simple Workflow Service", IsCorrect = false },
                new Answer { AnswerId = 701, QuestionId = 176, Text = "AWS Elastic Beanstalk", IsCorrect = false },
                new Answer { AnswerId = 702, QuestionId = 176, Text = "AWS CloudFormation", IsCorrect = true },
                new Answer { AnswerId = 703, QuestionId = 176, Text = "AWS OpsWorks", IsCorrect = false },
                new Answer { AnswerId = 704, QuestionId = 177, Text = "Spot Instances", IsCorrect = true },
                new Answer { AnswerId = 705, QuestionId = 177, Text = "Reserved instances", IsCorrect = false },
                new Answer { AnswerId = 706, QuestionId = 177, Text = "Dedicated instancesI", IsCorrect = false },
                new Answer { AnswerId = 707, QuestionId = 177, Text = "On-Demand instances", IsCorrect = false },
                new Answer { AnswerId = 708, QuestionId = 178, Text = "Route53", IsCorrect = true },
                new Answer { AnswerId = 709, QuestionId = 178, Text = "VPC", IsCorrect = false },
                new Answer { AnswerId = 710, QuestionId = 178, Text = "Direct Connect", IsCorrect = false },
                new Answer { AnswerId = 711, QuestionId = 178, Text = "VPN", IsCorrect = false },
                new Answer { AnswerId = 712, QuestionId = 179, Text = "CloudFormation", IsCorrect = false },
                new Answer { AnswerId = 713, QuestionId = 179, Text = "Elastic Beanstalk", IsCorrect = true },
                new Answer { AnswerId = 714, QuestionId = 179, Text = "Opswork", IsCorrect = false },
                new Answer { AnswerId = 715, QuestionId = 179, Text = "Container service", IsCorrect = false },
                new Answer { AnswerId = 716, QuestionId = 180, Text = "MySQL Installed on two Amazon EC2 Instances in a single Availability Zone", IsCorrect = false },
                new Answer { AnswerId = 717, QuestionId = 180, Text = "Amazon RDS for MySQL with Multi-AZ", IsCorrect = false },
                new Answer { AnswerId = 718, QuestionId = 180, Text = "Amazon ElastiCache", IsCorrect = true },
                new Answer { AnswerId = 719, QuestionId = 180, Text = "Amazon DynamoDB", IsCorrect = false },
                new Answer { AnswerId = 720, QuestionId = 181, Text = "Store the EBS volume in S3", IsCorrect = false },
                new Answer { AnswerId = 721, QuestionId = 181, Text = "Store the EBS volume in an RDS database", IsCorrect = false },
                new Answer { AnswerId = 722, QuestionId = 181, Text = "Create an EBS snapshot", IsCorrect = true },
                new Answer { AnswerId = 723, QuestionId = 181, Text = "Store the EBS volume in DynamoDB", IsCorrect = false },
                new Answer { AnswerId = 724, QuestionId = 182, Text = "Virtual servers in the Cloud.", IsCorrect = true },
                new Answer { AnswerId = 725, QuestionId = 182, Text = "A platform to run code (Java, PHP, Python), paying on an hourly basis.", IsCorrect = false },
                new Answer { AnswerId = 726, QuestionId = 182, Text = "Computer Clusters in the Cloud.", IsCorrect = false },
                new Answer { AnswerId = 727, QuestionId = 182, Text = "Physical servers, remotely managed by the customer.", IsCorrect = false },
                new Answer { AnswerId = 728, QuestionId = 183, Text = "AWS Multi-AZ", IsCorrect = true },
                new Answer { AnswerId = 729, QuestionId = 183, Text = "AWS Failover", IsCorrect = false },
                new Answer { AnswerId = 730, QuestionId = 183, Text = "AWS Secondary", IsCorrect = false },
                new Answer { AnswerId = 731, QuestionId = 183, Text = "AWS Standby", IsCorrect = false },
                new Answer { AnswerId = 732, QuestionId = 184, Text = "Cost Explorer", IsCorrect = true },
                new Answer { AnswerId = 733, QuestionId = 184, Text = "Cost Allocation Tags", IsCorrect = false },
                new Answer { AnswerId = 734, QuestionId = 184, Text = "AWS Consolidated billing", IsCorrect = false },
                new Answer { AnswerId = 735, QuestionId = 184, Text = "Payment History", IsCorrect = false },
                new Answer { AnswerId = 736, QuestionId = 185, Text = "SQS", IsCorrect = false },
                new Answer { AnswerId = 737, QuestionId = 185, Text = "S3", IsCorrect = false },
                new Answer { AnswerId = 738, QuestionId = 185, Text = "CloudTrail", IsCorrect = false },
                new Answer { AnswerId = 739, QuestionId = 185, Text = "CloudWatch Logs", IsCorrect = true },
                new Answer { AnswerId = 740, QuestionId = 186, Text = "AWS IAM Users", IsCorrect = false },
                new Answer { AnswerId = 741, QuestionId = 186, Text = "AWS IAM Roles", IsCorrect = true },
                new Answer { AnswerId = 742, QuestionId = 186, Text = "AWS IAM Groups", IsCorrect = false },
                new Answer { AnswerId = 743, QuestionId = 186, Text = "AWS IAM Permissions", IsCorrect = false },
                new Answer { AnswerId = 744, QuestionId = 187, Text = "Basic, Developer, Business, Enterprise", IsCorrect = true },
                new Answer { AnswerId = 745, QuestionId = 187, Text = "Basic, Startup, Business, Enterprise", IsCorrect = false },
                new Answer { AnswerId = 746, QuestionId = 187, Text = "Free, Bronze, Silver, Gold", IsCorrect = false },
                new Answer { AnswerId = 747, QuestionId = 187, Text = "All support is free", IsCorrect = false },
                new Answer { AnswerId = 748, QuestionId = 188, Text = "AWS RDS", IsCorrect = false },
                new Answer { AnswerId = 749, QuestionId = 188, Text = "DynamoDB", IsCorrect = true },
                new Answer { AnswerId = 750, QuestionId = 188, Text = "Oracle RDS", IsCorrect = false },
                new Answer { AnswerId = 751, QuestionId = 188, Text = "Elastic Map Reduce", IsCorrect = false },
                new Answer { AnswerId = 752, QuestionId = 189, Text = "The storage class used for the objects stored.", IsCorrect = true },
                new Answer { AnswerId = 753, QuestionId = 189, Text = "Number of S3 buckets", IsCorrect = false },
                new Answer { AnswerId = 754, QuestionId = 189, Text = "The total size in gigabytes of all objects stored.", IsCorrect = true },
                new Answer { AnswerId = 755, QuestionId = 189, Text = "Using encryption in S3", IsCorrect = false },
                new Answer { AnswerId = 756, QuestionId = 190, Text = "AWS Powershell", IsCorrect = false },
                new Answer { AnswerId = 757, QuestionId = 190, Text = "AWS SDK", IsCorrect = true },
                new Answer { AnswerId = 758, QuestionId = 190, Text = "AWS CLI", IsCorrect = false },
                new Answer { AnswerId = 759, QuestionId = 190, Text = "AWS Console", IsCorrect = false },
                new Answer { AnswerId = 760, QuestionId = 191, Text = "AWS VPC", IsCorrect = false },
                new Answer { AnswerId = 761, QuestionId = 191, Text = "AWS VPN", IsCorrect = true },
                new Answer { AnswerId = 762, QuestionId = 191, Text = "AWS Direct Connect", IsCorrect = true },
                new Answer { AnswerId = 763, QuestionId = 191, Text = "AWS Subnets", IsCorrect = false },
                new Answer { AnswerId = 764, QuestionId = 192, Text = "EBS Volumes", IsCorrect = false },
                new Answer { AnswerId = 765, QuestionId = 192, Text = "AMI", IsCorrect = true },
                new Answer { AnswerId = 766, QuestionId = 192, Text = "EC2 Snapshot", IsCorrect = false },
                new Answer { AnswerId = 767, QuestionId = 192, Text = "EBS Snapshot", IsCorrect = false },
                new Answer { AnswerId = 768, QuestionId = 193, Text = "On-Demand", IsCorrect = true },
                new Answer { AnswerId = 769, QuestionId = 193, Text = "Spot Instances", IsCorrect = false },
                new Answer { AnswerId = 770, QuestionId = 193, Text = "No Upfront costs Reserved", IsCorrect = false },
                new Answer { AnswerId = 771, QuestionId = 193, Text = "Partial Upfront costs Reserved", IsCorrect = false },
                new Answer { AnswerId = 772, QuestionId = 194, Text = "Consolidating billing", IsCorrect = true },
                new Answer { AnswerId = 773, QuestionId = 194, Text = "Combined Billing", IsCorrect = false },
                new Answer { AnswerId = 774, QuestionId = 194, Text = "Cost Explorer", IsCorrect = false },
                new Answer { AnswerId = 775, QuestionId = 194, Text = "IAM", IsCorrect = false },
                new Answer { AnswerId = 776, QuestionId = 131, Text = "Amazon SQS", IsCorrect = false },
                new Answer { AnswerId = 777, QuestionId = 64, Text = "Warm standby", IsCorrect = true }
                );
        }

        private void AddExplanations()
        {
            modelBuilder.Entity<Explanation>().HasData(
                new Explanation { ExplanationId = 3, Text = "One of the advantages of EC2 Instances is the per second billing concept. This is given in the AWS documentation also with per-second billing, you pay For only what you use. It takes cost of unused minutes and seconds in an hour off of the bill, so you can focus on improving your applications instead of maximizing usage to the hour. Especially, if you manage instances running for irregular periods of time, such as dev/testing, dataprocessing, analytics, batch processing and gaming applications, can benefit.", QuestionId = 3 },
                new Explanation { ExplanationId = 4, Text = "The AWS documentation mentions the following:<br/> An online resource to help you reduce cost, increase performance, and improve security by optimizing your AWS environment, Trusted Advisor provides real time guidance to help you provision your resources following AWS best practices", QuestionId = 4 },
                new Explanation { ExplanationId = 5, Text = "The AWS documentation mentions the following:<br/>Amazon CloudWatch is a monitoring service for AWS cloud resources and the applications you run on AWS.You can use Amazon CloudWatch to collect and trackmetrics, collect and monitor log files, set alarms, and automatically react to changes in your AWS resources", QuestionId = 5 },
                new Explanation { ExplanationId = 6, Text = "Using CloudWatch trail, one can monitor all the API activity conducted on all AWS services. The AWS documentation additionally mentions the following:<br/> AWS Cloud Trail is a service that enables governance, compliance, operational auditing, and risk auditing of your AWS account.<br/>With CloudTrail, you can log, continuously monitor, and retain account activity related to actions across your AWS infrastructure. CloudTrail provides event history of your AWS account activity, including actions taken through the AWS ManagementConsole, AWS SDKs, command line tools, and other AWS services. This event history simplifies security analysis, resource change tracking, and troubleshooting.", QuestionId = 6 },
                new Explanation { ExplanationId = 7, Text = "Route53 allows for registration of new domain names in AWS The AWS Documentation additionally mentions the following:<br/> Amazon Route 53 is a highly available and scalable cloud Domain Name System(DNS) web service. It is designed to give developers and businesses an extremely reliable and cost effective way to route end users to Internet applications by translating names like www.example.com into the numeric IP addresses like 192.0.2.1 that computers use to connect to each other. Amazon Route 53 is fully compliant with IPv6 as well.", QuestionId = 7 },
                new Explanation { ExplanationId = 8, Text = "It allows developers to easily work with the various AWS resources programmatically.", QuestionId = 8 },
                new Explanation { ExplanationId = 9, Text = "Each AZ is a set of one or more data centers. By deploying your AWS resources to multiple Availability Zones, you are designing with failure with mind. So if one AZ were to go down, the other NDS, would still be up and running and hence your application would be more fault tolerant.", QuestionId = 9 },
                new Explanation { ExplanationId = 10, Text = "The AWS documentation mentions the following:<br/>AWS Identity and Access Management (IAM) is a webservice that helps you securely control access to AWS resources. You use IAM to control who is authenticated (signed in) and authorized (has permissions) to use resources.", QuestionId = 10 },
                new Explanation { ExplanationId = 11, Text = "The AWS documentation mentions the following:<br/>Amazon Redshift is a fully managed, petabyte-scale data warehouse service in the cloud. You can start with just afew hundred gigabytes of data and scale to a petabyte ormore. This enables you to use your data to acquire new insights for your business and customers.", QuestionId = 11 },
                new Explanation { ExplanationId = 12, Text = "The responsibility of managing the various permissions of users and the roles and permission is withthe AWS customer.", QuestionId = 12 },
                new Explanation { ExplanationId = 13, Text = "The AWS documentation mentions the following:<br/> on AWS Cost Reports Cost Explorer is a free tool that youcan use to view your costs. You can view data up to the last 13 months, forecast how much you are likely to spend for the next three months, and get recommendations for what Reserved Instances to purchase", QuestionId = 13 },
                new Explanation { ExplanationId = 14, Text = "The entire of control of data within an AWS account is with the Account Owner.", QuestionId = 14 },
                new Explanation { ExplanationId = 15, Text = "The entire concept of decoupling components is to ensure that the different components of an applications can be managed and maintained separately. If all components are tightly coupled then when one component goes down, the entire application would go down. Hence it is always a better design practice to decouple application components.", QuestionId = 15 },
                new Explanation { ExplanationId = 16, Text = "Each AZ is a set of one or more data centers. By deploying your AWS resources to multiple Availability Zones, you are designing with failure with mind. So if oneAZ were to go down, the other AZ‘s would still be up and running and hence your application would be more fault tolerant.", QuestionId = 16 },
                new Explanation { ExplanationId = 17, Text = "As per the Shared Responsibility model, the security for users has to be managed by the AWS Customer.", QuestionId = 17 },
                new Explanation { ExplanationId = 18, Text = "The concept of Elasticity is the means of an application having the ability to scale up and scale downbased on demand. An example of such a service is the Auto Scaling service.", QuestionId = 18 },
                new Explanation { ExplanationId = 19, Text = "The AWS documentation mentions the following:<br/>Spot Instances are a cost-effective choice if you can be flexible about when your applications run and if your applications can be interrupted. For example, Spot Instances are well-suited for data analysis, batch jobs, background processing, and optional tasks.", QuestionId = 19 },
                new Explanation { ExplanationId = 20, Text = "The AWS Management console allows you to access and manage Amazon Web Services through a simple and intuitive web-based user interface.", QuestionId = 20 },
                new Explanation { ExplanationId = 21, Text = "The AWS Documentation mentions the following:<br/>Cost Explorer is a free tool that you can use to view your costs. You can view data up to the last 13 months, forecast how much you are likely to spend for the next three months, and get recommendations for what Reserved Instances to purchase. You can use Cost Explorer to see patterns in how much you spend on AWS resources overtime, identify areas that need further inquiry, and seetrends that you can use to understand your costs. Youalso can specify time ranges for the data, and view timedata by day or by month.", QuestionId = 21 },
                new Explanation { ExplanationId = 22, Text = "The AWS Documentation mentions the following:<br/>AWS Multi-Factor Authentication (MFA) is a simple best practice that adds an extra layer of protection on top of your user name and password.", QuestionId = 22 },
                new Explanation { ExplanationId = 23, Text = "The AWS Documentation mentions the following:<br/>You can use IAM in the AWS Management Console to enable a virtual MFA device for an IAM user in your account.", QuestionId = 23 },
                new Explanation { ExplanationId = 24, Text = "The AWS Documentation mentions the following:<br/>Businesses are using the AWS cloud to enable faster disaster recovery of their critical IT systems without incurring the infrastructure expense of a second physical site. The AWS cloud supports many popular disaster recovery (DR) architectures from 'pilot light' environments that may be suitable for small customerworkload data center failures to 'hot standby' environments that enable rapid failover at scale.With data centers in Regions all around the world, AWS provides a set of cloud-based disaster recovery servicesthat enable rapid recovery of your IT infrastructure and data.", QuestionId = 24 },
                new Explanation { ExplanationId = 25, Text = "Since EC2 Instances carry a charge when they are running, you need to factor in the number of servers that need to be migrated to AWS.", QuestionId = 25 },
                new Explanation { ExplanationId = 26, Text = "The AWS Documentation mentions the following:<br/>Amazon CloudFront is a web service that gives businesses and web application developers an easy and cost effective way to distribute content with low latency and high data transfer speeds. Like other AWS services, Amazon CloudFront is a self-service, pay-per-use offering, requiring no long term commitments or minimum fees.With CloudFront, your files are delivered to end-usersusing a global network of edge locations.", QuestionId = 26 },
                new Explanation { ExplanationId = 27, Text = "The AWS Documentation mentions the following:<br/>Amazon DynamoDB is a fast and flexible NoSQL database service for all applications that need consistent, single-digit millisecond latency at any scale. It is a fully managed cloud database and supports both documentand key-value store models. Its flexible data model, reliable performance, and automatic scaling ofthroughput capacity, makes it a great fit for mobile, web, gaming, ad tech, IoT, and many other applications.", QuestionId = 27 },
                new Explanation { ExplanationId = 28, Text = "The AWS Documentation mentions the following:<br/>Amazon Glacier is a secure, durable, and extremely low-cost cloud storage service for data archiving and long-term backup. It is designed to deliver 99.999999999% durability, and provides comprehensive security and compliance capabilities that can help meet even the most stringent regulatory requirements.", QuestionId = 28 },
                new Explanation { ExplanationId = 29, Text = "When you have instances that will be used continuously and throughout the year, the best option is tobuy reserved instances. By buying reserved instances, you are actually allocated an instance for the entire yearor the duration you specify with a reduced cost.", QuestionId = 29 },
                new Explanation { ExplanationId = 30, Text = "The AWS Documentation mentions the following:<br/>Amazon S3 Transfer Acceleration enables fast, easy, and secure transfers of files over long distances between your client and an S3 bucket. Transfer Acceleration takes advantage of Amazon CloudFront's globally distributed edge locations. As the data arrives at an edge location, data is routed to Amazon S3 over an optimized network path.", QuestionId = 30 },
                new Explanation { ExplanationId = 31, Text = "You need to take prior authorization from AWS before doing a penetration test on EC2 Instances.", QuestionId = 31 },
                new Explanation { ExplanationId = 32, Text = "Screenshot in below AWS Doc shows what servicesthe Trusted Advisor Dashboard offers.", QuestionId = 32 },
                new Explanation { ExplanationId = 33, Text = "Amazon S3 is the default storage service that should be considered for companies. If provides durable storage for all static content.", QuestionId = 33 },
                new Explanation { ExplanationId = 34, Text = "The principle means giving a user account only those privileges which are essential to perform its intended function. For example, a user account for the sole purpose of creating backups does not need to installs of tware: hence, it has rights only to run backup and backup-related applications.", QuestionId = 34 },
                new Explanation { ExplanationId = 35, Text = "The AWS Documentation mentions the following:<br/>Amazon Elastic Compute Cloud (Amazon EC2) is a webservice that provides secure, resizable compute capacityin the cloud. It is designed to make web-scale cloud computing easier for developers.", QuestionId = 35 },
                new Explanation { ExplanationId = 36, Text = "The AWS Documentation mentions the following:<br/>A security group acts as a virtual firewall for your instance to control inbound and outbound traffic.<br/>A network access control list (ACL) is an optional layer of security for your VPC that acts as a firewall for controlling traffic in and out of one or more subnets.", QuestionId = 36 },
                new Explanation { ExplanationId = 37, Text = "The AWS Documentation mentions the following:<br/>An Amazon Machine Image (AMI) provides the information required to launch an instance, which is a virtual server in the cloud. You specify an AMI when you launch an instance, and you can launch as many instances from the AMI as you need. You can also launch instances from as many different AMIs as you need.", QuestionId = 37 },
                new Explanation { ExplanationId = 38, Text = "The snapshot from the AWS Documentation mentions that some of the AWS services are already PCI compliant. This list should be checked when designing the application.", QuestionId = 38 },
                new Explanation { ExplanationId = 39, Text = "Note that the AWS Console cannot be used to upload data onto Glacier. The console can only be used to create a Glacier vault which can be used to upload the data.", QuestionId = 39 },
                new Explanation { ExplanationId = 40, Text = "Only the Enterprise support plan fits this requirement.", QuestionId = 40 },
                new Explanation { ExplanationId = 41, Text = "Only the Enterprise support plan fits this requirement.", QuestionId = 41 },
                new Explanation { ExplanationId = 42, Text = "The Edge location does not do the job of distributing load. It is used in conjunction with the CloudFront service to cache the obj ects and deliver content.", QuestionId = 42 },
                new Explanation { ExplanationId = 43, Text = "Amazon S3 is the perfect storage option. It also provides the facility of assigning a URL to each object which can be used to download the object.", QuestionId = 43 },
                new Explanation { ExplanationId = 44, Text = "If the database is going to be used for a minimum of one year at least, then it is better to get Reserved Instances. You can save on costs, and if you use a partial upfront option, you can get a better discount.", QuestionId = 44 },
                new Explanation { ExplanationId = 45, Text = "Since the requirement is just for 3 months, then the best cost effective option is to use On-Demand Instances.", QuestionId = 45 },
                new Explanation { ExplanationId = 46, Text = "When you define security rules for EC 2 Instances, you give a name, description, and write the rules for the security group.", QuestionId = 46 },
                new Explanation { ExplanationId = 47, Text = "The physical infrastructure is a responsibility of AWS and not with the customer. Hence it is <em>not</em> an advantage of moving to the AWS Cloud.<br/>AWS provides security mechanisms, but the responsibility of <em>security lies with the customer</em>.", QuestionId = 47 },
                new Explanation { ExplanationId = 48, Text = "Using CloudWatch trail, one can monitor all the API activity conducted on all AWS services. The AWS Documentation additionally mentions the following:<br/>AWS CloudTrail is a service that enables governance, compliance, operational auditing, and risk auditing of your AWS account. With CloudTrail, you can log, continuously monitor, and retain account activity relatedto actions across your AWS infrastructure. CloudTrailprovides event history of your AWS account activity, including actions taken through the AWS ManagementConsole, AWS SDKs, command line tools, and other AWS services. This event history simplifies security analysis, resource change tracking, and troubleshooting.", QuestionId = 48 },
                new Explanation { ExplanationId = 49, Text = "One can use the Read Replica feature of the database to ensure the data is replicated to another region.", QuestionId = 49 },
                new Explanation { ExplanationId = 50, Text = "Regions correspond to different geographic locations in AWS.", QuestionId = 50 },
                new Explanation { ExplanationId = 51, Text = "If you want a self-managed database, that means you want complete control over the database engine and the underlying infrastructure. In such a case you need to host the database on an EC2 Instance.", QuestionId = 51 },
                new Explanation { ExplanationId = 52, Text = "The AWS Documentation mentions the following:<br/>Amazon Aurora (Aurora) is a fully managed, MySQL and PostgreSQL-compatible, relational database engine. It combines the speed and reliability of high-end commercial databases with the simplicity and cost-effectiveness of open-source databases. It delivers up to five times the throughput of MySQL and up to three timesthe throughput of PostgreSQL without requiring changes tomost of your existing applications.", QuestionId = 52 },
                new Explanation { ExplanationId = 53, Text = "The concept of Elasticity is the means of an application having the ability to scale up and scale down based on demand.<br/>An example of such a service is the Auto Scaling service.", QuestionId = 53 },
                new Explanation { ExplanationId = 54, Text = "The AWS Documentation mentions the following:<br/> Aload balancer distributes incoming application traffic across multiple EC2 instances in multiple Availability Zones. This increases the fault tolerance of your applications. Elastic Load Balancing detects unhealthy instances and routes traffic only to healthy instances.", QuestionId = 54 },
                new Explanation { ExplanationId = 55, Text = "The AWS Documentation mentions the following:<br/>AWS Auto Scaling monitors your applications and automatically adjusts capacity to maintain steady, predictable performance at the lowest possible cost.Using AWS Auto Scaling, it's easy to setup application scaling for multiple resources across multiple services inminutes.", QuestionId = 55 },
                new Explanation { ExplanationId = 57, Text = "Creating snapshots of EBS Volumes can help ensure that you have a backup of your EBS volume in place.", QuestionId = 57 },
                new Explanation { ExplanationId = 58, Text = "The AWS SDK can be plugged in for various programming languages. Using the SDK you can then callthe required AWS services.", QuestionId = 58 },
                new Explanation { ExplanationId = 59, Text = "The AWS Documentation mentions the following:<br/>An IAM role is similar to a user, in that it is an AWS identity with permission policies that determine what the identity can and cannot do in AWS. However, instead of being uniquely associated with one person, a role is intended tobe assumable by anyone who needs it. Also, a role does not have standard long-term credentials (password oraccess keys) associated with it. Instead, if a user assumesa role, temporary security credentials are createddynamically and provided to the user.", QuestionId = 59 },
                new Explanation { ExplanationId = 60, Text = "The AWS Documentation mentions the following:<br/>You can use the consolidated billing feature in AWS Organizations to consolidate payment for multiple AWS accounts or multiple AISPL accounts. With consolidated billing, you can see a combined view of AWS charges incurred by all of your accounts. You also can get a cost report for each member account that is associated withyour master account. Consolidated billing is offered at noadditional charge.", QuestionId = 60 },
                new Explanation { ExplanationId = 61, Text = "The AWS Documentation mentions the following:<br/>DDoS attacks One of the first techniques to mitigate DDoS attacks is to minimize the surface area that can beattacked thereby limiting the options for attackers and allowing you to build protections in a single place. We want to ensure that we do not expose our application orresources to ports, protocols or applications from wherethey do not expect any communication. Thus, minimizingthe possible points of attack and letting us concentrateour mitigation efforts. In some cases, you can do this byplacing your computation resources behind ContentDistribution Networks (CDNs) or Load Balancers and restricting direct Internet traffic to certain parts of your infrastructure like your database servers. In other cases, you can use firewalls or Access Control Lists (ACLs) tocontrol what traffic reaches your applications.", QuestionId = 61 },
                new Explanation { ExplanationId = 62, Text = "The AWS Documentation mentions the following:<br/>AWS WAF is a web application firewall that lets you monitor the HTTP and HTTPS requests that are forwarded to Amazon CloudFront or an Application Load Balancer. AWS WAF also lets you control access to your content.", QuestionId = 62 },
                new Explanation { ExplanationId = 63, Text = "The AWS Documentation mentions the following:<br/>AWS Multi-Factor Authentication (MFA) is a simple best practice that adds an extra layer of protection on top of your user name and password. With MFA enabled, whena user signs in to an AWS website, they will be promptedfor their user name and password (the first factor-whatthey know), as well as for an authentication code fromtheir AWS MFA device (the second factor-what theyhave). Taken together, these multiple factors provideincreased security for your AWS account settings and resources.", QuestionId = 63 },
                new Explanation { ExplanationId = 64, Text = "The snapshot from the AWS Documentation shows the spectrum of the Disaster recovery methods. If you go to the further end of the spectrum you have the least time for downtime for the users.", QuestionId = 64 },
                new Explanation { ExplanationId = 65, Text = "The AWS Documentation mentions the following:<br/>Amazon S3 is object storage built to store and retrieve any amount of data from anywhere - web sites and mobile apps, corporate applications, and data from IoTsensors or devices. It is designed to deliver99.999999999% durability, and stores data for millionsof applications used by market leaders in every industry.", QuestionId = 65 },
                new Explanation { ExplanationId = 66, Text = "The AWS Documentation mentions the following:<br/>EBS Volumes An Amazon EBS volume is a durable, block-level storage device that you can attach to a single EC2 instance. You can use EBS volumes as primarystorage for data that requires frequent updates, such asthe system drive for an instance or storage for a databaseapplication", QuestionId = 66 },
                new Explanation { ExplanationId = 67, Text = "The AWS Documentation mentions the following:<br/>Amazon VPC Amazon V irtual Private Cloud (Amazon VPC) enables you to launch AWS resources into a virtual network that you've defined. This virtual network closelyresembles a traditional network that you'd operate inyour own data center, with the benefits of using thescalable infrastructure of AWS.", QuestionId = 67 },
                new Explanation { ExplanationId = 68, Text = "The AWS Documentation mentions the following:<br/>The Simple Queue Service Amazon Simple Queue Service(Amazon SQS) offers a reliable, highly-scalable hosted queue for storing messages as they travel between applications or microservices. It moves data between distributed application components and helps youdecouple these components.", QuestionId = 68 },
                new Explanation { ExplanationId = 69, Text = "The AWS documentation mentions the following:<br/>Amazon CloudFront is a web service that speeds up distribution of your static and dynamic web content, suchas .html, .css, .js, and image files, to your users.CloudFront delivers your content through a worldwide network of data centers called edge locations.", QuestionId = 69 },
                new Explanation { ExplanationId = 70, Text = "One of the advantages of EC2 Instances is per secondbilling concept. This is given in the AWS documentation also, With per-second billing, you pay for only what youuse. It takes cost of unused minutes and seconds in anhour off of the bill, so you can focus on improving your applications instead of maximizing usage to the hour.Especially, if you manage instances running for irregularperiods of time, such as dev/testing, data processing, analytics, batch processing and gaming applications, canbenefit.", QuestionId = 70 },
                new Explanation { ExplanationId = 71, Text = "The AWS documentation mentions the following:<br/> Anonline resource to help you reduce cost, increase performance, and improve security by optimizing your AWS environment, Trusted Advisor provides real timeguidance to help you provision your resources following AWS best practices The AWS Inspector can inspect EC 2Instances against common threats.", QuestionId = 71 },
                new Explanation { ExplanationId = 72, Text = "The AWS documentation mentions the following:<br/>Amazon CloudWatch is a monitoring service for AWS cloud resources and the applications you run on AWS.You can use Amazon CloudWatch to collect and trackmetrics, collect and monitor log files, set alarms, and automatically react to changes in your AWS resources.", QuestionId = 72 },
                new Explanation { ExplanationId = 73, Text = "Using CloudWatch trail, one can monitor all the API activity conducted on all AWS services. The AWS Documentation additionally mentions the following:<br/> AWS CloudTrail is a service that enables governance, compliance, operational auditing, and risk auditing of your AWS account. With CloudTrail, you can log, continuously monitor, and retain account activity related toactions across your AWS infrastructure. CloudTrailprovides event history of your AWS account activity, including actions taken through the AWS ManagementConsole, AWS SDKs, command line tools, and other AWS services. This event history simplifies security analysis, resource change tracking, and troubleshooting.", QuestionId = 73 },
                new Explanation { ExplanationId = 74, Text = "Route53 is a domain name system service by AWS. When a Disaster does occur, it can be easy to switch to secondary sites using the Route53 service. The AWS Documentation additionally mentions the following:<br/>Amazon Route 53 is a highly available and scalable cloud Domain Name System (DNS) web service. It isdesigned to give developers and businesses an extremelyreliable and cost effective way to route end users toInternet applications by translating names likewww.example.com into the numeric IP addresses like192.0.2.1 that computers use to connect to each other.Amazon Route 53 is fully compliant with IPv6 as well.", QuestionId = 74 },
                new Explanation { ExplanationId = 75, Text = "It allows developers to easily work with the various AWS resources programmatically", QuestionId = 75 },
                new Explanation { ExplanationId = 76, Text = "Each AZ is a set of one or more data centers. By deploying  your AWS resources to multiple Availability Zones, you are designing with failure with mind. So if one AZ were to go down, the other NDS, would still be up and running and hence your application would be more fault tolerant. For disaster recovery scenarios, one can move ormake resources run in other regions And finally one canuse the Elastic Load Balancer to distribute load tomultiple backend instances within a particular region.", QuestionId = 76 },
                new Explanation { ExplanationId = 77, Text = "The AWS documentation mentions the following:<br/>AWS Identity and Access Management (IAM) is a webservice that helps you securely control access to AWS resources. You use IAM to control who is authenticated(signed in) and authorized (has permissions) to use resources.", QuestionId = 77 },
                new Explanation { ExplanationId = 78, Text = "The AWS documentation mentions the following:<br/>AWS CloudFormation is a service that helps you model and set up your Amazon Web Services resources so thatyou can spend less time managing those resources and more time focusing on your applications that run in AWS.You create a template that describes all the AWS resources that you want (like Amazon EC2 instances orAmazon RDS DB instances), and AWS CloudFormationtakes care of provisioning and configuring thoseresources for you. You don't need to individually createand configure AWS resources and figure out what'sdependent on what; AWS CloudFormation hand les all ofthat", QuestionId = 78 },
                new Explanation { ExplanationId = 79, Text = "The AWS documentation mentions the following:<br/>Amazon Redshift is a fully managed, petabyte-scale data warehouse service in the cloud. You can start with just afew hundred gigabytes of data and scale to a petabyte or more. This enables you to use your data to acquire newinsights for your business and customers.", QuestionId = 79 },
                new Explanation { ExplanationId = 80, Text = "The responsibility of AWS includes the following<br/>1) Securing edge locations<br/>2) Monitoring physical device security<br/>3) Implementing service organization Control (SOC) standards", QuestionId = 80 },
                new Explanation { ExplanationId = 81, Text = "The AWS documentation mentions the following:<br/> on AWS Cost Reports Cost Explorer is a free tool that you can use to view your costs. You can view data up to thelast 13 months, forecast how much you are likely to spend for the next three months, and get recommendations for what Reserved Instances to purchase", QuestionId = 81 },
                new Explanation { ExplanationId = 82, Text = "The entire of control of data within an AWS accountis with the Account Owner.", QuestionId = 82 },
                new Explanation { ExplanationId = 83, Text = "The entire concept of decoupling components is to ensure that the different components of an applications can be managed and maintained separately. If all components are tightly coupled then when one component goes down, the entire application would dodown. Hence it is always a better design practice to decouple application components.", QuestionId = 83 },
                new Explanation { ExplanationId = 84, Text = "Each AZ is a set of one or more data centers. By deploying  your AWS resources to multiple Availability Zones, you are designing with failure with mind. So if one AZ were to go down, the other NDS, would still be up and running and hence your application would be more fault tolerant.", QuestionId = 84 },
                new Explanation { ExplanationId = 85, Text = "As per the Shared Responsibilitv model, the patching of the underlying hardware and physical security of AWS resources is the responsibility of AWS.", QuestionId = 85 },
                new Explanation { ExplanationId = 86, Text = "The concept of Elasticity is the means of an application having the ability to scale up and scale downbased on demand. An example of such a service is the Auto Scaling service.", QuestionId = 86 },
                new Explanation { ExplanationId = 87, Text = "The AWS documentation mentions the following:<br/>Spot Instances are a cost-effective choice if you can be flexible about when your applications run and if your applications can be interrupted. For example, SpotInstances are well-suited for data analysis, batch jobs, background processing, and optional tasks", QuestionId = 87 },
                new Explanation { ExplanationId = 88, Text = "The AWS Management console allows you to accessand manage Amazon Web Services through a simple and intuitive web-based user interface", QuestionId = 88 },
                new Explanation { ExplanationId = 89, Text = "The AWS Documentation mentions the following:<br/>AWS Organizations offers policy-based management For multiple AWS accounts. With Organizations, you can create groups of accounts and then apply policies to thosegroups. Organizations enables you to centrally manage policies across multiple accounts, without requiringcustom scripts and manual processes.", QuestionId = 89 },
                new Explanation { ExplanationId = 90, Text = "The AWS Documentation mentions the following:<br/>AWS Multi-Factor Authentication (MFA) is a simple best practice that adds an extra layer of protection on top of your user name and password.", QuestionId = 90 },
                new Explanation { ExplanationId = 91, Text = "The AWS Documentation mentions the following:<br/>AWS Elastic Beanstalk is an easy-to-use service For deploying and scaling web applications and services developed with Java, .NET, PHP, Node.js, Python, Ruby, Go. and Docker on familiar servers such as ADache.Nginx, Passenger, and IIS.", QuestionId = 91 },
                new Explanation { ExplanationId = 92, Text = "The AWS Documentation mentions the following:<br/>Businesses are using the AWS cloud to enable faster disaster recovery of their critical IT systems without incurring the infrastructure expense of a second physicalIsite. The AWS cloud supports many popular disaster recovery (DR) architectures from 'pilot light' environments that may be suitable for small customerworkload data center failures to 'hot stand by' environments that enable rapid failover at scale.With data centers in Regions all around the world, AWS provides a set of cloud-based disaster recovery services that enable rapid recovery of your IT infrastructure and data.", QuestionId = 92 },
                new Explanation { ExplanationId = 93, Text = "The AWS Documentation mentions the following:<br/>AWS continues to lower the cost of cloud computing For its customers. In 2014, AWS has reduced the cost of compute by an average of 30%, storage by an average of51% and relational databases by an average of 28%. AWS continues to drive down the cost of your IT infrastructure.", QuestionId = 93 },
                new Explanation { ExplanationId = 94, Text = "The AWS Documentation mentions the following:<br/>Amazon CloudFront is a web service that gives businesses and web application developers an easy and cost effective way to distribute content with low latency and high data transfer speeds. Like other AWS services, Amazon CloudFront is a self-service, pay-per-use offering, requiring no long term commitments or minimum fees. With CloudFront, your files are delivered to end-usersusing a global network of edge locations.", QuestionId = 94 },
                new Explanation { ExplanationId = 95, Text = "The AWS Documentation mentions the following:<br/>Amazon DynamoDB is a fast and flexible NoSQL database service for all applications that need consistent, single-digit millisecond latency at any scale. It is a fully managed cloud database and supports both documentand key-value store models. Its flexible data model, reliable performance, and automatic scaling of throughput capacity, makes it a great fit for mobile, web, gaming, ad tech, IoT, and many other applications.", QuestionId = 95 },
                new Explanation { ExplanationId = 96, Text = "The AWS Documentation mentions the following:<br/>Amazon Glacier is a secure, durable, and extremely low-cost cloud storage service for data archiving and long-term backup. It is designed to deliver 99.999999999% durability, and provides comprehensive security and compliance capabilities that can help meet even the most stringent regulatory requirements.", QuestionId = 96 },
                new Explanation { ExplanationId = 97, Text = "When you have instances that will be used continuously and throughout the year, the best option is to buy reserved instances. By buying reserved instances, you are actually allocated an instance for the entire year or the duration you specify with a reduced cost.", QuestionId = 97 },
                new Explanation { ExplanationId = 98, Text = "The AWS Documentation mentions the following:<br/>AWS Direct Connect makes it easy to establish a dedicated network connection from your premises to AWS. Using AWS Direct Connect, you can establish private connectivity between AWS and your datacenter, office, or colocation environment, which in many cases can reduce your network costs, increase bandwidth throughput, and provide a more consistent network experience than Internet-based connections.", QuestionId = 98 },
                new Explanation { ExplanationId = 99, Text = "Screenshot in AWS Doc shows what services the Trusted Advisor Dashboard offers.", QuestionId = 99 },
                new Explanation { ExplanationId = 100, Text = "Amazon S3 is the default storage service that should be considered for companies. If provides durable storage for all static content.", QuestionId = 100 },
                new Explanation { ExplanationId = 101, Text = "The principle means giving a user account only those privileges which are essential to perform its intended function. For example, a user account for the sole purpose of creating backups does not need to install software: hence, it has rights only to run backup and backup-related applications.", QuestionId = 101 },
                new Explanation { ExplanationId = 102, Text = "The AWS Documentation mentions the following:<br/>Amazon Elastic Compute Cloud (Amazon EC2) is a webservice that provides secure, resizable compute capacity in the cloud. It is designed to make web-scale cloud computing easier for developers.", QuestionId = 102 },
                new Explanation { ExplanationId = 103, Text = "The AWS Documentation mentions the following:<br/>A security group acts as a virtual firewall for your instance to control inbound and outbound trafficA network access control list (ACL) is an optional layer ofsecurity for your VPC that acts as a firewall for controllingtraffic in and out of one or more subnets.", QuestionId = 103 },
                new Explanation { ExplanationId = 104, Text = "The AWS Documentation mentions the following:<br/> An Amazon Machine Image (AMI) provides the informationrequired to launch an instance, which is a virtual server in the cloud. You specify an AMI when you launch aninstance, and you can launch as many instances from theAMI as vou need. You can also launch instances from asmany different AMIs as you need.", QuestionId = 104 },
                new Explanation { ExplanationId = 105, Text = "Note that the AWS Console cannot be used to upload data onto Glacier. The console can only be used to createa Glacier vault which can be used to upload the data.", QuestionId = 105 },
                new Explanation { ExplanationId = 106, Text = "The Enterprise support plan has support time less than 15 minutes for Business-critical system down.", QuestionId = 106 },
                new Explanation { ExplanationId = 107, Text = "The AWS Documentation mentions the following:<br/>Amazon CloudFront employs a global network of edge locations and regional edge caches that cache copies of your content close to your viewers. Amazon CloudFrontensures that end-user requests are served by the closest edge location. As a result, viewer requests travel a short distance, improving performance for your viewers. For files not cached at the edge locations and the regional edge caches, Amazon CloudFront keeps persistent connections with your origin servers so that those filescan be fetched from the origin servers as quickly aspossible.", QuestionId = 107 },
                new Explanation { ExplanationId = 108, Text = "The AWS Documentation mentions the following:<br/>Lifecycle configuration enables you to specify the life cycle management of objects in a bucket. The configuration is a set of one or more rules, where eachrule defines an action for Amazon Sp to amolv to a EI‘OUDof objects. These actions can be classified as follows: Transition actions - In which you define when objects transition to another storage class. For example, you may choose to transition obj ects to thestandard _IA (IA, for infrequent access) storage class 30 days after creation, or archive objects to the GLACIER storage class one year after creation. Expiration actions - In which you specifywhen the objects expire. Then Amazon S3 deletes theexpired objects on your behalf.", QuestionId = 108 },
                new Explanation { ExplanationId = 109, Text = "The AWS Documentation mentions the following:<br/> If you are looking to use replication to increase database availability while protecting your latest database updates against unplanned outages, consider running your DBinstance as a Multi-AZ deployment. You can use Multi-AZ deployments and Read Replicas in conjunction toenjoy the complementary benefits of each. You cansimply specify that a given Multi-AZ deployment is thesource DB instance for your Read Replica(s). That wayyou gain both the data durability and availability benefits of Multi-AZ deployments and the read scaling benefits of Read Replicas.", QuestionId = 109 },
                new Explanation { ExplanationId = 110, Text = "Since the requirement is just for 3 months, then the best cost effective option is to use On-Demand Instances.", QuestionId = 110 },
                new Explanation { ExplanationId = 111, Text = "The AWS Documentation mentions the following:<br/>Snowball is a petabyte-scale data transport solution thatuses secure appliances to transfer large amounts ofdata into and out of the AWS cloud. Using Snowball addresses common challenges with large-scale data transfers including high network costs, long transfer times, and security concerns. Transferring data withSnowball is simple, fast, secure, and can be as little asone-fifth the cost of high-speed Internet.", QuestionId = 111 },
                new Explanation { ExplanationId = 112, Text = "With AWS, some of the benefits you have is the 'Pay as you go model' and not having the need to pay up front for using AWS resources.", QuestionId = 112 },
                new Explanation { ExplanationId = 113, Text = "The AWS Documentation mentions the following:<br/>AWS Database Migration Service helps you migrate databases to AWS quickly and securely. The source database remains fully operational during the migration, minimizing downtime to applications that rely on the database. The AWS Database Migration Service canmigrate your data to and from most widely usedcommercial and open-source databases.", QuestionId = 113 },
                new Explanation { ExplanationId = 114, Text = "The AWS Documentation mentions the following:<br/>You can reduce the load on your source DB Instance byrouting read queries from your applications to the read replica. Read replicas allow you to elastically scale out beyond the capacity constraints of a single DB instancefor read-heavy database workloads.", QuestionId = 114 },
                new Explanation { ExplanationId = 115, Text = "Regions correspond to different geographic locations in AWS.", QuestionId = 115 },
                new Explanation { ExplanationId = 116, Text = "If you want a self-managed database, that means you want complete control over the database engine and the underlying infrastructure. In such a case you need to hostthe database on an EC2 Instance", QuestionId = 116 },
                new Explanation { ExplanationId = 117, Text = "The AWS Documentation mentions the following:<br/>Amazon Aurora (Aurora) is a fully managed, MySQL- and PostgreSQL-compatible, relational database engine. Itcombines the speed and reliability of high-endc ommercial databases with the simplicity and cost-effectiveness of open-source databases. It delivers up tofive times the throughput of MySQL and up to three timesthe throughput of PostgreSQL without requiring changes tomost of your existing applications.", QuestionId = 117 },
                new Explanation { ExplanationId = 118, Text = "The concept of Elasticity is the means of an application having the ability to scale up and scale downbased on demand. An example of such a service is the Auto Scaling service.", QuestionId = 118 },
                new Explanation { ExplanationId = 119, Text = "The AWS Documentation mentions the following:<br/> Aload balancer distributes incoming application traffic across multiple EC2 instances in multiple Availability Zones. This increases the fault tolerance of your applications. Elastic Load Balancing detects unhealthy instances and routes traffic only to healthy instances.", QuestionId = 119 },
                new Explanation { ExplanationId = 120, Text = "The AWS Documentation mentions the following:<br/>AWS Auto Scaling monitors your applications and automatically adjusts capacity to maintain steady, predictable performance at the lowest possible cost. Using AWS Auto Scaling, it's easy to setup application scaling for multiple resources across multiple services inminutes.", QuestionId = 120 },
                new Explanation { ExplanationId = 121, Text = "The AWS Documentation mentions the following:<br/>Use this calculator to compare the cost of running your applications in an on-premises or colocation environment toAWS. Describe your on-premises or colocationconfiguration to produce a detailed cost comparisonwith AWS.", QuestionId = 121 },
                new Explanation { ExplanationId = 122, Text = "When you create an EBS volume in an Availability Zone, it is automatically replicated within that zone toprevent data loss due to failure of any single hardwarecomponent", QuestionId = 122 },
                new Explanation { ExplanationId = 123, Text = "The AWS SDK can be plugged in for various programming languages. Using the SDK you can then call the required AWS services.", QuestionId = 123 },
                new Explanation { ExplanationId = 124, Text = "The AWS Documentation mentions the following:<br/> AnIAM role is similar to a user, in that it is an AWS identity with permission policies that determine what the identitycan and cannot do in AWS. However, instead of beinguniquely associated with one person, a role is intended to be assumable by anyone who needs it. Also, a role does not have standard long-term credentials (password oraccess keys) associated with it. Instead, if a user assumesa role, temporary security credentials are created dynamically and provided to the user.", QuestionId = 124 },
                new Explanation { ExplanationId = 125, Text = "The AWS Documentation mentions the following:<br/>You can use the consolidated billing feature in AWS Organizations to consolidate payment for multiple AWS accounts or multiple AISPL accounts. With consolidated billing, you can see a combined view of AWS charges incurred by all of your accounts. You also can get a costreport for each member account that is associated withyour master account. Consolidated billing is offered at noadditional charge.", QuestionId = 125 },
                new Explanation { ExplanationId = 126, Text = "The AWS Documentation mentions the following:<br/> on DDoS attacks One of the first techniques to mitigate DDoS attacks is to minimize the surface area that can beattacked thereby limiting the options for attackers and allowing you to build protections in a single place. Wewant to ensure that we do not expose our application orresources to ports, protocols or applications from wherethey do not expect any communication. Thus, minimizingthe possible points of attack and letting us concentrateour mitigation efforts. In some cases, you can do this byplacing your computation resources behind Content Distribution Networks (CDNs) or Load Balancers and restricting direct Internet traffic to certain parts of your infrastructure like your database servers. In other cases, you can use firewalls or Access Control Lists (ACLs) tocontrol what traffic reaches your applications.", QuestionId = 126 },
                new Explanation { ExplanationId = 127, Text = "The AWS Documentation mentions the following:<br/> AWS Lambda is a compute service that lets you run code without provisioning or managing servers. AWS Lambdaexecutes your code only when needed and scales automatically, from a few requests per day to thousand sper second.", QuestionId = 127 },
                new Explanation { ExplanationId = 128, Text = "The Simple Storage Service and DynamoDB are services where you don't need to manage the underlying infrastructure.", QuestionId = 128 },
                new Explanation { ExplanationId = 129, Text = "The snapshot from the AWS Documentation shows the spectrum of the Disaster recovery methods. If you go to the further end of the spectrum you have the least timefor downtime for the users.", QuestionId = 129 },
                new Explanation { ExplanationId = 130, Text = "The AWS Documentation mentions the following:<br/> Amazon Inspector enables you to analyze the behavior of your AWS resources and helps you to identify potential security issues. Using Amazon Inspector, you can define a collection of AWS resources that you want to include inan assessment target. You can then create an assessment template and launch a security assessment run of thistarget.", QuestionId = 130 },
                new Explanation { ExplanationId = 131, Text = "The AWS Documentation mentions the following:<br/> on AWS SQS Amazon Simple Queue Service (Amazon SQS)offers a reliable, highly-scalable hosted queue for storingmessages as they travel between applications ormicroservices. It moves data between distributed application components and helps you decouple these components.", QuestionId = 131 },
                new Explanation { ExplanationId = 132, Text = "The AWS Documentation mentions the following:<br/> Amazon EMR helps you analyze and process vastamounts of data by distributing the computational workacross a cluster of virtual servers running in the AWS Cloud. The cluster is managed using an open-source framework called Hadoop. Amazon EMR lets you focus on crunching or analyzing your data without having toworry about time-consuming setup, management, and tuning of Hadoop clusters or the compute capacity theyrely on.", QuestionId = 132 },
                new Explanation { ExplanationId = 133, Text = "This is given in the AWS Documentation", QuestionId = 133 },
                new Explanation { ExplanationId = 134, Text = "A fault tolerant system is one that ensures that the entire system works as expected even there are issues.", QuestionId = 134 },
                new Explanation { ExplanationId = 135, Text = "The entire advantage of the AWS Cloud or any cloud system is the ability to have a highly available infrastructure and to use resources on demand", QuestionId = 135 },
                new Explanation { ExplanationId = 136, Text = "The AWS Documentation mentions the following:<br/> CloudFront also integrates with AWS WAF, a web application firewall that helps protect web applications from common web exploits, and AWS Shield, a managed DDoS protection service that safeguards web applications running on AWS.", QuestionId = 136 },
                new Explanation { ExplanationId = 137, Text = "Since all are a part of consolidating billing, the pricing of reserved instances can be shared by all. and since 2 are already used by the Dev team, another one canbe used by the QA team. The rest of the instances can beon-demand instances.", QuestionId = 137 },
                new Explanation { ExplanationId = 138, Text = "Always build components which are loosely coupled. This is so that even if one component does fail, the entiresystem does not fail. Also if you build with theassumption that everything will fail, then you will ensurethat the right measures are taken to build a highly available and fault tolerant system.", QuestionId = 138 },
                new Explanation { ExplanationId = 139, Text = "The AWS Documentation mentions the following:<br/> an online resource to help you reduce cost, increase performance, and improve security by optimizing your AWS environment, Trusted Advisor provides real time guidance to help you provision your resources following AWS best practices.", QuestionId = 139 },
                new Explanation { ExplanationId = 140, Text = "The AWS Documentation mentions the following:<br/> Amazon S3 provides a simple web service interface thatyou can use to store and retrieve any amount of data, atany time, from anywhere on the web", QuestionId = 140 },
                new Explanation { ExplanationId = 141, Text = "All of the other services are all managed by AWS serverless components. Only you have complete control over the EC2 service.", QuestionId = 141 },
                new Explanation { ExplanationId = 142, Text = "The AWS Documentation mentions the following:<br/>AWS Database Migration Service helps you migrate databases to AWS quickly and securely. The source database remains fully operational during the migration, minimizing downtime to applications that rely on the database. The AWS Database Migration Service canmigrate your data to and from most widely usedcommercial and open-source databases.", QuestionId = 142 },
                new Explanation { ExplanationId = 143, Text = "Regions represent different geographic locations and is bets to host your application across multiple regions For disaster recovery", QuestionId = 143 },
                new Explanation { ExplanationId = 144, Text = "The AWS Documentation mentions the following:<br/> AWS Shield - All AWS customers benefit from the automatic protections of AWS Shield Standard, at no additional charge. AWS Shield Standard defends against most common, frequently occurring network and transport layer DDoS attacks that target your web site orapplications AWS Shield Advanced - For higher levels ofprotection against attacks targeting your web applications running on Amazon EC2, Elastic Load Balancing (ELB), CloudFront, and Route 53 resources, you can subscribe to AWS Shield Advanced. AWS Shield Advanced provides expanded DDoS attack protection for these resources.", QuestionId = 144 },
                new Explanation { ExplanationId = 145, Text = "The AWS Documentation mentions the following:<br/> AWS Lambda is a compute service that lets you run codewithout provisioning or managing servers. AWS Lambda executes your code only when needed and scales automatically, from a few requests per day to thousand sper second.", QuestionId = 145 },
                new Explanation { ExplanationId = 146, Text = "The AWS Documentation mentions the following:<br/> Amazon Virtual Private Cloud (Amazon VPC) enables you to launch AWS resources into a virtual network that you've defined. This virtual network closely resembles a traditional network that you'd operate in your own datacenter, with the benefits of using the scalable infrastructure of AWS.", QuestionId = 146 },
                new Explanation { ExplanationId = 147, Text = "The AWS Documentation mentions the following:<br/> the AWS TCO calculator makes it easy to estimate your savings when comparing the cloud to an on-premises orcolocation environment. Use the TCO calculator to get detailed reports and insights into the cost componentsthat make AWS a viable alternative to lower your costs.", QuestionId = 147 },
                new Explanation { ExplanationId = 148, Text = "A region is a geographical area divided into Availability Zones. Each region contains at least two Availability Zones.", QuestionId = 148 },
                new Explanation { ExplanationId = 149, Text = "AWS Doc shows the snapshot of the AWS Shared Responsibility Model.", QuestionId = 149 },
                new Explanation { ExplanationId = 150, Text = "The AWS Documentation mentions the following:<br/> AWS Identity and Access Management (IAM) is a webservice that helps you securely control access to AWS resources. You use IAM to control who is authenticated(signed in) and authorized (has permissions) to useresources.", QuestionId = 150 },
                new Explanation { ExplanationId = 151, Text = "The AWS Documentation mentions the following:<br/>When you create IAM policies, follow the standard security advice of granting least privilege-that is, granting only the permissions required to perform a task. Determine what users need to do and then craft policiesfor them that let the users perform only those tasks.", QuestionId = 151 },
                new Explanation { ExplanationId = 152, Text = "The AWS Documentation mentions the following:<br/>Amazon S3 Transfer Acceleration enables fast, easy, and secure transfers of files over long distances between your client and an S3 bucket. Transfer Acceleration takes advantage of Amazon CloudFront's globally distributededge locations. As the data arrives at an edge location, data is routed to Amazon S3 over an optimized network path.", QuestionId = 152 },
                new Explanation { ExplanationId = 153, Text = "If you see the snapshot from the EC2 on-demand should be considered for companies. If provides durable storage for all static content.", QuestionId = 158 },
                new Explanation { ExplanationId = 159, Text = "The AWS Documentation mentions the following:<br/>Elastic Load Balancing distributes incoming application traffic across multiple EC2 instances, in multiple Availability Zones. This increases the fault tolerance of your applications.", QuestionId = 159 },
                new Explanation { ExplanationId = 160, Text = "The AWS Documentation mentions the following:<br/>AWS Auto Scaling enables you to configure automatic scaling for the scalable AWS resources for your application in a matter of minutes. AWS Auto Scaling uses the Auto Scaling and Application Auto Scaling services to configure scaling policies for your scalable AWS resources.", QuestionId = 160 },
                new Explanation { ExplanationId = 161, Text = "The AWS Documentation mentions the following:<br/>Amazon Aurora (Aurora) is a fully managed, MySQL and PostgreSQL-compatible, relational database engine. It combines the speed and reliability of high-end commercial databases with the simplicity and cost-effectiveness of open-source databases. It delivers up to five times the throughput of MySQL and up to three timesthe throughput of PostgreSQL without requiring changes tomost of your existing applications.", QuestionId = 161 },
                new Explanation { ExplanationId = 162, Text = "The AWS Documentation mentions the following:<br/>Amazon Redshift is a fully managed, petabyte-scale data warehouse service in the cloud. You can start with just a few hundred gigabytes of data and scale to a petabyte or more. This enables you to use your data to acquire newinsights for your business and customers.", QuestionId = 162 },
                new Explanation { ExplanationId = 163, Text = "The AWS Documentation mentions the following:<br/>AWS CloudTrail is a service that enables governance, compliance, operational auditing, and risk auditing of your AWS account. With CloudTrail, you can log, continuously monitor, and retain account activity related toactions across your AWS infrastructure. CloudTrail provides event history of your AWS account activity, including actions taken through the AWS ManagementConsole, AWS SDKs, command line tools, and other AWSservices. This event history simplifies security analysis, resource change tracking, and troubleshooting.", QuestionId = 163 },
                new Explanation { ExplanationId = 164, Text = "You don't need to pay any termination fees when itcomes to EC2 Instances", QuestionId = 164 },
                new Explanation { ExplanationId = 165, Text = "Amazon Glacier is an extremely low-cost storage service that provides secure, durable, and flexible storage for data backup and archival. So Amazon glacier is used for infrequently accessed data and Data archives.", QuestionId = 165 },
                new Explanation { ExplanationId = 166, Text = "The AWS Documentation mentions the following:<br/>Amazon RDS is available on several database instance types - optimized for memory, performance or I/O - and provides you with six familiar database engines to choose from. including Amazon Aurora, PostgreSQL, MySQL, MariaDB, Oracle, and Microsoft SQL Server.", QuestionId = 166 },
                new Explanation { ExplanationId = 167, Text = "The AWS Documentation mentions the following:<br/>AWS Snowball is a service that accelerates transferring large amounts of data into and out of AWS using physical storage appliances, bypassing the Internet. Each AWS Snowball appliance type can transport data at faster-thaninternet speeds. This transport is done by shipping theIdata in the appliances through a regional carrier. Theappliances are rugged shipping containers, complete withE Ink shipping labels.", QuestionId = 167 },
                new Explanation { ExplanationId = 168, Text = "In AWS, there are regions with each region separated in a separate geographic area. Each region has multiple, isolated locations known as Availability Zones. An availability zone is used to host resources in a specific region.", QuestionId = 168 },
                new Explanation { ExplanationId = 169, Text = "The AWS Documentation mentions the following:<br/>A network access control list (ACL) is an optional layer ofsecurity for your VPC that acts as a firewall for controlling traffic in and out of one or more subnets. You might setup network ACLs with rules similar to your securitygroups in order to add an additional layer of security to your VPC.", QuestionId = 169 },
                new Explanation { ExplanationId = 170, Text = "You can use the Consolidated Billing feature to consolidate payment for multiple Amazon Web Services(AWS) accounts or multiple Amazon International Services Pvt. Ltd (AISPL) accounts within your organization by designating one of them to be the payer account. With Consolidated Billing, you can see acombined view of AWS charges incurred by all accounts, as well as get a cost report for each individual account associated with your payer account.", QuestionId = 170 },
                new Explanation { ExplanationId = 171, Text = "The AWS Documentation mentions the following:<br/>Amazon Simple Notification Service (Amazon SNS) is aweb service that enables applications, end-users, and devices to instantly send and receive notifications from the cloud.", QuestionId = 171 },
                new Explanation { ExplanationId = 172, Text = "A policy is a JSON document that specifies what auser can do on AWS. This document consists ofActions: what actions you will allow. Each AWS service has its own set of actions. Resources: which resources you allow theaction on. Effect: what the effect will be when the userrequests access-either allow or deny. The AWS Documentation mentions the following:<br/>A policy is an entity in AWS that, when attached to an identity or resource, defines their permissions. AWS evaluates these policies when a principal, such as a user, makes a request. Permissions in the policies determine whether the request is allowed or denied.", QuestionId = 172 },
                new Explanation { ExplanationId = 173, Text = "A security group acts as a virtual firewall for your instance to control inbound and outbound traffic. When you launch an instance in a VPC, you can assign the instance to up to five security groups. Security groups actat the instance level. Below is an example of a security group which has inbound rules. The below rule states that users can only SSH into EC2 instances that are attached to this security group.", QuestionId = 173 },
                new Explanation { ExplanationId = 174, Text = "The AWS Documentation mentions the following:<br/>Amazon Relational Database Service (Amazon RDS) makes it easy to set up, operate, and scale a relational database in the cloud. It provides cost-efficient and resizable capacity while automating time-consuming administration tasks such as hardware provisioning, database setup, patching and backups. It frees you to focus on your applications so you can give them the fastperformance, high availability, security and compatibilitythey need.", QuestionId = 174 },
                new Explanation { ExplanationId = 175, Text = "The AWS Documentation mentions the following:<br/>Amazon CloudFront employs a global network of edge locations and regional edge caches that cache copies of your content close to your viewers. Amazon CloudFront ensures that end-user requests are served by the closest edge location.", QuestionId = 175 },
                new Explanation { ExplanationId = 176, Text = "AWS CloudFormation gives developers and systems administrators an easy way to create and manage acollection of related AWS resources, provisioning and updating them in an orderly and predictable fashion.", QuestionId = 176 },
                new Explanation { ExplanationId = 177, Text = "When you think of cost effectiveness, you can either have to choose Spot or Reserved instances. Now when you have a regular processing job, the best is to use spotinstances and since your application is designed recover gracefully from Amazon EC2 instance failures, then evenif you lose the Spot instance, there is no issue becauseyour application can recover.", QuestionId = 177 },
                new Explanation { ExplanationId = 178, Text = "Amazon Route 53 provides highly available and scalable Domain Name System (DNS), domain name registration, and health-checking web services. It is designed to give developers and businesses an extremely reliable and cost effective way to route end users to Internet applications by translating names like example.com into the numeric IP addresses, suchas 192.0.2.1, that computers use to connect to each other.", QuestionId = 178 },
                new Explanation { ExplanationId = 179, Text = "AWS Elastic Beanstalk makes it even easier for developers to quickly deploy and manage applications in the AWS Cloud. Developers simply upload their application, and Elastic Beanstalk automatically handles the deployment details of capacity provisioning, load balancing, auto-scaling, and application health monitoring.", QuestionId = 179 },
                new Explanation { ExplanationId = 180, Text = "Amazon ElastiCache is a web service that makes iteasy to deploy, operate, and scale an in-memory datastore or cache in the cloud. The service improves theperformance of web applications by allowing you to retrieve information from fast, managed, in-memory datastores, instead of relying entirely on slower disk-based databases.", QuestionId = 180 },
                new Explanation { ExplanationId = 181, Text = "The AWS Documentation mentions the following:<br/>You can back up the data on your Amazon EBS volumes toAmazon S3 by taking point-in-time snapshots.", QuestionId = 181 },
                new Explanation { ExplanationId = 182, Text = "Amazon Elastic Compute Cloud (Amazon EC2) is a web service that provides resizable compute capacity in the cloud. It is designed to make web-scale cloud computing easier for developers. Amazon ECis simpleweb service interface allows you to obtain and configure capacity with minimal friction. It provides you with complete control of your computing resources and letsyou run on Amazon's proven computing environment. Amazon EC2 reduces the time required to obtain and boot new server instances to minutes, allowing you toquickly scale capacity, both up and down, as your computing requirements change.", QuestionId = 182 },
                new Explanation { ExplanationId = 183, Text = "The AWS Documentation mentions the following:<br/>Amazon RDS Multi-AZ deployments provide enhanced availability and durability for Database (DB) Instances, making them a natural fit for production database workloads. When you provision a Multi-AZ DB Instance, Amazon RDS automatically creates a primary DB Instance and synchronously replicates the data to astand by instance in a different Availability Zone (AZ). Each AZ runs on its own physically distinct, independent infrastructure, and is engineered to be highly reliable. Incase of an infrastructure failure, Amazon RDS performsan automatic failover to the stand by (or to a read replicain the case of Amazon Aurora), so that you can resume database operations as soon as the failover is complete.", QuestionId = 183 },
                new Explanation { ExplanationId = 184, Text = "The AWS Documentation mentions the following:<br/>Cost Explorer is a free tool that you can use to view your costs. You can view your costs as either a cash-based view(costs are recorded when cash is received or paid) with unblended costs or as an accrual-based view (costs are recorded when income is earned or costs are incurred). You can view data for up to the last 13 months, forecasthow much you are likely to spend for the next three months, and get recommendations for what Reserved Instances to purchase", QuestionId = 184 },
                new Explanation { ExplanationId = 185, Text = "You can use Amazon CloudWatch Logs to monitor, store, and access your log files from Amazon Elastic Compute Cloud (Amazon EC2) instances, AWS CloudTrail, and other sources. You can then retrieve the associated log data from CloudWatch Log", QuestionId = 185 },
                new Explanation { ExplanationId = 186, Text = "The AWS Documentation mentions the following:<br/> role is similar to a user, in that it is an AWS identity with permission policies that determine what the identitycan and cannot do in AWS. However, instead of being uniquely associated with one person, a role is intended tobe assumable by anyone who needs it. ", QuestionId = 186 },
                new Explanation { ExplanationId = 187, Text = "AWS Doc shows different support levels available", QuestionId = 187 },
                new Explanation { ExplanationId = 188, Text = "DynamoDB is a fully managed NoSQL offering provided by AWS. It is now available in most regions For users to consume.", QuestionId = 188 },
                new Explanation { ExplanationId = 189, Text = "AWS Doc shows a snapshot of the priciing calculator for AWS S3 For the link to pricing for AWS S3", QuestionId = 189 },
                new Explanation { ExplanationId = 190, Text = "The AWS Doc Shows an array of Software development kits are available for AWS.", QuestionId = 190 },
                new Explanation { ExplanationId = 191, Text = "The AWS Documentation mentions the following:<br/>AWS Direct Connect makes it easy to establish a dedicated network connection from your premises to AWS. Using AWS Direct Connect, you can establish private connectivity between AWS and your datacenter, office, or colocation environment, which in many cases can reduce vour network costs. increase band width throughput, and provide a more consistent network experience than Internet-based connections. You can connect your VPC to remote networks byusing a VPN connection.", QuestionId = 191 },
                new Explanation { ExplanationId = 192, Text = "The AWS Documentation mentions the following:<br/> An Amazon Machine Image (AMI) provides the information required to launch an instance, which is a virtual server in the cloud. You specify an AMI when you launch an instance, and you can launch as many instances from theAMI as you need. You can also launch instances from asmany different AMIs as you need.", QuestionId = 192 },
                new Explanation { ExplanationId = 193, Text = "Since the requirement is just for 3 months, then the best cost effective option is to use On-Demand Instances.", QuestionId = 193 },
                new Explanation { ExplanationId = 194, Text = "The AWS Documentation mentions the following:<br/>You can use the consolidated billing feature in AWS Organizations to consolidate payment for multiple AWS accounts or multiple AISPL accounts. With consolidated billing, you can see a combined view of AWS charges incurred by all of your accounts. You also can get a cost report for each member account that is associated with your master account. Consolidated billing is offered at no additional charge.", QuestionId = 194 }

                );
        }

        private void AddIdentity()
        {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
        private void AddQuestions()
        {
            modelBuilder.Entity<Question>().HasData(
                    new Question { QuestionId = 1, CertificationId = 1, NumberOfCorrectAnswers = 1, Text = "Shall we play a game?" },
                    new Question { QuestionId = 3, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is a benefit of Amazon Elastic Compute Cloud (Amazon <b>EC2</b>) over physical servers?" },
                    new Question { QuestionId = 4, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which AWS service provides infrastructure security optimization recommendations?" },
                    new Question { QuestionId = 5, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which service allows for the collection and tracking of metrics for AWS services?" },
                    new Question { QuestionId = 6, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company needs to know which user was responsible for terminating several critical Amazon Elastic Compute Cloud (Amazon EC2) Instances. Where can the customer find this information?" },
                    new Question { QuestionId = 7, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which service should an administrator use to register a new domain name with AWS?" },
                    new Question { QuestionId = 8, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is the value of having AWS Cloud services accessible through an Application Programming Interface(API)?" },
                    new Question { QuestionId = 9, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following examples supports the cloud design principle 'design for failure and nothing will fail'?" },
                    new Question { QuestionId = 10, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which service allows an administrator to create and modify AWS user permissions?" },
                    new Question { QuestionId = 11, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which AWS service automates infrastructure provisioning and administrative tasks for an analytical data warehouse?" },
                    new Question { QuestionId = 12, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is the responsibility of the AWS customer according to the Shared Security Model?" },
                    new Question { QuestionId = 13, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Where can a customer go to get more detail about Amazon Elastic Compute Cloud(Amazon EC2) billing activity that took place three months ago?" },
                    new Question { QuestionId = 14, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Who has control of the data in an AWS account?" },
                    new Question { QuestionId = 15, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "The main benefit of decoupling an application is to:" },
                    new Question { QuestionId = 16, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is a benefit of running an application across two Availability Zones?" },
                    new Question { QuestionId = 18, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Systems applying the cloud architecture principle of elasticity will" },
                    new Question { QuestionId = 19, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Amazon Elastic Compute Cloud (Amazon EC2) Spot instances are appropriate for which of the following workloads?" },
                    new Question { QuestionId = 20, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What AWS feature enables a user to manage services through a web-based user interface?" },
                    new Question { QuestionId = 21, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which tool can display the distribution of AWS spending?" },
                    new Question { QuestionId = 22, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "How can the AWS Management Console be secured against unauthorized access?" },
                    new Question { QuestionId = 23, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which AWS Cloud service is used to turn on Multi-Factor Authentication (MFA)?" },
                    new Question { QuestionId = 24, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A disaster recovery strategy on AWS should be based on launching infrastructure in a separate:" },
                    new Question { QuestionId = 25, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is a factor when calculating Total Cost of Ownership(TCO) for the AWS Cloud?" },
                    new Question { QuestionId = 26, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which AWS service is used to as a global content delivery network(CDN) service in AWS?" },
                    new Question { QuestionId = 27, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is a fully managed NoSQL database service available with AWS." },
                    new Question { QuestionId = 28, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company wants to store data that is not frequently accessed. What is the best and cost efficient solution that should be considered?" },
                    new Question { QuestionId = 29, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You are currently hosting an infrastructure and most of the EC2 instances are near 90-100% utilized. What is the type of EC2 instances you would utilize to ensure costs are minimized?" },
                    new Question { QuestionId = 30, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is the ability provided by AWS to enable fast, easy, and secure transfers of files over long distances between your client and your Amazon S3 bucket." },
                    new Question { QuestionId = 31, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "As per the AWS Acceptable Use Policy, penetration testing of EC2 instances:" },
                    new Question { QuestionId = 32, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "The Trusted Advisor service provides insight regarding which four categories of an AWS account?" },
                    new Question { QuestionId = 33, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company is deploying a two-tier, highly available web application to AWS. Which service provides durable storage for static content while utilizing lower overall CPU resources for the web tier?" },
                    new Question { QuestionId = 34, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What best describes the 'Principal of Least Privilege'?<br/>Choose the correct answer from the options given below:" },
                    new Question { QuestionId = 35, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the below mentioned services can be used to host virtual servers in the AWS Cloud?" },
                    new Question { QuestionId = 37, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You work for a company that is planning on using the AWS EC2 service. They currently create golden images of their deployed Operating system.<br/>Which of the following correspond to a golden image in AWS." },
                    new Question { QuestionId = 40, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following in the AWS Support plans gives access to a Support Concierge" },
                    new Question { QuestionId = 41, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company is planning to use AWS to host critical resources. Most of their systems are business critical and need to have response times less than 15 minutes. Which of the following support plans should they consider?" },
                    new Question { QuestionId = 42, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is NOT a feature of an edge location?" },
                    new Question { QuestionId = 43, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "There is a requirement object storage. The objects should be able to be downloaded via a URL. Which storage option would you choose?" },
                    new Question { QuestionId = 44, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "There is a requirement to host a database server for a minimum period of one year. Which of the following would result in the least cost?" },
                    new Question { QuestionId = 45, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "There is a requirement for a development and test environment for 3 months. Which would you use?" },
                    new Question { QuestionId = 48, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "There is an external audit being carried out on your company. The IT auditor needs to have a log of all access to the AWS resources in the companys account. Which of the below services can assist in providing the details?" },
                    new Question { QuestionId = 49, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following features of RDS allows for data redundancy across regions?" },
                    new Question { QuestionId = 50, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company has a set of EC2 instances hosted in AWS. There is a requirement to create snapshots from the EBS volumes attached to these EC2 Instances in another geographical location. As per this requirement, where would you create the snapshots?" },
                    new Question { QuestionId = 51, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company wants to host a self-managed database in AWS. How would you ideally implement this solution?" },
                    new Question { QuestionId = 52, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is a compatible MySQL database which also has the ability to grow in storage size on its own." },
                    new Question { QuestionId = 54, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is the concept of the Elastic load balancer?" },
                    new Question { QuestionId = 55, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is the concept of Auto Scaling?" },
                    new Question { QuestionId = 57, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is the responsibility of the customer when ensuring that data on EBS volumes is safe?" },
                    new Question { QuestionId = 58, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following can be used to call AWS services from programming languages?" },
                    new Question { QuestionId = 59, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is the secure way of using AWS API to call AWS services from EC2 Instances?" },
                    new Question { QuestionId = 60, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following are 2 ways that AWS allows tolink accounts?" },
                    new Question { QuestionId = 62, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services can be used as a web application firewall in AWS?" },
                    new Question { QuestionId = 63, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You want to add an extra layer of protection to the current authentication mechanism of user names and passwords for AWS. Which of the following can help in this regard" },
                    new Question { QuestionId = 64, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following disaster recovery deployment mechanisms that has the lowest downtime?" },
                    new Question { QuestionId = 65, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services in AWS allows for object level storage on the cloud?" },
                    new Question { QuestionId = 66, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following can be attached to EC2 Instances to store data?" },
                    new Question { QuestionId = 67, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following networking component can be used to host EC2 resources in the AWS Cloud?" },
                    new Question { QuestionId = 68, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company is planning to host resources in the AWS Cloud. They want to use services which can be used to decouple resources hosted on the cloud. Which of the following services can help fr1lfil this requirement" },
                    new Question { QuestionId = 69, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following components of the CloudFront service can be used to distribute contents to users acrossthe globe?" },
                    new Question { QuestionId = 70, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company is planning to move to the AWS Cloud. You need to give a presentation on the cost perspective when moving existing resources to the AWS Cloud. When it comes to Amazon EC2, which of the following is an advantage when it comes to the cost perspective." },
                    new Question { QuestionId = 71, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company is planning on moving to the AWS Cloud. Once the movement to the Cloud is complete, they want to ensure that the right security settings are put inplace. Which of the below tools can assist from a Security compliance.<br/>Choose <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 72, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "There is a requirement to collect important metrics from AWS RDS and EC2 Instances. Which of the following services can help fullfil this requirement." },
                    new Question { QuestionId = 73, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services can provide acomplete audit trail of all AWS services used within an account?" },
                    new Question { QuestionId = 74, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following service is most useful when a Disaster Recovery method is triggered in AWS." },
                    new Question { QuestionId = 75, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following can be used to work with AWS services in a programmatic manner?" },
                    new Question { QuestionId = 76, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "When designing a system, you use the principle of 'design for failure and nothing will fail'. Which of the following services/features of AWS can assist insupporting this design principle.<br/>Choose <strong>3</strong> answers from the options given below" },
                    new Question { QuestionId = 77, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Currently your organization has an operational team that takes care of ID management in their on-premise data center. They now also need to manage users and groups created in AWS. Which of the following AWS toolswould they need to use for performing this management function." },
                    new Question { QuestionId = 78, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You have a devops team in your current organization's structure. They are keen to know if there is any service available in AWS which can be used to manage infrastructure as code. Which of the following can be met with such a requirement?" },
                    new Question { QuestionId = 79, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services is a fully managed, petabyte-scale data warehouse service in the AWS cloud?" },
                    new Question { QuestionId = 81, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company has just started using the resources onthe AWS Cloud. They want to get an idea on the costs being incurred so far for the resources being used. Howcan this be achieved." },
                    new Question { QuestionId = 82, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "By default who from the below roles has complete administrative control over all resources in the respective AWS account?" },
                    new Question { QuestionId = 83, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your design team is planning to design an application that will be hosted on the AWS Cloud. One of their main non-functional requirements is given below. Reduce inter-dependencies so failures do not impact other components. Which of the following concepts does this requirement relate to?" },
                    new Question { QuestionId = 84, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following can be used to increase the fault tolerance of an application?" },
                    new Question { QuestionId = 85, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following security requirements are managed by AWS?<br/>Select <strong>3</strong> answers from the options given below." },
                    new Question { QuestionId = 86, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following terms relate to <em>'Creating systems that scale to the required capacity based on changes in demand'</em>?" },
                    new Question { QuestionId = 87, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company is planning to offload some of the batch processing workloads on to AWS. These jobs can be interrupted and resumed at any time. Which of the following instance types would be the most cost effective to use for this purpose?" },
                    new Question { QuestionId = 88, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following needs a user name and password to access AWS resources?" },
                    new Question { QuestionId = 89, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company is planning to use the AWS Cloud. But there is a management decision that resources need tosplit department wise. And the decision is tending towards managing multiple AWS accounts. Which of the following would help in effective management and also provide an efficient pricing model." },
                    new Question { QuestionId = 90, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following can be used as an additional layer of security to using a user name and password when logging into the AWS Console?" },
                    new Question { QuestionId = 91, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which AWS Cloud service helps in quick deployment of resources which can make use of different programming languages such as .Net and Java?" },
                    new Question { QuestionId = 92, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company handles a crucial ecommerce application. This applications needs to have an uptime ofat least 99.5%. There is a decision to move the application to the AWS Cloud. Which of the following deployment strategies can help build a robust architecture for such an application." },
                    new Question { QuestionId = 93, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following initiatives from AWS helps organizations reduce the overall expenditure for IT companies when they host resources on the AWS Cloud?" },
                    new Question { QuestionId = 94, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You are planning on deploying a video based application onto the AWS Cloud. These videos will be accessed by users across the world. Which of the below services can help stream the content in an efficient manner to the users across the globe?" },
                    new Question { QuestionId = 95, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is a fully managed NoSQL database service available in AWS?" },
                    new Question { QuestionId = 96, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following storage options is best when you want to store archive data?" },
                    new Question { QuestionId = 97, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "If there is a requirement to host EC2 Instances in the AWS Cloud wherein the utilization is guaranteed to be consistent for a long period of time, which of the following would you utilize to ensure costs are minimized?" },
                    new Question { QuestionId = 98, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services helps provide a dedicated connection from on-premise infrastructure to resources hosted in the AWS Cloud?" },
                    new Question { QuestionId = 99, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is not a category recommendation given by the AWS Trusted Advisor?" },
                    new Question { QuestionId = 100, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company is deploying a two-tier, highly available web application to AWS. The application needs a storage layer to store artefacts such as photos and videos. Which of the following services can be used as the underlyingstorage mechanism." },
                    new Question { QuestionId = 101, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "When giving permission to users via the AWS Identity and Access Management tool, which of the following principles should be applied when granting permissions" },
                    new Question { QuestionId = 102, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the below mentioned services is equivalent to hosting virtual servers on an on-premise location?" },
                    new Question { QuestionId = 103, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You have a set of EC2 Instances hosted on the AWS Cloud. The EC2 Instances are hosting a web application. If you get a DDos attack from the internet which of the following can help in reducing the overall threat to yourEC2 Instances.<br/>Choose <strong>2</strong> answers from the options givenbelow" },
                    new Question { QuestionId = 104, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company currently uses VM Templates to spin up virtual machines on their on-premise infrastructure. Which of the following can be used in a similar way to spin up EC2 instances on the AWS Cloud." },
                    new Question { QuestionId = 105, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the below cannot be used to get data onto Amazon Glacier?" },
                    new Question { QuestionId = 106, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company is planning to pay for an AWS Support plan. They have the following requirements asfar as the support plan goes 24x7 access to Cloud Support Engineers via email, chat & phone. A response time of less than 1 hour for anycritical faultsWhich of the following plans will suffice keeping in mind the cost factor." },
                    new Question { QuestionId = 108, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following storage options provides the option of Lifecycle policies that can be used to move objects to archive storage?" },
                    new Question { QuestionId = 110, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "There is a requirement hosting a set of servers in the Cloud for a short period of 6 months. Which of the following types of instances should be chosen to be costeffective." },
                    new Question { QuestionId = 111, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following from AWS can be used to transfer petabytes of data from on-premise locations to the AWS Cloud?" },
                    new Question { QuestionId = 113, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company wants to move an existing Oracle database to the AWS Cloud. Which of the following services can help facilitate this move." },
                    new Question { QuestionId = 114, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following features of AWS RDS allows for offloading reads of the database?" },
                    new Question { QuestionId = 115, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following terms refers to another geographic location in AWS?" },
                    new Question { QuestionId = 116, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company wants to have a database hosted on AWS. As much as possible they want to have control over the database itself. Which of the following would be an ideal option for this?" },
                    new Question { QuestionId = 117, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company currently has an application which consist of a .Net layer which connects to a MySQL database. They now want to move this application onto AWS. They want to make use of all AWS features such ashigh availability and automated backups. Which of the following would be an ideal database in AWS to migrate tofor this requirement." },
                    new Question { QuestionId = 119, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services relates the concept of <em>'Distributing traffic to multiple EC2 Instances'</em>?" },
                    new Question { QuestionId = 120, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services relates the concept of <em>'Scaling up resources based on demand''</em>?" },
                    new Question { QuestionId = 121, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company is planning to migrate their existing AWS Services to the Cloud. Which of the following would help them do a cost benefit analysis of moving to the AWS Cloud." },
                    new Question { QuestionId = 122, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following does AWS perform on its behalf for EBS volumes to make it less probe to failure?" },
                    new Question { QuestionId = 123, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You have a set of developers that need to use .Net to call AWS Services. Which of the following tools can beused to achieve this purpose." },
                    new Question { QuestionId = 124, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You have an EC2 Instance in development that interacts with the Simple Storage Service. The EC2 Instance is going to be promoted to the production environment. Which of the following features should beused for secure communication between the EC2 Instanceand the Simple Storage Service." },
                    new Question { QuestionId = 125, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following can be used to view one bill when you have multiple AWS Accounts?" },
                    new Question { QuestionId = 126, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Your company is planning to host a large ecommerce application on the AWS Cloud. One of their major concerns is Internet attacks such as DDos attacks. Which of the following services can help mitigate this concern.<br/>Choose <strong>2</strong> answers from the options given below" },
                    new Question { QuestionId = 127, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services is a serverless compute service in AWS?" },
                    new Question { QuestionId = 129, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following disaster recovery deployment machanisms has the highest downtime?" },
                    new Question { QuestionId = 130, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services allows you to analyze EC2 Instances against pre-defined security templates tocheck for vulnerabilities?" },
                    new Question { QuestionId = 131, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following storage mechanisms can be used to store messages effectively which can be used across distributed systems?" },
                    new Question { QuestionId = 132, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You are exploring what services AWS has off-hand. You have a large number of data sets that need to be processed. Which of the following services can help fulfil this requirement." },
                    new Question { QuestionId = 133, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which one of the following features is normally present in all of AWS Support plans?" },
                    new Question { QuestionId = 134, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You are planning to serve a web application on the AWS Platform by using EC2 Instances. Which of the below principles would you adopt to ensure that even if some of the EC2 Instances crashes, you still have a working application?" },
                    new Question { QuestionId = 136, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What AWS service has built-in DDoS mitigation?" },
                    new Question { QuestionId = 137, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You have 2 accounts in your AWS account. One for the Dev and the other for QA. All are part of consolidated billing. The master account has purchase 3 reserved instances. The Dev department is currently using 2 reserved instances. The QA team is planning on using 3 instances which of the same instance type. What is the pricing tier of the instances that can be used by the QA Team?" },
                    new Question { QuestionId = 139, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following AWS services can assist you with cost optimization?" },
                    new Question { QuestionId = 140, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is the amount of storage that can be stored in the Simple Storage service?" },
                    new Question { QuestionId = 141, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which services allow the customer to retain full administrative privileges of the underlying virtual infrastructure?" },
                    new Question { QuestionId = 142, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following AWS services should you use to migrate an existing database to AWS?" },
                    new Question { QuestionId = 143, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You have a mission-critical application which must be globally available at all times. If this is the case, which of the below deployment mechanisms would you employ?" },
                    new Question { QuestionId = 145, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is a serverless compute offering from AWS?" },
                    new Question { QuestionId = 146, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following allows you to carve out aportion of the AWS Cloud?" },
                    new Question { QuestionId = 147, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "In order to predict the cost of moving resources from on-premise to the cloud, which of the following can be used?" },
                    new Question { QuestionId = 148, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is the concept of an AWS region?" },
                    new Question { QuestionId = 150, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following can be used to manage identities in AWS?" },
                    new Question { QuestionId = 151, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is a best practice when working with permissions in AWS?" },
                    new Question { QuestionId = 152, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is the ability provided by AWS to enable very fast, easy, and secure transfers of files over long distances between your client and your Amazon S3 bucket?" },
                    new Question { QuestionId = 153, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "When working on the pricing for on-demand EC2 instances, which are the following are attributes which determine the pricing of the EC2 Instance?<br/>Choose <strong>3/strong> answers from the options given below." },
                    new Question { QuestionId = 154, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company wants to utilize AWS storage. For them low storage cost is paramount, the data is rarely retrieved, and data retrieval times of several hours are acceptable for them. What is the best storage option to use?" },
                    new Question { QuestionId = 156, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is the AWS service provided which provides a fully managed NoSQL database service that provides fast and predictable performance with seamless scalability." },
                    new Question { QuestionId = 157, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You want to monitor the CPU utilization of an EC2 resource in AWS. Which of the below services can help in this regard?" },
                    new Question { QuestionId = 158, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company is deploying a 2-tier, highly available web application to AWS. Which service provides durable storage for static content while utilizing lower Overall CPU resources for the web tier?" },
                    new Question { QuestionId = 159, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which AWS service allows for distribution of incoming application traffic across multiple EC2 instances?" },
                    new Question { QuestionId = 160, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the below AWS services allows you to basethe number of resources on the demand of the applicationor users?" },
                    new Question { QuestionId = 161, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is AWS managed database service provides processing power that is up to 5X faster than a traditional MySQL database?" },
                    new Question { QuestionId = 162, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is AWS services allows you tobuild a data warehouse on the cloud?" },
                    new Question { QuestionId = 163, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services helps in governance,compliance, and risk auditing in AWS?" },
                    new Question { QuestionId = 164, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "When using On-Demand instances in AWS, which of the following is a false statement when it comes to the pricing for the Instance?" },
                    new Question { QuestionId = 165, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "AWS provides a storage option known as Amazon Glacier. What is this AWS service designed for?<br/>Please specify <strong>2</strong> correct options." },
                    new Question { QuestionId = 166, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following is not a supported database in the AWS RDS service?" },
                    new Question { QuestionId = 167, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "There is a requirement to move 10 TB data warehouse to the AWS cloud. Which of the following is an ideal service which can be used to move this amount of data to the AWS Cloud?" },
                    new Question { QuestionId = 168, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is the key difference between an availabilityzone and an edge location?" },
                    new Question { QuestionId = 169, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following security features is associated with a Subnet in a VPC to protect against incoming traffic requests?" },
                    new Question { QuestionId = 170, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "In AWS billing what option can be used to ensure costs can be reduced if you have multiple accounts?" },
                    new Question { QuestionId = 171, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You have a Web application hosted in an EC2 Instance that needs to send notifications based on events. Which of the below services can assist in sending notifications." },
                    new Question { QuestionId = 172, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is a document that provides a formal statement of one or more permissions?" },
                    new Question { QuestionId = 173, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What acts as a firewall that controls the traffic allowed to reach one or more instances?" },
                    new Question { QuestionId = 175, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which AWS service uses Edge Locations for content caching?" },
                    new Question { QuestionId = 176, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company wants to create standard templates for deployment of their infrastructure. Which AWS service can be used in this regard?<br/>Please choose <strong>one</strong> option." },
                    new Question { QuestionId = 177, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You have a distributed application that periodically processes large volumes of data across multiple Amazon EC2 Instances. The application is designed to recover gracefully from Amazon EC2 instance failures. You are required to accomplish this task in the most cost-effectiveway. Which of the following will meet your requirements?" },
                    new Question { QuestionId = 178, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is the service provided by AWS that lets you host Domain Name systems? Please choose an answer from the options below." },
                    new Question { QuestionId = 179, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What is the service provided by AWS that allows developers to easily deploy and manage applications on the cloud? Please choose on answer from the options below." },
                    new Question { QuestionId = 180, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company is deploying a new two-tier web application in AWS. The company wants to store their most frequently used data so that the response time for the application is improved. Which AWS service provides the solution for the company's requirements?" },
                    new Question { QuestionId = 181, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "If you wanted to take a backup of an EBS Volume, what would you do?" },
                    new Question { QuestionId = 182, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What does Amazon EC2 provide?" },
                    new Question { QuestionId = 183, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following options of AWS RDS allows for AWS to failover to a secondary database in case the primary one fails?" },
                    new Question { QuestionId = 184, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What service from AWS can help manage the costsfor all resources in AWS?" },
                    new Question { QuestionId = 185, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What service helps you to aggregate logs from your EC2 instance? Choose one answer from the options below." },
                    new Question { QuestionId = 186, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following items allow an application deployed on an EC2 instance to write data to S3 in asecure manner?" },
                    new Question { QuestionId = 187, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "What are the four levels of AWS Premium Support?" },
                    new Question { QuestionId = 188, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "A company does not want to manage their database. Which of the following services is a fully managed NoSQL database provided by AWS." },
                    new Question { QuestionId = 190, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "If you want to develop an application in Java, which of the following tools would you use?" },
                    new Question { QuestionId = 191, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following services helps provide a connection from on-premise infrastructure to resources hosted in the AWS Cloud?<br/>Choose <strong>2</strong> answers from the options given below" },
                    new Question { QuestionId = 192, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "You want to take a snapshot of an EC2 Instance and create a new instance out of it. In AWS what is this snapshot equivalent to?" },
                    new Question { QuestionId = 193, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "There is a requirement hosting a set of servers in the Cloud for a short period of 3 months. Which of the following types of instances should be chosen to be cost effective?" },
                    new Question { QuestionId = 194, CertificationId = 3, NumberOfCorrectAnswers = 1, Text = "Which of the following concepts is used when you want to manage the bills for multiple accounts under one master account?" },
                    //Questions with Multiple Answers
                    new Question { QuestionId = 17, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following security requirements are managed by AWS customers? <br/>Select <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 36, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following can be used to protect EC2 Instances hosted in AWS<br/>Choose <strong>2</strong> answers from the options given below:" },
                    new Question { QuestionId = 38, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "You are developing and planning on deploying an application onto the AWS Cloud. This application needs to be PCI Compliant. Which of the below steps would you carry out to ensure the compliance is met for the application. <br/>Choose <strong>2</strong> answers." },
                    new Question { QuestionId = 39, CertificationId = 3, NumberOfCorrectAnswers = 3, Text = "Which of the below can be used to get data onto Amazon Glacier?<br/>Choose <strong>3</strong> answers from the options given below." },
                    new Question { QuestionId = 46, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "When creating security groups, which of the following is a responsibility of the customer?<br/>Choose <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 47, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following are advantages of having infrastructure hosted on the AWS Cloud?<br/>Choose <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 53, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following statements are TRUE when itcomes to elasticity?<br/>Choose <strong>2</strong> answers from the options given below" },
                    new Question { QuestionId = 61, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following helps in DDos protection<br/>Choose <strong>2</strong> answers from the options given below?" },
                    new Question { QuestionId = 80, CertificationId = 3, NumberOfCorrectAnswers = 3, Text = "Which of the following is the responsibility of AWS according to the Shared Security Model?<br/>Choose <strong>3</strong> answers from the options given below" },
                    new Question { QuestionId = 107, CertificationId = 3, NumberOfCorrectAnswers = 3, Text = "Which of the following are features of an edge location?<br/>Choose <strong>3</strong> answers from the options given below." },
                    new Question { QuestionId = 109, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following features of Amazon RDS allows for better availability of databases?<br/>Choose <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 112, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "When working with the AWS Cloud which of the following are headaches you don't need to worry about.<br/>Choose <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 118, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following statements are FALSE when it comes to elasticity? <br/>Choose <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 128, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following are services where you don't need to manage the underlyng Infrastructure?<br/>Choose <strong>2</strong>  answers from the options given below." },
                    new Question { QuestionId = 135, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following options would entice acompany to use AWS over an on-premises data center?<br/>Choose <strong>2</strong> answers from the options given below?" },
                    new Question { QuestionId = 138, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following are right principles when designing cloud based systems.<br/>Choose <strong>2</strong> answers fromt he options below?" },
                    new Question { QuestionId = 144, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following can be used to protect against DDos attacks?<br/>Choose <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 149, CertificationId = 3, NumberOfCorrectAnswers = 4, Text = "In AWS, which security aspects are the customer's responsibility?<br/>Choose <strong>4</strong> answers from the options given below." },
                    new Question { QuestionId = 155, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "What are characteristics of Amazon S3?<br/>Choose <strong>2</strong> answers from the options given below." },
                    new Question { QuestionId = 174, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following are benefits of the AWS's Relational Database Service (RDS)?<br/>Choose <strong>2</strong> answers from the options below." },
                    new Question { QuestionId = 189, CertificationId = 3, NumberOfCorrectAnswers = 2, Text = "Which of the following are attributes to the pricing for using the Simple Storage Service?<br/>Choose <strong>2</strong> answers from the options given below." }
                    );
        }

        public void AddCertifications()
        {
            modelBuilder.Entity<Certification>().HasData(
            new Certification
            {
                CertificationId = 1,
                Name = "WOPR",
                Description = "Machine Learning"
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
                Name = "CLF-C01",
                Description = "AWS Cloud Practitioner"
            },
            new Certification
            {
                CertificationId = 4,
                Name = "AZ-900",
                Description = "Microsoft Azure Fundamentals"
            },
             new Certification
             {
                 CertificationId = 5,
                 Name = "DVA-C01",
                 Description = "AWS Certified Developer–Associate"
             },
             new Certification
              {
                CertificationId = 6,
                 Name = "ANS-C00",
                 Description = "AWS Certified Advanced Networking–Specialty"
             }
            );
        }

        private void AddTags()
        {
            modelBuilder.Entity<Tag>().HasData(

                    new Tag
                    {
                        TagId = 1,
                        Name = "Cloud Concepts"
                    },

                    new Tag
                    {
                        TagId = 2,
                        Name = "Security"
                    },

                    new Tag
                    {
                        TagId = 3,
                        Name = "Technology"
                    },

                    new Tag
                    {
                        TagId = 4,
                        Name = "Billing and Pricing"
                    },

                    new Tag
                    {
                        TagId = 5,
                        Name = "Analytics"
                    },

                    new Tag
                    {
                        TagId = 6,
                        Name = "Application Integration"
                    },

                    new Tag
                    {
                        TagId = 7,
                        Name = "AR & VR"
                    },

                    new Tag
                    {
                        TagId = 8,
                        Name = "Cost Management"
                    },

                    new Tag
                    {
                        TagId = 9,
                        Name = "Blockchain"
                    },

                    new Tag
                    {
                        TagId = 10,
                        Name = "Business Applications"
                    },

                    new Tag
                    {
                        TagId = 11,
                        Name = "Management & Governance"
                    },

                    new Tag
                    {
                        TagId = 12,
                        Name = "IoT"
                    },

                    new Tag
                    {
                        TagId = 13,
                        Name = "Machine Learning"
                    },

                    new Tag
                    {
                        TagId = 14,
                        Name = "Compute"
                    },

                    new Tag
                    {
                        TagId = 15,
                        Name = "Migration and Transfer"
                    },

                    new Tag
                    {
                        TagId = 16,
                        Name = "Networking"
                    },
                    new Tag
                    {
                        TagId = 17,
                        Name = "Media Services"
                    },
                    new Tag
                    {
                        TagId = 18,
                        Name = "Database"
                    },

                    new Tag
                    {
                        TagId = 19,
                        Name = "Amazon CloudTrail"
                    },

                    new Tag
                    {
                        TagId = 20,
                        Name = "Amazon Glacier"
                    },

                    new Tag
                    {
                        TagId = 21,
                        Name = "Amazon VPC"
                    },

                    new Tag
                    {
                        TagId = 22,
                        Name = "Subnet"
                    },

                    new Tag
                    {
                        TagId = 23,
                        Name = "AWS Lambda"
                    },

                    new Tag
                    {
                        TagId = 24,
                        Name = "AWS Trusted Advisor"
                    },

                    new Tag
                    {
                        TagId = 25,
                        Name = "Amazon EC2"
                    },

                    new Tag
                    {
                        TagId = 26,
                        Name = "AWS Cost Explorer"
                    },

                    new Tag
                    {
                        TagId = 27,
                        Name = "AWS Config"
                    },

                    new Tag
                    {
                        TagId = 28,
                        Name = "Amazon Inspector"
                    },

                    new Tag
                    {
                        TagId = 29,
                        Name = "AWS Region"
                    },

                    new Tag
                    {
                        TagId = 30,
                        Name = "AWS Edge Location"
                    },

                    new Tag
                    {
                        TagId = 31,
                        Name = "Amazon CloudFront"
                    },

                    new Tag
                    {
                        TagId = 32,
                        Name = "Amazon S3"
                    },

                    new Tag
                    {
                        TagId = 33,
                        Name = "Amazon DynamoDB"
                    },

                    new Tag
                    {
                        TagId = 34,
                        Name = "Amazon ElastiCache"
                    },

                    new Tag
                    {
                        TagId = 35,
                        Name = "AWS Database Migration Service"
                    },

                    new Tag
                    {
                        TagId = 36,
                        Name = "Amazon Aurora"
                    },

                    new Tag
                    {
                        TagId = 37,
                        Name = "Amazon RDS"
                    },

                    new Tag
                    {
                        TagId = 38,
                        Name = "VMware"
                    },

                    new Tag
                    {
                        TagId = 39,
                        Name = "Amazon Redshift"
                    },

                    new Tag
                    {
                        TagId = 40,
                        Name = "Amazon Neptune"
                    },

                    new Tag
                    {
                        TagId = 41,
                        Name = "AWS MongoDB"
                    },

                    new Tag
                    {
                        TagId = 42,
                        Name = "Amazon Storage Gateway"
                    },

                    new Tag
                    {
                        TagId = 43,
                        Name = "Amazon EBS"
                    },

                    new Tag
                    {
                        TagId = 44,
                        Name = "Reserved instances"
                    },

                    new Tag
                    {
                        TagId = 45,
                        Name = "AWS Edge Location"
                    },
                    new Tag
                    {
                        TagId = 46,
                        Name = "Amazon CloudWatch"
                    },
                    new Tag
                    {
                        TagId = 47,
                        Name = "Core AWS Service"
                    },
                    new Tag
                    {
                        TagId = 48,
                        Name = "AWS SNS"
                    },
                    new Tag
                    {
                        TagId = 49,
                        Name = "AWS SQS"
                    },
                    new Tag
                    {
                        TagId = 50,
                        Name = "AWS Elastic Load Balancer"
                    },
                    new Tag
                    {
                        TagId = 51,
                        Name = "Deployment"
                    },
                    new Tag
                    {
                        TagId = 52,
                        Name = "Development with AWS Service"
                    },
                    new Tag
                    {
                        TagId = 53,
                        Name = "Refactoring"
                    },
                    new Tag
                    {
                        TagId = 54,
                        Name = "Monitory and Troubleshooting"
                    },
                    new Tag
                    {
                        TagId = 55,
                        Name = "Hybrid IT Network Architectures"
                    },
                    new Tag
                    {
                        TagId = 56,
                        Name = "Implement AWS newtorks"
                    },
                    new Tag
                    {
                        TagId = 57,
                        Name = "Automate AWS tasks"
                    },
                    new Tag
                    {
                        TagId = 58,
                        Name = "Network integration with application services"
                    },
                    new Tag
                    {
                        TagId = 59,
                        Name = "Security and Compliance"
                    },
                    new Tag
                    {
                        TagId = 60,
                        Name = "Manage newtork"
                    },
                    new Tag
                    {
                        TagId = 61,
                        Name = "Optimize newtork"
                    },
                    new Tag
                    {
                        TagId = 62,
                        Name = "Troubleshoot newtork"
                    }
                );
        }

        private void AddQuestionTags()
        {
            modelBuilder.Entity<QuestionTag>().HasData(
                new QuestionTag
                {
                    QuestionId = 3,
                    TagId = 1
                },
                new QuestionTag
                {
                    QuestionId = 4,
                    TagId = 2
                },
                new QuestionTag
                {
                    QuestionId = 5,
                    TagId = 3
                },
                new QuestionTag
                {
                    QuestionId = 6,
                    TagId = 3
                },
                new QuestionTag
                {
                    QuestionId = 6,
                    TagId = 2
                },
                new QuestionTag
                {
                    QuestionId = 7,
                    TagId = 3
                },
                new QuestionTag
                {
                    QuestionId = 8,
                    TagId = 1
                },
                 new QuestionTag
                 {
                     QuestionId = 23,
                     TagId = 2
                 },
                  new QuestionTag
                  {
                      QuestionId = 24,
                      TagId = 3
                  }
            );
        }

        public void AddCertificationTags()
        {
            modelBuilder.Entity<CertificationTag>().HasData(
                //Cloud Concepts
                new CertificationTag
                {
                    TagId = 1,
                    CertificationId = 3
                },
                //Security
                new CertificationTag
                {
                    TagId = 2,
                    CertificationId = 3
                },
                //Technology
                new CertificationTag
                {
                    TagId = 3,
                    CertificationId = 3
                },
                //Billing and Pricing
                new CertificationTag
                {
                    TagId = 4,
                    CertificationId = 3
                },
                //Analytics
                new CertificationTag
                {
                    TagId = 5,
                    CertificationId = 3
                },
                //Cost Management
                new CertificationTag
                {
                    TagId = 8,
                    CertificationId = 3
                },
                //Compute
                new CertificationTag
                {
                    TagId = 14,
                    CertificationId = 3
                },
                //Database
                new CertificationTag
                {
                    TagId = 18,
                    CertificationId = 3
                },
                //Amazon CloudTrail
                new CertificationTag
                {
                    TagId = 19,
                    CertificationId = 3
                },
                //Amazon Glacier
                new CertificationTag
                {
                    TagId = 20,
                    CertificationId = 3
                },
                 //Amazon VPC
                 new CertificationTag
                 {
                     TagId = 21,
                     CertificationId = 3
                 },
                //AWS Lambda
                new CertificationTag
                {
                    TagId = 23,
                    CertificationId = 3
                },
                //AWS Trusted Advisor
                new CertificationTag
                {
                    TagId = 24,
                    CertificationId = 3
                },
                //Amazon EC2
                new CertificationTag
                {
                    TagId = 25,
                    CertificationId = 3
                },
                //AWS Cost Explorer
                new CertificationTag
                {
                    TagId = 26,
                    CertificationId = 3
                },
                //Amazon Inspector
                new CertificationTag
                {
                    TagId = 28,
                    CertificationId = 3
                },
                //AWS Region
                new CertificationTag
                {
                    TagId = 29,
                    CertificationId = 3
                },
                //AWS Edge Location
                new CertificationTag
                {
                    TagId = 30,
                    CertificationId = 3
                },
                //Amazon CloudFront
                new CertificationTag
                {
                    TagId = 31,
                    CertificationId = 3
                },
                //Amazon S3
                new CertificationTag
                {
                    TagId = 32,
                    CertificationId = 3
                },
                //Amazon RDS
                new CertificationTag
                {
                    TagId = 37,
                    CertificationId = 3
                },
                //Amazon EBS
                new CertificationTag
                {
                    TagId = 43,
                    CertificationId = 3
                },
                //Reserved Instances
                new CertificationTag
                {
                    TagId = 44,
                    CertificationId = 3
                },
                //Edge Location
                new CertificationTag
                {
                    TagId = 45,
                    CertificationId = 3
                },
                //Amazon CloudWatch
                new CertificationTag
                {
                    TagId = 46,
                    CertificationId = 3
                }
                );
        }
    }
}