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
    public class GraphicsManager : GameSystem       
    {
        private Vector3 tmp;
        private Dictionary<string,XNARenderable> EntityList;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public void ManageEntity(XNARenderable E)
        {            
            EntityList.Add(E.ID,E);            
        }
        private List<string> RenderQueue; 
        public GraphicsManager()
        {
            graphics = null;
            spriteBatch = null;
            EntityList = new Dictionary<string,XNARenderable>();
            RenderQueue = new List<String>();
            tmp = new Vector3();
        }

        public void SetGraphicsDevice(GraphicsDeviceManager gManager )
        {
            graphics = gManager;
        }

        public void LoadRenderInfo(RenderInfo<Vector3,Vector3,Vector3,String>[] Info)
        {
            RenderQueue.Clear();
            foreach (RenderInfo<Vector3,Vector3,Vector3,String> a in Info)
            {
                if (EntityList.ContainsKey(a.ID))
                {
                    EntityList[a.ID].Position = a.Position;
                    EntityList[a.ID].Rotation = a.Rotation;
                    EntityList[a.ID].Scale = a.Scale;
                    RenderQueue.Add(a.ID);
                }
            }
        }

        protected override void BootLogic()
        {
            if (graphics != null)
                spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            else
            {
                Console.Write("Boot prevented: GraphicsDevice not set");
                this.status = SystemStatus.Ofline;
            }
        }

        protected override void RunLogic()
        {
            spriteBatch.Begin();
            graphics.GraphicsDevice.Clear(Color.Black);
            foreach (KeyValuePair<string,XNARenderable> a in EntityList)
            {
                if (a.Value.TextureList[0] == null)
                    ResourceLoader.InitializeXNAGraphicEntities(EntityList);
                a.Value.Animate(a.Value.CurFrame);
                a.Value.Render(spriteBatch);
            }
            spriteBatch.End();
        }

        protected override void ShutDownLogic()
        {
            spriteBatch = null;
        }
   
    }


}
