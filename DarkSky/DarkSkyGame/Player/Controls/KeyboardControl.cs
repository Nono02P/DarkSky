using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSky
{
    public class KeyboardControl : IControl
    {
        public bool OnUp => Input.OnPressed(Keys.Up) || Input.OnPressed(Keys.Z);
        public bool Up => Input.IsDown(Keys.Up) || Input.IsDown(Keys.Z);

        public bool OnDown => Input.OnPressed(Keys.Down) || Input.OnPressed(Keys.S);
        public bool Down => Input.IsDown(Keys.Down) || Input.IsDown(Keys.S);

        public bool OnLeft => Input.OnPressed(Keys.Left) || Input.OnPressed(Keys.Q);
        public bool Left => Input.IsDown(Keys.Left) || Input.IsDown(Keys.Q);
        
        public bool OnRight => Input.OnPressed(Keys.Right) || Input.OnPressed(Keys.D);
        public bool Right => Input.IsDown(Keys.Right) || Input.IsDown(Keys.D);

        public bool OnAction => Input.OnPressed(Keys.Space);
        public bool Action => Input.IsDown(Keys.Space);
    }
}
