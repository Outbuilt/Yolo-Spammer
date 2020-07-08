using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Yolo_Spammer
{
    class Program
    {
        public static int Total { get; set; }
        public static int Spam { get; set; }
        public static void Start()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The YOLO ID are the 10 numbers you find on the top link | ie, https://onyolo.com/(h514ekAAPT)");
            Console.WriteLine("The Question is the other thing that is not where you input the message | ie, Send anonymous messages to Outbuilt");
            Console.WriteLine("The Message is any message that you want spammed...");
            Console.WriteLine();
            Console.WriteLine("Amount to spam: ");
            string Original = Console.ReadLine();
            int Duration = Int32.Parse(Original);
            Console.WriteLine("Yolo ID (10 digits): ");
            string id = Console.ReadLine();
            Console.WriteLine("Question: ");
            string question = Console.ReadLine();
            Console.WriteLine("Message: ");
            string message = Console.ReadLine();
            Console.WriteLine();
            while (true)
            {
                if(Duration == Total)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine($"Successfully spammed {Duration} messages!");
                    Console.WriteLine($"Press any key to exit");
                    Console.ReadKey();
                    Process.GetCurrentProcess().Kill();
                }
                string RemoteUrl = $"https://onyolo.com/{id}/message";
                var httpReq = (HttpWebRequest)WebRequest.Create(RemoteUrl);
                httpReq.Proxy = null;
                httpReq.Method = "POST";
                httpReq.ContentType = httpReq.Accept = "application/json";
                using (var stream = httpReq.GetRequestStream())
                using (var sw = new StreamWriter(stream))
                {
                    sw.Write("{\"text\":\"" + message + "\",\"cookie\":\"" + Cookie(21) + "\",\"wording\":\"" + question + "\"}");
                }
                using (var response = httpReq.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    if (reader.ReadToEnd() == "ok")
                    {
                        Total = Total + 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--> Successfully sent spam!");
                        Console.Title = $"YOLO SPAMMER | CODED BY OUTBUILT.OOO | Total Spammed: {Total}";
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--> Failed to send spam!");
                        Console.Title = $"YOLO SPAMMER | CODED BY OUTBUILT.OOO | Total Spammed: {Total}";
                    }
                }
            }
        }
        private static Random random = new Random();
        public static string Cookie(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static void Main(string[] args)
        {
            Console.Title = "[FREE] YOLO SPAMMER | OUTBUILT.OOO";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Outbuilt's YOLO Spammer :)");
            Console.WriteLine("Made for debugging YOLO's API for education purposes...");
            Console.WriteLine("This is a free product provided by OUTBUILT.OOO");
            Console.WriteLine("If you paid for this you have been scammed!");
            Thread.Sleep(3000);
            Start();
        }
    }
}
