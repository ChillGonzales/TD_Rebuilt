using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TD_Rebuilt.Helpers;

namespace TD_Rebuilt.GameObjects
{
    public class GruntEnemy : BaseEnemy
    {      
        public GruntEnemy(Vector2 Position) : base(Position)
        {
            timeToUpdate = 1f / 8f;
            SpriteSheetCount = 8;
            FrameCount = 8;
            Texture = GameLoop.EnemyTexture;
            CreateAnimationList();
        }        
        protected override void DrawFrame()
        {
            switch (CurrentDirection)
            {
                case Animation.MovementDirection.East:
                    Position.X += 1;
                    break;
                case Animation.MovementDirection.North:
                    Position.Y -= 1;
                    break;
                case Animation.MovementDirection.West:
                    Position.X -= 1;
                    break;
                case Animation.MovementDirection.South:
                    Position.Y += 1;
                    break;
                case Animation.MovementDirection.Southwest:
                    Position.X -= 0.5f;
                    Position.Y += 0.5f;
                    break;
                case Animation.MovementDirection.Southeast:
                    Position.X += 0.5f;
                    Position.Y += 0.5f;
                    break;
                case Animation.MovementDirection.Northwest:
                    Position.X -= 0.5f;
                    Position.Y -= 0.5f;
                    break;
                case Animation.MovementDirection.Northeast:
                    Position.X += 0.5f;
                    Position.Y -= 0.5f;
                    break;
            }
        }                
    }
}
