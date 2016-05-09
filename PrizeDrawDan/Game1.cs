using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class Game1 : Game
	{
		//Game Classes
		SpriteBatch spriteBatch;
		PrizeDrawContext ctx;
		SplitScreen splitscreen;
		Buttons buttons;
		MouseControl mouse;
		Backgrounds background;
		Timer timer;

		//Background Stuff
		public Rectangle backRectangle;

		public Game1 ()
		{
			ctx = new PrizeDrawContext (new GraphicsDeviceManager (this));
			Content.RootDirectory = "Content";
			splitscreen = new SplitScreen ();
			buttons = new Buttons ();
			mouse = new MouseControl ();
			background = new Backgrounds ();
			timer = new Timer ();
		}


		protected override void Initialize ()
		{
			//PrizeDrawContext Initialize
			ctx.Initialize();
			IsMouseVisible = false;

			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//Load Game Content
			splitscreen.LoadContent (ctx);
			buttons.LoadContent (Content);
			mouse.LoadContent (Content);
			background.LoadContent (Content);
			timer.LoadContent (Content);
		}


		protected override void Update (GameTime gameTime)
		{

			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif

			//Update logic   
			buttons.Update();
			mouse.Update ();
			timer.Update ();

			//Button Over Logic
			if (buttons.MMNButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.MMNButtonDefault = buttons.MMNButtonHover; 
			} else { buttons.MMNButtonDefault = buttons.MMNButton; }

			if (buttons.CountdownButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.CountdownButtonDefault = buttons.CountdownButtonHover;
			} else { buttons.CountdownButtonDefault = buttons.CountdownButton; }

			if (buttons.RedrawButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.RedrawButtonDefault = buttons.RedrawButtonHover;
			} else { buttons.RedrawButtonDefault = buttons.RedrawButton; }

			//Mouse Click Logic
			if(mouse.mouseState.LeftButton == ButtonState.Pressed && mouse.oldMouseState.LeftButton == ButtonState.Released 
					&& buttons.MMNButtonPos.Contains (mouse.mouseRectangle))
			{
				if (ctx.gameState == GameState.Back1) 
				{ ctx.gameState = GameState.Back2; } 
				else { ctx.gameState = GameState.Back1; }
			}

			base.Update (gameTime);
		}
			

		protected override void Draw (GameTime gameTime)
		{
			//Draw the game
			backRectangle = new Rectangle (0, 0, ctx.graphics.GraphicsDevice.Viewport.Width, ctx.graphics.GraphicsDevice.Viewport.Width);
			ctx.graphics.GraphicsDevice.Clear (Color.Black);

			//Draw to the Game Window Side (Left)
			ctx.graphics.GraphicsDevice.Viewport = splitscreen.Game();
			spriteBatch.Begin ();
				switch (ctx.gameState) {
				case GameState.Back1:
					spriteBatch.Draw (background.back1, backRectangle, Color.White);
					break;
				case GameState.Back2:
				spriteBatch.Draw (background.back2, backRectangle, Color.White);
					break;
				}
			timer.Draw (spriteBatch);
			spriteBatch.End ();

			//Draw to the User Interface Side (Right)
			ctx.graphics.GraphicsDevice.Viewport = splitscreen.Ui ();
			spriteBatch.Begin ();
			buttons.Draw(spriteBatch);
			mouse.Draw (spriteBatch);
			spriteBatch.End ();


			base.Draw (gameTime);
		}
	}
}

