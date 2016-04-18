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
		MainMenu mainMenu;

		//Button Test
		Rectangle buttonRectangle;
		Texture2D buttonDefault;
		Texture2D buttonHover;
		Texture2D buttonTexture;
		Texture2D buttonClicked;


		//Background stuff
		Rectangle backRectangle;
		Texture2D back1;
		Texture2D back2;

		//Mouse Stuff
		private MouseState oldMouseState;
		Rectangle mouseRectangle;
		Vector2 mousePos;
		Texture2D mouseTexture;


		//GameState CurrentGameState = GameState.Back1;

		public Game1 ()
		{
			ctx = new PrizeDrawContext (new GraphicsDeviceManager (this));
			Content.RootDirectory = "Content";
			splitscreen = new SplitScreen ();
			mainMenu = new MainMenu ();

			//background = new BackgroundContent ();

		}


		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			ctx.Initialize();
			IsMouseVisible = false;

			base.Initialize ();
		}
		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: use this.Content to load your game content here 
			splitscreen.LoadContent (ctx);

			//background.LoadContent (Content);
			mainMenu.LoadContent (Content);

			back1 = Content.Load<Texture2D> ("Background1");
			back2 = Content.Load<Texture2D> ("Background2");

			buttonTexture = Content.Load<Texture2D> ("Button");
			buttonHover = Content.Load<Texture2D> ("Button Hover");
			buttonClicked = Content.Load<Texture2D> ("Button Clicked");
			buttonDefault = buttonTexture;

			mouseTexture = Content.Load<Texture2D> ("Mouse Pointer");

//			bbtn = new bButton (Content.Load<Texture2D>("Button"), ctx.graphics.GraphicsDevice);
//			bbtn.setPosition (new Vector2 (350, 300));

		}


		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif


//			switch (CurrentGameState) {
//			case GameState.Back1:
//				if (bbtn.isClicked == true)
//					CurrentGameState = GameState.Back2;
//				bbtn.Update (mouse);
//				break;
//			}

			// TODO: Add your update logic here
			MouseState mouseState = Mouse.GetState();

			mousePos.X = mouseState.X;
			mousePos.Y = mouseState.Y;

			mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

			buttonRectangle = new Rectangle (100, 100, buttonDefault.Width, buttonDefault.Height);


			if (buttonRectangle.Contains(mouseRectangle)) {
				buttonDefault = buttonHover;
			} else {
				buttonDefault = buttonTexture;
			}
				


			if(mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released 
				&& buttonRectangle.Contains(mouseRectangle))
			{
				if (ctx.gameState == GameState.Back1) 
				{
					ctx.gameState = GameState.Back2;
				} else 
				{
					ctx.gameState = GameState.Back1;
				}
			}
			oldMouseState = mouseState;
            
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			backRectangle = new Rectangle (0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
			ctx.graphics.GraphicsDevice.Clear (Color.Black);
            

			//TODO: Add your drawing code here
		

			//Draw to the Game Window Side (Left)
			ctx.graphics.GraphicsDevice.Viewport = splitscreen.Game();
			spriteBatch.Begin ();
			switch (ctx.gameState){
			case GameState.Back1:
				spriteBatch.Draw (back1, backRectangle, Color.White);
				break;
			case GameState.Back2:
				spriteBatch.Draw (back2, backRectangle, Color.White);
				break;
			}
			spriteBatch.End ();


			//Draw to the User Interface Side (Right)
			ctx.graphics.GraphicsDevice.Viewport = splitscreen.Ui ();
			spriteBatch.Begin ();
			mainMenu.Draw (spriteBatch); 
			spriteBatch.Draw (buttonDefault, buttonRectangle, Color.White);
			spriteBatch.Draw (mouseTexture, mousePos, Color.White);
			spriteBatch.End ();


			base.Draw (gameTime);
		}
	}
}

