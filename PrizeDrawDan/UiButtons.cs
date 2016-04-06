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


		//Button Assets
		string id;
		Texture2D buttonImage;
		public Rectangle buttonRectangle;
		string assetName;
		Color colour = new Color (255, 255, 255, 255);


		//Button Name and Id Getter
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

		//Load Button and Position by Name
		public void LoadContent (ContentManager content){
			buttonImage = content.Load<Texture2D> (assetName);
			buttonRectangle = new Rectangle (100, 100, buttonImage.Width, buttonImage.Height);
		}

		//Center the button
		public void CenterButton(int width, int height){
			buttonRectangle = new Rectangle ((width / 2) - (this.buttonImage.Width / 2),
				(height / 2) - (this.buttonImage.Height / 2), this.buttonImage.Width, this.buttonImage.Height);
		}


		public void MoveButton(int x, int y){
			buttonRectangle = new Rectangle (buttonRectangle.X += x, buttonRectangle.Y += y, 
				buttonRectangle.Width, buttonRectangle.Height);
		}

		//Draw Button
		public void Draw (SpriteBatch spriteBatch){
			spriteBatch.Draw (buttonImage, buttonRectangle, colour);
		}
	}
}