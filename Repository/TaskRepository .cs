using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    public class TaskRepository : BaseRepository<TaskModel>, ITaskRepository
    {
        List<TaskModel> lstTaskModel = new List<TaskModel>();

        private readonly Context _context;

        public TaskRepository()
        {

        }
        public TaskRepository(Context context) : base(context)
        {
            _context = context;


        }
        public  List<TaskModel> GetallTasks()
        {


          

            //List<UserModel> UserModels = new List<UserModel>();

            //UserModel UserModel1 = new UserModel() { Id=10, FirstName="tst", LastName="Test",Email="test@test.com",Password="" };
            //UserModels.Add(UserModel1);



            return lstTaskModel;

        }

       public void CreateTask(TaskModel objTaskModel)
        {

            if (_context.Tasks.Count() == 0)
            {
                _context.Tasks.Add(new TaskModel
                {
                    AssignedUserId = objTaskModel.AssignedUserId,
                    CreatedOn = objTaskModel.CreatedOn,
                    Detail = objTaskModel.Detail,
                    Id = objTaskModel.Id,
                    ProjectId= objTaskModel.ProjectId,
                    Status=objTaskModel.Status
                });
            }
            _context.SaveChanges();

            lstTaskModel.Add(objTaskModel);
        }
       public  string UpdateTask(TaskModel TaskModel)
       {
            var result = lstTaskModel.Find(x => x.Id == TaskModel.Id);
            lstTaskModel.RemoveAll(x => x.Id == TaskModel.Id);
            lstTaskModel.Add(TaskModel);
            //   UserModels.Remove(x => x.id == UserModel.Id);
            string returnresult;
            if (result == null)
            {
                returnresult = "failed";
            }
            else
            {
                returnresult = "success";
            }
            return returnresult;

        }
       public TaskModel GetaTask(int id)
       {
            var result = lstTaskModel.Find(x => x.Id == id);


            return result;

        }
    }
}