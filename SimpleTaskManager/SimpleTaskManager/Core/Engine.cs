using SimpleTaskManager.Core.Interfaces;
using SimpleTaskManager.Models;
using SimpleTaskManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Core
{
    public class Engine : IEngine
    {
        private const string FakeDataBasePath = @"..\..\..\FakeDataBase.txt";
        ITaskManager taskManager;
        IController controller;

        private const string WelcomeMessage = "WELCOME TO -=TASK MANAGER=-";
        private const string EndCommand = "End";
        private const string WrongCommand = "Incorrect command !";

        public Engine()
        {
            taskManager = new FileTaskManager(FakeDataBasePath);
            controller = new Controller(taskManager);
        }

        public void Run()
        {
            // Possible commands will be:
            // Add, Delete, Display, Complete, End

            Console.WriteLine(WelcomeMessage);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != EndCommand)
            {
                try
                {
                    string[] commandInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string commandName = commandInfo[0];

                    string result = string.Empty;

                    // Add:
                    if (commandName == "Add")
                    {
                        string[] taskDiscription = commandInfo
                            .Skip(1)
                            .ToArray();

                        string discription = string.Join(" ", taskDiscription);
                        int taskId = taskManager.GetAll().Count + 1;

                        ITask[] tasks = taskManager.GetAll().OrderBy(x => x.Id).ToArray();

                        // Do not dublicate Id's
                        if (tasks.Any(x => x.Id == taskId))
                        {
                            for (int i = 0; i < taskManager.GetAll().Count; i++)
                            {
                                if (tasks[i].Id != i + 1)
                                {
                                    taskId = tasks[i].Id - 1;
                                    break;
                                }
                            }
                        }

                        result = controller.AddTask(taskId, discription);
                    }
                    // Delete:
                    else if (commandName == "Delete")
                    {
                        int taskId = int.Parse(commandInfo[1]);

                        result = controller.DeleteTask(taskId);
                    }
                    // Display:
                    else if (commandName == "Display")
                    {
                        controller.DisplayTasks();
                    }
                    // Complete:
                    else if (commandName == "Complete")
                    {
                        int taskId = int.Parse(commandInfo[1]);

                        result = controller.CompleteTask(taskId);
                    }
                    // End:
                    else if (commandName == EndCommand)
                    {
                        controller.CloseApp();
                    }
                    else
                    {
                        result = WrongCommand;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
