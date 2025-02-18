
using Course;
using System.Text;

const string File = $"..\\..\\..\\src\\course.txt";
List<Hallgato> hallgatok = [];

using StreamReader sr = new(File, encoding: Encoding.UTF8);
while (!sr.EndOfStream) hallgatok.Add(new(sr.ReadLine()));

//1/////////

Console.WriteLine("1.feladat");
Console.WriteLine($"A file {hallgatok.Count()} db halgató adatai tartalmazza.");


//2/////////


var f2 = hallgatok
    .Where(x => x.Eredmeny.ContainsKey("Backend"))
    .Average(x => x.Eredmeny["Backend"]);

Console.WriteLine($"A halgató átlagos backend eredménye {f2}");


//3/////////


var f3 = hallgatok.Max(x => x.Eredmeny.Values.Sum());

Console.WriteLine($"Az osztály első halgató: {f3}");


//4/////////

var f4 = hallgatok.Where(x => x.Nem == true);

Console.WriteLine($"A férfiak aránya: {f4.Count()}");


//5/////////

var f5 = hallgatok
    .Where(x => x.Eredmeny.ContainsKey("Frontend") && x.Eredmeny.ContainsKey("Backend") && x.Nem == false)
    .Max(x => x.Eredmeny.Values.Sum());

Console.WriteLine($"A legjobb női hallgató pontszámai webfejlesztésből (Frontend / Backend): {f5}");


//6/////////

var f6 = hallgatok.Where(x => x.Befizet == 2600);

Console.WriteLine($"Azon halgatók száma akik befizették.");