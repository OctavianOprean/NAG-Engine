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
    class LogicManager : GameSystem
    {

        private List<Entity> EntityList;

        public void ManageEntity (Entity E)
        {
            EntityList.Add(E);
            
        }

        public LogicManager()
        {
            EntityList = new List<Entity>();
        }

        protected override void BootLogic()
        {
            
        }

        protected override void RunLogic()
        {
            foreach (Entity a in EntityList)
            {
                a.Update();
            }
        }

        public RenderInfo<Vector3,Vector3,Vector3,String>[] GetRenderInfo()
        {
            RenderInfo<Vector3, Vector3, Vector3, String>[] info = new RenderInfo<Vector3, Vector3, Vector3, String>[EntityList.Count];
            for(int i = 0; i< EntityList.Count; i++)
            {
                info[i].ID = EntityList[i].ID;
                info[i].Position = EntityList[i].Position;
                info[i].Rotation = EntityList[i].Rotation;
                info[i].Scale = EntityList[i].Scale;
            }
            return info;
        }

        protected override void ShutDownLogic()
        {

        }

    }


}
