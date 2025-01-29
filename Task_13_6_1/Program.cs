using System.Diagnostics.Tracing;
using System.Diagnostics;

namespace Task_13_6_1
{
    internal class Program
    {
        //Наша задача — сравнить производительность вставки в List<T> и LinkedList<T>.Для этого используйте StopWatch.
        static void Main(string[] args)
        {
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText("C:\\Users\\swnik\\Downloads\\cdev_Text.txt");

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', ',', '.', '-', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            Console.WriteLine(words.Length);

            var booklist = new List<string>();
            var linkedbooklist = new LinkedList<string>();

            foreach (var word in words)
            {
                booklist.Add(word);
                linkedbooklist.AddLast(word);
            }
            Console.WriteLine(booklist.Count);
            Console.WriteLine();

            Stopwatch stopWatch_tick = new Stopwatch();
            stopWatch_tick.Start();

            var findedword = linkedbooklist.Find(words[20]);
            if (findedword != null)
                linkedbooklist.AddAfter(findedword, "Крыса");

            stopWatch_tick.Stop();
            Console.WriteLine(stopWatch_tick.Elapsed.TotalMilliseconds);

            booklist.Insert(21, "Лошадь");

        }
    }
}
