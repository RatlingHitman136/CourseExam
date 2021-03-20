using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CourseExam
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Array76();
        }

        static void For12()
        {
            int N = int.Parse(Console.ReadLine());
            double ans = 1;
            for (int i = 1; i <= N; i++)
            {
                double curValue = double.Parse("1." + i);
                ans *= curValue;
            }
            Console.WriteLine(ans);
        }

        static void For20()
        {
            int N = int.Parse(Console.ReadLine());
            int cachedMul = 1;
            int ans = 0;
            for (int i = 1; i <= N; i++)
            {
                cachedMul *= i;
                ans += cachedMul;
            }
            
            Console.WriteLine(ans);
        }

        static void For34()
        {
            int N = int.Parse(Console.ReadLine());
            double a_prev = double.Parse(Console.ReadLine());
            double a_cur = double.Parse(Console.ReadLine());

            Console.WriteLine("{0} \n{1}", a_prev, a_cur);

            for (int i = 3; i <= N; i++)
            {
                double a_new = (2 * a_cur + a_prev) / 3;
                a_prev = a_cur;
                a_cur = a_new;
                Console.WriteLine(a_new);
            }
        }
        static void While4()
        {
            int N = int.Parse(Console.ReadLine());
            while (N % 3 == 0)
            {
                N /= 3;
            }
            
            if(N == 1)
                Console.WriteLine("TRUE");
            else
                Console.WriteLine("FALSE");
        }

        static void While12()
        {
            int N = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 1;
            while (sum <= N)
            {
                sum += counter;
                counter++;
            }
            Console.WriteLine(counter-2);
        }
        static void While23()
        {
            int A = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());
            while (Math.Min(A, B) != 0)
            {
                if (A > B)
                {
                    A = A % B;
                }
                else
                {
                    B = B % A;
                }
            }

            Console.WriteLine(Math.Max(A, B));
        }

        static void Series21()
        {
            int N = int.Parse(Console.ReadLine());
            double[] array = new double[N];
            for (int i = 0; i < N; i++)
                array[i] = double.Parse(Console.ReadLine());

            for (int i = 1; i < N; i++)
            {
                if (array[i] < array[i - 1])
                {
                    Console.WriteLine("FALSE");
                    return;
                }
            }

            Console.WriteLine("TRUE");
        }

        static void Proc52()
        {
            int Y = int.Parse(Console.ReadLine());
            Console.WriteLine(IsLeapYear(Y));
        }

        static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        static void MinMax12()
        {
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];
            for (int i = 0; i < N; i++)
                array[i] = int.Parse(Console.ReadLine());
            int min = int.MaxValue;

            for (int i = 0; i < N; i++)
            {
                if (array[i] > 0 && array[i] < min)
                {
                    min = array[i];
                }
            }

            if (min == int.MinValue)
                min = 0;
            Console.WriteLine(min);
        }

        static void Array16()
        {
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];
            for (int i = 0; i < N; i++)
                array[i] = int.Parse(Console.ReadLine());

            for (int i = 0; i < N / 2 + 1; i++)
            {
                Console.WriteLine(array[i]);
                if (i != N - 1 - i)
                    Console.WriteLine(array[N - i - 1]);
            }
        }
        
        static void Array47()
        {
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];
            for (int i = 0; i < N; i++)
                array[i] = int.Parse(Console.ReadLine());

            Array.Sort(array);

            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine(array[i]);
                }
                else
                {
                    if (array[i] != array[i-1])
                    {
                        Console.WriteLine(array[i]);
                    }
                }
            }
        }
        
        static void Array68()
        {
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];
            for (int i = 0; i < N; i++)
                array[i] = int.Parse(Console.ReadLine());
            int MaxValue, MaxValueIndex = 0;
            int MinValue, MinValueIndex = 0;

            MaxValue = int.MinValue;
            MinValue = int.MaxValue;
            
            
            for (int i = 0; i < N; i++)
            {
                if (MaxValue < array[i])
                {
                    MaxValue = array[i];
                    MaxValueIndex = i;
                }
                
                if (MinValue > array[i])
                {
                    MinValue = array[i];
                    MinValueIndex = i;
                }
            }

            array[MaxValueIndex] = MinValue;
            array[MinValueIndex] = MaxValue;
            
            for (int i = 0; i < N; i++)
                Console.Write("{0} ", array[i]);
        }
        
        static void Array76()
        {
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];

            List<int> localMinIndexes = new List<int>();
            
            for (int i = 0; i < N; i++)
                array[i] = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                if (i == 0 && array[i] > array[i + 1])
                {
                    localMinIndexes.Add(i);
                    continue;
                }
                if (i == N-1 && array[i] > array[i - 1])
                {
                    localMinIndexes.Add(i);
                    continue;
                }
                if (array[i] > array[Clamp(i - 1,0,N-1)] && array[i] > array[Clamp(i + 1,0,N-1)])
                {
                    localMinIndexes.Add(i);
                }
            }

            foreach (var VARIABLE in localMinIndexes)
            {
                array[VARIABLE] = 0;
            }
            
            for (int i = 0; i < N; i++)
                Console.Write("{0} ", array[i]);
        }

        static int Clamp(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
        
        static void Array110()
        {
            int N = int.Parse(Console.ReadLine());
            int[] array = new int[N];
            int[] outputArray;
            
            for (int i = 0; i < N; i++)
                array[i] = int.Parse(Console.ReadLine());

            List<int> outputList = new List<int>();

            for (int i = 0; i < N; i++)
            {
                outputList.Add(array[i]);
                if (array[i] % 2 == 0)
                {
                    outputList.Add(array[i]);
                }
            }

            outputArray = outputList.ToArray();
            
            for (int i = 0; i < outputArray.Length; i++)
                Console.Write("{0} ", outputArray[i]);
        }
    }
}