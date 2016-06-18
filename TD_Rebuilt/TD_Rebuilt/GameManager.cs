using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TD_Rebuilt.Game_Objects;

namespace TD_Rebuilt
{
    class GameManager
    {
        private static List<Tower> towerList = new List<Tower>();
                   
        public GameManager()
        {

        }

        public static void AddTower(float x, float y, Texture2D texture)
        {
            var tower = new Tower(x, y, texture);
            towerList.Add(tower);
        }

        public static void UpdateTowerPositions()
        {
            foreach (var tower in towerList)
            {
                tower.position = GameLoop.cursorPosition;
            }
        }

        public void DrawGameObjects(ref SpriteBatch _spriteBatch)
        {
            foreach (var tower in towerList)
            {
                tower.Draw(ref _spriteBatch);
            }
        }
    }
}
