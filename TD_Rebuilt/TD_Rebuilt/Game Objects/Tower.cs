using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD_Rebuilt.Game_Objects
{
    class Tower
    {
        float xPos, yPos;
        public Texture2D Texture;

        public Vector2 position
        {
            get { return new Vector2(xPos, yPos); }
            set { xPos = position.X; yPos = position.Y; }
        }        

        public Tower(float x, float y, Texture2D texture)
        {
            xPos = x;
            yPos = y;
            Texture = texture;
        }

        public void Draw(ref SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, position, Color.White);
        }


    }
}
