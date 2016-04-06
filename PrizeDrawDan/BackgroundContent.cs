using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace PrizeDrawDan
{
	class BackgroundContent
	{
		//Background Texture Types
		Texture2D backgroundImage;
		Texture2D window;
		Texture2D banner;

		string currentBackground;
		SpriteBatch batch;
		GraphicsDevice device;
		GameState game;
	

		internal BackgroundContent(GameState theGame)
		{
			game = theGame;
		}

		internal void LoadContent(GraphicsDevice graphicsDevice, ContentManager Content)
		{
			batch = new SpriteBatch (graphicsDevice);
			device = graphicsDevice;
		}

		internal void Update(GameTime gameTime)
		{
			bool loadDefault = false;
		}

		internal void Draw(GraphicsDevice graphicsDevice)
		{
			graphicsDevice.Clear(Color.Black);

			if (backgroundImage != null) {
				batch.Begin ();
				batch.Draw (backgroundImage, new Vector2 (0, 0), Color.White);	
				batch.End ();
			}
		}
	}
}