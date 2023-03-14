using UsersList.Logic.Models.TasksList;
using UsersList.Logic.Models.UsersList;
using UsersListLogic.Models.UsersList;
using UsersListWeb.Models.UsersList;

namespace UsersListWeb.Models.TasksList
{
    public class TasksListViewModel
    {
        public List<TaskViewModel> Tasks { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }
        public TasksListViewModel()
        {
            Tasks = new List<TaskViewModel>();
        }

        public TasksListViewModel(TaskListDTO taskList, int page, int size)
        {
            Tasks = new List<TaskViewModel>();
            foreach (TaskDTO task in taskList.Tasks)
            {
                Tasks.Add(new TaskViewModel(task));
            }
            TotalCount = taskList.TotalCount;
            Page = page;
            Size = size;

            CanBack = Page > 0;
            CanForward = (Page + 1) * Size < TotalCount;
        }
    }
}
