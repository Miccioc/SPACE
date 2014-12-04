using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class PlanetManager
    {
        private List<Sprite> planets = new List<Sprite>();
        private int screenWidth = 800;
        private int screenHeight = 600;
        private Random rand = new Random();
        private Color[] colors = { Color.White, Color.Yellow, 
                           Color.Wheat, Color.WhiteSmoke, 
                           Color.SlateGray };

        public PlanetManager(
            int screenWidth,
            int screenHeight,
            int starCount,
            Vector2 starVelocity,
            Texture2D texture,
            Rectangle frameRectangle)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            for (int x = 0; x < starCount; x++)
            {
                planets.Add(new Sprite(
                    new Vector2(rand.Next(0, screenWidth),
                        rand.Next(0, screenHeight)),
                    texture,
                    frameRectangle,
                    starVelocity));
                Color starColor = colors[rand.Next(0, colors.Count())];
                starColor *= (float)(rand.Next(30, 80) / 100f); planets[planets.Count() - 1].TintColor = starColor;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite planet in planets)
            {
                planet.Update(gameTime);
                if (planet.Location.Y > screenHeight)
                {
                    planet.Location = new Vector2(
                        rand.Next(0, screenWidth), 0);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite planet in planets)
            {
                planet.Draw(spriteBatch);
            }
        }

    }
}

    

