class Vector2 {
    // by default numbers are set to 0
    public float x;
    public float y;

    // add (and subtract)
    public void Add(Vector2 b) {
        x = x + b.x;
        y = y + b.y;
    }

    // scale/multiply
    public void Scale(float s){
        x = x * s;
        y = y * s;
    }

    // definition/signature of a function
    public void Normalize(){
        // var direction = 5;
        // new Vector2(){
        //     x = direction,
        //     y = direction
        // };

        x = x/Magnitude();
        y = y/Magnitude();
    }
    // public AAA BBB(CCC1 ddd1, CCC2 ddd2);

    // AAA = return type
    // BBB = name of the function
    // CCCn = type of parameter n
    // dddn = name of the parameter n

    public float Magnitude(){
        return MathF.Sqrt((x*x)+(y*y));
    }

    public bool Equals(Vector2 other) {
        return x == other.x && y == other.y;
    }
}