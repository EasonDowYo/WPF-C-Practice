using System;

using System.Threading;
using System.Threading.Tasks;

namespace TaskTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program start");

            // Generate Task

            // Method 1 
            Task subThread1 = new Task(() => MyTask1());

            // Method 2
            Task subThread2 = new Task(() =>
            {
                for (int i = 0; i < 50; i++)
                    Console.Write("2");
            });

            // Method 3
            Task subThread3 = new Task(MyTask3);


            // Method 4 with input
            Task<string> subThread4 = Task.Run<string>(() => MyTask4("subThread4"));

            // 讓2條線程開始跑
            subThread2.Start();
            subThread1.Start();
            subThread3.Start();

            Task.WhenAll(subThread1, subThread2, subThread3, subThread4).Wait();
            Console.WriteLine(subThread4.Result);

            /*
            // GetAwaiter() : 等待完成, OnCompleted() : 線程完成後要做的事
            subThread1.GetAwaiter().OnCompleted(() => {
                // 線程完成後要做的事
                // 讓2條線程開始跑, 當第一條線程跑完
                subThread4.Start();
                subThread3.Start();
            });
            // GetAwaiter() : 等待完成, GetResult() : 取得結果
            // 實際寫法範例 result =  subThread2.GetAwaiter().GetResult(); (這裡只是因為沒有回傳才這樣寫)
            subThread2.GetAwaiter().GetResult();
            // 等待線程完成才繼續往下走
            subThread3.Wait();
            subThread4.Wait();
            */
        }

        private static void MyTask1()
        {
            for (int i =0; i<150; i++)
                Console.Write("1");
        }
        private static void MyTask2()
        {
            for (int i = 0; i < 150; i++)
                Console.Write("2");
        }
        private static void MyTask3()
        {
            for (int i = 0; i < 150; i++)
                Console.Write("3");
            
        }
        private static string MyTask4(string str)
        {
            Console.Write(str);
            for (int i = 0; i < 150; i++)
                Console.Write("4");
            return "MyTask4Return";
        }

        static void MyMethod2(object message)
        {
            for (int i = 0; i < 500; i++)
            {
                Console.Write(message.ToString());
            }
        }
    }
}
