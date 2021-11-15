using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Ball: Actor
    {
        public Ball(int x, int y)
        {
            SetImage(Constants.IMAGE_BALL);
            SetPosition(new Point(x,y));
            SetHeight(Constants.BALL_HEIGHT);
            SetWidth(Constants.BALL_WIDTH);
            SetVelocity(new Point(-5,-5));
        }
    }
}