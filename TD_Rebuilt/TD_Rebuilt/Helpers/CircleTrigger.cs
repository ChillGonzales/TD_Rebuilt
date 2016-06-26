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
        public event TriggerDelegate OnTriggerEnter;

        public CircleTrigger(Vector2 center, float radius)
            : this()
        {
            Center = center;
            Radius = radius;
        }

        public void Contains(Vector2 point)
        {
            if ((point - Center).Length() <= Radius)
            {
                //TODO: Fire Event
                OnTriggerEnter(this, new TriggerArgs(new Vector2(point.X, point.Y)));                
            }            
        }

        public void Intersects(Rectangle other)
        {
            //TODO: Fire event if true
            if (((new Vector2(other.Center.X, other.Center.Y)) - Center).Length() < (other.Width - Radius) || ((new Vector2(other.Center.X, other.Center.Y) - Center).Length() < (other.Height - Radius)))
            {
                OnTriggerEnter(this, new TriggerArgs(Center));                
            }            
        }

        public void Intersects(CircleTrigger other)
        {
            if (((other.Center) - Center).Length() < (other.Radius - Radius))
            {
                OnTriggerEnter(this, new TriggerArgs(other.Center));                
            }            
        }
    }

    public delegate void TriggerDelegate(object sender, TriggerArgs e);

    public class TriggerArgs : EventArgs
    {
        private Vector2 OtherPosition;
        public TriggerArgs(Vector2 otherPos)
        {
            OtherPosition = otherPos;
        }
        public Vector2 OtherPos()
        {
            return OtherPosition;
        }
    }
}
