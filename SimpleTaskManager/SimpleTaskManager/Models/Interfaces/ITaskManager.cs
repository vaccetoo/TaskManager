﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Models.Interfaces
{
    public interface ITaskManager
    {
        IReadOnlyCollection<CustomTask> GetAll();

        void Add(CustomTask task);

        void Display();

        void MarkTaskAsCompleted(int taskId);

        void Delete(int taskId);
    }
}
