using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class BackgroundGame
	{
		SpriteBatch spriteBatch;
		Texture2D backgroundImage;
		Vector2 position;
		//Rectangle destinationRectangle;
		//Rectangle sourceRectangle;
		//float rotation = 0; 
		//Vector2 scale;



		public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content){
			
			spriteBatch = new SpriteBatch (graphicsDevice);
			backgroundImage = content.Load<Texture2D>("back");
			position = new Vector2 (0, 0);
			//destinationRectangle = new Rectangle (0, 0, 1080, 720);
			//sourceRectangle = new Rectangle (0, 0, 1080, 720);
			//scale = new Vector2 (0, 0);


		}

		public void Draw(GraphicsDevice GraphicsDevice){
			spriteBatch.Begin ();
			spriteBatch.Draw (backgroundImage, position);
			spriteBatch.End ();
		}
	}

}

