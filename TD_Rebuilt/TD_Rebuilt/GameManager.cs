using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TD_Rebuilt.Game_Objects;
using TD_Rebuilt.Helpers;

namespace TD_Rebuilt
{
    class GameManager
    {
        protected static List<Tower> towerList = new List<Tower>();        
                   
        public GameManager()
        {

        }

        public static void AddTower(float x, float y, Texture2D texture)
        {
            var tower = new Tower(new Vector2(x - GameLoop.screenX, y - GameLoop.screenY), texture);
            towerList.Add(tower);
        }

        public void UpdateTowerPositions(int x, int y)
        {
            var correctedPos = new Vector2(x-GameLoop.screenX, y-GameLoop.screenY);
            //var query = from Tile item in GameLoop.backgroundTiles where item.Contains(correctedPos) select item;
            //towerList[towerList.Count - 1].position = query.ElementAt(0).position;
            towerList[towerList.Count - 1].position = correctedPos;
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
