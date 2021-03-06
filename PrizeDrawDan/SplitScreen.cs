using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace PrizeDrawDan
{
	class SplitScreen
	{
		Viewport game;
		Viewport ui;

		public void LoadContent(GraphicSettings graphicSettings){

			game = graphicSettings.graphics.GraphicsDevice.Viewport;
			ui = graphicSettings.graphics.GraphicsDevice.Viewport;
			game.Width = game.Width / 2;
			ui.Width = ui.Width / 2;
			ui.X = game.Width;
		}

		public Viewport Game(){
			return game;
		}

		public Viewport Ui(){
			return ui;
		}


	}

}

