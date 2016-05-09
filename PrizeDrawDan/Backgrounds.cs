using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class Backgrounds
	{
		//Background Textures
		public Texture2D back1;
		public Texture2D back2;

		public void LoadContent (ContentManager content){
			//Background Content
			back1 = content.Load<Texture2D> ("Background1");
			back2 = content.Load<Texture2D> ("Background2");
		}
	}
}

