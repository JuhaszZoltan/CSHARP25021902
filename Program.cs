using CSHARP25021902;

const string PATH = "E:\\PROJECTS\\CSHARP25021902\\COURSE";
const int TELJES_AR = 2600;

List<Hallgato> hallgatok = [];

StreamReader sr = new($"{PATH}\\course.txt");
while (!sr.EndOfStream) hallgatok.Add(new(sr.ReadLine()));

Console.WriteLine($"f1: hallgatok szama: {hallgatok.Count} fo");

var f2 = hallgatok.Average(h => h.Eredmenyek["Backend"]);
Console.WriteLine($"f2: backend avg: {f2:0.00}%");

var f3 = hallgatok.MaxBy(h => h.Eredmenyek.Values.Sum());
Console.WriteLine($"f3: osztalyelso: {f3.Nev}");

var f4 = hallgatok.Count(h => h.Nem);
Console.WriteLine($"f4: ferfiak aranya: {f4 / (float)hallgatok.Count * 100:0.00}%");

var f5 = hallgatok
    .Where(h => !h.Nem)
    .MaxBy(h => h.Eredmenyek["Frontend"] + h.Eredmenyek["Backend"]);
Console.WriteLine($"f5: legjobb noi webes: {f5.Nev}");

var f6 = hallgatok.Where(h => h.Befizetes >= TELJES_AR).Select(h => h.Nev);
Console.WriteLine($"f6: akik mar elofinansziroztak:");
foreach (var n in f6) Console.WriteLine($"\t- {n}");

Console.Write("f7: irja be egy hallgato nevet: ");
var f7input = Console.ReadLine();
var f7hallgato = hallgatok.SingleOrDefault(h => h.Nev == f7input);
if (f7hallgato is null)
    Console.WriteLine($"\tnincs {f7input} nevu hallgato");
else if (!f7hallgato.Eredmenyek.Values.Any(e => e <= 50))
    Console.WriteLine($"\t{f7input}-nak nem kell javitovizsgat tennie");
else
{
    Console.WriteLine($"\t{f7input}-nak/nek a kovetkezokbol kell jv-t tennie:");
    foreach (var kvp in f7hallgato.Eredmenyek)
        if (kvp.Value <= 50) Console.WriteLine($"\t\t- {kvp.Key} ({kvp.Value}%)");
}

var f8 = hallgatok.Count(h => h.Eredmenyek.Values.Any(v => v == 100) && h.Eredmenyek.Values.All(v => v > 50));
Console.WriteLine($"f8: kerdeses hallgatok szama: {f8}");

var f9dict = new Dictionary<string, int>();
foreach (var kvp in hallgatok.First().Eredmenyek)
    f9dict.Add(kvp.Key, 0);
foreach (var h in hallgatok)
{
    foreach (var kvp in h.Eredmenyek)
    {
        if (kvp.Value <= 50) f9dict[kvp.Key]++;
    }
}
Console.WriteLine("f9: tantargyankent jv-sek szama: ");
foreach (var kvp in f9dict) Console.WriteLine($"\t{kvp.Key}: {kvp.Value} fo");

var f10 = hallgatok.OrderBy(h => h.CsaladNev);
using StreamWriter sw = new($"{PATH}\\output.txt");
foreach (var h in f10) sw.WriteLine($"{h.Nev} {h.Atlag:0.00}");


