using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class MouseControl
	{

		//Mouse 
		public MouseState oldMouseState;
		public Vector2 mousePos;
		public int mousePosX;
		public int mousePosY;
		Texture2D mouseTexture;
		public Rectangle mouseRectangle;

		public void LoadContent (ContentManager content){
			//Mouse Pointer
			mouseTexture = content.Load<Texture2D> ("Mouse Pointer");
			Mouse.SetPosition(500, 300);
		}


		public void Update (){

			mousePos = new Vector2 (mousePosX, mousePosY);

			MouseState mouseState = Mouse.GetState();
			mousePosX = mouseState.X;
			mousePosY = mouseState.Y;

			mouseRectangle = new Rectangle (mousePosX, mousePosY, 1, 1);

			oldMouseState = mouseState;
		}

		public void Draw(SpriteBatch spriteBatch){
			spriteBatch.Draw (mouseTexture, mousePos, Color.White);
		}

	}
}

