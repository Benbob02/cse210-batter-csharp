using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp.Scripting
{
    public class HandleOffScreenAction : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (List<Actor> group in cast.Values)
            {
                foreach (Actor actor in group)
                {
                    if(actor.GetTopEdge()<=0)
                    {
                        bounceActorY(actor);
                    }
                    else if(actor.GetBottomEdge()>=Constants.MAX_Y)
                    {
                        bounceActorY(actor);
                    }
                    else if(actor.GetLeftEdge()<=0)
                    {
                        bounceActorX(actor);
                    }
                    else if(actor.GetRightEdge()>=Constants.MAX_X)
                    {
                        bounceActorX(actor);
                    }
                    
                }
            }
        }
        private void bounceActorY(Actor actor)
        {
            int x = actor.GetVelocity().GetX();
            int y = actor.GetVelocity().GetY();
            y *= -1;
            actor.SetVelocity(new Point(x,y));
        }
        private void bounceActorX(Actor actor)
        {
            int x = actor.GetVelocity().GetX();
            int y = actor.GetVelocity().GetY();
            x *= -1;
            actor.SetVelocity(new Point(x,y));
        }
    }
}