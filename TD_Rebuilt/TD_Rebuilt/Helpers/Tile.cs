using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TD_Rebuilt.Helpers
{
    public class Tile
    {
        private float xPos, yPos;
        private Texture2D Texture;
        private bool passable;
        public Vector2 position { get { return new Vector2((int)xPos, (int)yPos); } }

        public Tile(float _xPos, float _yPos, Texture2D _texture, bool _passable)
        {
            xPos = _xPos;
            yPos = _yPos;
            Texture = _texture;
            passable = _passable;
        }
       
        public static Tile[,] CreateTileArray(int _arraySize, Texture2D _texture)
        {
            Tile[,] tileArray = new Tile[_arraySize, _arraySize];
            for (int i = 0; i < tileArray.Length / _arraySize; i++)
            {
                for (int j = tileArray.Length / _arraySize - 1; j >= 0; j--)
                {
                    tileArray[i, j] = new Tile((i * _texture.Width / 1.99f) + (j * _texture.Width / 1.99f)-500,
                        (i * _texture.Height / 2.94f) - (j * _texture.Height / 2.94f)+200, _texture, true);

                }
            }
            return tileArray;  
        }

        public static void DrawTileArray(ref SpriteBatch _spriteBatch, ref Tile[,] _tileArray)
        {            
            for (int i = 0; i < _tileArray.Length / Math.Sqrt(_tileArray.Length); i++)
            {
                for (int j = _tileArray.Length / (int) Math.Sqrt(_tileArray.Length) - 1; j >= 0; j--)
                {
                    var AT = _tileArray[i, j];
                    _spriteBatch.Draw(AT.Texture, new Vector2(AT.xPos, AT.yPos), Color.White);
                }
            }
        }

        public bool Contains(Vector2 _position)
        {
            //var bounds = new Rectangle((int)xPos, (int)yPos, Texture.Width, Texture.Height);
            if (Texture.Bounds.Contains(_position)) { return true; }
            else{return false;}
        }

    }
}
