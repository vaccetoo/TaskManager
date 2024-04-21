
using SimpleTaskManager.Models;

// Tests for FileTaskManager ...

FileTaskManager fileTaskManager = new FileTaskManager(@"..\..\..\FileTaskManager.txt");

CustomTask task = new CustomTask(1, "Shopping");
CustomTask task1 = new CustomTask(2, "Fitness");
CustomTask task2 = new CustomTask(3, "Study");
CustomTask task3 = new CustomTask(4, "Play games");

fileTaskManager.Add(task);
fileTaskManager.Display();
fileTaskManager.MarkTaskAsCompleted(1);
//fileTaskManager.Add(task1);
//fileTaskManager.Add(task2);
//fileTaskManager.Add(task3);