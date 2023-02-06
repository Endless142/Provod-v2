using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace provodnik
{
    internal class Strelka

    {
        int minimum;
        int maximum;

        public Strelka(int a, int b)
        {
            minimum = a;
            maximum = b;
        }

        public void Draw(int i)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine("->");        
        }

        public int Mini()
        {
            return minimum;
        }

        public int Max()
        {
            return maximum;
        }

        public void Del(int i)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine("  ");
        }

    }
}
