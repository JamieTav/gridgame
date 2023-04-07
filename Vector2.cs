class Vector2 {
    // by default numbers are set to 0
    public float x;
    public float y;

    // constructors
    public Vector2() {
        this.x = 0;
        this.y = 0;
    }
    
    public Vector2(float x, float y) {
        this.x = x;
        this.y = y;
    }

    // add (and subtract)
    public Vector2 Add(Vector2 b) {
        var v = new Vector2();
        v.x = x + b.x;
        v.y = y + b.y;
        return v;
    }

    // scale/multiply
    public Vector2 Scale(float s){
        var v = new Vector2();
        v.x = x * s;
        v.y = y * s;
        return v;
    }

    // definition/signature of a function
    public Vector2 Normalize(){
        var n = new Vector2();
        n.x = x/Magnitude();
        n.y = y/Magnitude();
        return n;
    }
    // public AAA BBB(CCC1 ddd1, CCC2 ddd2);

    // AAA = return type
    // BBB = name of the function
    // CCCn = type of parameter n
    // dddn = name of the parameter n

    public float Magnitude(){
        return MathF.Sqrt((x*x)+(y*y));
    }
    public Vector2 Subtract(Vector2 b){
        var c = new Vector2();
        c.x = x - b.x;
        c.y = y - b.y;
        return c;
    }
    public bool Equals(Vector2 other) {
        return x == other.x && y == other.y;
    }
}