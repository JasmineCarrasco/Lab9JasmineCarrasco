Console.Clear();
int TasksCreated = 0;
int TasksRemoved = 0;
int TasksCompleted = 0;
List<(string, string, DateTime)> StartTasks = new List<(string, string, DateTime)>();
Console.WriteLine("Welcome to your to-do program!");
DateTime StartTime = new DateTime();
List<(string, string, DateTime, DateTime)> CompleteTasks = new List<(string, string, DateTime, DateTime)>();
DateTime CompletionTime = new DateTime();


//1

void ToDoItems(){
    Console.WriteLine("The following are your Incomplete items: ");
    for(int x = 0; x <StartTasks.Count; x++){
        Console.WriteLine($" {x + 1}: {StartTasks[x]}");
    }
    if(StartTasks.Count == 0)
    Console.WriteLine("There are not tasks listed.");
    Console.ReadLine();
    TaskMenu();
}
//2
void CompletedTasks(){
    Console.WriteLine("The following are your Completed Tasks: ");
    for(int x = 0; x < CompleteTasks.Count; x++){
    Console.WriteLine($" {x + 1}: {CompleteTasks[x]}");
    }
    if(CompleteTasks.Count == 0)
    Console.WriteLine("YThere are not tasks listed.");
    Console.ReadLine();
    TaskMenu();
}

//3

void AddingItems(){
        Console.WriteLine("Enter a task you would like to add.");
        string response = Console.ReadLine();
        string Task = response;
        Console.WriteLine($"The name of the task is the following: {Task}");
        Console.WriteLine("What is the description?");
        response = Console.ReadLine();
        string Description = response;
        Console.WriteLine($"Task name: {Task}: {Description}");
        Console.WriteLine("Is this correct?\n<y or n>");
        response = Console.ReadLine();
        if(response == "y"){
            Console.WriteLine("The task you entered is now added to your list");
            StartTime = DateTime.Now;
            (string, string, DateTime) TaskToBeDone = (Task, Description, StartTime);
            StartTasks.Add(TaskToBeDone);
            TasksCreated++;
            TaskMenu();
        }
        if(response == "n"){
            Console.WriteLine("Noted.");
            TaskMenu();
        }
    }

//4

void CompletingTasks(){
    Console.WriteLine("WhatTask would you like to mark as complete?");
    for(int x = 0; x <StartTasks.Count; x++){
        Console.WriteLine($" {x + 1}: {StartTasks[x]}");
    }
    Console.WriteLine("(Enter the number.)");
    int NumComp = int.Parse(Console.ReadLine()) - 1;
    if(NumComp > StartTasks.Count){
        Console.WriteLine("Invalid Input");
        TaskMenu();
    }
    Console.WriteLine($"Is this the correct task that you want to mark as Complete {StartTasks[NumComp]}\n<y or n>");
    string response = Console.ReadLine();
    if(response == "y"){
        Console.WriteLine("Noted. Task is now complete congrats!");
        (string, string, DateTime) TaskCompleted = StartTasks[NumComp];
        CompletionTime = DateTime.Now;
        StartTasks.Remove(StartTasks[NumComp]);
        CompleteTasks.Add((TaskCompleted.Item1,TaskCompleted.Item2, TaskCompleted.Item3, CompletionTime));
        TasksCompleted++;
        TaskMenu();
    }
    if(response == "n"){
        Console.WriteLine("Noted.");
        TaskMenu();
    }


    TaskMenu();
}

//5

void RemoveTasks(){
    Console.WriteLine("What Task do you want removed?");

    for(int x = 0; x <StartTasks.Count; x++){
        Console.WriteLine($" {x + 1}: {StartTasks[x]}");
    }
    Console.WriteLine("(Enter the number of the task)");
    int NumComp = int.Parse(Console.ReadLine()) - 1;
    if(NumComp > StartTasks.Count){
        Console.WriteLine("Try again, enter a valid number");
        TaskMenu();
    }
    Console.WriteLine($"Is this the correct task that you want removed? {StartTasks[NumComp]}\n<y or n>");
    string response = Console.ReadLine();
    if(response == "y"){
        Console.WriteLine("Noted, task removed");
        StartTasks.Remove(StartTasks[NumComp]);
        TasksRemoved++;
        TaskMenu();
    }
    if(response == "n"){
        Console.WriteLine("noted");
        TaskMenu();
    }
    Console.ReadLine();
    TaskMenu();
}


//6

void Stats(){
    Console.WriteLine("This is your actvity.");
    Console.WriteLine($"Tasks Created: {TasksCreated} \nTasks Completed: {TasksCompleted} \nTasks Removed: {TasksRemoved}");
    Console.ReadLine();
    TaskMenu();
}

//7 exit 

void exit(){
 Console.WriteLine("Goodbye, come again soon to boost your productivity :)");
    System.Environment.Exit(0);
}

//driver program:task menu

void TaskMenu(){
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1) View tasks that need be done\n2) View InComplete Tasks\n3) Add Tasks\n4) Complete Tasks \n5) Remove Tasks\n6) See Stats\n7) Exit ");
    string response = Console.ReadLine();
    if(response == "1")
        ToDoItems();
    if(response == "2")
        CompletedTasks();
    if(response == "3")
        AddingItems();
    if(response == "4")
       CompletingTasks();
      
    if(response == "5")
      RemoveTasks();

    if(response == "6")
        Stats();
    if(response == "7")
    exit();
}
     TaskMenu();





