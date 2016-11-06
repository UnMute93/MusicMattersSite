using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileLogic
{
    class Program
    {
        Thread MainThread;
        bool StopFlag = false;

        public void Start()
        {
            try
            {
                if (MainThread != null)
                {
                    if (MainThread.ThreadState == ThreadState.Running)
                    {
                        Console.WriteLine("Stopping current thread");

                        //Lock to prevent other threads accessing thread 
                        lock (MainThread)
                        {
                            MainThread.Abort();
                        }
                    }
                }
                MainThread = new Thread(Run);
                StopFlag = false;
                MainThread.Start();
            }
            catch (Exception ex)
            {
                //ToDo: Logging to file or eventlog
                Console.WriteLine(ex.Message);
            }
        }

        private void Run()
        {
            try
            {
                Console.WriteLine("Starting...");
                FileChecker fileChecking = new FileChecker(@"C:\temp\AVP400");
                while (StopFlag != true)
                {
                    fileChecking.AddFilesToDatabase();
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                //ToDo: Logging to file or eventlog
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            //ToDo: Logging to file or eventlog
            Console.WriteLine("Stopping...");
            StopFlag = true;
        }
    }
}
