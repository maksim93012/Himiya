using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Himiya.Models.Abstract;

namespace Himiya.Models.Entities
{
    public class Store : IStore
    {
        HimiyaDbContext dbContext;
        public Store()
        {
            dbContext = new HimiyaDbContext();
        }

        public int CreateGroup(Group group)
        {
            if (group == null) throw new ArgumentNullException();
            return dbContext.Groups.Add(group).Id;
        }

        public int CreateQuestion(Question question)
        {
            if (question == null) throw new ArgumentNullException();
            return dbContext.Questions.Add(question).Id;
        }

        public int CreateTest(Test test)
        {
            if (test == null) throw new ArgumentNullException();
            return dbContext.Tests.Add(test).Id;
        }

        public void DeleteGroup(int id)
        {
            var del = dbContext.Groups.Find(id);
            dbContext.Groups.Remove(del);
        }

        public void DeleteQuestion(int id)
        {
            var del = dbContext.Questions.Find(id);
            dbContext.Questions.Remove(del);
        }

        public void DeleteTest(int id)
        {
            var del = dbContext.Tests.Find(id);
            dbContext.Tests.Remove(del);
        }

        public Group GetGroup(int id)
        {
            return dbContext.Groups.Find(id);
        }

        public IEnumerable<Group> GetGroupsList()
        {
            return dbContext.Groups.ToList();
        }

        public Question GetQuestion(int id)
        {
            return dbContext.Questions.Find(id);
        }

        public IEnumerable<Question> GetQuestionsListByTest(int testId)
        {
            return dbContext.Questions.Where(x => x.TestId == testId).ToList();
        }

        public Test GetTest(int id)
        {
            return dbContext.Tests.Find(id);
        }

        public IEnumerable<Test> GetTestsListByGroup(int groupId)
        {
            return dbContext.Tests.Where(x => x.GroupId == groupId).ToList();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public int UpdateGroup(Group group)
        {
            var g = dbContext.Groups.Find(group.Id);
            g.Name = group.Name;
            return g.Id;
        }

        public int UpdateQuestion(Question question)
        {
            var q = dbContext.Questions.Find(question.Id);
            q.Quest = question.Quest;
            q.Answer = question.Answer;
            q.IgnoreCase = question.IgnoreCase;
            return q.Id;
        }

        public int UpdateTest(Test test)
        {
            var t = dbContext.Tests.Find(test.Id);
            t.Name = test.Name;
            t.QuestsCount = test.QuestsCount;
            t.PriceForQuest = test.PriceForQuest;
            t.Duration = test.Duration;
            return t.Id;
        }

        public IEnumerable<Result> GetResultsList()
        {
            return dbContext.Results.ToList().OrderBy(x => x.DateTime).Reverse();
        }

        public void ClearResults()
        {
            foreach (var item in dbContext.Results)
                dbContext.Results.Remove(item);
        }
        public void WriteResult(Result result)
        {
            dbContext.Results.Add(result);
        }
    }
}