using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TD_Rebuilt.Helpers;
using System.Diagnostics;

namespace TD_Rebuilt.GameObjects
{
    class Tower
    {
        //int xPos, yPos;

        public Texture2D Texture;
        public Vector2 Position;
        public CircleTrigger Trigger;
        public List<Projectile> ProjectileList;
        private bool EnemyPresent;
        private double timeElapsed, timeToUpdate;
        private Vector2 CurrentEnemy;
        //public Vector2 position
        //{
        //    get { return new Vector2(xPos, yPos); }
        //    set { xPos = position.X; yPos = position.Y; }
        //}        

        public Tower(Vector2 _position)
        {
            Position = _position;
            Texture = GameLoop.fireTowerTexture;
            Trigger = new CircleTrigger(Position, 250);
            Trigger.OnTriggerEnter += new TriggerDelegate(OnTriggerEnter);
            ProjectileList = new List<Projectile>();
            timeToUpdate = 1/2;
        }

        public void Update(ref GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;
                if (EnemyPresent) { FireAtTarget(); }
            }
        }

        public void Draw(ref SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, Position, Color.White);
            foreach (var p in ProjectileList)
            {
                p.Draw(ref _spriteBatch);
            }
        }

        private void OnTriggerEnter(object sender, TriggerArgs e)
        {
            Debug.Print("FIRE!!!!");
            EnemyPresent = true;
            CurrentEnemy = e.OtherPos();
        }

        private void FireAtTarget()
        {
            var proj = new Projectile(this.Position, CurrentEnemy);
            ProjectileList.Add(proj);
        }


    }
}
