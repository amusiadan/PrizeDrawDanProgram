using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		SpriteBatch spriteBatch;
		PrizeDrawContext ctx;
		SplitScreen splitscreen;
		Buttons buttons;
		MouseControl mouse;


		//Background Stuff
		Rectangle backRectangle;
		Texture2D back1;
		Texture2D back2;


		//Timer
		SpriteFont timerFont;
		Vector2 timerPos;
		string date;

		//GameState CurrentGameState = GameState.Back1;

		public Game1 ()
		{
			ctx = new PrizeDrawContext (new GraphicsDeviceManager (this));
			Content.RootDirectory = "Content";
			splitscreen = new SplitScreen ();
			buttons = new Buttons ();
			mouse = new MouseControl ();
		}


		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			ctx.Initialize();
			IsMouseVisible = false;

			base.Initialize ();
		}

		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: use this.Content to load your game content here 
			splitscreen.LoadContent (ctx);
			buttons.LoadContent (Content);
			mouse.LoadContent (Content);

			//Background Content
			back1 = Content.Load<Texture2D> ("Background1");
			back2 = Content.Load<Texture2D> ("Background2");

			//Timer Content
			timerFont = Content.Load<SpriteFont> ("Timer Font");

		}


		protected override void Update (GameTime gameTime)
		{

			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif

			// TODO: Add your update logic here      
			buttons.Update();
			mouse.Update ();

			//timer update
			date = DateTime.Now.ToString ("F");


			base.Update (gameTime);
		}
			

		protected override void Draw (GameTime gameTime)
		{
			//TODO: Add your drawing code here
			backRectangle = new Rectangle (0, 0, ctx.graphics.GraphicsDevice.Viewport.Width, ctx.graphics.GraphicsDevice.Viewport.Width);
			ctx.graphics.GraphicsDevice.Clear (Color.Black);
			timerPos = new Vector2 (20, 20);
		

			//Draw to the Game Window Side (Left)
			ctx.graphics.GraphicsDevice.Viewport = splitscreen.Game();
			spriteBatch.Begin ();
				switch (ctx.gameState) {
				case GameState.Back1:
					spriteBatch.Draw (back1, backRectangle, Color.White);
					break;
				case GameState.Back2:
					spriteBatch.Draw (back2, backRectangle, Color.White);
					break;
				}
			spriteBatch.DrawString (timerFont, "Time: " + date, timerPos, Color.White);
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

