using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Посередник
{
    class Aircraft
    {
        public string Name { get; }
        public Runway CurrentRunway { get; set; }
        public bool IsTakingOff { get; set; }
        private CommandCentre _commandCentre;

        public Aircraft(string name, CommandCentre commandCentre)
        {
            Name = name;
            _commandCentre = commandCentre;
            _commandCentre.RegisterAircraft(this);
        }

        public void RequestLanding()
        {
            _commandCentre.LandAircraft(this);
        }

        public void RequestTakeOff()
        {
            _commandCentre.TakeOffAircraft(this);
        }
    }
}
