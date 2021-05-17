using System;
using System.Collections.Generic;
using System.Text;

namespace Тестирование_Форвард._Жиляков_Григорий
{
    class TestStand
    {

        public double StartTest(Engine testing_engine, double t_outside, double t_interval) 
        {
            double Time_to_overheat=0;
            
            while (testing_engine.T_engine < testing_engine.T)
            {
                testing_engine.M = testing_engine.Comp_M(testing_engine.V);
                testing_engine.T_engine += (testing_engine.Heats(testing_engine.M)+ testing_engine.Cools(t_outside)) * t_interval;
                testing_engine.V += testing_engine.Comp_Acceliration(testing_engine.M) * t_interval;
                // т.к. зависимость крутящего момента при скорости вращения коленвала более 300 радан/сек не указана
                // ограничиваем максимальную скорость на 300 радиан/сек. 
                // Если раскоментировать это условие, то при некоторых значениях температуры окружающей среды (менее 20), 
                // цикл будет работать бесконечно, т.к. крутящий момент будет равен 0 и нагрев будет компенсироваться охлаждением. Возможно я некорректно построил алгоритм.
                // При необходимости, прошу раскоментировать данное условие.
                //if (testing_engine.V > 300) 
                //{
                //    testing_engine.V = 300;
                //}
                Time_to_overheat += t_interval;
                Console.Clear();
                Console.WriteLine($@"Текущая температура ДВС: {testing_engine.T_engine}
Текущая скорость вращения коленчатого вала: {testing_engine.V}"); 
                System.Threading.Thread.Sleep(1000);
               
            }
            Console.Clear();

            return Time_to_overheat;
        }
    }
}
