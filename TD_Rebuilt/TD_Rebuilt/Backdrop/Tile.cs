using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TD_Rebuilt.Backdrop
{
    class Tile
    {
        private float xPos, yPos;
        private Texture2D tileTexture;
        private bool passable;

        public Tile(float _xPos, float _yPos, Texture2D _texture, bool _passable)
        {
            xPos = _xPos;
            yPos = _yPos;
            tileTexture = _texture;
            passable = _passable;
        }
        //i * spriteSheetBackground[i, j].Width / 2.02f) + (j * spriteSheetBackground[i, j].Width / 2.02f)
        //(i * spriteSheetBackground[i,j].Height / 2.5f) - (j * spriteSheetBackground[i,j].Height / 2.5f)
        public static Tile[,] CreateTileArray(int _arraySize, Texture2D _texture)
        {
            Tile[,] tileArray = new Tile[_arraySize, _arraySize];
            for (int i = 0; i < tileArray.Length / _arraySize; i++)
            {
                for (int j = tileArray.Length / _arraySize - 1; j >= 0; j--)
                {
                    tileArray[i, j] = new Tile((i * _texture.Width / 2.02f) + (j * _texture.Width / 2.02f),
                        (i * _texture.Height / 2.5f) - (j * _texture.Height / 2.5f), _texture, true);

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
                    _spriteBatch.Draw(AT.tileTexture, new Vector2(AT.xPos, AT.yPos), Color.White);
                }
            }
        }

    }
}
