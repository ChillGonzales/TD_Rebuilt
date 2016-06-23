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

        public Wave(int level)
        {
            Level = level;
            WaveList = new List<IEnemy>();
            for (int i = 0; i < 10; i++)
            {
                var enem = new GruntEnemy(new Vector2(400 - (i*50), 50));
                WaveList.Add(enem);
            }
        }

        public void Begin()
        {
            if (Level == 1)
            {
                WaveStarted = true;        
            }
        }

        public void Update(ref GameTime gameTime)
        {
            if (WaveStarted)
            {
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
