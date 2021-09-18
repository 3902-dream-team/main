﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Command;
using Project1.Controller;
using Project1.LinkComponents;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public ILink Link;
        private IController keyboard;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            keyboard = new KeyboardController();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Requirement - Arrow and "wasd" keys should move Link and change his facing direction.
            keyboard.RegisterCommand(new LinkMoveUpCmd(this), Keys.W);
            keyboard.RegisterCommand(new LinkMoveDownCmd(this), Keys.S);
            keyboard.RegisterCommand(new LinkMoveRightCmd(this), Keys.D);
            keyboard.RegisterCommand(new LinkMoveLeftCmd(this), Keys.A);

            keyboard.RegisterCommand(new LinkMoveUpCmd(this), Keys.Up);
            keyboard.RegisterCommand(new LinkMoveDownCmd(this), Keys.Down);
            keyboard.RegisterCommand(new LinkMoveRightCmd(this), Keys.Right);
            keyboard.RegisterCommand(new LinkMoveLeftCmd(this), Keys.Left);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
