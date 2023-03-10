class Vector2 {
    public int x=0;
    public int y=0;

    public void Add(Vector2 b) {
        x = x + b.x;
        y = y + b.y;
    }

    public bool Equals(Vector2 other) {
        return x == other.x && y == other.y;
    }
}