using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program2
{
    public class PlanetCatalog
    {
        private readonly List<Planet> _planets = new();
        private int _serialNumberFromTheSun;
        private int _equatorLength;
        private string? _errorMessage;
        private Planet? _head;
        private int _counter = 1;

        public PlanetCatalog(params Planet[] inputs)
        {
            var listOfInputs = new List<Planet>();
            foreach (var input in inputs)
            {
                var newHead = new Planet(input.Name, input.SerialNumberFromTheSun, input.EquatorLength);
                newHead.PreviousPlanet = _head;
                _head = newHead;
                listOfInputs.Add(newHead);
            }
            this._planets = listOfInputs;
        }

        public (int serialNumberFromTheSun, int equatorLength, string? errorMessage) GetPlanet(string planetName) 
        {
            _serialNumberFromTheSun = 0;
            _equatorLength = 0;
            _errorMessage = string.Empty;

            if (_counter >= 3)
            {
                Console.WriteLine("You ask too often!");
                Console.WriteLine();
            }

            List<string> avaliablePlanet = _planets.Select(r => r.Name).ToList();

            if (avaliablePlanet.Contains(planetName))
            {
                _serialNumberFromTheSun = _planets.Where(r => r.Name == planetName).Select(r => r.SerialNumberFromTheSun).FirstOrDefault();
                _equatorLength = _planets.Where(r => r.Name == planetName).Select(r => r.EquatorLength).FirstOrDefault();
            }
            else 
            { 
                _errorMessage = "Failed to find planet!"; 
            }
            _counter++;
            return (_serialNumberFromTheSun, _equatorLength, _errorMessage);
        }
    }
}
