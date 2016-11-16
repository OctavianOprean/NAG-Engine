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

    class EntityFactory : GameSystem 
    {

        private GraphicsManager Graphics;
        private LogicManager Logic;

        public EntityFactory()
        {
            Graphics = null;
            Logic = null;
        }

        public void CreateRenderableEntity<LogicType, RenderType>()
            where LogicType : Entity, new()
            where RenderType : XNARenderable, new()
        {
            LogicType logicEntity = new LogicType();
            RenderType renderEntity = new RenderType();
            renderEntity.ChangeID(logicEntity.ID);            
                       
            Logic.ManageEntity(logicEntity);            
            Graphics.ManageEntity(renderEntity);
            
        }

        public void CreateTheoreticalEntity<LogicType>() where LogicType : Entity, new()
        {
            LogicType tempEntity = new LogicType();
            Logic.ManageEntity(tempEntity);
        }

        public void CreateGraphicEntity<RenderType>() where RenderType : XNARenderable, new()
        {
            RenderType tempEntity = new RenderType();
            Graphics.ManageEntity(tempEntity);
        }

        public void SetRenderUnit(GraphicsManager system)
        {
            Graphics = system;
        }
        public void SetLogicUnit(LogicManager system)
        {
            Logic = system;
        }

        protected override void BootLogic()
        {
            if (Graphics == null)
            {
                Console.Write("Error, RenderUnit not set");
                this.status = SystemStatus.Ofline;
            }

            if (Logic == null)
            {
                Console.Write("Error, LogicUnit not set");
                this.status = SystemStatus.Ofline;
            }
        }

        protected override void RunLogic()
        {

        }

        protected override void ShutDownLogic()
        {

        }

    }


}
