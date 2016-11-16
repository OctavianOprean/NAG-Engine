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
   
    public class InfirmaryInc : Game
    {

        NAGEngine.System.Director QTarantino;
        public InfirmaryInc()
            : base()
        {
            QTarantino = new NAGEngine.System.Director();
            QTarantino.LinkGame(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            QTarantino.Boot();
            base.Initialize();
        }
       
        protected override void LoadContent()
        {            
            
        }

        protected override void UnloadContent()
        {
        
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            QTarantino.Run();
            base.Update(gameTime);         
        }

        protected override void Draw(GameTime gameTime)
        {
            QTarantino.Run();
            
            base.Draw(gameTime);
        }
    }
}
