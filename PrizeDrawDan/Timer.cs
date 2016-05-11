using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.BitmapFonts;

namespace PrizeDrawDan
{
	public class Timer
	{
		//Timer
		BitmapFont timerFont;
		TimeSpan timeSpan = new TimeSpan(0, 0, 120);
		Vector2 timerPos;
		//string timerText;
		Color timerColor;
		float timer = 1;

		//TImer Int
		private int endTimer; 
		private int countTimerRef;


		//Timer Text
		public string displayTimer;

		//Timer Switches
		public bool timerShow;
		public bool isRunning;
		public bool isFinished;


		public Timer(){
			displayTimer = "";
			endTimer = 0;
			countTimerRef = 0; 
			isRunning = false; 
			isFinished = false; 

		}

		public void start(int seconds) 
		{ 
			endTimer = seconds; 
			isRunning = true; 
			displayTimer = endTimer.ToString ();
		} 

		public Boolean checkTime(GameTime gameTime) 
		{ 
			countTimerRef += (int)gameTime.ElapsedGameTime.TotalMilliseconds; 
			if (!isFinished) 
			{ 
				if (countTimerRef >= 1000.0f) 
				{ 
					endTimer = endTimer - 1; 
					displayTimer  = endTimer.ToString(); 
					countTimerRef = 0; 
					if (endTimer <= 0) 
					{ 
						endTimer = 0; 
						isFinished = true; 
						displayTimer  = "Game Over"; 
					} 
				} 
			} 
			else 
			{ 

				displayTimer = "Game Over"; 
			} 
			return isFinished; 
		} 
		public void reset() 
		{ 
			isRunning = false; 
			isFinished = false; 
			displayTimer = "None"; 
			countTimerRef = 0; 
			endTimer = 0; 
		}   

		public void LoadContent (ContentManager content){

			//Timer Content
			timerFont = content.Load<BitmapFont> ("Timer Font");
		}


		public void Update(){

			//Timer Update
			//date = DateTime.Now.ToString ("t");
			timer += (float)timeSpan.TotalSeconds;

			timerPos = new Vector2 (260, 720/2);


			if (timerShow == true)
			{ timerColor = Color.Black; }
			else if (timerShow == false)
			{ timerColor = Color.Transparent; }


				
		}

		public void Draw (SpriteBatch spriteBatch){

			//Timer Draw
			spriteBatch.DrawString (timerFont, displayTimer, timerPos, timerColor);
		}
	}
}

