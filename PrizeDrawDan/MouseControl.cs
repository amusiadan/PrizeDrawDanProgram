using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PrizeDrawDan
{
	public class MouseControl
	{

		//Mouse States
		public MouseState mouseState;
		public MouseState oldMouseState;
		public bool clicked;

		//Moust Positions
		public Vector2 mousePos;
		public int mousePosX;
		public int mousePosY;

		//Mouse Texture
		Texture2D mouseDefault;
		Texture2D mouseTexture;
		Texture2D mouseClicked;
		public Rectangle mouseRectangle;

	



		public void LoadContent (ContentManager Content){

			//Mouse Pointer Load
			mouseTexture = Content.Load<Texture2D> ("Mouse Pointer");
			mouseClicked = Content.Load<Texture2D> ("Mouse Pointer Clicked");
			Mouse.SetPosition(500, 300);
			mouseDefault = mouseTexture;
		}




		public void Update (GameTime gametime, Buttons buttons, RedrawTimer redrawTimer, Backgrounds background, CountdownTimer countdownTimer)
		{
			

			//Mouse Position
			mousePos = new Vector2 (mousePosX, mousePosY);
			mouseRectangle = new Rectangle (mousePosX, mousePosY, 1, 1);

			//Mouse State Updates
			oldMouseState = mouseState;
			mouseState = Mouse.GetState();
			mousePosX = mouseState.X;
			mousePosY = mouseState.Y;

				
			//Mouse Texture Click Logic
			if (mouseState.LeftButton == ButtonState.Pressed)
			{ mouseDefault = mouseClicked;} else { mouseDefault = mouseTexture; }


			//MMN Button Click Logic
			if (mouseState.LeftButton == ButtonState.Pressed && buttons.MMNButtonPos.Contains (mouseRectangle)) {
				buttons.MMNButtonDefault = buttons.MMNButtonDown;
				buttons.MMNButtonisClicked = true; buttons.GenericDrawButtonisClicked = false; } 
			if (buttons.MMNButtonisClicked) { buttons.MMNButtonDefault = buttons.MMNButtonDown; }

			//Generic Button Click Logic
			if (mouseState.LeftButton == ButtonState.Pressed && buttons.GenericDrawButtonPos.Contains (mouseRectangle)) {
				buttons.GenericDrawButtonDefault = buttons.GenericDrawButtonDown;
				buttons.GenericDrawButtonisClicked = true; buttons.MMNButtonisClicked = false; } 
			if (buttons.GenericDrawButtonisClicked) { buttons.GenericDrawButtonDefault = buttons.GenericDrawButtonDown; }


			//Countdown Timer Click Logic
			if (buttons.CountdownButtonisClicked == false && mouseState.LeftButton == ButtonState.Released
				&& oldMouseState.LeftButton == ButtonState.Pressed && buttons.CountdownButtonPos.Contains (mouseRectangle)) 
			{ buttons.CountdownButtonisClicked = true;} 
			if (buttons.CountdownButtonisClicked) { 
				buttons.CountdownButtonDefault = buttons.CountdownButtonDown;} 
			if (buttons.CountdownButtonisClicked && buttons.CountdownButtonPos.Contains (mouseRectangle)) { 
				buttons.CountdownButtonDefault = buttons.CountdownButtonHover;}
			if (redrawTimer.endTimer <= 120 && buttons.CountdownButtonisClicked && mouseState.LeftButton == ButtonState.Released
				&& oldMouseState.LeftButton == ButtonState.Pressed && buttons.CountdownButtonPos.Contains (mouseRectangle)) {
				buttons.CountdownButtonisClicked = false;}


			//Redraw Timer Click Logic
			if (buttons.RedrawButtonisClicked == false && mouseState.LeftButton == ButtonState.Released && 
				oldMouseState.LeftButton == ButtonState.Pressed && buttons.RedrawButtonPos.Contains (mouseRectangle)) 
			{ buttons.RedrawButtonisClicked = true; } 
			if (buttons.RedrawButtonisClicked) { 
				buttons.RedrawButtonDefault = buttons.RedrawButtonDown;} 
			if (buttons.RedrawButtonisClicked && buttons.RedrawButtonPos.Contains (mouseRectangle)) { 
				buttons.RedrawButtonDefault = buttons.RedrawButtonHover;}
			if (redrawTimer.endTimer <= 120 && buttons.RedrawButtonisClicked && mouseState.LeftButton == ButtonState.Released
				&& oldMouseState.LeftButton == ButtonState.Pressed && buttons.RedrawButtonPos.Contains (mouseRectangle)) {
				buttons.RedrawButtonisClicked = false;}
		}  
			

		public void Draw(SpriteBatch spriteBatch){
			spriteBatch.Draw (mouseDefault, mousePos, Color.White);
		}

	}
}

