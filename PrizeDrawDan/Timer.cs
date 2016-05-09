using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class Timer
	{
		//Timer
		SpriteFont timerFont;
		Vector2 timerPos;
		string date;

		public void LoadContent (ContentManager content){

			//Timer Content
			timerFont = content.Load<SpriteFont> ("Timer Font");
		}

		public void Update (){

			//Timer Update
			date = DateTime.Now.ToString ("F");
			timerPos = new Vector2 (20, 20);
		}

		public void Draw (SpriteBatch spriteBatch){

			//Timer Draw
			spriteBatch.DrawString (timerFont, "Time: " + date, timerPos, Color.White);
		}
	}
}

