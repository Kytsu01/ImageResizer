using System;
using System.Threading;
using System.IO;

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

        }
    }
}