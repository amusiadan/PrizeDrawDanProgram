using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace PrizeDrawDan
{
	public class Backgrounds
	{
		PrizeDrawContext ctx;

		//Background stuff
		Texture2D back1;
		Texture2D back2;

		Rectangle backRectangle;


		public void LoadContent (ContentManager content)
		{
			//Background Content
			back1 = content.Load<Texture2D> ("Background1");
			back2 = content.Load<Texture2D> ("Background2");
		}

		//Center the button
		public void BackgroundPos(Rectangle backRectangle){
			backRectangle = new Rectangle (0, 0, ctx.graphics.GraphicsDevice.Viewport.Width, ctx.graphics.GraphicsDevice.Viewport.Width);
		}

		public void Draw (SpriteBatch spriteBatch)
		{
		switch (ctx.gameState) {
		case GameState.Back1:
			spriteBatch.Draw (back1, backRectangle, Color.White);
			break;
		case GameState.Back2:
			spriteBatch.Draw (back2, backRectangle, Color.White);
			break;
			}
		}
	}
}
