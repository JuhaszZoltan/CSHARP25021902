namespace CSHARP25021902;

internal class Hallgato
{
    public string Nev { get; set; }
    public bool Nem { get; set; }
    public int Befizetes { get; set; }
    public Dictionary<string, int> Eredmenyek { get; set; }

    public double Atlag => Eredmenyek.Values.Average();
    public string CsaladNev => Nev.Split(' ')[1];

    public Hallgato(string sor)
    {
        var t = sor.Split(';');
        Nev = t[0];
        Nem = t[1] == "m";
        Befizetes = int.Parse(t[2]);
        Eredmenyek = new()
        {
            { "Hálózat",  int.Parse(t[3]) },
            { "Mobil",    int.Parse(t[4]) },
            { "Frontend", int.Parse(t[5]) },
            { "Backend",  int.Parse(t[6]) },
        };
    }
}
