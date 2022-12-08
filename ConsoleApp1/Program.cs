using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
		public static int cntrl;
       static void Main(string[] args)
        {
			control();
		}

		public static void tm() //часы
		{
			int cn = cntrl;
			int start, end; //для секундомера
			int ms = 0;
			int ns = 0;
			int sec = 0;
			int min = 0;
			int hr = 0;
			string key;
			//start = stopWatch();

			int hr2, min2, sec2; //для таймера

			switch (cntrl)
			{
				case 1:
					while (true)
					{
						//end = clock();
						//ns = end - start;
						ms++;
						if (ms > 100)
						{
							sec = sec + 1;
							ms = 0;
						}
						if (sec > 59)
						{
							min = min + 1;
							sec = 0;
						}
						if (min > 59)
						{
							hr = hr + 1;
							min = 0;
						}
						Console.WriteLine("%d:%d:%d.%d\r", hr, min, sec, ms);
						key = Console.ReadLine();
						if (key == "ESCAPE")
						{
							break;
						}
						Thread.Sleep(97);
					}
					control();
					break;
				case 2:
					
					Console.WriteLine("Введите количество часов: ");
					hr2 = int.Parse(Console.ReadLine());

					Console.WriteLine("Введите количество минут: ");
					min2 = int.Parse(Console.ReadLine());

					Console.WriteLine("Введите количество секунд: ");
					sec2 = int.Parse(Console.ReadLine());
					
					while (true)
					{

						Thread.Sleep(970); // 970 + 30 = 1 секунда (30 от обработки)

						if (sec2 > 0)
						{
							sec2--;
							Console.WriteLine("%d:%d\r", min2, sec2);
						}
						else if (sec2 == 0 && min2 > 0)
						{
							sec2 = 59;
							min2--;
							Console.WriteLine("%d:%d\r", min2, sec2);
						}
						else if (sec2 == 0 && min2 == 0 && hr > 0)
						{
							sec2 = 59;
							min2 = 59;
							hr--;
							Console.WriteLine("%d:%d:%d\r", hr, min2, sec2);
						}
						else if (sec2 == 0 && min2 == 0 && hr == 0)
						{
							Console.WriteLine("Отсчет закончен\r");
							Console.WriteLine("%d:%d:%d\r", hr, min2, sec2);
							control();
						}
						key = Console.ReadLine();
						if (key == "ESCAPE")
						{
							break;
						}

					}
					break;
				case 3:
					Console.WriteLine("Часы запущены\n");
					while (true)
					{
						//SYSTEMTIME st;
						//GetLocalTime(&st);
						Stopwatch sp = new Stopwatch();
						//DateTime st = new DateTime();
						sp.Start();
						Console.WriteLine("{0}:{1}:{2}", hr, min, sec);
						sp.Stop();
						Thread.Sleep(1000 - (int)sp.ElapsedMilliseconds);
						//Thread.Sleep(970);

						//key = Console.ReadLine();
						//if (key == "ESCAPE")
						//{
						//	break;
						//}
					}
					Console.Clear();
					control();
					break;
			}

			Console.Clear();
			//control();
		}

		//Thread t1 = new Thread(new ThreadStart(control));
		//Thread t2 = new Thread(new ThreadStart(tm));

		public static void control() //управление часами
		{
			

			Console.WriteLine(" 1 - режим секундомера;\n 2 - пауза; 3 - снять с паузы;\n 4 - запуск таймера;\n 5 - запуск часов;\n");
			Console.WriteLine("Введите номер управления: ");
			int command = int.Parse(Console.ReadLine());
			Console.WriteLine("\n");

			switch (command)
			{
				case 1:
					Console.WriteLine("запуск секундомера\n");					
					cntrl = 1;
					Thread t1 = new Thread(tm);
					t1.Start(1);
					break;
				case 2:
					Console.WriteLine("Поток поставлен на паузу\n");
					Thread t2 = new Thread(tm);
					t2.Abort();
					break;
				case 3:
					Console.WriteLine("Работа потока возобновлена\n");
					Thread t3 = new Thread(tm);
					t3.Resume();
					break;
				case 4:
					Console.WriteLine("Режим таймера\n");
					cntrl = 2;
					Thread t4 = new Thread(tm);
					t4.Start();
					break;
				case 5:
					Console.WriteLine("Режим часов\n");
					cntrl = 3;
					Thread t5 = new Thread(tm);
					t5.Start();
					break;
				default:
					break;
			}
			//ExitThread(0);
		}
	}
}
