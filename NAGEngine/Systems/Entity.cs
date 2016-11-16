
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

namespace NAGEngine
{
    public interface Entity
    {
        String ID { get; }

        Vector3 Position { get; }
        Vector3 Rotation { get; }
        Vector3 Scale { get; }

        void ChangeID(string newID);
        void Serialize(string Path);
        void Update();
        void ReleaseMemory();

        
    }
}