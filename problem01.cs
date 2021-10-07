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
        static int G_index = 0;

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
        static void sum()
        {
            if (Data_Global[G_index] % 2 == 0)
            {
                Sum_Global -= Data_Global[G_index];
            }
            else if (Data_Global[G_index] % 3 == 0)
            {
                Sum_Global += (Data_Global[G_index]*2);
            }
            else if (Data_Global[G_index] % 5 == 0)
            {
                Sum_Global += (Data_Global[G_index] / 2);
            }
            else if (Data_Global[G_index] %7 == 0)
            {
                Sum_Global += (Data_Global[G_index] / 3);
            }
            Data_Global[G_index] = 0;
            G_index++;   
        }

        static void worker1()
        {
            int i;
            long Sum_Local = 0;
            int L_index = 0;
            for(i=0;i < 500000000; i++)
            {
                if (Data_Global[L_index] % 2 == 0)
                {
                    Sum_Local -= Data_Global[L_index];
                }
                else if (Data_Global[L_index] % 3 == 0)
                {
                    Sum_Local += (Data_Global[L_index]*2);
                }
                else if (Data_Global[L_index] % 5 == 0)
                {
                    Sum_Local += (Data_Global[L_index] / 2);
                }
                else if (Data_Global[L_index] %7 == 0)
                {
                    Sum_Local += (Data_Global[L_index] / 3);
                }
                Data_Global[L_index] = 0;
                L_index++; 
            }
            // Console.WriteLine("Summation W1 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void worker2()
        {
            int i;
            long Sum_Local = 0;
            int L_index = 500000000;
            for(i=500000000;i < 1000000000; i++)
            {
                if (Data_Global[L_index] % 2 == 0)
                {
                    Sum_Local -= Data_Global[L_index];
                }
                else if (Data_Global[L_index] % 3 == 0)
                {
                    Sum_Local += (Data_Global[L_index]*2);
                }
                else if (Data_Global[L_index] % 5 == 0)
                {
                    Sum_Local += (Data_Global[L_index] / 2);
                }
                else if (Data_Global[L_index] %7 == 0)
                {
                    Sum_Local += (Data_Global[L_index] / 3);
                }
                Data_Global[L_index] = 0;
                L_index++; 
            }
            // Console.WriteLine("Summation W2 result: {0}", Sum_Local);
            Sum_Global+=Sum_Local;
        }

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int i, y;

            /* Thread */
            Thread th1 = new Thread(worker1);
            Thread th2 = new Thread(worker2);

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
            th1.Join();
            th2.Join();
            // for (i = 0; i < 1000000000; i++){
            //     sum();
            // }           
            sw.Stop();
            Console.WriteLine("Done.");

            /* Result */
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}
