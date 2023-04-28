class GameObject {
    public Vector2 position = new Vector2(); 
    public ColorCharacter character = new ColorCharacter();
    public Sprite sprite = null ;
    public Vector2 velocity = new Vector2();
    public float depth = 0f;
    
    public virtual void Update() {
        position = position.Add(velocity);

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
        if (sprite == null || other.sprite == null || other == null){
            return false;
        }
        if (
            position.x < other.position.x + other.sprite.Width &&
            position.x + sprite.Width > other.position.x &&
            position.y < other.position.y + other.sprite.Height &&
            sprite.Height + position.y > other.position.y
        ) {
            // Collision detected!
            return true;
        } else {
            // No collision
            return false;
        }
    
    }
}

// int i;  // i = 0
// bool b; // b = false
// Vector2 v; // v = null; v = {x=0, y=0}