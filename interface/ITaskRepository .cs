using System.Collections.Generic;

namespace WebApplication1
{ 
    public interface ITaskRepository
    {
    List<TaskModel> GetallTasks();
        void CreateTask(TaskModel TaskModel);
        string UpdateTask(TaskModel TaskModel);
        TaskModel GetaTask(int id);
}
}