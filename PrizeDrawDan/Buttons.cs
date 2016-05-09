using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PrizeDrawDan
{
	public class Buttons
	{
		//Mouse Rectangle
		MouseControl mouseControl;
		//Rectangle mouseRectangle;

		//Button Positions
		Rectangle MMNButtonPos;
		Rectangle CountdownButtonPos;
		Rectangle RedrawButtonPos;

		//Button Textures
		Texture2D MMNButtonDefault;
		Texture2D MMNButtonHover;
		Texture2D MMNButton;
		Texture2D CountdownButtonDefault;
		Texture2D CountdownButtonHover;
		Texture2D CountdownButton;
		Texture2D RedrawButtonDefault;
		Texture2D RedrawButtonHover;
		Texture2D RedrawButton;


		public void LoadContent (ContentManager content){

			//Button Content
			MMNButton = content.Load<Texture2D> ("MMN Button");
			MMNButtonHover = content.Load<Texture2D> ("MMN Button Hover");
			CountdownButton = content.Load<Texture2D> ("Countdown Button");
			CountdownButtonHover = content.Load<Texture2D> ("Countdown Button Hover");
			RedrawButton = content.Load<Texture2D> ("Redraw Button");
			RedrawButtonHover = content.Load<Texture2D> ("Redraw Button Hover");
			MMNButtonDefault = MMNButton;
			CountdownButtonDefault = CountdownButton;
			RedrawButtonDefault = RedrawButton;
		}

		public void Update (){

			//Mouse Rectangle
			mouseControl = new MouseControl();


			//Button Rectangles
			MMNButtonPos = new Rectangle (10, 300, MMNButtonDefault.Width, MMNButtonDefault.Height);
			CountdownButtonPos = new Rectangle (850, 500, CountdownButtonDefault.Width, CountdownButtonDefault.Height);
			RedrawButtonPos = new Rectangle (850, 580, RedrawButtonDefault.Width, RedrawButtonDefault.Height);


			//Mouse/Button Behaviour
			if (MMNButtonPos.Contains (mouseControl.mouseRectangle)) {
				MMNButtonDefault = MMNButtonHover;
			} else {
				MMNButtonDefault = MMNButton;
			}
			if (CountdownButtonPos.Contains (mouseControl.mouseRectangle)) {
				CountdownButtonDefault = CountdownButtonHover;
			} else {
				CountdownButtonDefault = CountdownButton;
			}
			if (RedrawButtonPos.Contains (mouseControl.mouseRectangle)) {
				RedrawButtonDefault = RedrawButtonHover;
			} else {
				RedrawButtonDefault = RedrawButton;
			}
		}


		public void Draw(SpriteBatch spriteBatch){

			//Draw Buttons
			spriteBatch.Draw (MMNButtonDefault, MMNButtonPos, Color.White);
			spriteBatch.Draw (CountdownButtonDefault, CountdownButtonPos, Color.White);
			spriteBatch.Draw (RedrawButtonDefault, RedrawButtonPos, Color.White);
		}
	}
}
