using System;
using System.Threading.Tasks;

namespace WeihanLi.Common.Helpers
{
    /// <summary>
    /// 重试帮助类
    /// </summary>
    public static class RetryHelper
    {
        public static bool Try(Func<bool> func, int maxRetryTimes = 3)
        {
            bool result = func();
            int time = 1;
            while (!result && time < maxRetryTimes)
            {
                result = func();
                time++;
            }
            return result;
        }

        public static async Task<bool> TryAsync(Func<Task<bool>> func, int maxRetryTimes = 3)
        {
            bool result = await func();
            int time = 1;
            while (!result && time < maxRetryTimes)
            {
                result = await func();
                time++;
            }
            return result;
        }

        public static int Try(Func<int> func, int maxRetryTimes = 3)
            => Try(func, r => r > 0, maxRetryTimes);

        public static Task<int> TryAsync(Func<Task<int>> func, int maxRetryTimes = 3)
            => TryAsync(func, r => r > 0, maxRetryTimes);

        public static TResult Try<TResult>(Func<TResult> func, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = func();
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = func();
                time++;
            }
            return result;
        }

        public static TResult Try<T1, TResult>(Func<T1, TResult> func, T1 t1, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = func(t1);
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = func(t1);
                time++;
            }
            return result;
        }

        public static TResult Try<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 t1, T2 t2, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = func(t1, t2);
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = func(t1, t2);
                time++;
            }
            return result;
        }

        public static TResult Try<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 t1, T2 t2, T3 t3, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = func(t1, t2, t3);
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = func(t1, t2, t3);
                time++;
            }
            return result;
        }

        public static TResult Try<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 t1, T2 t2, T3 t3, T4 t4, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = func(t1, t2, t3, t4);
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = func(t1, t2, t3, t4);
                time++;
            }
            return result;
        }

        public static async Task<TResult> TryAsync<TResult>(Func<Task<TResult>> func, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = await func();
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = await func();
                time++;
            }
            return result;
        }

        public static async Task<TResult> TryAsync<T1, TResult>(Func<T1, Task<TResult>> func, T1 t1, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = await func(t1);
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = await func(t1);
                time++;
            }
            return result;
        }

        public static async Task<TResult> TryAsync<T1, T2, TResult>(Func<T1, T2, Task<TResult>> func, T1 t1, T2 t2, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = await func(t1, t2);
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = await func(t1, t2);
                time++;
            }
            return result;
        }

        public static async Task<TResult> TryAsync<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> func, T1 t1, T2 t2, T3 t3, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = await func(t1, t2, t3);
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = await func(t1, t2, t3);
                time++;
            }
            return result;
        }

        public static async Task<TResult> TryAsync<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, Task<TResult>> func, T1 t1, T2 t2, T3 t3, T4 t4, Func<TResult, bool> validFunc, int maxRetryTimes)
        {
            var result = await func(t1, t2, t3, t4);
            int time = 1;
            while (validFunc(result) && time < maxRetryTimes)
            {
                result = await func(t1, t2, t3, t4);
                time++;
            }
            return result;
        }
    }
}