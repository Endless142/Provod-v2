using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace provodnik
{
    internal class katalog
    {

        public string ViborDiska()
        {
            int position = 3;
            ConsoleKeyInfo key;
            List<string> aMas = new List<string>();
            int i = 0;
            Console.Clear();
            Console.WriteLine("   Выберите диск");
            foreach (var drive in DriveInfo.GetDrives())
            {
                Console.WriteLine("  Имя диска: " + drive.Name + "  Объем доступного свободного места (в байтах): " + drive.AvailableFreeSpace);
                aMas.Insert(i, drive.Name);
                i++;
            }
            Strelka strel = new Strelka(3, 3 + i - 1);

            while (true)
            {
                strel.Draw(position);
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position > strel.Mini())
                    {
                        strel.Del(position);
                        position--;
                        strel.Draw(position);
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position < strel.Max())
                    {
                        strel.Del(position);
                        position++;
                        strel.Draw(position);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return aMas[position - 3];
                }


            }
        }



        public string Drawkat(string cStr)  // показать каталог
        {
            int position = 3;
            int i = 0;
            ConsoleKeyInfo key;
            List<string> aMas = new List<string>();
            Console.Clear();
            Console.WriteLine("      Название папки или файла ");

            string[] allDir = Directory.GetDirectories(cStr); 
            foreach (string f in allDir)
            {
                Console.WriteLine("  " + Path.GetFileName(f));
                aMas.Insert(i, f);
                i++;
            }
            string[] allFiles = Directory.GetFiles(cStr); 
            foreach (string f in allFiles)
            {
                Console.WriteLine("  " + Path.GetFileName(f));
                aMas.Insert(i, f);
                i++;
            }


            Strelka strel = new Strelka(3, 3 + allDir.Length + allFiles.Length - 1);

            while (true)
            {
                strel.Draw(position);
                key = Console.ReadKey(); 

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position > strel.Mini())
                    {
                        strel.Del(position);
                        position--;
                        strel.Draw(position);
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position < strel.Max())
                    {
                        strel.Del(position);
                        position++;
                        strel.Draw(position);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    FileInfo fi = new FileInfo(aMas[position - 3]);
                    if (fi.Exists)
                    {
                        Process.Start(new ProcessStartInfo { FileName = aMas[position-3],UseShellExecute=true });
                    }
                    else
                    {
                        return aMas[position - 3];
                    }

                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    DirectoryInfo di = new DirectoryInfo(cStr);
                    DirectoryInfo parentDir = di.Parent;
                    if (parentDir != null)
                    {
                        return parentDir.FullName;
                    }
                    else
                    {
                        return "Disk";
                    }

                }

            }



        }
    }
}
