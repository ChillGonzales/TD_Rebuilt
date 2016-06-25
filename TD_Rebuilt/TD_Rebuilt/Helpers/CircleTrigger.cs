using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TD_Rebuilt.Helpers
{
    public struct CircleTrigger
    {
        public Vector2 Center { get; set; }
        public float Radius { get; set; }
        //public event TriggerDelegate OnTriggerEnter;

        public CircleTrigger(Vector2 center, float radius)
            : this()
        {
            Center = center;
            Radius = radius;
        }

        public bool Contains(Vector2 point)
        {
            if ((point - Center).Length() <= Radius)
            {
                //TODO: Fire Event
                return true;
            }
            else { return false; }
        }

        public bool Intersects(Rectangle other)
        {
            //TODO: Fire event if true
            return ((new Vector2(other.Center.X, other.Center.Y)) - Center).Length() < (other.Width - Radius) || ((new Vector2(other.Center.X, other.Center.Y) - Center).Length() < (other.Height - Radius));
        }

        public bool Intersects(CircleTrigger other)
        {
            return ((other.Center) - Center).Length() < (other.Radius - Radius);
        }
    }

    //public delegate void TriggerDelegate(object sender, TriggerArgs e);

    //public class TriggerArgs : EventArgs
    //{
    //    private int Trigger;
    //    public TriggerArgs(int enemycount)
    //    {
    //        EnemyNum = enemycount;
    //    }
    //    public int EnemyCount()
    //    {
    //        return EnemyNum;
    //    }
    //}
}
