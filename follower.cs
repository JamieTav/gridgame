class Follower : GameObject {
    public Player Following;
    public float Speed;
    public List<GameObject> Cacas = new List<GameObject>();

    public Scene scene;

    int frames = 0;
    int cacaRate = 120;
    Vector2 displacement = new Vector2(1,1);
    Sprite cacaSprite = new Sprite("caca.spr");

    

    public override void Update() {
        // given the players position, change velocity
        var displace = Following.position.Subtract(position);
        var dir = displace.Normalize();
        velocity = dir.Scale(Speed);
        frames = frames +1;
        if (frames == cacaRate){
            var caca = new GameObject(){
                sprite = (cacaSprite),
                position = this.position.Subtract(displacement),
            };
            scene.ToCreate.Add(caca);
            Cacas.Add(caca);
            frames = 0;
        }
        base.Update();
    }
}