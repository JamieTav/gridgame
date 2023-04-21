class Follower : GameObject {
    public Player Following;
    public float Speed;
    public List<GameObject> Cacas = new List<GameObject>();

    public Scene scene;

    int frames = 0;
    int cacaRate = 120;
    Vector2 displacement = new Vector2(1,1);
    Sprite cacaSprite = new Sprite("caca.spr");
    Vector2 followOffset = new Vector2(-3,1);

    public override void Update() {
        // given the players position, change velocity
        var target = Following.position.Add(followOffset);
        var displace = target.Subtract(position);
        var dir = displace.Normalize();
        var currentSpeed = MathF.Min(Speed, displace.Magnitude());
        velocity = dir.Scale(currentSpeed);
        // poop stuff
        frames = frames + 1;
        if (frames == cacaRate){
            var caca = new GameObject(){
                sprite = (cacaSprite),
                position = this.position.Subtract(displacement),
                depth = -1,
            };
            scene.ToCreate.Add(caca);
            Cacas.Add(caca);
            frames = 0;
        }
        base.Update();
    }
}