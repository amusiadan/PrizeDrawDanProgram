using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PrizeDrawDan
{
	public class Buttons
	{
		//Mouse Positions
		MouseControl mouseControl;

		//Button Positions
		public Rectangle MMNButtonPos;
		public Rectangle CountdownButtonPos;
		public Rectangle RedrawButtonPos;


		//Button Textures
		public Texture2D MMNButtonDefault;
		public Texture2D MMNButtonHover;
		public Texture2D MMNButton;
		public Texture2D CountdownButtonDefault;
		public Texture2D CountdownButtonHover;
		public Texture2D CountdownButton;
		public Texture2D RedrawButtonDefault;
		public Texture2D RedrawButtonHover;
		public Texture2D RedrawButton;


		public void LoadContent (ContentManager Content){

			//Button Content
			MMNButton = Content.Load<Texture2D> ("MMN Button");
			MMNButtonHover = Content.Load<Texture2D> ("MMN Button Hover");
			CountdownButton = Content.Load<Texture2D> ("Countdown Button");
			CountdownButtonHover = Content.Load<Texture2D> ("Countdown Button Hover");
			RedrawButton = Content.Load<Texture2D> ("Redraw Button");
			RedrawButtonHover = Content.Load<Texture2D> ("Redraw Button Hover");

			//Default Button States
			MMNButtonDefault = MMNButton;
			CountdownButtonDefault = CountdownButton;
			RedrawButtonDefault = RedrawButton;
		}

		public void Update (){
			
			//Mouse Vectors
			mouseControl = new MouseControl();

			//Button Rectangles
			MMNButtonPos = new Rectangle (10, 300, MMNButtonDefault.Width, MMNButtonDefault.Height);
			CountdownButtonPos = new Rectangle (850, 500, CountdownButtonDefault.Width, CountdownButtonDefault.Height);
			RedrawButtonPos = new Rectangle (850, 580, RedrawButtonDefault.Width, RedrawButtonDefault.Height);
		}


		public void Draw (SpriteBatch spriteBatch){

			//Draw Buttons
			spriteBatch.Draw (MMNButtonDefault, MMNButtonPos, Color.White);
			spriteBatch.Draw (CountdownButtonDefault, CountdownButtonPos, Color.White);
			spriteBatch.Draw (RedrawButtonDefault, RedrawButtonPos, Color.White);
		}
	}
}
