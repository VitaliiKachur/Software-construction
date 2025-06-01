using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class VisibleState : IVisibilityState
    {
        public string ApplyState(string html) => html;
        public string GetStateName() => "Видимий";
    }
}
