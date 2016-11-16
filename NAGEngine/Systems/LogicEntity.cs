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
    public abstract class LogicEntity : Entity
    {
        protected String GUID;
        public String ID { get { return GUID; } }
        public Vector3 Position { get { return position; } }
        public Vector3 Rotation { get { return rotation; } }
        public Vector3 Scale { get { return scale; } }

        protected Vector3 position;
        protected Vector3 rotation;
        protected Vector3 scale;

        public LogicEntity()
        {
            GUID = Guid.NewGuid().ToString();
            position = new Vector3(0.0f, 0.0f, 0.0f);
            scale = new Vector3(1.0f, 1.0f, 1.0f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        public void ChangeID(string newID)
        {
            GUID = newID;
        }

        public abstract void Serialize(string Path);
        public abstract void Update();
        public abstract void ReleaseMemory();
    }
}
