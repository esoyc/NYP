using System;
using System.Collections.Generic;

enum CihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

class Cihaz
{
    public int Kimlik { get; set; }
    public string Ad { get; set; }
    public CihazTuru Tur { get; set; }
    public bool AcikMi { get; private set; }

    // Constructor
    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false; // ilk bas kapali
    }

    public void Ac()
    {
        AcikMi = true;
    }

    public void Kapat()
    {
        AcikMi = false;
    }

    public void BilgileriGoster()
    {
        Console.WriteLine($"kimlik: {Kimlik}, ad: {Ad}, tür: {Tur}, acikMi: {(AcikMi ? "Açık" : "Kapalı")}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cihaz> cihazlar = new List<Cihaz>();

        // Başlangıç cihazları
        cihazlar.Add(new Cihaz(1, "Salon Lambası",
            CihazTuru.Lamba));

        cihazlar.Add(new Cihaz(2, "Salon Kliması",
            CihazTuru.Klima));

        cihazlar.Add(new Cihaz(3, "Ev Alarmı",
            CihazTuru.GuvenlikSistemi));

        while (true)
        {
            Console.WriteLine("\n--- AKILLI EV ---");
            Console.WriteLine("1- Cihazları Listele");
            Console.WriteLine("2- Yeni Cihaz Ekle");
            Console.WriteLine("3- Cihaz Aç");
            Console.WriteLine("4- Cihaz Kapat");
            Console.WriteLine("0- Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    foreach (Cihaz cihaz in cihazlar)
                    {
                        cihaz.BilgileriGoster();
                    }
                    break;

                case "2":
                    Console.Write("Cihaz kimliği: ");

                    if (!int.TryParse(Console.ReadLine(),
                        out int kimlik))
                    {
                        Console.WriteLine("Geçersiz kimlik!");
                        break;
                    }

                    if (cihazlar.Exists(c => c.Kimlik == kimlik))
                    {
                        Console.WriteLine("Bu kimlik zaten var!");
                        break;
                    }

                    Console.Write("Cihaz adı: ");
                    string ad = Console.ReadLine();

                    Console.WriteLine("1- Lamba");
                    Console.WriteLine("2- Klima");
                    Console.WriteLine("3- Güvenlik Sistemi");
                    Console.Write("Cihaz türü: ");

                    if (!int.TryParse(Console.ReadLine(),
                        out int tur) || tur < 1 || tur > 3)
                    {
                        Console.WriteLine("Geçersiz tür!");
                        break;
                    }

                    cihazlar.Add(new Cihaz(kimlik, ad,
                        (CihazTuru)tur));

                    Console.WriteLine("Cihaz eklendi.");
                    break;

                case "3":
                case "4":
                    Console.Write("Cihaz kimliği: ");

                    if (!int.TryParse(Console.ReadLine(),
                        out int arananKimlik))
                    {
                        Console.WriteLine("Geçersiz kimlik!");
                        break;
                    }

                    Cihaz bulunan = cihazlar.Find(c => c.Kimlik == arananKimlik);

                    if (bulunan == null)
                    {
                        Console.WriteLine("Cihaz bulunamadı!");
                    }
                    else if (secim == "3")
                    {
                        bulunan.Ac();
                        Console.WriteLine("Cihaz açıldı.");
                    }
                    else
                    {
                        bulunan.Kapat();
                        Console.WriteLine("Cihaz kapatıldı.");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        }
    }
}
