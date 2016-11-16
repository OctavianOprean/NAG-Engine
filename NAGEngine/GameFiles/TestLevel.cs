using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAGEngine
{
    class TestLevel : NAGEngine.System.Level
    {
        string metalPhoto;
        public override void LoadLevelResource()
        {
            string[] a = new string[1];
            a[0] = "E:\\NAGEngine\\NAGEngine\\bin\\WindowsGL\\Debug\\a.jpg";
            NAGEngine.System.ResourceLoader.LoadReguest(System.ResourceType.texture2DList,"metal", a);
        }
        public override void InitializeLogic()
        {
            metalPhoto = manager.RequestRenderableEntity<NAGEngine.System.TestL, NAGEngine.System.Sprite2D>();
            NAGEngine.System.ResourceLoader.Link("metal", metalPhoto);
            NAGEngine.System.LogicManager.GetEntityWithID(metalPhoto).Serialize();
        }
        public override void LevelLogic()
        {

        }
        public override void Cleanup()
        {

        }
    }
}
