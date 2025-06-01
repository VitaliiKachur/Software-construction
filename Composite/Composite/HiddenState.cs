using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class HiddenState : IVisibilityState
    {
        public string ApplyState(string html) => "<!-- Приховано -->";
        public string GetStateName() => "Прихований";
    }
}
