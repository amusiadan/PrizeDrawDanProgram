using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace PrizeDrawDan
{
	public class GraphicSettings
	{
		public GraphicsDeviceManager graphics;
		public GameState gameState = GameState.STARTUP;



		public GraphicSettings (GraphicsDeviceManager graphics){
			this.graphics = graphics;
		}

		public void Initialize (){
		
			graphics.PreferredBackBufferHeight = 720;
			graphics.PreferredBackBufferWidth = 2160;
			graphics.IsFullScreen = false;
			graphics.ApplyChanges();
		}

	}

}

