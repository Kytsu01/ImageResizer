using System;
using System.Threading;
using System.IO;
using System.Drawing;

namespace ImageResizer
{


    internal class Program
    {

        static string Msg = "Procurando arquivos...";
        static int ChosenHeight;

        private static void Main(string[] args)
        {

            Console.WriteLine("Redimensionador Iniciado! \n");

            Console.WriteLine("Por padrao, o redimensionador ira redimensionar as imagens para uma altura de 200, 500 e 800 pixels!");
            Console.WriteLine("Digite uma altura em pixels que voce deseja redimensionar seu arquivo: ");
            ChosenHeight = Convert.ToInt32(Console.ReadLine());

            Thread thread = new Thread(ResizeImage);
            thread.Start();

            Thread.Sleep(new TimeSpan(0, 0, 2));
            while(true)
            {
                Console.Clear();
                Console.WriteLine(Msg);
                Thread.Sleep(new TimeSpan(0, 0, 2));

            }


        }    

        static void ResizeImage()
        {

            string inputDirectory = "Input_Files";
            string resizedDirectory = "Resized_Files";
            string finishedDirectory = "Finished_Files";

            var allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ".jpg", ".jpeg", ".png", ".jfif"
            };

            string ext;

            string[] pixels = new string[4] { "200_Pixels", "500_Pixels", "800_Pixels", $"{ChosenHeight}_Pixels" };

            if(!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
            }

            if(!Directory.Exists(resizedDirectory))
            {
                Directory.CreateDirectory(resizedDirectory);
            }

            if(!Directory.Exists(finishedDirectory))
            {
                Directory.CreateDirectory(finishedDirectory);
            }

            for (int i = 0; i < 4; i++)
            {
                if(!Directory.Exists(resizedDirectory + @"\" + pixels[i]))
                {
                    Directory.CreateDirectory(resizedDirectory + @"\" + pixels[i]);
                }

            }



            FileStream fileStream;
            FileInfo fileInfo;

            int[] height = new int[4] { 200, 500, 800, ChosenHeight }; 

            while(true)
            {
                var inputFiles = Directory.EnumerateFiles(inputDirectory);


                foreach(var file in inputFiles)
                {

                    ext = Path.GetExtension(file);

                    if (!allowedExtensions.Contains(ext))
                    {
                        throw new InvalidDataException($"Formato nao suportado: '{ext}'");
                    }

                    Msg = "Redimensionando arquivos...";

                    Thread.Sleep(500);
                    for (int i = 0; i < 4; i++)
                    {

                        fileStream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                        fileInfo = new FileInfo(file);

                        string path = Environment.CurrentDirectory + @"\" + resizedDirectory + @"\" + $"{pixels[i]}" + @"\" + DateTime.Now.Millisecond.ToString() + $" millisegundos, {height[i]} pixels_" + fileInfo.Name;

                        Resize(Image.FromStream(fileStream), height[i], path);

                        fileStream.Close();

                        string finishedPath = Environment.CurrentDirectory + @"\" + finishedDirectory + @"\" + fileInfo.Name;

                        if (i == 3)
                        {
                            fileInfo.MoveTo(finishedPath);
                        }

                    }

                    Msg = "Arquivos redimensionados, adicione mais arquivos caso queira redimensionar mais!";

                }


                Thread.Sleep(new TimeSpan(0, 0, 3));
            }

        }

        static void Resize(Image img, int height, string path)
        {
            double ratio = (double)height / img.Height;
            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            Bitmap newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphic = Graphics.FromImage(newImage))
            {
                graphic.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            newImage.Save(path);

            newImage.Dispose();
            img.Dispose();

        }
    }
}