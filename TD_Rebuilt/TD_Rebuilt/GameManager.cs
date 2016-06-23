using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TD_Rebuilt.Helpers;
using TD_Rebuilt.GameObjects;

namespace TD_Rebuilt
{
    class GameManager
    {
        protected static List<Tower> towerList = new List<Tower>();        
        private bool GameStarted;
        private Wave wave;
                   
        public GameManager()
        {            
        }

        public static void AddTower(float x, float y)
        {
            var tower = new Tower(new Vector2(x - GameLoop.screenX, y - GameLoop.screenY));
            towerList.Add(tower);
        }

        public void UpdateTowerPositions(int x, int y)
        {
            var correctedPos = new Vector2(x-GameLoop.screenX, y-GameLoop.screenY);
            //var query = from Tile item in GameLoop.backgroundTiles where item.Contains(correctedPos) select item;
            //towerList[towerList.Count - 1].position = query.ElementAt(0).position;
            towerList[towerList.Count - 1].position = correctedPos;
        }

        public void StartGame()
        {
            GameStarted = true;
            wave = new Wave(1);
            wave.Begin();
        }

        public void Update(GameTime gameTime)
        {
            if (GameStarted)
            {
                wave.Update(ref gameTime);
            }
        }

        public void DrawGameObjects(ref SpriteBatch _spriteBatch)
        {
            foreach (var tower in towerList)
            {
                tower.Draw(ref _spriteBatch);
            }
            if (GameStarted)
            {
                wave.Draw(ref _spriteBatch);
            }
        }
    }
}
