using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Models.Interfaces
{
    public interface ITask
    {
        public int Id { get; }

        public string Discription {  get; }

        public bool IsCompleted { get; }

        void Complete();
    }
}
