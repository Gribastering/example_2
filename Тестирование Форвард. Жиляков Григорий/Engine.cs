using System;
using System.Collections.Generic;
using System.Text;

namespace Тестирование_Форвард._Жиляков_Григорий
{
    class Engine
    {       
            public double I { get; private set; }

            private double[] m_array = { 20, 75, 100, 105, 75, 0 };

            private double[] v_array = { 0, 75, 150, 200, 250, 300 };
            public double T { get; private set; }
            public double Hm { get; private set; }
            public double Hv { get; private set; }
            public double C { get; private set; }

            // текущее значение температуры охлаждающей жидкости ДВС
            public double T_engine { get; set; }

            // текущее значение скорости вращения коленчатого вала ДВС
            public  double V { get; set; }
            // текущее значение крутящего момента ДВС
            public  double M { get; set; }

            public Engine(double I, double T, double Hm, double Hv, double C, double T_outside)
            {
                this.I = I;
                this.T = T;
                this.Hm = Hm;
                this.Hv = Hv;
                this.C = C;
                T_engine = T_outside;
                V = 0;
            }

            public double Comp_M(double V_current)
            {
                int index = -1;

                for (int i = 0; i < v_array.Length; i++)
                {
                    if (v_array[i] == V_current)
                    {
                        return m_array[i];
                    }
                    else if (v_array[i] > V_current)
                    {
                        index = i;
                        // вычисляем текущее значение крутящего момента ДВС
                        return m_array[index - 1] + (m_array[index] - m_array[index - 1])
                            * (V_current - v_array[index - 1]) / (v_array[index] - v_array[index - 1]);
                    }                    
                }
                
                return 1;
            }

            public double Heats(double M)
            {            
                return (M * Hm) + (Math.Pow(V, 2) * Hv);
            }
            public double Cools(double T_outside)
            {            
                return C * (T_outside - T_engine);
            }
            public double Comp_Acceliration(double M_current)
            {
                return M_current / I;
            }        
    }
}
