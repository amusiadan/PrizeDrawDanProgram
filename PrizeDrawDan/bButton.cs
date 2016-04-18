using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace PrizeDrawDan
{
	class bButton
	{
		Texture2D texture;
		Vector2 position;
		Rectangle rectangle;

		Color colour = new Color (255, 255, 255, 255);

		public Vector2 size;

		public bButton(Texture2D newTexture, GraphicsDevice graphics){
			texture = newTexture;


			size = new Vector2 (graphics
				.Viewport.Width / 8, graphics.Viewport.Height / 30);
		}

		public void setPosition (Vector2 newPosition){
			position = newPosition;
		}

		bool down;
		public bool isClicked;
		public void Update(MouseState mouse){
			rectangle = new Rectangle ((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);

			Rectangle mouseRectangle = new Rectangle (mouse.X, mouse.Y, 1, 1);

			if (mouseRectangle.Intersects (rectangle)) {
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
			}
		}

		public void Draw(SpriteBatch spriteBatch){
			spriteBatch.Draw(texture, rectangle, colour);
		}
	}
}



