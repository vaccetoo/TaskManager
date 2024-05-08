using SimpleTaskManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleTaskManager.Models
{
    public class FileTaskManager : ITaskManager
    {
        private List<CustomTask> tasks;
        private string filePath;

        public FileTaskManager(string filePath)
        {
            tasks = new List<CustomTask>();

            this.filePath = filePath;

            LoadTasksFromFile();
        }

        public void Add(CustomTask task)
        {
            tasks.Add(task);

            SaveTasksToFile();
        }

        public string Delete(int taskId)
        {
            CustomTask task = tasks.FirstOrDefault(t => t.Id == taskId);

            if (task != null)
            {
                tasks.Remove(task);
                SaveTasksToFile();

                return $"Task {taskId} has been successfully deleted !";
            }
            else
            {
                return $"Task {taskId} not faund !";
            }
        }

        public void Display()
        {
            foreach (CustomTask task in tasks.OrderBy(x => x.Id))
            {
                Console.WriteLine(task);
            }
        }

        public IReadOnlyCollection<CustomTask> GetAll()
            => tasks;

        public string MarkTaskAsCompleted(int taskId)
        {
            CustomTask task = tasks.FirstOrDefault(t => t.Id == taskId);

            if (task != null)
            {
                task.Complete();
                SaveTasksToFile();

                return $"Task {taskId} has been completed !";
            }
            else
            {
                return $"Task {taskId} not faund !";
            }
        }

        private void LoadTasksFromFile()
        {

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line
                        .Split(new[] { " - " }, StringSplitOptions.None);

                    int id = int.Parse(parts[0]
                        .Split(':').Last()
                        .Trim());

                    string description = parts[1]
                        .Split(':')
                        .Last()
                        .Trim();

                    bool isCompleted = parts[2]
                        .Split(':')
                        .Last()
                        .Trim() == "Completed";

                    tasks.Add(new CustomTask(id, description, isCompleted));
                }
            }
        }

        private void SaveTasksToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (CustomTask task in tasks)
                {
                    writer.WriteLine(task.ToString());
                }
            }
        }
    }
}
