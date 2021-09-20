﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.SpriteFactory;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.LinkComponents
{
    class Link : ILink
    {
        public ILinkState LinkState { get; set; }
        public ILinkItemState LinkItemState { get; set; }
        public Texture2D Texture { get; set; }
        public int Columns { get; set; }
        public int TotalFrames { get; set; }
        public int Rows { get; set; }
        private int currentFrame;
        private Vector2 position;
        private Game1 game;
        public int start { get; set; }
        private int speed=2;

        public Link(Game1 game)
        {
            LinkDirectionState = new LinkStateUp(this, game);
            LinkItemState = new LinkStateNoItem(this); 
            this.game = game;
            Texture = LinkSpriteFactory.Instance.DirectionSpriteSheet(this);
            start = 4;
            currentFrame = 0;
        }
        public void MoveDown()
        {
            if ((int)position.Y < game.GraphicsDevice.Viewport.Height)
                position.Y+=speed;
            
            LinkState.MoveDown();
        }

        public void MoveLeft()
        {
            if ((int)position.X > 0)
                position.X-=speed;
            
            LinkState.MoveLeft();
        }

        public void MoveRight()
        {
            if ((int)position.X < game.GraphicsDevice.Viewport.Width)
                position.X+=speed;
            
            LinkState.MoveRight();
        }

        public void MoveUp()
        {
            if ((int)position.Y > 0)
                position.Y-=speed;
            
            LinkState.MoveUp();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage()
        {

        }

        public void UseNoItem()
        {
            LinkItemState.UseNoItem();
        }
        public void UseMagicalRod()
        {
            LinkItemState.UseMagicalRod(); 
        }
        public void UseMagicalSheild()
        {
            LinkItemState.UseMagicalSheild();
        }
        public void UseMagicalSword()
        {
            LinkItemState.UseMagicalSword();
        }
        public void UseWhiteSword()
        {
            LinkItemState.UseWhiteSword();
        }
        public void UseWoodenSword()
        {
            LinkItemState.UseWoodenSword();
        }

        public void Draw()
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height/Rows;
            //int column = start % Columns;
            int row = currentFrame / Columns;
            Rectangle sourceRectangle = new Rectangle(start*width, height*row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            start++;
            if (currentFrame == TotalFrames)
            {
                currentFrame = 0;
                start -= TotalFrames;
               
            }
                
        }
    }
}
