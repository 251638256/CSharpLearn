using System;
using ClassLibrary;
using DynamicQuery;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace 基础 {
    public class AsyncHelper {

        public static void Test() {
            //var r = AsyncHelper.WaitNoReturnValue();
            //Task<int> r = AsyncHelper.WaitWithReturnValue();
            //r.GetAwaiter().OnCompleted(() => {
            //    Console.WriteLine("我被执行完毕了 啦啦啦");
            //});
            //Console.WriteLine(r.Result); // 直接使用result相等于等待任务执行完毕 如果没有执行完毕 程序阻塞 如果不阻塞 程序直接退出 不会等待线程执行完毕


            WaitMulti();
            Thread.Sleep(5000);
        }

        /// <summary>
        /// 相当于返回了这个Task 外部使用wait方法可以等待这个方法执行完毕
        /// </summary>
        /// <returns></returns>
        public static async Task WaitNoReturnValue() {
            Task task = Task.Delay(3800);
            //task.Wait();
            await task; // 无返回值直接使用await不需要写return (为什么不用return task<void> ???
        }

        /// <summary>
        /// 奇怪的是 带有值得task就能直接返回
        /// </summary>
        /// <returns></returns>
        public static async Task<int> WaitWithReturnValue() {

            //return await task;

            // 错误 要么彻底阻塞 要么马上就会开始执行阻塞
            //Task<int> task11 = new Task<int>(() => {
            //    Console.WriteLine("ID =" + Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(1000);
            //    return 1;
            //});
            //return await task11;


            // 正确 创建立即执行的任务才可以使用
            //return await Task.Run(() => {
            //    Thread.Sleep(1000);
            //    return 1;
            //});

            // 正确 上面方法的泛型
            return await Task.Run<int>(() => {
                Thread.Sleep(5000);
                return 1;
            });
        }

        public static async void WaitMulti() {
            await Task.Run(() => { Thread.Sleep(500); });
            Console.WriteLine("A");
            await Task.Run(() => { Thread.Sleep(500); });
            Console.WriteLine("B");
            await Task.Run(() => { Thread.Sleep(500); });
            Console.WriteLine("C");
            int i = await Task.Run<int>(() => { Thread.Sleep(500); return 1; });
            Console.WriteLine($"i = {i}");
        }

    }
}