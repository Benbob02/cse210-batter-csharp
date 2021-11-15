using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["bricks"] = new List<Actor>();

            // TODO: Add your bricks here
            
            for(int x = 10; x < Constants.MAX_X - Constants.BRICK_WIDTH;x += Constants.BRICK_WIDTH + 10)
            {
                for(int y = 10; y <= 146;y += Constants.BRICK_HEIGHT + 10)
                {
                    cast["bricks"].Add(new Brick(x,y));
                }
            }
            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();

            // TODO: Add your ball here
            cast["balls"].Add(new Ball(Constants.MAX_X/2,Constants.MAX_Y/2));
            cast["balls"].Add(new Ball(Constants.MAX_X/4,Constants.MAX_Y/4));
            cast["balls"].Add(new Ball(Constants.MAX_X/3,Constants.MAX_Y/3));
            // The paddle
            cast["paddle"] = new List<Actor>();

            // TODO: Add your paddle here
            cast["paddle"].Add(new Paddle());
            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.
            MoveActorsAction movment = new MoveActorsAction();
            HandleOffScreenAction offScreen = new HandleOffScreenAction();
            ControlActorsAction paddlemove = new ControlActorsAction();
            HandleCollisionsAction brickcollide = new HandleCollisionsAction();
            script["update"].Add(movment);
            script["update"].Add(offScreen);
            script["update"].Add(paddlemove);
            script["update"].Add(brickcollide);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
