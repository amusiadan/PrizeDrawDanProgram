using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PrizeDrawDan
{
	public class Buttons
	{
		//Button Positions
		public Rectangle MMNButtonPos;
		public Rectangle GenericDrawButtonPos;
		public Rectangle CountdownButtonPos;
		public Rectangle RedrawButtonPos;



		//Button Textures
		public Texture2D MMNButtonDefault;
		public Texture2D MMNButtonHover;
		public Texture2D MMNButton;
		public Texture2D MMNButtonDown;
		public Texture2D GenericDrawButtonDefault;
		public Texture2D GenericDrawButtonHover;
		public Texture2D GenericDrawButton;
		public Texture2D GenericDrawButtonDown;
		public Texture2D CountdownButtonDefault;
		public Texture2D CountdownButtonHover;
		public Texture2D CountdownButton;
		public Texture2D CountdownButtonDown;
		public Texture2D RedrawButtonDefault;
		public Texture2D RedrawButtonHover;
		public Texture2D RedrawButton;
		public Texture2D RedrawButtonDown;

		//Button Click States
		public bool MMNButtonisClicked;
		public bool GenericDrawButtonisClicked;
		public bool CountdownButtonisClicked;
		public bool RedrawButtonisClicked;
		public bool CountdownButtonisDown;

		public void LoadContent (ContentManager Content){

			//Button Content
			MMNButton = Content.Load<Texture2D> ("MMN Button");
			MMNButtonHover = Content.Load<Texture2D> ("MMN Button Hover");
			MMNButtonDown = Content.Load<Texture2D> ("MMN Button Down");
			GenericDrawButton = Content.Load<Texture2D> ("Generic Draw Button");
			GenericDrawButtonHover = Content.Load<Texture2D> ("Generic Draw Button Hover");
			GenericDrawButtonDown = Content.Load<Texture2D> ("Generic Draw Button Down");
			CountdownButton = Content.Load<Texture2D> ("Countdown Button");
			CountdownButtonHover = Content.Load<Texture2D> ("Countdown Button Hover");
			CountdownButtonDown = Content.Load<Texture2D> ("Countdown Button Down");
			RedrawButton = Content.Load<Texture2D> ("Redraw Button");
			RedrawButtonHover = Content.Load<Texture2D> ("Redraw Button Hover");
			RedrawButtonDown = Content.Load<Texture2D> ("Redraw Button Down");

			//Default Button States
			MMNButtonDefault = MMNButton;
			GenericDrawButtonDefault = GenericDrawButton;
			CountdownButtonDefault = CountdownButton;
			RedrawButtonDefault = RedrawButton;

		}

		public void Update (GameTime gameTime, MouseControl mouse, Buttons buttons, RedrawTimer redrawTimer, Backgrounds background, CountdownTimer countdownTimer){

			//Button Rectangles
			MMNButtonPos = new Rectangle (10, 300, MMNButtonDefault.Width, MMNButtonDefault.Height);
			GenericDrawButtonPos = new Rectangle (10, 200, MMNButtonDefault.Width, MMNButtonDefault.Height);
			CountdownButtonPos = new Rectangle (850, 500, CountdownButtonDefault.Width, CountdownButtonDefault.Height);
			RedrawButtonPos = new Rectangle (850, 580, RedrawButtonDefault.Width, RedrawButtonDefault.Height);


			//Button Hover Logic
			if (MMNButtonPos.Contains (mouse.mouseRectangle)) {
				MMNButtonDefault = MMNButtonHover;  } else { MMNButtonDefault = MMNButton; }
			
			if (GenericDrawButtonPos.Contains (mouse.mouseRectangle)) {
				GenericDrawButtonDefault = GenericDrawButtonHover; } else { GenericDrawButtonDefault = GenericDrawButton; }

			if (CountdownButtonPos.Contains (mouse.mouseRectangle)) {
			CountdownButtonDefault = CountdownButtonHover; } else { CountdownButtonDefault = CountdownButton; }

			
			if ( RedrawButtonPos.Contains (mouse.mouseRectangle)) {
				RedrawButtonDefault = RedrawButtonHover;} else { RedrawButtonDefault = RedrawButton; }

			//Countdown Button Logic
			if (CountdownButtonisClicked == true) {
				redrawTimer.timerShow = false;
				CountdownButtonisClicked = true; 
				redrawTimer.isRunning = true;
				countdownTimer.timerShow = true;
			}
			if (buttons.CountdownButtonisClicked == false) {
				buttons.CountdownButtonisClicked = false; 
				countdownTimer.timerShow = false;
				redrawTimer.isRunning = false;
		}



			//Redraw Button Logic
			if (RedrawButtonisClicked == true) {
				redrawTimer.timerShow = true;
				background.overlayShow = true;
				redrawTimer.isRunning = true;
				countdownTimer.timerShow = false;}

			if (RedrawButtonisClicked == false) {
				redrawTimer.timerShow = false; 
				background.overlayShow = false;
				}
		}


		public void Draw (SpriteBatch spriteBatch){

			//Draw Buttons
			spriteBatch.Draw (MMNButtonDefault, MMNButtonPos, Color.White);
			spriteBatch.Draw (GenericDrawButtonDefault, GenericDrawButtonPos, Color.White);
			spriteBatch.Draw (CountdownButtonDefault, CountdownButtonPos, Color.White);
			spriteBatch.Draw (RedrawButtonDefault, RedrawButtonPos, Color.White);
		}
	}
}
