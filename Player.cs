using System.Windows.Input;

class Player : GameObject {
    public float Speed;
    public int Iframes = 10;
    int iframecount;
    
    // this is saying that we are replacing what Update originally does
    public override void Update() {
        velocity = new Vector2();
        if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
        {
            velocity.y = -Speed;
        }
        else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
        {
            velocity.x = -Speed;
        }
        else if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
        {
            velocity.y = Speed;
        }
        else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
        {
            velocity.x = Speed;
        }

        iframecount++;

        // call the update code from the base class
        base.Update();
    }

    public void OnHit() {
        iframecount = 0;
    }
    
    public bool IsInvincible() {
        return iframecount < Iframes;
    }
}