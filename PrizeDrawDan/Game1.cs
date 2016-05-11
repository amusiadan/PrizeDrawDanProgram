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
		GraphicSettings graphicSettings;
		SplitScreen splitscreen;
		Buttons buttons;
		MouseControl mouse;
		Backgrounds background;
		Timer timer;


		public Game1 ()
		{
			graphicSettings = new GraphicSettings (new GraphicsDeviceManager (this));
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
			graphicSettings.Initialize();
			IsMouseVisible = false;

			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//Load Game Content
			splitscreen.LoadContent (graphicSettings);
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
			background.Update ();



			//Button Over Logic
			if (buttons.MMNButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.MMNButtonDefault = buttons.MMNButtonHover; 
			} else { buttons.MMNButtonDefault = buttons.MMNButton; }

			if (buttons.GenericDrawButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.GenericDrawButtonDefault = buttons.GenericDrawButtonHover; 
			} else { buttons.GenericDrawButtonDefault = buttons.GenericDrawButton; }

			if (buttons.CountdownButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.CountdownButtonDefault = buttons.CountdownButtonHover;
			} else { buttons.CountdownButtonDefault = buttons.CountdownButton; }

			if (buttons.RedrawButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.RedrawButtonDefault = buttons.RedrawButtonHover;
			} else { buttons.RedrawButtonDefault = buttons.RedrawButton; }


			//Update Game States
			//StartUp Game State
			if (graphicSettings.gameState == GameState.STARTUP) {
				if ( buttons.MMNButtonisClicked == true ) graphicSettings.gameState = GameState.MMN;
				if ( buttons.GenericDrawButtonisClicked == true ) graphicSettings.gameState = GameState.GENERIC;
				background.backgroundSet = background.backStartUp;
			}

			//MMN Game State
			if (graphicSettings.gameState == GameState.MMN) {
				if ( buttons.MMNButtonisClicked == true ) graphicSettings.gameState = GameState.MMN;
				if ( buttons.GenericDrawButtonisClicked == true ) graphicSettings.gameState = GameState.GENERIC;
				if (mouse.mouseState.LeftButton == ButtonState.Pressed && buttons.MMNButtonPos.Contains (mouse.mouseRectangle)) {
					buttons.MMNButtonDefault = buttons.MMNButtonDown;
				}

				buttons.MMNButtonDefault = buttons.MMNButtonDown;
				background.backgroundSet = background.back1;
			}

			//GENERIC Game State
			if (graphicSettings.gameState == GameState.GENERIC) {
				if ( buttons.MMNButtonisClicked == true ) graphicSettings.gameState = GameState.MMN;
				if ( buttons.GenericDrawButtonisClicked == true ) graphicSettings.gameState = GameState.GENERIC;
				if (mouse.mouseState.LeftButton == ButtonState.Pressed && buttons.GenericDrawButtonPos.Contains (mouse.mouseRectangle)) {
					buttons.GenericDrawButtonDefault = buttons.GenericDrawButtonDown;
				}
				buttons.GenericDrawButtonDefault = buttons.GenericDrawButtonDown;
				background.backgroundSet = background.back2;
			}


			//Mouse Click Logic
			if ( mouse.mouseState.LeftButton == ButtonState.Pressed && buttons.MMNButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.MMNButtonDefault = buttons.MMNButtonDown;
				buttons.MMNButtonisClicked = true; 
				buttons.GenericDrawButtonisClicked = false;
			} 

			if ( mouse.mouseState.LeftButton == ButtonState.Pressed && buttons.GenericDrawButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.GenericDrawButtonDefault = buttons.GenericDrawButtonDown;
				buttons.GenericDrawButtonisClicked = true; 
				buttons.MMNButtonisClicked = false;
			} 

			//Timer Click Logic
			if (mouse.mouseState.LeftButton == ButtonState.Pressed && buttons.CountdownButtonPos.Contains (mouse.mouseRectangle)) {
				buttons.CountdownButtonDefault = buttons.CountdownButtonDown; 
				timer.timerShow = true; buttons.RedrawButtonisClicked = false; buttons.CountdownButtonisClicked = true; background.overlayShow = true;} 
			if (buttons.CountdownButtonisClicked) { buttons.CountdownButtonDefault = buttons.CountdownButtonDown; }


			//Redraw Click Logic
			if (mouse.mouseState.LeftButton == ButtonState.Pressed && buttons.RedrawButtonPos.Contains (mouse.mouseRectangle)) 
			{ buttons.RedrawButtonDefault = buttons.RedrawButtonDown; 
				timer.timerShow = false; buttons.RedrawButtonisClicked = true; buttons.CountdownButtonisClicked = false; background.overlayShow = false;} 
			if (buttons.RedrawButtonisClicked == true) { buttons.RedrawButtonDefault = buttons.RedrawButtonDown; } 


			base.Update (gameTime);
		}
			

		protected override void Draw (GameTime gameTime)
		{
			//Draw the game
			background.backRectangle = new Rectangle (0, 0, graphicSettings.graphics.GraphicsDevice.Viewport.Width, graphicSettings.graphics.GraphicsDevice.Viewport.Width);
			graphicSettings.graphics.GraphicsDevice.Clear (Color.Black);

			//Draw to the Game Window Side (Left)
			graphicSettings.graphics.GraphicsDevice.Viewport = splitscreen.Game();
			spriteBatch.Begin ();
			background.Draw (spriteBatch);
			//spriteBatch.Draw (background.backgroundSet, background.backRectangle, Color.White);
			timer.Draw (spriteBatch);
			spriteBatch.End ();

			//Draw to the User Interface Side (Right)
			graphicSettings.graphics.GraphicsDevice.Viewport = splitscreen.Ui ();
			spriteBatch.Begin ();
			buttons.Draw(spriteBatch);
			mouse.Draw (spriteBatch);
			spriteBatch.End ();

			base.Draw (gameTime);
		}
	}
}

