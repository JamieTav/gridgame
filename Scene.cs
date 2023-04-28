class Scene {

    public int coinsCollected = 0;
    public int coinGoal = 3;
    public int lives = 3;
    public bool gameOver = false;
    public Player player;
    public GameObject coin;
    public List<GameObject> livesUi = new List<GameObject>();
    public List<GameObject> gameObjects;
    public List<GameObject> Enemies;
    public List<GameObject> ToCreate = new List<GameObject>();
    public List<GameObject> ToDestroy = new List<GameObject>();
        
    public Scene(){
        // load all sprites
        var swordSprite = new Sprite("Sword.spr");
        var gunSprite = new Sprite("Gun.spr");
        var knifeSprite = new Sprite("Knife.spr");

        //initialize game state
        coinsCollected = 0;
        coinGoal = 3;
        lives = 3;
        gameOver = false;
        
        //create all game objects
        gameObjects = new List<GameObject>();
        Enemies = new List<GameObject>();

        Enemies.Add(new GameObject()
        {
            position = new Vector2(Constants.width - 2, 1),
            sprite = swordSprite,
            velocity = new Vector2(2, 0),
        });
        Enemies.Add(new GameObject()
        {
            position = new Vector2(Constants.width - 2, Constants.height - 3),
            sprite = gunSprite,
            velocity = new Vector2(-2, 0),
        });
        Enemies.Add(new GameObject()
        {
            position = new Vector2(5, Constants.height - 3),
            sprite = knifeSprite,
            velocity = new Vector2(0, 2),
        });
      

        for (var i = 0; i < lives; i++)
        {
            livesUi.Add(new GameObject()
            {
                sprite = new Sprite("Lives.spr"),
                position = new Vector2(2+i*8,2)
            });
        }


        //objects
        coin = new GameObject()
        {
            position = new Vector2(Constants.width / 2, Constants.height / 2),
            sprite = new Sprite("Coin.spr")
        };

        player = new Player()
        {
            position = new Vector2(10f, 20f),
            sprite = new Sprite("Player.spr"),
            Speed = 1f
         };


        var follower = new Follower()
        {
            Speed = 0.3f,
            position = new Vector2(40, 5),
            sprite = new Sprite("Follower.spr"),
            Following = player,
            scene = this,
        };

        gameObjects.Add(player);
        gameObjects.Add(coin);
        gameObjects.AddRange(Enemies);
        gameObjects.Add(follower);
        gameObjects.AddRange(livesUi);
    }
}