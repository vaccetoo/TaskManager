﻿using SimpleTaskManager.Core.Interfaces;
using SimpleTaskManager.Models;
using SimpleTaskManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Core
{
    public class Controller : IController
    {
        private ITaskManager fileTaskManager;

        public Controller(ITaskManager fileTaskManager)
        {

            this.fileTaskManager = fileTaskManager;

        }

        public string AddTask(int id, string discription)
        {
            CustomTask task = new CustomTask(id, discription);

            fileTaskManager.Add(task);

            return $"Task {id} - {discription} added successfully !";
        }

        public string DeleteTask(int id)
        {
            return fileTaskManager.Delete(id);
        }

        public void DisplayTasks()
        {
            fileTaskManager.Display();
        }

        public string CompleteTask(int taskId)
        {
           return fileTaskManager.MarkTaskAsCompleted(taskId);
        }

        public void CloseApp()
        {
            Environment.Exit(0);
        }
    }
}
