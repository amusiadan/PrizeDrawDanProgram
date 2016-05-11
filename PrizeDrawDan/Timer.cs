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
		Color timerColor;
		public bool timerShow;

		public void LoadContent (ContentManager content){

			//Timer Content
			timerFont = content.Load<SpriteFont> ("Timer Font");
		}

		public void Update (){
			

			//Timer Update
			date = DateTime.Now.ToString ("F");
			timerPos = new Vector2 (260, 720/2);

			if (timerShow == true)
			{ timerColor = Color.Black; }
			else if (timerShow == false)
			{ timerColor = Color.Transparent; }
		}

		public void Draw (SpriteBatch spriteBatch){

			//Timer Draw
			spriteBatch.DrawString (timerFont, "Time: " + date, timerPos, timerColor);
		}
	}
}

