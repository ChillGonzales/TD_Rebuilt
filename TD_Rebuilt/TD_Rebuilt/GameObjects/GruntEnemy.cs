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
            CurrentDirection = Animation.MovementDirection.Southwest;
            CreateAnimationList();
        }        
        protected override void DrawFrame()
        {
            Position += Animation.Move(CurrentDirection);
        }                
    }
}
