namespace Program2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var planets = new PlanetCatalog(new("Venus", 2, 38025), new("Earth", 3, 40075), new("Mars", 4, 21344));
            var inputs = new List<string>() { "Earth", "Lemonia", "Mars" };

            foreach (var input in inputs)
            {
                var planet = planets.GetPlanet(input);
                if (planet.errorMessage == string.Empty)
                {
                    Console.WriteLine($"Name: {input}, SerialNumberFromTheSun: {planet.serialNumberFromTheSun}, EquatorLength: {planet.equatorLength}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(planet.errorMessage);
                    Console.WriteLine();
                }
            }
        }
    }
}
