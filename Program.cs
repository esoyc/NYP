using System;

class Motor
{
    public string Model { get; set; }
    public int BeygirGucu { get; set; }
    public Motor(string model, int beygirGucu)
    {
        Model = model;
        BeygirGucu = beygirGucu;
    }

    public void Calistir()
    {
        Console.WriteLine($"{Model} motor calisti.");
    }
}

class Araba
{
    public string Marka { get; set; }
    private Motor motor;
    public Araba(string marka, string motorModeli, int beygirGucu)
    {
        Marka = marka;
        motor = new Motor(motorModeli, beygirGucu);
    }

    public void Ac()
    {
        Console.WriteLine($"{Marka} araba calisiyor.");
        motor.Calistir();
    }
    public void BilgileriGoster()
    {
        Console.WriteLine($"Motor: {motor.Model}");
        Console.WriteLine($"Beygir gucu: {motor.BeygirGucu}");
    }
}

class Program
{
    static void Main()
    {
        Araba araba1 = new Araba("Toyota", "1.5L Dynamic Force", 125);
        araba1.BilgileriGoster();
        Console.WriteLine();
        araba1.Ac();
    }
}