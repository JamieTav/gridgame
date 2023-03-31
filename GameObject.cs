class GameObject {
    public Vector2 position = new Vector2(); 
    public ColorCharacter character = new ColorCharacter();
    public Vector2 velocity = new Vector2();
    
    public virtual void Update() {
        position.Add(velocity);

        if (position.x > Constants.width-2) {
            position.x = 1;
        }

        if (position.x < 1) {
            position.x = Constants.width-2;
        }

        if(position.y < 1) {
            position.y = Constants.height-3;
        }

        if (position.y > Constants.height-3) {
            position.y=1;
        }
    }

    public bool CollidesWith(GameObject other) {
        return MathF.Floor(position.x) == MathF.Floor(other.position.x) && MathF.Floor(position.y) == MathF.Floor(other.position.y);
    }
}

// int i;  // i = 0
// bool b; // b = false
// Vector2 v; // v = null; v = {x=0, y=0}