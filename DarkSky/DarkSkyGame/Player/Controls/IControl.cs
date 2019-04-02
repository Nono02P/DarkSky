using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky
{
    public interface IControl
    {
        bool OnUp { get; }
        bool Up { get; }
        bool OnDown { get; }
        bool Down { get; }
        bool OnLeft { get; }
        bool Left { get; }
        bool OnRight { get; }
        bool Right { get; }
        bool OnAction { get; }
        bool Action { get; }
    }
}
