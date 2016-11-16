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
    public abstract class LogicEntity : UniqueEntity, Entity
    {

        public bool ToDestroy { get { return toDestroy; } }
        public Vector3 Position { get { return position; } }
        public Vector3 Rotation { get { return rotation; } }
        public Vector3 Scale { get { return scale; } }

        protected bool toDestroy;
        protected Vector3 position;
        protected Vector3 rotation;
        protected Vector3 scale;

        public LogicEntity()
        {
            toDestroy = false;
            position = new Vector3(0.0f, 0.0f, 0.0f);
            scale = new Vector3(1.0f, 1.0f, 1.0f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
        }

        public void Serialize()
        {
            Serializer.ClearBuffer();
            Initialize();
        }
        public abstract void Initialize();
        public abstract void Update();
        public abstract void ReleaseMemory();
    }


    public class TestL : LogicEntity
    {
        float speed = 5;
        public override void Initialize()
        {
            Serializer.ReadFile("E:\\NAGEngine\\NAGEngine\\bin\\WindowsGL\\Debug\\a.txt");
            speed = Serializer.SerializeFloat("speed");
            position.X = Serializer.SerializeFloat("x");
            position.Y = Serializer.SerializeFloat("y");
        }
        public override void Update()
        {
            position.X += speed * 0.17f;
            rotation.Z += speed/15  * 0.17f;
        }
        public override void ReleaseMemory()
        {

        }
    }
}