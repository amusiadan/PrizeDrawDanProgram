using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class Backgrounds
	{
		public Rectangle backRectangle;

		//Background Textures
		public Texture2D backgroundSet;
		public Texture2D backStartUp;
		public Texture2D back1;
		public Texture2D back2;
		public Texture2D overlay;

		public Color overlayColor;
		public bool overlayShow;
		Color overlayTransparentColor;


		public void LoadContent (ContentManager Content){
			//Background Content
			backStartUp = Content.Load<Texture2D> ("Startup");
			back1 = Content.Load<Texture2D> ("Background1");
			back2 = Content.Load<Texture2D> ("Background2");
			overlay = Content.Load<Texture2D> ("BackgroundOverlay");


		}

		public void Update (){

			overlayTransparentColor = new Color(60, 60, 60, 10);

			if (overlayShow == true)
			{ overlayColor = overlayTransparentColor; }
			else if (overlayShow == false)
			{ overlayColor = Color.Transparent; }
		}

		public void Draw (SpriteBatch spriteBatch){
			spriteBatch.Draw (backgroundSet, backRectangle, Color.White);
			spriteBatch.Draw (overlay, backRectangle, overlayColor);
		}
	}
}

