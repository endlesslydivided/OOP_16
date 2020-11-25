using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace OOP_16
{
    class Program
    {
        public static void EratosSieve1(int n)
        {
            System.Threading.Thread.Sleep(100);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;
            }

            WriteLine($"Все простые числа до {n}:  ");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Write($" {i} ");
                }
            }
            WriteLine();
            sw.Stop();
            WriteLine($"Алгоритм занял {sw.ElapsedMilliseconds} мсек");
        }

        public static CancellationTokenSource tokenSource = new CancellationTokenSource();
        public static void EratosSieve2(int n)
        {
            System.Threading.Thread.Sleep(100);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                WriteLine($"Выполняется задача №{Task.CurrentId}.");
                System.Threading.Thread.Sleep(200);
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;
                
                if(tokenSource.IsCancellationRequested)
                {
                    WriteLine("\n Процесс преждевременно остановлен.");
                    return;
                }
            }
            WriteLine($"Все простые числа до {n}:  ");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Write($" {i} ");
                }
            }
            WriteLine();
            sw.Stop();
            WriteLine($"Алгоритм занял {sw.ElapsedMilliseconds} мсек");
        }


        static void Main()
        {
            #region ЗАДАНИЕ_1

            //Write("Введите n:");
            //int n;
            //n = Convert.ToInt32(ReadLine());

            //Task task = new Task(() => EratosSieve1(n));
            //WriteLine($"Task #{task.Id} статус - {task.Status}");
            //task.Start();

            //while (true)
            //{
            //    System.Threading.Thread.Sleep(10);
            //    WriteLine($"Task #{task.Id} статус - {task.Status}");
            //    if (task.Status == TaskStatus.RanToCompletion)
            //        break;
            //    else
            //        WriteLine($"Task #{task.Id} статус - {task.Status}");
            //}

            //WriteLine($"Task #{task.Id} статус - {task.Status}");

            #endregion

            #region ЗАДАНИЕ_2

            //Write("Введите n:");
            //int n2;
            //n2 = Convert.ToInt32(ReadLine());

            //Task task2 = new Task(() => EratosSieve2(n2));
            //WriteLine($"Task #{task2.Id}  статус - {task2.Status}");
            //task2.Start();

            //WriteLine("\nЧтобы остановить задачу нажмите 0:");
            //string s = ReadLine();
            //if (s == "0")
            //    tokenSource.Cancel();

            //WriteLine($"Task #{task2.Id} статус - выполнено");

            #endregion

            #region ЗАДАНИЕ_3
            //Random rand = new Random();
            //Task<int> rand_num1 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 100) / 1 + 2; });
            //Task<int> rand_num2 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 100) / 3 + 4; });
            //Task<int> rand_num3 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 100) / 5 + 6; });

            //rand_num1.Start();
            //rand_num2.Start();
            //rand_num3.Start();

            //int sum(int a, int b, int c)
            //{ return a + b + c; }

            //Task<int> result = new Task<int>(() => sum(rand_num1.Result, rand_num2.Result, rand_num3.Result));
            //result.Start();

            //WriteLine($"Результат вычислений задачи {result.Id}:{result.Result} ");

            #endregion

            #region ЗАДАНИЕ_4

            ////#region 4.1
            //int Sum(int a, int b) => a + b;
            //void Display(int sum)
            //{ WriteLine($"Сумма равна: {sum}"); }

            //Task<int> task1 = new Task<int>(() => Sum(4, 5));

            //Task task2 = task1.ContinueWith(sum => Display(sum.Result));

            //task1.Start();
            //ReadKey();
            //#endregion

            //#region 4.2

            //Task<int> task3 = new Task<int>(() => Sum(5, 6));

            //TaskAwaiter<int> task3_awaiter = task3.GetAwaiter();
            //int result_1 = task3_awaiter.GetResult();

            //task3.Start();
            //ReadKey();

            //#endregion
            #endregion

            #region ЗАДАНИЕ_5
            //decimal factorial(int x)
            //{
            //    decimal result = 1;

            //    for (decimal i = 1; i <= x; i++)
            //    {
            //        result *= i;
            //    }
            //    return result;
            //}


            //int[][] arr_1 = new int[10][];
            //List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            //Stopwatch sw_1 = new Stopwatch();
            //Random rand = new Random();
            //WriteLine($"Инициализация 10 массивов по 100000 элементов.\n");
            //sw_1.Start();
            //Parallel.For(0, arr_1.Length, (int i) =>
            //{
            //    arr_1[i] = new int[1000000];
            //    for (int item = 0; item < 1000000; item++)
            //    {
            //        arr_1[i][item] = rand.Next(0, 100);
            //    }
            //});
            //WriteLine($"Процесс завершён и занял {sw_1.ElapsedMilliseconds} мсек");
            //sw_1.Restart();
            //WriteLine($"\nВычисление факториала чисел от 1 до 20.\n");
            //Parallel.ForEach(list, (a) => Console.WriteLine("Факториал числа " + a + " равен " + factorial(a)));
            //WriteLine($"\nПроцесс завершён и занял {sw_1.ElapsedMilliseconds} мсек");
            #endregion

            #region ЗАДАНИЕ_6

            //Parallel.Invoke
            //(
            //    () => { Thread.Sleep(1000); WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); },
            //    () => { Thread.Sleep(1000); WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); },
            //    () => { Thread.Sleep(1000); WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); },
            //    () => { Thread.Sleep(1000); WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); },
            //    () => { Thread.Sleep(1000); WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); }
            //);
            #endregion

            #region ЗАДАНИЕ_7

            //BlockingCollection<string> bc = new BlockingCollection<string>(5);
            //CancellationTokenSource ts = new CancellationTokenSource();

            //Task[] sellers = new Task[10]
            //{
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Доска"); } }),
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Гвоздь"); } }),
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Лист ПВХ"); } }),
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Шуруп"); } }),
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Столешница"); } }),

            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Подоконник"); } }),
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Вазон"); } }),
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Дверная ручка"); } }),
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Стояк"); } }),
            //    new Task (()=>{while (true) { Thread.Sleep(700); bc.Add("Зеркало"); } }),
            //};

            //Task[] consumers = new Task[5]
            //{
            //    new Task(() => { while(true){ Thread.Sleep(200);   bc.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(500);   bc.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(250);   bc.Take(); } })
            //};

            //foreach (var item in sellers)
            //    if (item.Status != TaskStatus.Running)
            //        item.Start();

            //foreach (var item in consumers)
            //    if (item.Status != TaskStatus.Running)
            //        item.Start();
            //int count = 0;
            //while (true)
            //{
            //    if (bc.Count != count && bc.Count != 0)
            //    {
            //        count = bc.Count;
            //        Thread.Sleep(400);
            //        Clear();
            //        WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬Склад▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            //        foreach (var item in bc)
            //            WriteLine(item);

            //        if (ts.IsCancellationRequested)
            //        {
            //            WriteLine("\n Процесс остановлен.");
            //            return;
            //        }
            //        WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            //    }
            //}
            #endregion

            #region ЗАДАНИЕ_8
            //void Factorial()
            //{
            //    int result = 1;
            //    for (int i = 1; i <= 6; i++)
            //    {
            //        result *= i;
            //    }
            //    Thread.Sleep(1000);
            //    WriteLine($"Факториал равен {result}");
            //}

            //async void FactorialAsync()
            //{
            //    WriteLine("Начало метода FactorialAsync");
            //    await Task.Run(() => Factorial());
            //    WriteLine("Конец метода FactorialAsync");
            //}

            //FactorialAsync();
            //WriteLine("main продолжает свое выполнение");
            //ReadKey();
            #endregion
            ReadKey();
        }
    }
}
