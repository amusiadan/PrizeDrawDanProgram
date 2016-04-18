using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace PrizeDrawDan
{
	class MainMenu
	{
		List<UiButtons> main = new List<UiButtons> ();


		public MainMenu()
		{
			main.Add (new UiButtons ("Button1", "Button"));
			main.Add (new UiButtons ("Button2", "Button"));
			main.Add (new UiButtons ("Button3", "Button"));
		}

 
		public void LoadContent(ContentManager content){
			foreach (UiButtons element in main) {
				element.LoadContent (content);
				element.CenterButton (1080, 720);
			}
			main.Find (x => x.Id == "Button1").MoveButton (450, -150);
			main.Find (x => x.Id == "Button2").MoveButton (450, 0);
			main.Find (x => x.Id == "Button3").MoveButton (450, 150);
		}

		public void Draw(SpriteBatch spriteBatch){
			foreach (UiButtons element in main) {
				element.Draw(spriteBatch);
			}
		}
	}
}

