using System;
using System.Collections.Generic;
using System.IO;

namespace _3_лаба
{
    class Программа
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== ЛАБОРАТОРНАЯ РАБОТА: ВАРИАНТ 4 ===\n");
            Console.ResetColor();

            List<Автомобиль> гараж = new List<Автомобиль>();

            Console.WriteLine("\n--- СОЗДАНИЕ АВТОМОБИЛЕЙ ---");

            гараж.Add(new Автомобиль());
            Console.Write("Автомобиль №1: ");
            гараж[0].ВывестиНазвание();
            Console.WriteLine("(конструктор по умолчанию)");

            гараж.Add(new Автомобиль("BMW", 2022, 250, 2));
            Console.Write("Автомобиль №2: ");
            гараж[1].ВывестиНазвание();
            Console.WriteLine("(конструктор с параметрами)");

            гараж.Add(new Автомобиль("Lada", 2015));
            Console.Write("Автомобиль №3: ");
            гараж[2].ВывестиНазвание();
            Console.WriteLine("(упрощенный конструктор)");

            Автомобиль рандомная = new Автомобиль();
            рандомная.СлучайноеЗаполнение();
            гараж.Add(рандомная);
            Console.Write("Автомобиль №4: ");
            гараж[3].ВывестиНазвание();
            Console.WriteLine("(случайная машина)");

            гараж.Add(new Автомобиль(гараж[3]));
            Console.Write("Автомобиль №5: ");
            гараж[4].ВывестиНазвание();
            
            Console.WriteLine($"(копия {гараж[3].ПолучитьМарку()})");

            File.WriteAllText("test_car.txt", "Tesla\n2023\n300\n2\n450\n1200");
            гараж.Add(new Автомобиль("test_car.txt"));
            Console.Write("Автомобиль №6: ");
            гараж[5].ВывестиНазвание();
            Console.WriteLine("(из файла)");

            гараж.Add(new Автомобиль());
            Console.Write("Автомобиль №7: ");
            Console.WriteLine("БезМарки (будет заполнена с клавиатуры)");

            Console.WriteLine("\n--- ВЫВОД ИНФОРМАЦИИ ---");
            for (int i = 0; i < гараж.Count - 1; i++)
            {
                Console.WriteLine($"\nАвтомобиль #{i + 1}:");
                гараж[i].ВывестиИнформацию();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n--- ЗАПОЛНЕНИЕ ПОСЛЕДНЕГО АВТОМОБИЛЯ ---");
            гараж[гараж.Count - 1].ВводСклавиатуры();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n--- ПОИСК САМОГО УБИТОГО АВТОМОБИЛЯ ---");
            Автомобиль самыйУбитый = Автомобиль.СамыйУбитый(гараж);
            Console.WriteLine("САМЫЙ УБИТЫЙ АВТОМОБИЛЬ:");
            самыйУбитый.ВывестиИнформацию();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n--- СОХРАНЕНИЕ В ФАЙЛЫ ---");
            for (int i = 0; i < гараж.Count; i++)
            {
                string маркаДляФайла = гараж[i].ПолучитьМарку().Replace(" ", "_");
                string имяОбъекта = $"{маркаДляФайла}_{i + 1}.txt";
                гараж[i].СохранитьВФайл(имяОбъекта);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n--- ПОИСК САМОЙ МЕДЛЕННОЙ МАШИНЫ ---");
            Автомобиль самаяМедленная = гараж[0];
            foreach (Автомобиль авто in гараж)
            {
                if (авто.МаксимальнаяСкорость < самаяМедленная.МаксимальнаяСкорость)
                    самаяМедленная = авто;
            }
            Console.WriteLine("Самая медленная машина:");
            самаяМедленная.ВывестиИнформацию();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n=== ИТОГ ===");
            Console.WriteLine($"Всего создано автомобилей: {Автомобиль.КоличествоАвтомобилей}");
            Console.WriteLine("\nУРРРРАААА!!!!");
        }
    }
}