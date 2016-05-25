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
		CurrentState currentState;
		Buttons buttons;
		MouseControl mouse;
		Backgrounds background;
		RedrawTimer redrawTimer;
		CountdownTimer countdownTimer;
		UIText uiText;





		public Game1 ()
		{
			//Game Classes
			graphicSettings = new GraphicSettings (new GraphicsDeviceManager (this));
			Content.RootDirectory = "Content";
			splitscreen = new SplitScreen ();
			currentState = new CurrentState ();
			buttons = new Buttons ();
			mouse = new MouseControl ();
			background = new Backgrounds ();
			redrawTimer = new RedrawTimer();
			countdownTimer = new CountdownTimer ();
			uiText = new UIText ();
		}


		protected override void Initialize ()
		{
			//GraphicSettings Initialize
			graphicSettings.Initialize();
			IsMouseVisible = false;

			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

			//Load Game Content
			splitscreen.LoadContent (graphicSettings);
			buttons.LoadContent (Content);
			mouse.LoadContent (Content);
			background.LoadContent (Content);
			redrawTimer.LoadContent (Content);
			countdownTimer.LoadContent (Content);
			uiText.LoadContent (Content);
		}


		protected override void Update (GameTime gameTime)
		{
			//Exit Game Button
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif


			//Update logic
			currentState.Update (gameTime, graphicSettings, buttons, background, mouse, redrawTimer, uiText);
			buttons.Update(gameTime, mouse, buttons, redrawTimer, background, countdownTimer);
			mouse.Update (gameTime, buttons, redrawTimer, background, countdownTimer);
			redrawTimer.Update (gameTime, graphicSettings);
			background.Update (graphicSettings);
			countdownTimer.Update (gameTime);
			uiText.Update (redrawTimer);
			base.Update (gameTime);
		}
			

		protected override void Draw (GameTime gameTime)
		{
			//Draw the game
			graphicSettings.graphics.GraphicsDevice.Clear (Color.Black);

			//Draw to the Game Window Side (Left)
			graphicSettings.graphics.GraphicsDevice.Viewport = splitscreen.Game();
			spriteBatch.Begin ();
			background.Draw (spriteBatch);
			redrawTimer.Draw (spriteBatch);
			countdownTimer.Draw (spriteBatch);
			spriteBatch.End ();

			//Draw to the User Interface Side (Right)
			graphicSettings.graphics.GraphicsDevice.Viewport = splitscreen.Ui ();
			spriteBatch.Begin ();
			uiText.Draw (spriteBatch);
			buttons.Draw(spriteBatch);
			mouse.Draw (spriteBatch);
			spriteBatch.End ();

			base.Draw (gameTime);
		}
	}
}

