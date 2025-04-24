using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Посередник
{
    class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public Aircraft IsBusyWithAircraft;

        internal void AssignAircraft(Aircraft aircraft)
        {
            IsBusyWithAircraft = aircraft;
            HighlightRed();
        }

        internal void ClearRunway()
        {
            IsBusyWithAircraft = null;
            HighlightGreen();
        }

        internal bool IsAvailable()
        {
            return IsBusyWithAircraft == null;
        }

        public void HighlightRed()
        {
            Console.WriteLine($"Злітна смуга {Id} зайнята.");
        }

        public void HighlightGreen()
        {
            Console.WriteLine($"Злітна смуга {Id} вільна.");
        }
    }
}
