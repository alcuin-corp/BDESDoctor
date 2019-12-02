using System;

namespace Alcuin.BDES.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Alcuin\Data\input_sage.xlsx";
            var referenceYear = 2018;
            var request = RequestFactory.Create(filePath, referenceYear);
            request.ProgressChanged += Request_ProgressChanged;
            request.MonitoringMsgPublished += Request_MonitoringMsgPublished;
            request.ProcessFinished += Request_ProcessFinished;
            request.Run();
            Console.ReadKey();
        }

        private static void Request_ProcessFinished(object sender, ProcessFinishedEventArgs e)
        {
            if (e.Exception != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{e.Exception}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Process finished");
        }

        static object obj = new object();

        private static void Request_MonitoringMsgPublished(object sender, MonitoringMsgPublishedEventArgs e)
        {
            lock (obj)
            {
                switch (e.Type)
                {
                    case MonitoringType.Error:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case MonitoringType.Succes:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case MonitoringType.Warrning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        break;
                }

                Console.WriteLine($"{e.Message}");
            }
        }

        private static void Request_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lock (obj)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{e.ProgressRate} %");
            }
        }
    }
}
