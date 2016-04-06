﻿using System;

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

		//Background stuff
		Rectangle backRectangle;
		Texture2D back1;
		Texture2D back2;
		Color colour;

		//Mouse Stuff
		private MouseState oldState;


		public Game1 ()
		{
			ctx = new PrizeDrawContext (new GraphicsDeviceManager (this));
			Content.RootDirectory = "Content";
			splitscreen = new SplitScreen ();
			main = new MainMenu ();
			//background = new BackgroundContent ();
			colour = new Color(255, 255, 255, 255);
			this.IsMouseVisible = true;

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

			back1 = Content.Load<Texture2D> ("Background1");
			back2 = Content.Load<Texture2D> ("Background2");


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
			// TODO: Add your update logic here
			MouseState newState = Mouse.GetState();
			if(newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
			{
				if (ctx.gameState == GameState.Back1) 
				{
					ctx.gameState = GameState.Back2;
				} else 
				{
					ctx.gameState = GameState.Back1;
				}
			}
			oldState = newState;
            
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
				spriteBatch.Draw (back1, backRectangle, colour);
				break;
			case GameState.Back2:
				spriteBatch.Draw (back2, backRectangle, colour);
				break;

			}
			spriteBatch.End ();


			//Draw to the User Interface Side (Right)
			ctx.graphics.GraphicsDevice.Viewport = splitscreen.Ui ();
			spriteBatch.Begin ();
			main.Draw (spriteBatch); 
			spriteBatch.End ();


			base.Draw (gameTime);
		}
	}
}

