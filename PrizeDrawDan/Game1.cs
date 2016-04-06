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
		MainMenu main;
		//BackgroundContent background;
		UiButtons btn1;
		UiButtons btn2;
		UiButtons btn3;

		enum GameState
		{
			Game1,
			Game2,
			Game3,
		}

		GameState CurrentGameState = GameState.Game1;


		public Game1 ()
		{
			ctx = new PrizeDrawContext (new GraphicsDeviceManager (this));
			Content.RootDirectory = "Content";
			splitscreen = new SplitScreen ();
			main = new MainMenu ();
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


			this.IsMouseVisible = true;

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
			main.LoadContent (Content);

			btn1 = new UiButtons ("Button1", "Button");
			btn2 = new UiButtons ("Button2", "Button");
			btn3 = new UiButtons ("Button3", "Button");
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

			MouseState mouse = Mouse.GetState ();

			switch (CurrentGameState) {
			case GameState.Game1:
				if (btn1.isClicked == true)
					CurrentGameState = GameState.Game1;
				btn1.Update (mouse);
				break;

			case GameState.Game2:
				if (btn2.isClicked == true)
					CurrentGameState = GameState.Game2;
				btn2.Update (mouse);
				break;

			case GameState.Game3:
				if (btn3.isClicked == true)
					CurrentGameState = GameState.Game3;
				btn3.Update (mouse);
				break;
				
			}
			// TODO: Add your update logic here

			main.Update ();
            
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			ctx.graphics.GraphicsDevice.Clear (Color.Black);
            

			//TODO: Add your drawing code here
			ctx.graphics.GraphicsDevice.Viewport = splitscreen.Game();
			spriteBatch.Begin ();
			switch (CurrentGameState) {
			case GameState.Game1:
				spriteBatch.Draw (Content.Load<Texture2D> ("Background1"), new Rectangle 
					(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
				break;

			case GameState.Game2:
				spriteBatch.Draw (Content.Load<Texture2D> ("Background2"), new Rectangle 
					(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
				break;

			case GameState.Game3:

				break;
			}
			spriteBatch.End ();


			ctx.graphics.GraphicsDevice.Viewport = splitscreen.Ui ();
			spriteBatch.Begin ();
			main.Draw (spriteBatch); 
			spriteBatch.End ();



            
			base.Draw (gameTime);
		}
	}
}

