using System.Diagnostics.Tracing;
using System.Diagnostics;

namespace Task_13_6_1
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            string text = File.ReadAllText("C:\\Users\\swnike\\Downloads\\cdev_Text.txt");

            char[] delimiters = new char[] { ' ', ',', '.', '-', '\r', '\n' };
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            Console.WriteLine($"Кол-во слов в массиве {words.Length}");

            var booklist = new List<string>();
            var linkedbooklist = new LinkedList<string>();

            foreach (var word in words)
            {
                booklist.Add(word);
                linkedbooklist.AddLast(word);
            }
            Console.WriteLine($"Кол-во слов в списке {booklist.Count}");

            Stopwatch stopWatch_tick = new Stopwatch();
            stopWatch_tick.Start();

            var findedword = linkedbooklist.Find(words[20]);
            if (findedword != null)
                linkedbooklist.AddAfter(findedword, "Крыса");

            stopWatch_tick.Stop();
            Console.WriteLine($"Время ввода элемента в связанный список составило { stopWatch_tick.Elapsed.TotalMilliseconds} мс");

            stopWatch_tick.Start();
            booklist.Insert(21, "Лошадь");
            stopWatch_tick.Stop();
            Console.WriteLine($"Время ввода элемента в обычный список составило {stopWatch_tick.Elapsed.TotalMilliseconds} мс");
        }
    }
}
