class Follower : GameObject {
    public Player following;
    public float speed;

    public override void Update() {
        // given the players position, change velocity
        var displace = following.position.Subtract(position);
        var dir = displace.Normalize();
        velocity = dir.Scale(speed);
        base.Update();
    }
}