using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Himiya.Models
{
    public class HimiyaDbContext:DbContext
    {
        static HimiyaDbContext()
        {
            Database.SetInitializer<HimiyaDbContext>(new HimiyaInitializer());
        }
        public HimiyaDbContext() : base("HimiyaConnect") { }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class HimiyaInitializer : CreateDatabaseIfNotExists<HimiyaDbContext>
    {
        protected override void Seed(HimiyaDbContext context)
        {
            var gr = new Group { Name = "6 класс(Демо)" };
            context.Groups.Add(gr);
            var tst = new Test { Name = "Хімічні елементи(Демо)", Duration = 120, PriceForQuest = 2, QuestsCount = 6, Group = gr, GroupId = gr.Id };
            context.Tests.Add(tst);
            var qs = new List<Question> { new Question {Quest="Як позначається Літій?", Answer="Li", IgnoreCase=false, Test=tst, TestId=tst.Id },
            new Question {Quest="Як називається Na?", Answer="Натрій", IgnoreCase=false, Test=tst, TestId=tst.Id },
            new Question {Quest="Це тестове питання 3", Answer="Тест", IgnoreCase=true, Test=tst, TestId=tst.Id },
            new Question {Quest="Це тестове питання 4", Answer="Тест", IgnoreCase=true, Test=tst, TestId=tst.Id },
            new Question {Quest="Це тестове питання 5", Answer="Тест", IgnoreCase=true, Test=tst, TestId=tst.Id },
            new Question {Quest="Це тестове питання 6", Answer="Тест", IgnoreCase=true, Test=tst, TestId=tst.Id },
            new Question {Quest="Це тестове питання 7", Answer="Тест", IgnoreCase=true, Test=tst, TestId=tst.Id },
            new Question {Quest="Це тестове питання 8", Answer="Тест", IgnoreCase=true, Test=tst, TestId=tst.Id },};
            context.Questions.AddRange(qs);
            context.SaveChanges();
        }
    }
}