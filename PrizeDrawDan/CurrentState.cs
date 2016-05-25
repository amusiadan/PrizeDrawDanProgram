using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	class CurrentState
	{

		public void Update(GameTime gameTime, GraphicSettings graphicSettings, Buttons buttons, Backgrounds background, MouseControl mouse, RedrawTimer redrawTimer, UIText uiText){
			//Update Game States
			//StartUp Game State
			if (graphicSettings.gameState == GameState.STARTUP) {
				if (buttons.MMNButtonisClicked == true)
					graphicSettings.gameState = GameState.MMN;
				if (buttons.GenericDrawButtonisClicked == true)
					graphicSettings.gameState = GameState.GENERIC;
				background.backgroundSet = background.backStartUp;
				uiText.gameSelection = "Select Game";
			}


			//MMN Game State
			if (graphicSettings.gameState == GameState.MMN) {
				if (buttons.MMNButtonisClicked == true)
					graphicSettings.gameState = GameState.MMN;
				if (buttons.GenericDrawButtonisClicked == true)
					graphicSettings.gameState = GameState.GENERIC;
				if (mouse.mouseState.LeftButton == ButtonState.Pressed && buttons.MMNButtonPos.Contains (mouse.mouseRectangle)) {
					buttons.MMNButtonDefault = buttons.MMNButtonDown;
				}

				buttons.MMNButtonDefault = buttons.MMNButtonDown;
				background.backgroundSet = background.back1;
				uiText.gameSelection = "Member Money Night";
			}

			//GENERIC Game State
			if (graphicSettings.gameState == GameState.GENERIC) {
				if (buttons.MMNButtonisClicked == true)
					graphicSettings.gameState = GameState.MMN;
				if (buttons.GenericDrawButtonisClicked == true)
					graphicSettings.gameState = GameState.GENERIC;
				if (mouse.mouseState.LeftButton == ButtonState.Pressed && buttons.GenericDrawButtonPos.Contains (mouse.mouseRectangle)) {
					buttons.GenericDrawButtonDefault = buttons.GenericDrawButtonDown;
				}
				buttons.GenericDrawButtonDefault = buttons.GenericDrawButtonDown;
				background.backgroundSet = background.back2;
				uiText.gameSelection = "Generic Draw";
			}
		}
	}
}

