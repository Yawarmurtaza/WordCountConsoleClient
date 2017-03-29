using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WordCountConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApiWrapper api = new WebApiWrapper();
            int pageCounter = 1;
            Task t = Task.Run(async () =>
            {

                do
                {
                    string jsonString = await api.CallApi(pageCounter++);
                    IEnumerable<WordOccurance> data = api.ConvertIntoModelObject(jsonString);
                    foreach (WordOccurance nextWord in data)
                    {
                        Console.WriteLine($"{nextWord.Word} \t\t\t\t{nextWord.Count}");
                    }
                } while (Console.ReadLine() != "x");
            });

            t.Wait();
        }
    }
}