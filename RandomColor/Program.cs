using System;
using System.Threading;
using NAudio;
using NAudio.Wave;
using NAudio.Codecs;

namespace RandomColor
{
    class Program
    {
        private static string[] colors = new string[] { "Green", "Blue", "Orange", "Yellow" };
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("");
            int i = 0;

            while (true)
            {
                using (var waveOut = new WaveOutEvent())
                using (var wavReader = new WaveFileReader(@"C:\beep-07.wav"))
                {
                    Signalize(rand.Next(4), ++i);
                    waveOut.Init(wavReader);
                    waveOut.Play();
                    Thread.Sleep(2000);
                }
            }
        }
        public static void Signalize(int i, int index)
        {
            Console.Write($"\r       {colors[i]}           {index}        ");
        }
    }
}
