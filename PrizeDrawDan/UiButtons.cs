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
		Texture2D buttonImage;
		Rectangle buttonRectangle;
		string assetName;

		public delegate void ButtonClicked(string button);

		public event ButtonClicked clickEvent;

		public UiButtons(string assetName){
			this.assetName = assetName;
		}

		public string AssetName {
			get {
				return assetName;
			}
			set { assetName = value; }
		}

		public void LoadContent(ContentManager content){
			buttonImage = content.Load<Texture2D> (assetName);
			buttonRectangle = new Rectangle (100, 100, buttonImage.Width, buttonImage.Height);
		}

		public void Update(){
			if (buttonRectangle.Contains (new Point (Mouse.GetState ().X, Mouse.GetState ().Y))
			    && Mouse.GetState ().LeftButton == ButtonState.Pressed) {
				clickEvent (assetName);
			}
		}

		public void Draw (SpriteBatch spriteBatch){
			spriteBatch.Draw (buttonImage, buttonRectangle, Color.White);
		}

		public void CenterButton(int width, int height){
			buttonRectangle = new Rectangle ((width / 2) - (this.buttonImage.Width / 2),
				(height / 2) - (this.buttonImage.Height / 2), this.buttonImage.Width, this.buttonImage.Height);
		}

		public void MoveButton(int x, int y){
			buttonRectangle = new Rectangle (buttonRectangle.X += x, buttonRectangle.Y += y, 
				buttonRectangle.Width, buttonRectangle.Height);
		}


	}
}