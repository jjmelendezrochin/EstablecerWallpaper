using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace EstableceWallpaper
{
    class Program
    {
        // Used to set wallpaper
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINFILE = 1;
        public const int SPIF_SENDCHANGE = 2;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static void Main(string[] args)
        {
            String imagePath=null;
            try
            {
                //Establece las rutas
                string sDir = @"D:\My Drive";
                string path = null;

                if (Directory.Exists(sDir))
                {
                    // This path is a directory
                    path = @"D:\My Drive\otros\fondo.txt";
                }
                else
                {
                    path = @"D:\Mi unidad\otros\fondo.txt";
                }

                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                imagePath = sr.ReadLine();
               
                //close the file
                sr.Close();

                // Set wallpaper
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINFILE | SPIF_SENDCHANGE);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
