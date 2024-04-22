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

        public Engine()
        {
            taskManager = new FileTaskManager(FakeDataBasePath);
            controller = new Controller(taskManager);
        }

        public void Run()
        {
            // Possible commands will be:
            // Add, Delete, Display, Complete 

            Console.WriteLine(WelcomeMessage);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != EndCommand)
            {
                try
                {
                    string[] commandInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string commandType = commandInfo[0];
                    string result = string.Empty;

                    // Add Command:
                    if (commandType == "Add")
                    {
                        string[] taskDiscription = commandInfo
                            .Skip(1)
                            .ToArray();

                        string discription = string.Join(" ", taskDiscription);
                        int taskId = taskManager.GetAll().Count + 1;

                        result = controller.AddTask(taskId, discription);
                    }

                    Console.WriteLine(result);

                    // TODO: End command => Enviroment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
