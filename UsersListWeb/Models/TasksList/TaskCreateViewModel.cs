namespace UsersListWeb.Models.TasksList
{
    public class TaskCreateViewModel
    {
        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeadlineDate { get; set; }

        //public int IdUser { get; set; }
    }
}
