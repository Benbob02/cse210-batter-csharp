using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Paddle: Actor
    {
        public Paddle()
        {
            SetImage(Constants.IMAGE_PADDLE);
            SetPosition(new Point(Constants.PADDLE_X,Constants.PADDLE_Y));
            SetHeight(Constants.PADDLE_HEIGHT);
            SetWidth(Constants.PADDLE_WIDTH);
            
        }
    }
}
