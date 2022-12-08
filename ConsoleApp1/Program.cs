using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Timers;

namespace ConsoleApp1
{
    internal class Program
    {
		public static int cntrl = 1;
      

		public static void tm() //часы
		{
			int start, end; //для секундомера
			int ms = 0;
			int ns = 0;
			int sec = 0;
			int min = 0;
			int hr = 0;
			int key = 0; ;
			//start = stopWatch();

			int hr2, min2, sec2; //для таймера

			switch (cntrl)
			{
				case 1:
					while (true)
					{
						ms++;
						if (ms > 100)
						{
							sec++;
							ms = 0;
						}
						if (sec > 59)
						{
							min++;
							sec = 0;
						}
						if (min > 59)
						{
							hr++;
							min = 0;
						}
						Console.WriteLine("{0}:{1}:{2}:{3}", hr, min, sec, ms);
						key++;
						Thread.Sleep(100);

						if (key > 10)
						{
							Console.Clear();
							control();
							break;
						}
						
					}
					
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
							key++;
							sec2--;
							Console.WriteLine("{0}:{1}", min2, sec2);
						}
						else if (sec2 == 0 && min2 > 0)
						{
							sec2 = 59;
							min2--;
							Console.WriteLine("{0}:{1}", min2, sec2);
						}
						else if (sec2 == 0 && min2 == 0 && hr > 0)
						{
							key++;
							sec2 = 59;
							min2 = 59;
							hr--;
							Console.WriteLine("{0}:{1}:{2}", hr, min2, sec2);
						}
						else if (sec2 == 0 && min2 == 0 && hr == 0)
						{
							Console.WriteLine("Отсчет закончен\r");
							Console.WriteLine("{0}:{1}:{2}", hr, min2, sec2);
							Console.ReadKey();
							Console.Clear();
							control();
						}
					}
					break;
				case 3:
					Console.WriteLine("Часы запущены\n");
					while (true)
					{
						key++;
						Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
						Thread.Sleep(1000);
						if (key > 10)
						{
							Console.Clear();
							control();
							break;
						}
					}
					break;
			}

			Console.Clear();
			//control();
		}

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
					tm();
					//t1.Start(1);
					break;
				case 2:
					Console.WriteLine("Поток поставлен на паузу\n");
					Thread t2 = new Thread(tm);
					t2.Abort();
					control();
					break;
				case 3:
					Console.WriteLine("Работа потока возобновлена\n");
					Thread t3 = new Thread(tm);
					//t3.Resume();
					control();
					break;
				case 4:
					Console.WriteLine("Режим таймера\n");
					cntrl = 2;
					Thread t4 = new Thread(tm);
					tm();
					break;
				case 5:
					Console.WriteLine("Режим часов\n");
					cntrl = 3;
					Thread t5 = new Thread(tm);
					tm();
					break;
				default:
					break;
			}

		}
		public static void TestMethod()
		{

			//int ms = 0;
			//int sec = 0;
			//int min = 0;
			//int hr = 0;
			//int key = 0;


			//Console.WriteLine("Я запустилась");
			//switch (cntrl)
			//{
			//	case 1:
			//		while (true)
			//		{
			//			ms++;
			//			if (ms > 100)
			//			{
			//				sec++;
			//				ms = 0;
			//			}
			//			if (sec > 59)
			//			{
			//				min++;
			//				sec = 0;
			//			}
			//			if (min > 59)
			//			{
			//				hr++;
			//				min = 0;
			//			}
			//			Console.WriteLine("{0}:{1}:{2}:{3}", hr, min, sec, ms);
			//			key++;
			//			//key = Console.ReadLine();
			//			//if (key == "ESCAPE")
			//			//{
			//			//	break;
			//			//}
			//			Thread.Sleep(100);

			//			if (key>10)
			//                     {
			//                         control();
			//                     }
			//                 }
			//		break;
			//	case 2:
			//		break;

			//}

			Console.WriteLine("Введите количество часов: ");
			int hr2 = int.Parse(Console.ReadLine());


			switch (hr2)
			{
				case 1:
					Console.WriteLine("{0}", hr2);
					break;
				case 2:
					Console.WriteLine("{0}", hr2);
					break;
			}
		}


		static void Main(string[] args)
		{
			control();
			//Console.WriteLine("{0}", hr2);
			Console.ReadKey();
		}
	}
}
