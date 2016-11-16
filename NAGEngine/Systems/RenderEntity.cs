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
    public interface XNARenderable
    {
        String ID { get; }
        Rectangle ScreenPos { get; }        
        Texture2D[] TextureList{get;}
        void Render(SpriteBatch batch);
        void ChangeID(String newID);
    }

    public abstract class RenderEntity : LogicEntity, XNARenderable
    {
        public Texture2D[] TextureList { get { return textureList; } }
        public Rectangle ScreenPos { get { return ScreenPos; } }
        protected Rectangle screenPos;
        protected  Texture2D[] textureList;

        public RenderEntity()
        {

        }

        public void Render(SpriteBatch batch)
        {

        }
    }
}
