class GameObject {
    public Vector2 position = new Vector2(); 
    public ColorCharacter c = new ColorCharacter();
    public Vector2 velocity = new Vector2();
    
    public void Update() {
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
        return position.Equals(other.position);
    }
}

// int i;  // i = 0
// bool b; // b = false
// Vector2 v; // v = null; v = {x=0, y=0}