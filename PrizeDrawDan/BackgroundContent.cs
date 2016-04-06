using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace PrizeDrawDan
{
	public class BackgroundContent
	{
		List<BackgroundGame> main = new List<BackgroundGame> ();

		public BackgroundContent ()
		{
			main.Add (new BackgroundGame ("Background1", "Background1"));
			main.Add (new BackgroundGame ("Background2", "Background2"));
		}

		public void LoadContent (ContentManager content){		
			foreach (BackgroundGame element in main) {
				element.LoadContent (content);
			}
		}

		/*public void Update(){
			foreach (BackgroundGame element in main) {
				element.Update ();
			}
		}*/

		public void Draw(SpriteBatch spriteBatch){
			foreach (BackgroundGame element in main) {
				main.Find (x => x.Id == "Background1").Draw (spriteBatch);
				main.Find (x => x.Id == "Background2").Draw (spriteBatch);
				//element.Draw(spriteBatch);
			}

		} 
			
	}
}

