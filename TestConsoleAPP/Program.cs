using SearchCharTranslate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleAPP
{
    class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите строку");
                var str = Console.ReadLine();

                try
                {
                    Console.Clear();
                    Console.WriteLine($"Вы ввели : {str}");
                    Console.WriteLine($"Результат преобразования");

                    var res = CharTranslate.TranslateKeyboardsChar(str, out string leng);

                    Console.WriteLine($"Определен язык : {leng}");

                    Console.WriteLine($"Что получилось: {res}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                finally
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            
        }        
    }
}
