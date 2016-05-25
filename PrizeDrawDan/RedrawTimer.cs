using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.BitmapFonts;

namespace PrizeDrawDan
{
	public class RedrawTimer
	{
		//GraphicSettings graphics;

		//Timer Font
		BitmapFont timerFont;

		//Timer Positions
		Vector2 timerPos;
		Vector2 timerShadow;

		//Name Positions
		Vector2 namePos;
		Vector2 nameSize;
		Vector2 nameShadow;


		//Timer
		TimeSpan timeSpan = new TimeSpan (0, 2, 0);
		float timer = 1;

		//TImer Colors
		Color timerColor;
		Color shadowColor;

		//Name Entry Text
		public string nameEntry;

		//TImer Int
		public int endTimer; 
		private int countTimerRef;
		public int timerDuration = 121;

		//Timer Text
		public string displayTimer;
		public string uiTimer;

		//Timer Switches
		public bool timerShow;
		public bool isRunning;
		public bool isFinished;


		public RedrawTimer(){
			displayTimer = "";
			endTimer = 0;
			countTimerRef = 0; 
			isRunning = false; 
			isFinished = false; 

		}

		public void start(int seconds) 
		{ 
			endTimer = seconds; 
			isRunning = false; 
		} 

		public Boolean checkTime(GameTime gameTime) 
		{ 
			countTimerRef += (int)gameTime.ElapsedGameTime.TotalMilliseconds; 
			if (!isFinished) 
			{ 
				if (countTimerRef >= 1000.0f) 
				{ 
					endTimer = endTimer - 1; 
					int min = endTimer / 60;
					int sec = endTimer % 60;
					displayTimer = string.Format ("{0:00}:{1:00}", min, sec); 
					uiTimer = string.Format ("{0:00}:{1:00}", min, sec);
					countTimerRef = 0; 
					if (endTimer <= 0) 
					{ 
						endTimer = 0; 
						isFinished = true; 
						displayTimer  = "Jackpot"; 
						uiTimer = "Jackpot";
					} 
				} 
			} 
			else 
			{ 

				displayTimer = "REDRAW"; 
			} 
			return isFinished; 
		} 
		public void reset() 
		{ 
			isRunning = false; 
			isFinished = false; 
			displayTimer = "None"; 
			uiTimer = "None";
			countTimerRef = 0; 
			endTimer = 0; 
		}   

		public void LoadContent (ContentManager Content){

			//Timer Content
			timerFont = Content.Load<BitmapFont> ("Timer Font");
		}


		public void Update(GameTime gameTime, GraphicSettings graphicSettings){

			//Timer Update
			timer += (float)timeSpan.TotalSeconds;

			//Name Input
			nameEntry = ("Daniel Mazzarol");

			//Timer Position
			int centerTimerPos = (graphicSettings.graphics.GraphicsDevice.Viewport.Width / 2);
			timerPos = new Vector2 (centerTimerPos - 180, 720 / 2 + 50);
			timerShadow = new Vector2 (centerTimerPos - 175, 720 / 2+ 55);

			//Name Position
			nameSize = timerFont.MeasureString(nameEntry);
			int centerTextPos = (graphicSettings.graphics.GraphicsDevice.Viewport.Width / 2) - ((int)nameSize.X / 2);
			namePos = new Vector2 (centerTextPos, 720 / 2 - 305);
			nameShadow = new Vector2 (centerTextPos + 5, 720/2 - 300);


			//Hide/Show Logic
			if (timerShow == true)
			{ timerColor = Color.White; shadowColor = Color.Black; }
			else if (timerShow == false)
			{ timerColor = Color.Transparent; shadowColor = Color.Transparent;}

			//Counter starts seconds down
			if (isRunning == false) 
			{ start(timerDuration); } else { checkTime(gameTime); }   

		}

		public void Draw (SpriteBatch spriteBatch){

			//Timer Draw
			spriteBatch.DrawString (timerFont, nameEntry, nameShadow, shadowColor);
			spriteBatch.DrawString (timerFont, nameEntry, namePos, timerColor);
			spriteBatch.DrawString (timerFont, displayTimer, timerShadow, shadowColor);
			spriteBatch.DrawString (timerFont, displayTimer, timerPos, timerColor);
		}
	}
}

