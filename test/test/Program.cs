using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test
{
    class Program

    {
        static public void Swap(ref NST a, ref NST b)
        {
            NST c = a;
            a = b;
            b = c;
        }
        static public int pow(int a, int b)
        {
            int tong = 1;
            for (int i = 0; i < b; i++)
                tong = tong * a;
            return tong;
        }
        static public int change(char[] a)
        {
            int so = 0;
            for (int i = 3; i >= 0; i--)
            {
                if (Convert.ToInt32(a[i]) - 48 == 1) so = so + pow(2, 3 - i);

            }
            return so;
        }

        public class NST
        {
            public char[] gen = new char[4];
            public int fitness { get; set; }


            public int Fitness()
            {
                return change(gen);
            }

            public NST(char []a)
            {
                get_gen(a);
            }
            public void get_gen(char[] a)
            {
                gen = a;
                get_fitness(a);
               
            }
            public void get_fitness(char[] a)
            {
                fitness = Math.Abs (2 * change(a) + 3 * (change(a) - 1) - 7);
            }
        }

        public void find(population a)

        { 
            


        }

        public class population
        {
            public List<NST> dsNST = new List<NST>();
            public int size;
            public NST best;

            public void show()
            {
                Console.WriteLine(dsNST[0].fitness);
                Console.WriteLine(dsNST[0].gen);
            }

            public void Sort()
            {
                size = dsNST.Count;
                int minValueIndex = 0;
                for (int i = 0; i < dsNST.Count - 1; i++)
                {
                    minValueIndex = i;
                    for (int j = i + 1; j < dsNST.Count; j++)
                    {
                        if (dsNST[j].fitness < dsNST[minValueIndex].fitness)
                        {
                            minValueIndex = j;
                        }
                    }

                    if (minValueIndex != i)
                    {
                        char[] c = dsNST[i].gen;
                        dsNST[i].get_gen(dsNST[minValueIndex].gen);
                        //dsNST[i] = dsNST[minValueIndex];
                        dsNST[minValueIndex].get_gen (c);
                    }
                }
                best = dsNST[0];
             }
        }

            static void Main(string[] args)
            {
                char[] a = new char[4];
                a[0] = '1'; a[1] = '0'; a[2] = '1'; a[3] = '0';
                int so = change(a);
                // function f = 2*x + 3(x-1) -7 =0 

                //Console.WriteLine(pow(2, 3));

                //Console.WriteLine(change(a));
                //Console.WriteLine(2 * so + 3 * (so - 1) - 7);
               
                population pop = new population();
                a[0] = '0'; a[1] = '1'; a[2] = '1'; a[3] = '0';
          
                Console.WriteLine(change(a));
                NST a1 = new NST(a);
                a[0] = '1'; a[1] = '1'; a[2] = '1'; a[3] = '0';
                Console.WriteLine(change(a));
                NST a2 = new NST(a);
                a[0] = '0'; a[1] = '0'; a[2] = '0'; a[3] = '0';
                Console.WriteLine(change(a));
                NST a3 = new NST(a);
                a[0] = '1'; a[1] = '1'; a[2] = '1'; a[3] = '1';
                Console.WriteLine(change(a));
                NST a4 = new NST(a);
                pop.dsNST.Add(a1);
                pop.dsNST.Add(a2);
                pop.dsNST.Add(a3);
                pop.dsNST.Add(a4);
                pop.Sort();
            pop.show();

                Console.ReadLine();

        }
        }
    
}