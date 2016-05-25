using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.BitmapFonts;

namespace PrizeDrawDan
{
	public class CountdownTimer
	{
		//BarrelTime barrelTime;
		public string timeNow;
		BitmapFont timerFont;
		Vector2 timerPos;
		Color timerColor;


		//Barrel Timer Switches
		public bool timerShow;
		public bool isRunning;
		public bool isFinished;

		public void LoadContent (ContentManager Content){

			//Timer Content
			timerFont = Content.Load<BitmapFont> ("Timer Font");
		}
			
		public void Update(GameTime gameTime){

			timeNow = DateTime.Now.ToString ("T");


			if (timerShow == true)
			{ timerColor = Color.Black; }
			else if (timerShow == false)
			{ timerColor = Color.Transparent; }

			timerPos = new Vector2 (1080/2 - 420, 720/2 - 200);
		}

		public void Draw(SpriteBatch spriteBatch){

			//Barrel Timer Draw
			spriteBatch.DrawString (timerFont, timeNow, timerPos, timerColor);
		}


	}
}