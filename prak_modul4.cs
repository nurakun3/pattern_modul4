public class Zakaz
{
    public List<ZakazTovar> Tovary { get; } = new List<ZakazTovar>();
    public IOplata SposobOplaty { get; set; }
    public IDostavka SposobDostavki { get; set; }
    public IUvedomlenie SposobUvedomleniya { get; set; }

    public void DobavitTovar(string nazvanieTovara, int kolichestvo, decimal tsena)
    {
        Tovary.Add(new ZakazTovar(nazvanieTovara, kolichestvo, tsena));
    }

    public decimal RaschitatObshuyuTsenu()
    {
        return Tovary.Sum(tovar => tovar.RaschitatTsenu());
    }

    public decimal RaschitatTsenuSoSkidkoy(ISkidka skidka)
    {
        var obshayaTsena = RaschitatObshuyuTsenu();
        return skidka.PrimenitSkidku(obshayaTsena);
    }

    public void ObrabotatZakaz()
    {
        SposobOplaty.ObrabotatOplatu(RaschitatObshuyuTsenu());
        SposobDostavki.Dostavit();
        SposobUvedomleniya.OtpravitUvedomlenie();
    }
}

public class ZakazTovar
{
    public string NazvanieTovara { get; }
    public int Kolichestvo { get; }
    public decimal Tsena { get; }

    public ZakazTovar(string nazvanieTovara, int kolichestvo, decimal tsena)
    {
        NazvanieTovara = nazvanieTovara;
        Kolichestvo = kolichestvo;
        Tsena = tsena;
    }

    public decimal RaschitatTsenu()
    {
        return Kolichestvo * Tsena;
    }
}

public interface IDostavka
{
    void Dostavit();
}

public class KurerskayaDostavka : IDostavka
{
    public void Dostavit()
    {
        Console.WriteLine("Dostavka kur'erom.");
    }
}

public class PochtaDostavka : IDostavka
{
    public void Dostavit()
    {
        Console.WriteLine("Dostavka pochtoy.");
    }
}

public class SamovyvozDostavka : IDostavka
{
    public void Dostavit()
    {
        Console.WriteLine("Pokupatel sam zabiraet tovar iz punkta samovyvoza.");
    }
}

public interface IUvedomlenie
{
    void OtpravitUvedomlenie();
}

public class EmailUvedomlenie : IUvedomlenie
{
    public void OtpravitUvedomlenie()
    {
        Console.WriteLine("Otpravka email-uvedomleniya.");
    }
}

public class SmsUvedomlenie : IUvedomlenie
{
    public void OtpravitUvedomlenie()
    {
        Console.WriteLine("Otpravka SMS-uvedomleniya.");
    }
}

public interface ISkidka
{
    decimal PrimenitSkidku(decimal obshayaSumma);
}

public class ProtsentnayaSkidka : ISkidka
{
    private readonly decimal protsent;

    public ProtsentnayaSkidka(decimal protsent)
    {
        this.protsent = protsent;
    }

    public decimal PrimenitSkidku(decimal obshayaSumma)
    {
        return obshayaSumma - (obshayaSumma * protsent / 100);
    }
}

public class FiksirovannayaSkidka : ISkidka
{
    private readonly decimal summaSkidki;

    public FiksirovannayaSkidka(decimal summaSkidki)
    {
        this.summaSkidki = summaSkidki;
    }

    public decimal PrimenitSkidku(decimal obshayaSumma)
    {
        return obshayaSumma - summaSkidki;
    }
}

public class Programma
{
    public static void Main()
    {
        var zakaz = new Zakaz();
        
        zakaz.DobavitTovar("Noutbuk", 1, 1000m);
        zakaz.DobavitTovar("Mysh", 2, 25m);
        
        zakaz.SposobOplaty = new KreditnayaKartaOplata();

        zakaz.SposobDostavki = new KurerskayaDostavka();

        zakaz.SposobUvedomleniya = new EmailUvedomlenie();

        var skidka = new ProtsentnayaSkidka(10);
        decimal itogSoSkidkoy = zakaz.RaschitatTsenuSoSkidkoy(skidka);

        Console.WriteLine($"Itog so skidkoy: {itogSoSkidkoy}");

        zakaz.ObrabotatZakaz();
    }
}

public interface IOplata
{
    void Oplatit();
}

public class KreditnayaKarta : IOplata
{
    public void Oplatit()
    {
        Console.WriteLine("Оплата картой");
    }
}

public class PayPalOplata : IOplata
{
    public void Oplatit()
    {
        Console.WriteLine("Оплата через PayPal");
    }
}

