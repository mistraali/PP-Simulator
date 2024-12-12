using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    internal class Birds : Animals
    {
        //properties
        public bool CanFly { get; set; } = true;

        public override string Info => $"{Description} (fly{(CanFly ? '+' : '-')}) <{Size}>";
    }
}
