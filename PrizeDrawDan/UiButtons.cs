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
		//Mouse Assets
		Rectangle mouseRectangle;
		Color colour;
		bool down;
		public bool isClicked;

		//Button Assets
		string id;
		Texture2D buttonImage;
		public Rectangle buttonRectangle;
		string assetName;

		public delegate void ButtonClicked(string element);

		public event ButtonClicked clickEvent;

		public UiButtons(string id, string assetName){
			this.id = id;
			this.assetName = assetName;
		}

		public string Id {
			get {
				return id;
			}
		}

		public string AssetName {
			get {
				return assetName;
			}
			set { assetName = value; }
		}


		public void LoadContent (ContentManager content){
			buttonImage = content.Load<Texture2D> (assetName);
			buttonRectangle = new Rectangle (100, 100, buttonImage.Width, buttonImage.Height);
			colour = new Color (255, 255, 255, 255);
		}
			

		public void Update(MouseState mouse){

			mouseRectangle = new Rectangle (mouse.X, mouse.Y, 1, 1);


			if (mouseRectangle.Intersects (buttonRectangle)) {
				if (colour.A == 255)
					down = false;
				if (colour.A == 0)
					down = true;
				if (down)
					colour.A += 3;
				else
					colour.A -= 3;

				if (mouse.LeftButton == ButtonState.Pressed)
					isClicked = true;
				else if (colour.A < 255) {
					colour.A += 3;
					isClicked = false;
				}
				if (buttonRectangle.Contains (new Point (Mouse.GetState ().X, Mouse.GetState ().Y))
				    && Mouse.GetState ().LeftButton == ButtonState.Pressed) {
					clickEvent (assetName);
				}
			}
		}


		public void CenterButton(int width, int height){
			buttonRectangle = new Rectangle ((width / 2) - (this.buttonImage.Width / 2),
				(height / 2) - (this.buttonImage.Height / 2), this.buttonImage.Width, this.buttonImage.Height);
		}

		public void MoveButton(int x, int y){
			buttonRectangle = new Rectangle (buttonRectangle.X += x, buttonRectangle.Y += y, 
				buttonRectangle.Width, buttonRectangle.Height);
		}

		public void Draw (SpriteBatch spriteBatch){
			spriteBatch.Draw (buttonImage, buttonRectangle, colour);
		}
	}
}