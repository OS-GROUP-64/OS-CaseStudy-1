using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Problem01
{
    class Program
    {
        static byte[] Data_Global = new byte[1000000000];
        static long Sum_Global = 0;
        static int NofThread = 12;

        static int ReadData()
        {
            int returnData = 0;
            FileStream fs = new FileStream("Problem01.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            try 
            {
                Data_Global = (byte[]) bf.Deserialize(fs);
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Read Failed:" + se.Message);
                returnData = 1;
            }
            finally
            {
                fs.Close();
            }

            return returnData;
        }
        static long sum(int threadN, int N)
        {
            int firstIndex = (int)(1000000000 * (threadN*1.0 / N*1.0));
            Console.WriteLine("\n\nFirst Index :" + firstIndex);
            int lastIndex = (int)(1000000000 * ((threadN + 1)*1.0 / N*1.0));
            Console.WriteLine("Last Index :" + lastIndex);
            int index;
            long result = 0;
            for(index = firstIndex ; index < lastIndex ; index++)
            {
                if (Data_Global[index] % 2 == 0)
                {
                    result -= Data_Global[index];
                }
                else if (Data_Global[index] % 3 == 0)
                {
                    result += (Data_Global[index]*2);
                }
                else if (Data_Global[index] % 5 == 0)
                {
                    result += (Data_Global[index] / 2);
                }
                else if (Data_Global[index] %7 == 0)
                {
                    result += (Data_Global[index] / 3);
                }
                Data_Global[index] = 0;
            }
            return result;
        }

        static void worker1()
        {
            long Sum_Local = 0;
            Sum_Local = sum(0,NofThread);
            Console.WriteLine("Summation W1 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker2()
        {
            long Sum_Local = 0;
            Sum_Local = sum(1,NofThread);
            Console.WriteLine("Summation W2 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker3()
        {
            long Sum_Local = 0;
            Sum_Local = sum(2,NofThread);
            Console.WriteLine("Summation W1 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker4()
        {
            long Sum_Local = 0;
            Sum_Local = sum(3,NofThread);
            Console.WriteLine("Summation W2 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }
        static void worker5()
        {
            long Sum_Local = 0;
            Sum_Local = sum(4,NofThread);
            Console.WriteLine("Summation W1 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker6()
        {
            long Sum_Local = 0;
            Sum_Local = sum(5,NofThread);
            Console.WriteLine("Summation W2 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker7()
        {
            long Sum_Local = 0;
            Sum_Local = sum(6,NofThread);
            Console.WriteLine("Summation W1 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker8()
        {
            long Sum_Local = 0;
            Sum_Local = sum(7,NofThread);
            Console.WriteLine("Summation W2 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker9()
        {
            long Sum_Local = 0;
            Sum_Local = sum(8,NofThread);
            Console.WriteLine("Summation W1 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker10()
        {
            long Sum_Local = 0;
            Sum_Local = sum(9,NofThread);
            Console.WriteLine("Summation W2 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker11()
        {
            long Sum_Local = 0;
            Sum_Local = sum(10,NofThread);
            Console.WriteLine("Summation W1 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker12()
        {
            long Sum_Local = 0;
            Sum_Local = sum(11,NofThread);
            Console.WriteLine("Summation W2 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker13()
        {
            long Sum_Local = 0;
            Sum_Local = sum(12,NofThread);
            Console.WriteLine("Summation W2 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }


        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int y;

            /* Thread */
            Thread th1 = new Thread(worker1);
            Thread th2 = new Thread(worker2);
            Thread th3 = new Thread(worker3);
            Thread th4 = new Thread(worker4);
            Thread th5 = new Thread(worker5);
            Thread th6 = new Thread(worker6);
            Thread th7 = new Thread(worker7);
            Thread th8 = new Thread(worker8);
            Thread th9 = new Thread(worker9);
            Thread th10 = new Thread(worker10);
            Thread th11 = new Thread(worker11);
            Thread th12 = new Thread(worker12);

            /* Read data from file */
            Console.Write("Data read...");
            y = ReadData();
            if (y == 0)
            {
                Console.WriteLine("Complete.");
            }
            else
            {
                Console.WriteLine("Read Failed!");
            }

            /* Start */
            Console.Write("\n\nWorking...");
            sw.Start();
            
            th1.Start();
            th2.Start();
            th3.Start();
            th4.Start();
            th5.Start();
            th6.Start();
            th7.Start();
            th8.Start();
            th9.Start();
            th10.Start();
            th11.Start();
            th12.Start();

            th1.Join();
            th2.Join();
            th3.Join();
            th4.Join();
            th5.Join();
            th6.Join();
            th7.Join();
            th8.Join();
            th9.Join();
            th10.Join();
            th11.Join();
            th12.Join();

            sw.Stop();
            Console.WriteLine("Done.");

            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}