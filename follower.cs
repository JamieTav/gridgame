class Follower : GameObject {
    public Player following;

    public override void Update() {
        // given the players position, change velocity
        velocity = new Vector2();
        if (following.position.x>position.x){
            velocity.x=1;
        }
        else if (following.position.x<position.x){
            velocity.x=-1;
        }
        else if (following.position.x==position.x){
            velocity.x=0;
        }
        
        if (following.position.y>position.y){
            velocity.y=1;
        }
        else if (following.position.y<position.y){
            velocity.y=-1;
        }
        else if (following.position.y==position.y){
            velocity.y=0;
        }
        base.Update();
    }
}