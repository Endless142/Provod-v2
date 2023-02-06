using System;
using System.IO;

namespace provodnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int position = 2;
            string cStr, cStr1;
            Strelka strel = new Strelka(2, 10);
            ConsoleKeyInfo key;

            while (true)
            {
                katalog vd = new katalog();
                cStr = vd.ViborDiska();

                while (true)
                {
                    katalog kat = new katalog();
                    cStr1 = kat.Drawkat(cStr);
                    cStr = cStr1;
                    if (cStr == "Disk")
                        {
                        break;
                        }
                }
            }
        }      
    }
}
    