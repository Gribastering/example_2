using System;

namespace Тестирование_Форвард._Жиляков_Григорий
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                Console.Write("Здравствуйте." +
                    "\nДля начала теста введите температуру воздуха окружающей среды и модельное время тестирования." +
                    "\nТемпература воздуха окружающей среды, С° (от -100 до + 100): ");
                double t_outside = 0;
                int t_interval = 0;

                try
                {
                    t_outside = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Модельное время, секунд (от 1 до 10): ");
                    t_interval = Convert.ToInt32(Console.ReadLine());
                    if (t_interval < 1 ||
                        t_interval > 10 ||
                        t_outside < -100 ||
                        t_outside > 100)
                    {
                        Console.WriteLine("Параметры заданы неверно, попробуйте еще раз. " +
                            "Нажмите любую клавишу для продолжения.");                      
                        Console.ReadKey();
                        continue;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // входные параметры
                double I = 10;
                double T = 110;
                double Hm = 0.01;
                double Hv = 0.0001;
                double C = 0.1;


                TestStand testStand = new TestStand();

                double res = testStand.StartTest(new Engine(I, T, Hm, Hv, C, t_outside), t_outside, t_interval);
                Console.WriteLine($"Время прошедшее до перегрева ДВС: {res} сек"+
                    "\nНажмите любую клавишу для продолжения.");
                Console.ReadKey();

            } while (true);

        }
    }
}
