using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        public void Main(string[] args)
        {
			control();
		}

		public int tm(int cntrl) //часы
		{

			int start, end; //для секундомера
			int ms = 0;
			int ns = 0;
			int sec = 0;
			int min = 0;
			int hr = 0;
			string key;
			start = stopWatch();

			int hr2, min2, sec2; //для таймера

			switch (cntrl)
			{
				case 1:
					while (true)
					{
						
						end = clock();
						ns = end - start;
						ms = ns / 10;
						if (ms > 100)
						{
							sec = sec + 1;
							ms = ms - 100;
							start = end;
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
						DateTime st = new DateTime();
						Console.WriteLine(st.ToLongTimeString());
						Thread.Sleep(970);
						
						key = Console.ReadLine();
						if (key == "ESCAPE")
						{
							break;
						}
					}
					Console.Clear();
					control();
					break;
			}

			Console.Clear();
			//control();
			return 0;
		}

		public int control() //управление часами
		{
			Console.WriteLine(" 1 - режим секундомера;\n 2 - пауза; 3 - снять с паузы;\n 4 - запуск таймера;\n 5 - запуск часов;\n");
			Console.WriteLine("Введите номер управления: ");
			int command = int.Parse(Console.ReadLine());
			Console.WriteLine("\n");

			switch (command)
			{
				case 1:
					Console.WriteLine("запуск секундомера\n");
					hThread[1] = CreateThread(NULL, 0, tm, 1, 0, 0);
					break;
				case 2:
					Console.WriteLine("Поток поставлен на паузу\n");
					hThread[1] = SuspendThread(1);
					//SuspendThread(hThread[1]);
					control();
					break;
				case 3:
					Console.WriteLine("Работа потока возобновлена\n");
					hThread[1] = ResumeThread(1);
					//ResumeThread(hThread[1]);
					control();
					break;
				case 4:
					Console.WriteLine("Режим таймера\n");
					hThread[1] = CreateThread(NULL, 0, tm, 2, 0, 0);
					break;
				case 5:
					Console.WriteLine("Режим часов\n");
					hThread[1] = CreateThread(NULL, 0, tm, 3, 0, 0);
					break;
				default:
					CloseHandle(hThread[0]);
					CloseHandle(hThread[1]);
					break;
			}
			ExitThread(0);
			return 0;
		}
	}
}
