using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himiya.Models.Abstract
{
    public interface IStore
    {
        //получение списков
        IEnumerable<Group> GetGroupsList();
        IEnumerable<Test> GetTestsListByGroup(int groupId);
        IEnumerable<Question> GetQuestionsListByTest(int testId);
        IEnumerable<Result> GetResultsList();

        void ClearResults();
        void WriteResult(Result result);

        //управление группами
        Group GetGroup(int id);
        int CreateGroup(Group group);
        int UpdateGroup(Group group);
        void DeleteGroup(int id);

        //управление тестами
        Test GetTest(int id);
        int CreateTest(Test test);
        int UpdateTest(Test test);
        void DeleteTest(int id);

        //управление вопросами
        Question GetQuestion(int id);
        int CreateQuestion(Question question);
        int UpdateQuestion(Question question);
        void DeleteQuestion(int id);

        //общее
        void Save();
    }
}
