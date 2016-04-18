using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	class MouseControl
	{
		//Mouse States
		MouseState previousState, currentState;

		//Mouse Position
		public Vector2 Position
		{
			get;
			protected set;
		}

		//Mouse Boundaries
		public Rectangle Rectangle
		{
			get;
			protected set;
		}

		//Mouse Texture
		Texture2D texture;

		//Left Click
		public bool LeftClick
		{
			get { return currentState.LeftButton == ButtonState.Pressed; }
		}
		public bool NewLeftClick
		{
			get { return currentState.LeftButton == ButtonState.Pressed 
				&& previousState.LeftButton == ButtonState.Released; }
		}
		public bool LeftRelease
		{
			get { return !LeftClick && previousState.LeftButton == ButtonState.Pressed; }
		}
		public bool NormalState
		{
			get { return !LeftClick && !LeftRelease; }
		}

		public ClickableGameplayObject ClickedObject
		{
			get;
			set;
		}

		//Creates an empty mouse object.
		public MouseControl() { }

		//Creates a mouse object with the texture.
		public MouseControl(Texture2D texture)
		{
			this.texture = texture;
		}

		//Loads Texture
		public MouseControl(ContentManager content, string assetName)
		{
			texture = content.Load<Texture2D>(assetName);
		}

		//Mouse State Update
		public void Update()
		{
			previousState = currentState;
			currentState = Microsoft.Xna.Framework.Input.Mouse.GetState();

			Position = new Vector2(currentState.X, currentState.Y);
			Rectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
		}

		//Draw Mouse texture
		public void Draw(SpriteBatch spriteBatch)
		{
			if (texture != null)
			{
				spriteBatch.Begin();
				spriteBatch.Draw(texture, Position, Color.White);
				spriteBatch.End();
			}
		}

	}

}

