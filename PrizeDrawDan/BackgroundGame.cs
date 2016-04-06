using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class BackgroundGame
	{
		Texture2D backgroundImage;
		Vector2 position;
		string backgroundName;
		string id;

		public BackgroundGame(string backgroundImage, string id){
			this.backgroundName = backgroundImage;
			this.id = id;
		}

		public string BackgroundImage{
			get {
				return backgroundName;
			}
			set { backgroundName = value; }
		}

		public string Id {
			get {
				return id;
			}
			set { id = value; }
		}

		public void LoadContent(ContentManager content){
			backgroundImage = content.Load<Texture2D>(backgroundName);
			position = new Vector2 (0, 0);
		}

		public void Draw(SpriteBatch spriteBatch){
			spriteBatch.Draw (backgroundImage, position);
		}
	}

}

