#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace NAGEngine.System
{
    
    public class RenderInfo<P, R, S, G>
    {
        public P Position;
        public R Rotation;
        public S Scale;
        public G ID;
    }
}
