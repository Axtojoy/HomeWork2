using UsersList.Logic.Models.TasksList;
using UsersList.Logic.Models.UsersList;
using UsersListLogic.Models.UsersList;
using UsersListWeb.Models.UsersList;

namespace UsersListWeb.Models.TasksList
{
    public class TasksListModel
    {
        public List<TaskModel> Tasks { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }
        public TasksListModel()
        {
            Tasks = new List<TaskModel>();
        }

        public TasksListModel(TaskListDTO taskList, int page, int size)
        {
            Tasks = new List<TaskModel>();
            foreach (TaskDTO task in taskList.Tasks)
            {
                Tasks.Add(new TaskModel(task));
            }
            TotalCount = taskList.TotalCount;
            Page = page;
            Size = size;

            CanBack = Page > 0;
            CanForward = (Page + 1) * Size < TotalCount;
        }
    }
}
