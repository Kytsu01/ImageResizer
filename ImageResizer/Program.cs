using System;
using System.Threading;
using System.IO;
using System.Drawing;

namespace ImageResizer
{


    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Iniciando redimensionador!");
            Thread thread = new Thread(ResizeImage);
            thread.Start();


        }    

        static void ResizeImage()
        {

            string inputDirectory = "Input_Files";
            string resizedDirectory = "Resized_Files";
            string finishedDirectory = "Finished_Files";

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

            FileStream fileStream;
            FileInfo fileInfo;

            int[] height = new int[3] { 200, 500, 800 }; 

            while(true)
            {
                var inputFiles = Directory.EnumerateFiles(inputDirectory);


                    foreach(var file in inputFiles)
                    {
                        for (int i = 0; i < 3; i++)
                        {

                            fileStream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                            fileInfo = new FileInfo(file);

                            string path = Environment.CurrentDirectory + @"\" + resizedDirectory + @"\" + DateTime.Now.Millisecond.ToString() + $" millisegundos, {height[i]} pixels_" + fileInfo.Name;

                            Resize(Image.FromStream(fileStream), height[i], path);

                            fileStream.Close();

                            string finishedPath = Environment.CurrentDirectory + @"\" + finishedDirectory + @"\" + fileInfo.Name;

                            if (i == 2)
                            {
                                fileInfo.MoveTo(finishedPath);
                            }

                        }


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
            img.Dispose();

        }
    }
}