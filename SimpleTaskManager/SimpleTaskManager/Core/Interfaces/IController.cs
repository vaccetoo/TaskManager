using SimpleTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManager.Core.Interfaces
{
    public interface IController
    {
        string AddTask(int id, string discription);
    }
}
