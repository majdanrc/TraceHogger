using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;

namespace WasteBubble
{
    class Program
    {
        static readonly List<List<Version>> Handles = new List<List<Version>>();

        static void Main(string[] args)
        {
            var sideTaskObo = Task.Factory.StartNew(LitterTheRoadObo);
            var sideTaskAao = Task.Factory.StartNew(LitterTheRoadAao);
            //var sideTaskKPI = Task.Factory.StartNew(LitterTheRoadKPI);
            
            while (true)
            {
                if (GetAvailableRAM() > 1200)
                {
                    //var handle = Marshal.AllocHGlobal(1024 * 1024);
                    //handles.Add(handle);

                    var versionList = new List<Version>();
                    for (var i = 0; i < 1024*1024; i++)
                    {
                        var vt = new Version();
                        versionList.Add(vt);
                    }
                    Handles.Add(versionList);

                    var available = GetAvailableRAM();

                    Console.WriteLine(available + " MB");
                }
                else
                {
                    var witcher = new Stopwatch();
                    witcher.Start();

                    witcher.Stop();
                    Console.WriteLine("## BOX - KPI time: " + witcher.ElapsedMilliseconds);
                    witcher.Reset();
                }
            }
        }

        public static ulong GetAvailableRAM()
        {
            var ci = new ComputerInfo();
            var mem = ulong.Parse(ci.AvailablePhysicalMemory.ToString());
            return mem / (1024 * 1024);
        }

        public static void LitterTheRoadObo()
        {
            while (true)
            {
                //var listSup = SupplierMock.RandomIds().Aggregate("", (current, supp) => current + (supp + ","));

                Action obo = () =>
                {
                };

                const int taskCount = 10;

                var tasks = new Task[taskCount];

                for (var taskNumber = 0; taskNumber < taskCount; taskNumber++)
                {
                    tasks[taskNumber] = Task.Factory.StartNew(obo);
                }

                Task.WaitAll(tasks);
            }
        }

        public static void LitterTheRoadAao()
        {
            while (true)
            {
                //var listSup = SupplierMock.RandomIds().Aggregate("", (current, supp) => current + (supp + ","));

                Action aao = () =>
                {
                };

                const int taskCount = 10;

                var tasks = new Task[taskCount];

                for (var taskNumber = 0; taskNumber < taskCount; taskNumber++)
                {
                    tasks[taskNumber] = Task.Factory.StartNew(aao);
                }

                Task.WaitAll(tasks);
            }
        }

        public static void LitterTheRoadKPI()
        {

            while (true)
            {
                Action obo = () =>
                {
                };

                const int taskCount = 10;

                var tasks = new Task[taskCount];

                for (var taskNumber = 0; taskNumber < taskCount; taskNumber++)
                {
                    tasks[taskNumber] = Task.Factory.StartNew(obo);
                }

                Task.WaitAll(tasks);
            }
        }
    }
}
