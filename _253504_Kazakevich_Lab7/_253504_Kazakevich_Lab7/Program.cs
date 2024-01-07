using _253504_Kazakevich_Lab7.Domain;
using System;


Progress progress = new(1) { Delay = 1 };
var solver = new IntegralSolver(3);
solver.NotifyProgressListeners += (step) =>
{
	progress.Update(step);
};
solver.NotifyCompletionListeners += (result) =>
{
	Console.WriteLine($"\n{result}");
};
solver.Solve();

//1
//var solver1 = new IntegralSolver(2);
//solver1.NotifyCompletionListeners += (result) =>
//{
//    Console.WriteLine(result);
//};

//var thread1 = new Thread(() => solver1.Solve())
//{
//    Priority = ThreadPriority.Highest
//};

//var thread2 = new Thread(() => solver1.Solve())
//{
//    Priority = ThreadPriority.Lowest
//};

//thread1.Start();
//thread2.Start();
//thread1.Join();
//thread2.Join();


//2
//var solver2 = new IntegralSolver(1);
//solver2.NotifyCompletionListeners += (result) =>
//{
//    Console.WriteLine(result);
//};

//Thread[] threads1 = new Thread[5];

//for (int i = 0; i < 5; i++)
//{
//    threads1[i] = new Thread(() => solver2.Solve());
//    threads1[i].Start();
//}

//foreach (var thread in threads1)
//{
//    thread.Join();
//}


//3
//var solver3 = new IntegralSolver(3);
//solver3.NotifyCompletionListeners += (result) =>
//{
//    Console.WriteLine(result);
//};

//Thread[] threads2 = new Thread[5];

//for (int i = 0; i < 5; i++)
//{
//    threads2[i] = new Thread(() => solver3.Solve());
//    threads2[i].Start();
//}

//foreach (var thread in threads2)
//{
//    thread.Join();
//}
