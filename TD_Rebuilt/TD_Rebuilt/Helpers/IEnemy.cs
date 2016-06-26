using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD_Rebuilt.Helpers
{
    public interface IEnemy
    {
        Rectangle HurtBox{ get; }
        void Draw(ref SpriteBatch spriteBatch);
        void Update(ref GameTime gameTime);
    }
}
