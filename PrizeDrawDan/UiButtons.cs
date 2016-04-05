using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class UiButtons
	{
		Texture2D button;
		Rectangle buttonRectangle;
		string assetName;

		public UiButtons(string assetName){
			this.assetName = assetName;
		}

		public void LoadContent(ContentManager content){
			button = content.Load<Texture2D> (assetName);
			buttonRectangle = new Rectangle (0, 0, button.Width, button.Height);
		}

		public void Draw (SpriteBatch spriteBatch){
			spriteBatch.Draw (button, buttonRectangle, Color.White);
		}
	}
}