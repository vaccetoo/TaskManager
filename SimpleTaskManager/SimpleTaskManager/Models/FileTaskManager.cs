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

            CreateFileTaskManagerFile(filePath);
        }

        public void Add(CustomTask task)
        {
            tasks.Add(task);

            SaveTasksToFile();
        }

        public void Delete(int taskId)
        {
            CustomTask task = tasks.FirstOrDefault(t => t.Id == taskId);

            if (task != null)
            {
                tasks.Remove(task);
                SaveTasksToFile();
            }
            else
            {
                Console.WriteLine("Task not faund !");
            }
        }

        public void Display()
        {
            foreach (CustomTask task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        public IReadOnlyCollection<CustomTask> GetAll()
            => tasks;

        public void MarkTaskAsCompleted(int taskId)
        {
            CustomTask task = tasks.FirstOrDefault(t => t.Id == taskId);

            if (task != null)
            {
                task.Complete();
                SaveTasksToFile();
            }
            else
            {
                Console.WriteLine("Task not faund !");
            }
        }

        private void CreateFileTaskManagerFile(string filePath)
        {
            // If the file exist will use it, if not will create new one

            if (File.Exists(filePath))
            {
                this.filePath = filePath;
            }
            else
            {
                File.Create(filePath).Close();
                this.filePath = filePath;
            }
        }

        private void SaveTasksToFile()
        {
            File.Delete(this.filePath);

            foreach (CustomTask task in tasks)
            {
                File.AppendAllText(filePath, task.ToString() + Environment.NewLine);
            }
        }
    }
}
