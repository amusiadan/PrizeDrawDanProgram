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
			main.Add(new UiButtons("Button1"));
			main.Add(new UiButtons("Button2"));
		}

 
		public void LoadContent(ContentManager content){
			foreach (UiButtons element in main) {
				element.LoadContent (content);
				element.CenterButton (1080, 720);
				element.clickEvent += OnClick;
			}
			main.Find (x => x.AssetName == "Button1").MoveButton (0, -200);
			main.Find (x => x.AssetName == "Button2").MoveButton (0, 0);
		}
			

		public void Update(){
			foreach (UiButtons elemnent in main) {
				elemnent.Update ();
			}
		}

		public void Draw(SpriteBatch spriteBatch){
			foreach (UiButtons element in main) {
				element.Draw(spriteBatch);
			}
		}

		public void OnClick(string element){
			if (element == "Button1") {
				//something happens
			} 
			else if (element == "Button2") {
				//something else happens
			}
		}
	}

}

