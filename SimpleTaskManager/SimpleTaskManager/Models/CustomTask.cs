using SimpleTaskManager.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Models
{
    public class CustomTask : ITask
    {
        private int id;
        private string discription;
        private bool isCompleted;

        public CustomTask(int id, string discription)
        {
            Id = id;
            Discription = discription;

            isCompleted = false;
        }

        public int Id
        {
            get => id; 
            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Task Id must be a positive number !");
                }
                id = value;
            }
        }

        public string Discription
        {
            get => discription; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Discription can not be null or white space !");
                }
                discription = value;
            }
        }

        public bool IsCompleted
            => isCompleted;

        public void Complete()
            => isCompleted = true;

        public override string ToString()
            => $"ID: {Id} - Discription: {Discription} - Status: {(IsCompleted ? "Completed" : "Not completed")}";
    } 
}
