using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace _3_лаба
{
     class Автомобиль
    {
        // ============= ПОЛЯ КЛАССА =============
        int КоличествоАварий;
        List<int> СтоимостьРемонтов;
        static int количествоАвтомобилей = 0;
        string Марка;
        int ГодВыпуска;
        public int МаксимальнаяСкорость;
        ConsoleColor цветМашины;

        // Публичное свойство для доступа к Марке из Program.cs
        public string ПолучитьМарку()
        {
            return Марка;
        }

        // Публичное свойство для доступа к статическому полю
        public static int КоличествоАвтомобилей
        {
            get { return количествоАвтомобилей; }
        }

        static Random rnd = new Random();

        static ConsoleColor СлучайныйЦвет()
        {
            ConsoleColor[] цвета = {
            ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue,
            ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta,
            ConsoleColor.DarkRed, ConsoleColor.DarkGreen, ConsoleColor.DarkBlue,
            ConsoleColor.DarkYellow
        };
            return цвета[rnd.Next(цвета.Length)];
        }

        public Автомобиль()
        {
            Марка = "БезМарки";
            ГодВыпуска = 2000;
            МаксимальнаяСкорость = 120;
            КоличествоАварий = 0;
            СтоимостьРемонтов = new List<int>();
            цветМашины = СлучайныйЦвет();
            количествоАвтомобилей++;
        }

        public Автомобиль(string марка, int год, int максСкорость, int аварии)
        {
            Марка = марка;
            ГодВыпуска = год;
            МаксимальнаяСкорость = максСкорость;
            КоличествоАварий = аварии;
            СтоимостьРемонтов = new List<int>();
            for (int i = 0; i < КоличествоАварий; i++)
                СтоимостьРемонтов.Add(1000);
            цветМашины = СлучайныйЦвет();
            количествоАвтомобилей++;
        }

        public Автомобиль(string марка, int год)
        {
            this.Марка = марка;
            this.ГодВыпуска = год;
            this.МаксимальнаяСкорость = 150;
            this.КоличествоАварий = 0;
            this.СтоимостьРемонтов = new List<int>();
            цветМашины = СлучайныйЦвет();
            количествоАвтомобилей++;
        }

        public Автомобиль(Автомобиль другой)
        {
            Марка = другой.Марка;
            ГодВыпуска = другой.ГодВыпуска;
            МаксимальнаяСкорость = другой.МаксимальнаяСкорость;
            КоличествоАварий = другой.КоличествоАварий;
            СтоимостьРемонтов = new List<int>(другой.СтоимостьРемонтов);
            цветМашины = СлучайныйЦвет();
            количествоАвтомобилей++;
        }

        public Автомобиль(string имяФайла)
        {
            try
            {
                string[] данные = File.ReadAllLines(имяФайла);
                Марка = данные[0];
                ГодВыпуска = int.Parse(данные[1]);
                МаксимальнаяСкорость = int.Parse(данные[2]);
                КоличествоАварий = int.Parse(данные[3]);
                СтоимостьРемонтов = new List<int>();
                for (int i = 0; i < КоличествоАварий; i++)
                    СтоимостьРемонтов.Add(int.Parse(данные[4 + i]));
                цветМашины = СлучайныйЦвет();
                количествоАвтомобилей++;
            }
            catch (Exception ex)
            {
                CarException carEx = new CarException(ex);
                carEx.obrabotka();
            }
        }

        public void ВывестиИнформацию()
        {
            Console.ForegroundColor = цветМашины;
            Console.WriteLine("\n=== ИНФОРМАЦИЯ ОБ АВТОМОБИЛЕ ===");
            Console.WriteLine($"Марка: {Марка}");
            Console.WriteLine($"Год выпуска: {ГодВыпуска}");
            Console.WriteLine($"Максимальная скорость: {МаксимальнаяСкорость} км/ч");
            Console.WriteLine($"Количество аварий: {КоличествоАварий}");

            if (КоличествоАварий > 0)
            {
                Console.Write("Стоимость ремонтов: ");
                foreach (int стоимость in СтоимостьРемонтов)
                    Console.Write(стоимость + " лей ");
                Console.WriteLine();
                Console.WriteLine($"Общая стоимость ремонтов: {СуммаРемонтов()} лей");
            }
            else
            {
                Console.WriteLine("Аварий не было, водитель молодец!");
            }
            Console.WriteLine("================================");
            Console.ResetColor();
        }

        public void ВывестиНазвание()
        {
            Console.ForegroundColor = цветМашины;
            Console.Write($"{Марка} ");
            Console.ResetColor();
        }

        public void ВводСклавиатуры()
        {
            Console.WriteLine("\n=== ЗАПОЛНЕНИЕ ДАННЫХ АВТОМОБИЛЯ ===");

            string[] поля = { "Марка", "ГодВыпуска", "МаксимальнаяСкорость", "КоличествоАварий", "СтоимостьРемонтов" };

            Random rand = new Random();
            for (int i = 0; i < поля.Length; i++)
            {
                int randomIndex = rand.Next(i, поля.Length); // Выбираем случайный индекс
                string temp = поля[i];  // Меняем местами элементы
                поля[i] = поля[randomIndex];
                поля[randomIndex] = temp;
            }
             
            foreach (string поле in поля) // Перебираем каждое поле в случайном порядке
            {
                bool flag; // Флаг: true - была ошибка, нужно повторить ввод
                do
                {
                    flag = false; // Сначала считаем, что ошибок нет
                    try // ПЫТАЕМСЯ выполнить ввод и проверку
                        //try = "попробуй выполнить этот код"
                        //catch = "если ошибка, сделай это"
                        //throw = "я сам создаю ошибку"
                        //CarException = "мой специальный тип ошибки"
                    {
                        switch (поле)
                        {
                            case "Марка":
                                Console.Write("Введите марку: ");
                                Марка = Console.ReadLine();
                                break;

                            case "ГодВыпуска":
                                Console.Write("Введите год выпуска (1980–2025): ");
                                int год = Convert.ToInt32(Console.ReadLine());
                                if (год < 1980 || год > 2025)
                                    throw new CarException(год);
                                ГодВыпуска = год;
                                break;

                            case "МаксимальнаяСкорость":
                                Console.Write("Введите максимальную скорость (60–300): ");
                                int скорость = Convert.ToInt32(Console.ReadLine());
                                if (скорость < 60 || скорость > 300)
                                    throw new CarException("скорость", скорость);
                                МаксимальнаяСкорость = скорость;
                                break;

                            case "КоличествоАварий":
                                Console.Write("Введите количество аварий (0–20): ");
                                int аварии = Convert.ToInt32(Console.ReadLine());
                                if (аварии < 0 || аварии > 20)
                                    throw new CarException("аварии", аварии);
                                КоличествоАварий = аварии;
                                СтоимостьРемонтов.Clear();
                                for (int j = 0; j < КоличествоАварий; j++)
                                    СтоимостьРемонтов.Add(0);
                                break;

                            case "СтоимостьРемонтов":
                                if (КоличествоАварий == 0)
                                {
                                    Console.WriteLine("Аварий нет, стоимость ремонтов не вводится.");
                                    break;
                                }
                                Console.WriteLine($"Введите стоимость {КоличествоАварий} ремонтов:");
                                for (int j = 0; j < КоличествоАварий; j++)
                                {
                                    bool costFlag;
                                    do
                                    {
                                        costFlag = false;
                                        try
                                        {
                                            Console.Write($"Ремонт {j + 1}(10-10000): ");
                                            double стоимость = Convert.ToDouble(Console.ReadLine());
                                            if (стоимость < 10 || стоимость > 10000)
                                                throw new CarException(стоимость);
                                            СтоимостьРемонтов[j] = (int)стоимость;
                                        }
                                        catch (CarException ex)
                                        {
                                            ex.obrabotka();
                                            costFlag = true;
                                        }
                                        catch (Exception ex)
                                        {
                                            CarException carEx = new CarException(ex);
                                            carEx.obrabotka();
                                            costFlag = true;
                                        }
                                    } while (costFlag);
                                }
                                break;
                        }
                    }
                    catch (CarException ex)
                    {
                        ex.obrabotka();
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        CarException carEx = new CarException(ex);
                        carEx.obrabotka();
                        flag = true;
                    }
                } while (flag);
            }
            Console.WriteLine("Данные успешно введены!");
        }

        public int СуммаРемонтов()
        {
            int сумма = 0;
            foreach (int цена in СтоимостьРемонтов)
                сумма += цена;
            return сумма;
        }

        public void СлучайноеЗаполнение()
        {
            Random rnd = new Random();
            string[] марки = { "BMW", "Audi", "Toyota", "Honda", "Ford" };
            Марка = марки[rnd.Next(марки.Length)];
            ГодВыпуска = rnd.Next(1990, 2025);
            МаксимальнаяСкорость = rnd.Next(120, 300);
            КоличествоАварий = rnd.Next(0, 6);
            СтоимостьРемонтов.Clear();
            for (int i = 0; i < КоличествоАварий; i++)
                СтоимостьРемонтов.Add(rnd.Next(10, 10000));
        }

        public void СохранитьВФайл(string имяФайла)
        {
            try
            {
                using (StreamWriter файл = new StreamWriter(имяФайла))
                {
                    файл.WriteLine(Марка);
                    файл.WriteLine(ГодВыпуска);
                    файл.WriteLine(МаксимальнаяСкорость);
                    файл.WriteLine(КоличествоАварий);
                    foreach (int цена in СтоимостьРемонтов)
                        файл.WriteLine(цена);
                }
                Console.ForegroundColor = цветМашины;
                Console.WriteLine($"Данные сохранены в файл {имяФайла}");
                Console.ResetColor();
            }
            catch (Exception ошибка)
            {
                CarException carEx = new CarException(ошибка);
                carEx.obrabotka();
            }
        }

        public static Автомобиль СамыйУбитый(List<Автомобиль> список)
        {
            Автомобиль худший = список[0];
            foreach (Автомобиль авто in список)
                if (авто.СуммаРемонтов() > худший.СуммаРемонтов())
                    худший = авто;
            return худший;
        }
    }
}
