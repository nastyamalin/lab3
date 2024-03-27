using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
class Lab_3
{
    private int minValue;
    private int maxValue;
    private int value;
    public Lab_3()
    {
        minValue = 0;
        maxValue = 100;
        value = minValue;
    }
    public Lab_3(int min, int max, int initialValue)
    {

        Console.Write("Мінімум ");
        minValue = int.Parse(Console.ReadLine());

        Console.Write("Максимум");
        maxValue = int.Parse(Console.ReadLine());

        Console.Write("Поточне число");
        initialValue = int.Parse(Console.ReadLine());

        if (initialValue >= minValue && initialValue <= maxValue)
            value = initialValue;
        else
            value = minValue;

    }
    public void Increment()
    {
        if (value < maxValue)
            value++;
        else
            Console.WriteLine("=max");
    }
    public void Decrement()
    {
        if (value > minValue)
            value--;
        else
            Console.WriteLine("=min");
    }

    public int Value
    {
        get { return value; }
    }
    public int CurrentValue { get; private set; }

    public void SetCurrentValue(int value)
    {
        if (value >= minValue && value <= maxValue)
            CurrentValue = value;
        else
            CurrentValue = minValue;
    }
    public void SaveToJson(string fileName)
    {
        string path = @"C:\Users\Asus\Desktop\uni\lab_3\lab_3\bin\Debug\net6.0\" + fileName + ".json";
        string json = JsonConvert.SerializeObject(this);
        File.WriteAllText(path, json);
        Console.WriteLine("збережено у" + path);
    }
    public static Lab_3 LoadFromJson(string fileName)
    {
        string path = @"C:\Users\Asus\Desktop\uni\lab_3\lab_3\bin\Debug\net6.0\" + fileName + ".json";
        string json = File.ReadAllText(path);
        var obj = JsonConvert.DeserializeObject<Lab_3>(json);

        Lab_3 counter = new Lab_3();
        counter.SetCurrentValue(obj.Value);

        return counter;
    }
}
