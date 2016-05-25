using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class UIText
	{
		SpriteFont font;
		Vector2 textPos;
		Vector2 debugPos;
		string nameText;
		string debugText;
		public string gameSelection;

		public void LoadContent(ContentManager Content){
			font = Content.Load<SpriteFont> ("TextFont");
		
			textPos = new Vector2 (10, 10);
			debugPos = new Vector2 (10, 640);
		}
			
		public void Update (RedrawTimer redrawTimer){
			nameText = gameSelection + "\n" + "Name:" + redrawTimer.nameEntry + 
				"\n" + "Club No:"+ "\n" + "Counter:" + redrawTimer.uiTimer;
			debugText = "Network Status Information \n goes here" + "\n" + "\n" + DateTime.Now.ToString("F");
		}


		public void Draw(SpriteBatch spriteBatch){
			spriteBatch.DrawString (font, nameText, textPos, Color.White);
			spriteBatch.DrawString (font, debugText, debugPos, Color.White);
		}
	}
}

