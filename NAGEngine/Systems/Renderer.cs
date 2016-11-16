using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAGEngine
{
    class GraphicsManager : GameSystem       
    {
        private List<XNARenderable> EntityList;

        public void ManageEntity(XNARenderable E)
        {            
            EntityList.Add(E);            
        }

        public GraphicsManager()
        {
            EntityList = new List<XNARenderable>();
        }

        protected override void BootLogic()
        {

        }

        protected override void RunLogic()
        {

        }

        protected override void ShutDownLogic()
        {

        }
   
    }


}
