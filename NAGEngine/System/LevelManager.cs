using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace NAGEngine.System
{
    public enum EntityType
    {
        Renderable,
        Graphic,
        Logic
    }

    public abstract class Level
    {
        public bool Initialized{get{return initialized;}}
        public bool Completed{get {return completed;}}
        public int NextLevel{get {return nextLevel;}}

        protected bool initialized;
        protected bool completed;
        protected int nextLevel;
        protected LevelManager manager;
        protected Dictionary<string, string> EntityIDs;

        public Level()
        {
            nextLevel = 0;
            initialized = false;
            completed = false;
            EntityIDs = new Dictionary<string, string>();
        }

        public void setManager(LevelManager Manager)
        {
            manager = Manager;
        }

        public abstract void LoadLevelResource();


        public void Initialize()
        {
            LoadLevelResource();
            InitializeLogic();
            //string[] a = new string[1];
            //a[0] = "F:\\Uni\\Game Design and Engeneering\\NAGEngine\\NAGEngine\\bin\\WindowsGL\\Debug\\a.jpg";

            //ResourceLoader.Link(ResourceLoader.LoadReguest(ResourceType.texture2DList, a), manager.RequestRenderableEntity<TestL, Sprite2D>());

            initialized = true;
        }

        public abstract void InitializeLogic();
        public abstract void LevelLogic();
        public abstract void Cleanup();


    }

    public class LevelManager : GameSystem
    {

        private EntityFactory factory;
        private int curLevel;
        private List<Level> LevelList;

        public LevelManager()
        {
            curLevel = 0;
            LevelList = new List<Level>();
        }

        public void LoadLevel(Level A)
        {
            LevelList.Add(A);
        }

        public void SetEntityCreator(EntityFactory Creator)
        {
            factory = Creator;
        }

        public string RequestLogicEntity<EntityClass>() where EntityClass : Entity, new()
        {
            return factory.CreateTheoreticalEntity<EntityClass>();
        }

        public string RequestGraphicEntity<EntityClass>() where EntityClass : XNARenderable, new()
        {
            return factory.CreateGraphicEntity<EntityClass>();
        }

        public string RequestRenderableEntity<EntityLogicClass, EntityRenderClass>()
            where EntityLogicClass : Entity, new()
            where EntityRenderClass : XNARenderable, new()
        {
            return factory.CreateRenderableEntity<EntityLogicClass, EntityRenderClass>();
        }


        protected override void BootLogic()
        {
            foreach (Level a in LevelList)
            {
                a.setManager(this);
            }
        }

        protected override void RunLogic()
        {
            if (LevelList[curLevel] != null)
            {
                if (LevelList[curLevel].Initialized)
                {
                    if (!LevelList[curLevel].Completed)
                        LevelList[curLevel].LevelLogic();
                    else
                    {
                        LevelList[curLevel].Cleanup();
                        curLevel = LevelList[curLevel].NextLevel;
                    }
                }
                else LevelList[curLevel].Initialize();
            }
            else if(LevelList.Count>curLevel)
                 curLevel++;
        }

        protected override void ShutDownLogic()
        {

        }

    }


}
