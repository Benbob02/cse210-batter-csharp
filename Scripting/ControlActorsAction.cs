using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;



namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to get user input and update actors accordingly.
    /// </summary>
    public class ControlActorsAction : Action
    {
        InputService _inputService;

        public ControlActorsAction()
        {
            _inputService = new InputService();
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            
            Actor robot = cast["paddle"][0];

            Point velocity = direction.Scale(Constants.PADDLE_SPEED);
            robot.SetVelocity(velocity);
        }
        
    }
}