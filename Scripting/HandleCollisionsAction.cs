using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;



namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to appropriately handle any collisions in the game.
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        PhysicsService _physicsService = new PhysicsService();

        public HandleCollisionsAction()
        {
            _physicsService = new PhysicsService();
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> balls = cast["balls"]; // There is only one
            Actor paddle = cast["paddle"][0]; // There is only one
            List<Actor> bricks = cast["bricks"]; // Get all the artifacts
            List<Actor> brokenBrick = new List<Actor>();


            foreach (Actor ball in balls)
            {
                foreach (Actor brick in bricks)
                {
                    if(_physicsService.IsCollision(ball,brick))
                    {
                        bounceActorY(ball);
                        brokenBrick.Add(brick);
                    }
                }
                if(_physicsService.IsCollision(ball,paddle))
                {
                    bounceActorY(ball);
                }
            }
            foreach(Actor brick in brokenBrick)
            {
                bricks.Remove(brick);
            }
            brokenBrick.Clear();
        }
        private void bounceActorY(Actor actor)
        {
            int x = actor.GetVelocity().GetX();
            int y = actor.GetVelocity().GetY();
            y *= -1;
            actor.SetVelocity(new Point(x,y));
        }

    }
}