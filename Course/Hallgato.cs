
namespace Course;

class Hallgato
{
    public string Nev { get; set; }
    public bool Nem { get; set; }
    public int Befizet { get; set; }
    public Dictionary<string, int> Eredmeny { get; set; }


    public Hallgato(string sor)
    {
        var v = sor.Split(";");
        Nev = v[0];
        Nem = v[1] == "m";
        Befizet = int.Parse(v[2]);
        Eredmeny = new()
        {
            {"Hálózat", int.Parse(v[3])},
            {"Mobil", int.Parse(v[4])},
            {"Frontend", int.Parse(v[5])},
            {"Backend", int.Parse(v[6])}
        };
    }

    public override string ToString()
    {
        return $"{Nev},{(Nem ? "f":"m")},{Befizet}";
    }
}
