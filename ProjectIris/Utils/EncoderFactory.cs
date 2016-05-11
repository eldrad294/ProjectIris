using ProjectIris.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectIris.Utils
{
    public class EncoderFactory
    {
        public static string EncodeIris(string Filename)
        {
            int ExitCode;
            string BinaryString = "";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Anaconda2\python.exe";//cmd is full path to python.exe
            //start.Arguments = @"C:\Users\eldrad294\Desktop\python\IrisEncoder.py";//args is path to .py file and any cmd line args
            string path = @"C:\inetpub\wwwroot\ProjectIris\ProjectIris\Scripts\python\IrisEncoder.py " + Filename;
            start.Arguments = path;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    BinaryString += result;
                }
                ExitCode = process.ExitCode;
                //BinaryString = ExitCode.ToString();
                return BinaryString;
            }
        }

        //public static string RecognizeIris(string Filename, Entities db)
        //{
        //    string IrisCode = EncodeIris(Filename);

        //    var clients = db.clients;
        //    foreach (var client in clients)
        //    {
        //        if (client.iriscode == IrisCode)
        //        {
        //            return client.clientidnumber;
        //        }
        //    }

        //    //Returns empty string if account is not recognized
        //    return "";
        //}

        public static string RecognizeIris(string Filename, Entities db)
        {
            string IrisCode = EncodeIris(Filename);
            var clients = db.clients;
            Dictionary<int, int> HammingDict = new Dictionary<int, int>();

            foreach(client client in clients)
            {
                //Console.WriteLine(client.iriscode.Length);
                HammingDict.Add(client.id, GetHammingDistance(IrisCode, client.iriscode));
            }

            var OrderedHammingDict = HammingDict.OrderBy(key => key.Value);

            foreach (var item in OrderedHammingDict)
            {
                if(item.Value < IrisCode.Length / 3.5)
                {
                    return db.clients.Find(item.Key).clientidnumber;
                }
            }
            return "";
        }

        private static int GetHammingDistance(string IrisCode, string IrisCodeTemp)
        {
            int HammingDifference = 0;
            for(int i = 0; i < IrisCode.Length; i++)
            {
                if(IrisCode[i] != IrisCodeTemp[i])
                {
                    HammingDifference++;
                }
            }
            return HammingDifference;
        }
    }
}