using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            request.Run();
            Console.ReadKey();
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
