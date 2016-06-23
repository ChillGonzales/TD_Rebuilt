using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TD_Rebuilt.GameObjects;

namespace TD_Rebuilt.Helpers
{
    public class Wave
    {
        List<IEnemy> WaveList;
        int Level;
        public event WaveStartDelegate OnWaveStart;
        private bool WaveStarted = false;
        private double timetoUpdate = 2, deltaTime;

        public Wave(int level)
        {
            Level = level;
            WaveList = new List<IEnemy>();            
        }

        public void Begin()
        {
            if (Level == 1)
            {
                WaveStarted = true;
                var enem = new GruntEnemy(new Vector2(500, 50));
                WaveList.Add(enem);
            }
        }

        public void Update(ref GameTime gameTime)
        {
            if (WaveStarted)
            {
                if (WaveList.Count < 10){
                deltaTime += gameTime.ElapsedGameTime.TotalSeconds;
                    if (deltaTime > timetoUpdate)
                    {
                        deltaTime -= timetoUpdate;
                        deltaTime = 0;
                        WaveList.Add(new GruntEnemy(new Vector2(500, 50)));
                    }
                }
                foreach (var enem in WaveList)
                {
                    enem.Update(ref gameTime);
                }
            }
        }

        public void Draw(ref SpriteBatch spriteBatch)
        {
            if (WaveStarted)
            {
                foreach (var enem in WaveList)
                {
                    enem.Draw(ref spriteBatch);
                }
            }
        }
                
    }

    public delegate void WaveStartDelegate(object sender, WaveEventArgs e);

    public class WaveEventArgs : EventArgs
    {
        private int EnemyNum;
        public WaveEventArgs(int enemycount)
        {
            EnemyNum = enemycount;
        }
        public int EnemyCount()
        {
            return EnemyNum;
        }
    }
}
