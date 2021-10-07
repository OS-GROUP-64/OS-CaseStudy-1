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
        static int NUM_THREAD = Environment.ProcessorCount;

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
            //Console.WriteLine("\n\nFirst Index :" + firstIndex);
            int lastIndex = (int)(1000000000 * ((threadN + 1)*1.0 / N*1.0));
            //Console.WriteLine("Last Index :" + lastIndex);
            int index;
            long result = 0;
            for(index = firstIndex ; index < lastIndex ; index++)
            {
                //Console.Write(Data_Global[index]);
                if (Data_Global[index] % 2 == 0)
                {
                    result -= Data_Global[index];
                }
                else if (Data_Global[index] % 3 == 0)
                {
                    result += (Data_Global[index] * 2);
                }
                else if (Data_Global[index] % 5 == 0)
                {
                    result += (Data_Global[index] / 2);
                }
                else if (Data_Global[index] % 7 == 0)
                {
                    result += (Data_Global[index] / 3);
                }
                Data_Global[index] = 0;
            }
            return result;
        }

        static void worker(object num)
        {
            long Sum_Local = 0;
            Sum_Local = sum((int)num, NUM_THREAD); //#threadNumber, all threads
            //Console.WriteLine("Summation W1 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int y;

            Console.WriteLine("Thread Num : {0}", NUM_THREAD);
            Thread[] threadsArray = new Thread[NUM_THREAD];

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
            Console.Write("\n\nWorking...\n");
            sw.Start();

            for (int i=0; i<NUM_THREAD; i++)
            {
                threadsArray[i] = new Thread(worker);
                threadsArray[i].Start(i);
            }
            for (int i=0; i<NUM_THREAD; i++)
                threadsArray[i].Join();     

            sw.Stop();
            Console.WriteLine("Done.");           
            /* STOP */



            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}