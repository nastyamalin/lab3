//Описати клас, який реалізує десятковий лічильник, який може збільшувати або зменшувати своє значення на одиницю в заданому діапазоні.
//Передбачити ініціалізацію лічильника значеннями за замовчуванням і довільними значеннями. Лічильник має два методи: збільшення і зменшення та властивість,
//що дозволяє отримати його поточний стан.
//Написати програму, яка демонструвала б всі можливості класу. Зробити властивості класу приватними, а для їх читання створити методи-геттери.


using System;
using System.Diagnostics.Metrics;
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Лічильник за замовчуванням,з json файлу чи самостійно створений(0<x<100) ('1' або '2' або '3')");
        string choice = Console.ReadLine().ToLower();
        Lab_3 counter;
        if (choice == "1")
        {
            counter = new Lab_3();
        }
        else if (choice == "2")
        {
            Console.Write("Введіть ім'я JSON файлу: ");
            
            string fileNameLoad = Console.ReadLine();
            counter = Lab_3.LoadFromJson(fileNameLoad);
            Console.WriteLine("Дані завантажено з файлу: " + fileNameLoad);
        }
        else if (choice == "3")
        {
            counter = new Lab_3(0, 0, 0);
        }
        else
        {
            Console.WriteLine("Помилка");
            return;
        }


        while (true)
        {
            Console.WriteLine("\nОберіть дію:");
            Console.WriteLine("1. Збільшити");
            Console.WriteLine("2. Зменшити");
            Console.WriteLine("3. Поточний стан");
            Console.WriteLine("4. Зберегти в JSON");
            Console.WriteLine("5. Вийти");

            int choice_2 = int.Parse(Console.ReadLine());

            switch (choice_2)
            {
                case 1:
                    counter.Increment();
                    break;
                case 2:
                    counter.Decrement();
                    break;
                case 3:
                    Console.WriteLine("Поточний стан: " + counter.Value);
                    break;
                case 4:
                    Console.Write("Ім'я файлу");
                    string fileNameSave = Console.ReadLine();
                    counter.SaveToJson(fileNameSave);
                    break;
                case 5:
                    Console.WriteLine("Завершено роботу програми");
                    return;
                default:
                    Console.WriteLine("Помилка");
                    break;
            }
        }

    }
}