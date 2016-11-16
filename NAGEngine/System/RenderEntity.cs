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
    public interface XNARenderable
    {
        bool Initialized { get; }
        uint CurFrame{get;}
        String ID { get; }
        Vector3 Position { get; set; }
        Vector3 Rotation { get; set; }
        Vector3 Scale { get; set; }
        uint Width {get;}
        uint Height { get; }
        Texture2D[] TextureList{get;}
        void Render(SpriteBatch batch);
        void ChangeID(String newID);
        void Animate(uint Keyframe);
        void LoadTexturList(Texture2D[] Textures);
    }

    public abstract class RenderEntity :  UniqueEntity,XNARenderable
    {
        public bool Initialized { get { return initialized; } }
        public uint CurFrame { get { return curFrame; } }
        public Texture2D[] TextureList { get { return textureList; } }
        public uint Width { get { return width; } }
        public uint Height { get { return height; } }
        public Vector3 Position { get { return position; } set { this.position = value; } }
        public Vector3 Rotation { get { return rotation; } set { this.rotation = value; } }
        public Vector3 Scale { get { return scale; } set { this.scale = value; } }

        protected Vector3 position;
        protected Vector3 rotation;
        protected Vector3 scale;
        protected uint width;
        protected uint height;
        protected uint curFrame;
        protected bool initialized;
        protected  Texture2D[] textureList;

        public RenderEntity()
        {
            width = 500;
            height = 500;
            curFrame = 0;
            position = new Vector3(0.0f, 0.0f, 0.0f);
            scale = new Vector3(1.0f, 1.0f, 1.0f);
            rotation = new Vector3(0.0f, 0.0f, 0.0f);
            initialized = false;
            textureList = new Texture2D[1];
        }

        public abstract void LoadTexturList(Texture2D[] Textures);
        public abstract void Render(SpriteBatch batch); 
        public abstract void Animate(uint Keyframe);  
    }

    public class Sprite2D : RenderEntity
    {
        public override void LoadTexturList(Texture2D[] Textures)
        {
            textureList = Textures;
            initialized = true;
        }

        public override void Render(SpriteBatch batch)
        {
            batch.Draw(textureList[curFrame], new Vector2(position.X, position.Y),null, Color.White, Rotation.Z, new Vector2(width/2,height/2), new Vector2(scale.X, scale.Y),SpriteEffects.None,position.Z);
            
        }
        public override void Animate(uint Keyframe)
        { 
        
        }
    }
}
