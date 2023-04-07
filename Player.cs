using System.Windows.Input;

class Player : GameObject {
        
    // this is saying that we are replacing what Update originally does
    public override void Update() {
        velocity = new Vector2();
        var playerSpeed = 0.5f;
        if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
        {
            velocity.y = -playerSpeed;
        }
        else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
        {
            velocity.x = -playerSpeed;
        }
        else if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
        {
            velocity.y = playerSpeed;
        }
        else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
        {
            velocity.x = playerSpeed;
        }

        // call the update code from the base class
        base.Update();
    }
}