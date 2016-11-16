#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion;

namespace NAGEngine.System
{
    class Director : GameSystem
    {
        public Director()
        {
            this.AddSubSystem<GraphicsManager>("Renderer");
            this.AddSubSystem<LogicManager>("EntityManager");
            this.AddSubSystem<EntityFactory>("EntityCreator");
            this.AddSubSystem<LevelManager>("LevelManager");            
        }

        public void LinkGame (Game CurrentGame)
        {
            GraphicsDeviceManager a = new GraphicsDeviceManager(CurrentGame);
            this.GetSubSystem<GraphicsManager>("Renderer").SetGraphicsDevice(a);
            ResourceLoader.AssignGraphicsDevice(a);
        }

        protected override void BootLogic( )
        {
            
            EntityFactory Creator = this.GetSubSystem<EntityFactory>("EntityCreator");
            Creator.SetLogicUnit(this.GetSubSystem<LogicManager>("EntityManager"));
            Creator.SetRenderUnit(this.GetSubSystem<GraphicsManager>("Renderer"));
            this.GetSubSystem<LevelManager>("LevelManager").SetEntityCreator(this.GetSubSystem<EntityFactory>("EntityCreator"));                       
            this.GetSubSystem<LevelManager>("LevelManager").LoadLevel(new TestLevel());
            
        }

        protected override void RunLogic()
        {
            this.GetSubSystem<LevelManager>("LevelManager").Run();
            this.GetSubSystem<GraphicsManager>("Renderer").LoadRenderInfo(this.GetSubSystem<LogicManager>("EntityManager").GetRenderInfo());
        }

        protected override void ShutDownLogic()
        {
            
        }
       
    }


}
