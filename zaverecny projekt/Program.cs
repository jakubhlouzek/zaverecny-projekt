global using zaverecny_projekt;

Console.WriteLine("Vítej ve hře kámen, nůžky, papír");
Console.WriteLine("Hra začíná za...");
Console.WriteLine("3");
Thread.Sleep(1000);
Console.WriteLine("2");
Thread.Sleep(1000);
Console.WriteLine("1");
Thread.Sleep(1000);

Hra Hra = new Hra();
bool pokracovani = true;
int zadaniHrace = 0;
string[] volby = new string[3] { "kámen", "nůžky", "papír" };


while (pokracovani)
{
    Console.Clear();
    
    Console.WriteLine($"Hráč: {Hra.SkoreHrac}");
    Console.WriteLine($"Soupeř: {Hra.SkoreSouper}");
    Console.WriteLine("------------");
    Console.WriteLine("Kolo hráče:");
    Console.WriteLine("1 - kámen");
    Console.WriteLine("2 - nůžky");
    Console.WriteLine("3 - papír"); 
    Console.WriteLine("------------");

    overeni:
    while (!int.TryParse(Console.ReadLine(), out zadaniHrace))
        Console.WriteLine("Neplatné číslo, zadejte znovu");
    if (zadaniHrace > 3)
    {
        Console.WriteLine("Neplatné číslo, zadejte znovu");
        goto overeni;
    }

    int volbaHrace = zadaniHrace - 1;
    Hra VolbaSouper = new Hra();
    int volbaSouper = VolbaSouper.generatorVoleb.Next(3);
    
    if (volby[volbaHrace] == "kámen" && volby[volbaSouper] == "nůžky")
    {
        Console.WriteLine($"Hráč vyhrál - soupeř zvolil {volby[volbaSouper]}");
        Hra.SkoreHrac = Hra.SkoreHrac + 1;
    }
    else if (volby[volbaHrace] == "kámen" && volby[volbaSouper] == "papír")
    {
        Console.WriteLine($"Soupeř vyhrál - zvolil {volby[volbaSouper]}");
        Hra.SkoreSouper = Hra.SkoreSouper + 1;
    }
    else if (volby[volbaHrace] == "papír" && volby[volbaSouper] == "kámen")
    {
        Console.WriteLine($"Hráč vyhrál - Soupeř zvolil {volby[volbaSouper]}");
        Hra.SkoreHrac = Hra.SkoreHrac + 1;
    }
    else if (volby[volbaHrace] == "papír" && volby[volbaSouper] == "nůžky")
    {
        Console.WriteLine($"Soupeř vyhrál - zvolil {volby[volbaSouper]}");
        Hra.SkoreSouper = Hra.SkoreSouper + 1; Hra.SkoreSouper = +1;
    }
    else if (volby[volbaHrace] == "nůžky" && volby[volbaSouper] == "kámen")
    {
        Console.WriteLine($"Soupeř vyhrál - zvolil {volby[volbaSouper]}");
        Hra.SkoreSouper = Hra.SkoreSouper + 1;
    }
    else if (volby[volbaHrace] == "nůžky" && volby[volbaSouper] == "papír")
    {
        Console.WriteLine($"Hráč vyhrál - Soupeř zvolil {volby[volbaSouper]}");
        Hra.SkoreHrac = Hra.SkoreHrac + 1;
    }
    else 
    {
        Console.WriteLine("Remíza");
    }
    Thread.Sleep(1000);
    
    if (Hra.SkoreHrac > 4 | Hra.SkoreSouper > 4)
    {
        pokracovani = false;
    }
}

if (Hra.SkoreHrac > Hra.SkoreSouper)
{
    Console.WriteLine();
    Console.WriteLine("Vyhrál jsi");
}
else
{
    Console.WriteLine();
    Console.WriteLine("Prohrál jsi");
}