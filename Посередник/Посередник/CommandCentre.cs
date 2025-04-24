using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Посередник
{
    class CommandCentre
    {
        private List<Runway> _runways = new List<Runway>();
        private List<Aircraft> _aircrafts = new List<Aircraft>();

        public CommandCentre(Runway[] runways)
        {
            _runways.AddRange(runways);
        }

        public void RegisterAircraft(Aircraft aircraft)
        {
            _aircrafts.Add(aircraft);
        }

        public void LandAircraft(Aircraft aircraft)
        {
            Console.WriteLine($"Літак {aircraft.Name} запитує посадку.");
            foreach (var runway in _runways)
            {
                if (runway.IsAvailable())
                {
                    runway.AssignAircraft(aircraft);
                    Console.WriteLine($"Літак {aircraft.Name} здійснив посадку на смугу {runway.Id}.");
                    return;
                }
            }
            Console.WriteLine($"Немає доступної смуги для посадки літака {aircraft.Name}.");
        }

        public void TakeOffAircraft(Aircraft aircraft)
        {
            Console.WriteLine($"Літак {aircraft.Name} запитує зліт.");
            foreach (var runway in _runways)
            {
                if (!runway.IsAvailable())
                {
                    runway.ClearRunway();
                    Console.WriteLine($"Літак {aircraft.Name} злетів зі смуги {runway.Id}.");
                    return;
                }
            }
            Console.WriteLine($"Немає смуги, з якої може злетіти літак {aircraft.Name}.");
        }
    }
}
