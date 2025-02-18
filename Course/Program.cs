
using Course;
using System.Text;

const string File = $"..\\..\\..\\src\\course.txt";
const string path = $"..\\..\\..\\src\\hallgatok.txt";

List<Hallgato> hallgatok = [];

using StreamReader sr = new(File, encoding: Encoding.UTF8);
while (!sr.EndOfStream) hallgatok.Add(new(sr.ReadLine()));

//1/////////

Console.WriteLine("1.feladat");
Console.WriteLine($"A file {hallgatok.Count()} db halgató adatai tartalmazza.");


//2/////////

Console.WriteLine("2.feladat");

var f2 = hallgatok
    .Where(x => x.Eredmeny.ContainsKey("Backend"))
    .Average(x => x.Eredmeny["Backend"]);

Console.WriteLine($"A halgató átlagos backend eredménye {f2}");


//3/////////

Console.WriteLine("3.feladat");

var f3 = hallgatok.Max(x => x.Eredmeny.Values.Sum());

Console.WriteLine($"Az osztály első halgató: {f3}");


//4/////////

Console.WriteLine("4.feladat");

var f4 = hallgatok.Where(x => x.Nem == true);

Console.WriteLine($"A férfiak aránya: {f4.Count()}");


//5/////////

Console.WriteLine("5.feladat");

var f5 = hallgatok
    .Where(x => x.Eredmeny.ContainsKey("Frontend") && x.Eredmeny.ContainsKey("Backend") && x.Nem == false)
    .Max(x => x.Eredmeny.Values.Sum());

Console.WriteLine($"A legjobb női hallgató pontszámai webfejlesztésből (Frontend / Backend): {f5}");


//6/////////

Console.WriteLine("6.feladat");

var f6 = hallgatok.Where(x => x.Befizet == 2600);

Console.WriteLine($"Azon halgatók száma akik befizették a teljes tanfolyamot: {f6.Count()}");


//7/////////


Console.WriteLine("7.feladat");


Console.WriteLine("Adjon meg egy halgató nevét: ");
string valasz = Console.ReadLine();

bool found = false;
foreach (var item in hallgatok)
{
    if (item.Nev.Contains(valasz)) 
    {
        found = true;
        List<string> kellVizsgazni = new List<string>(); // Tanegységek, ahol javítóvizsga kell

        foreach (var eredmeny in item.Eredmeny)
        {
            if (eredmeny.Value < 51) // Ha az eredmény 51% alatt van
            {
                kellVizsgazni.Add(eredmeny.Key); // Hozzáadjuk a tantárgyat
            }
        }

        if (kellVizsgazni.Count > 0)
        {
            Console.WriteLine($"{item.Nev} javítóvizsgát kell tennie a következő tantárgyakból:");
            foreach (var tantargy in kellVizsgazni)
            {
                Console.WriteLine(tantargy);
            }
        }
        else
        {
            Console.WriteLine($"{item.Nev} nem kell javítóvizsgát tennie.");
        }
    }
}

if (!found)
{
    Console.WriteLine("Nincs ilyen nevű hallgatónk.");
}

//8/////////


var f8 = hallgatok.Where(x => x.Eredmeny.Values.Any(val => val == 100) && x.Eredmeny.Values.All(val => val >= 51));
Console.WriteLine("8.feladat");
Console.WriteLine($"Azon hallgatók száma, akik legalább egy modulból 100%-ot teljesítettek és egyik modulból sem kell javítóvizsgát tennie: {f8.Count()}");



//9/////////

Console.WriteLine("9.feladat");

// Modulok, amelyeket szeretnénk ellenőrizni
var modulok = new[] { "Hálózat", "Mobil", "Frontend", "Backend" };

// A tantárgyanként szükséges javítóvizsgázó diákok száma
foreach (var modul in modulok)
{
    int count = hallgatok.Count(x => x.Eredmeny.ContainsKey(modul) && x.Eredmeny[modul] < 51);
    Console.WriteLine($"{modul}: {count} diáknak kell javítóvizsgát tennie.");
}


//10/////////

Console.WriteLine("10.feladat");

// Rendezés családnév (második név) alapján
var f10 = hallgatok.OrderBy(x => x.Nev.Split(' ')[1]).ToList(); // A Split segítségével a családnevet választjuk

// Átlageredmény kiszámítása és kiírás fájlba
using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
{
    foreach (var hallgato in f10)
    {
        // Átlageredmény kiszámítása
        double atlag = hallgato.Eredmeny.Values.Average();

        // Kiírás a fájlba
        sw.WriteLine($"{hallgato.Nev} - Átlag: {atlag:F2}"); // F2 formázás a két tizedesjegyhez
    }
}

Console.WriteLine("A hallgatók rendezve lettek és ki lettek írva a fájlba.");
