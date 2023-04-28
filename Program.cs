using System;
using System.Windows.Input;

internal class Program
{ 
    
    [STAThread]
    private static void Main()
    {
        var rng = new Random();
        var canvas = new Canvas();
        var scene = new Scene();

        //game starts
        var isGameRunning = true;
        while (isGameRunning)
        {
            //game over
            for (int h = 0; h < scene.Enemies.Count; h++)
            {
                if (scene.player.CollidesWith(scene.Enemies[h])&& !scene.player.IsInvincible())
                {
                    scene.lives = scene.lives - 1;
                    scene.ToDestroy.Add(scene.livesUi[scene.lives]);
                    scene.player.OnHit();
                }
            }

            if (scene.lives <= 0 && scene.gameOver == false)
            {
                var gameOverText = new GameObject(){
                    position = new Vector2(Constants.width/2,0),
                    sprite = new Sprite("GameOver.spr")
                };
                scene.ToCreate.Add(gameOverText);
                scene.gameOver = true;
            }

            if (scene.player.CollidesWith(scene.coin))
            {
                var x = 40 + 8*scene.coinsCollected;
                var coinUi = new GameObject(){
                    sprite = new Sprite("CoinCollected.spr"),
                    position = new Vector2(x,2)
                };
                scene.coin.position.x = rng.Next(1, Constants.width - 1);
                scene.coin.position.y = rng.Next(1, Constants.height - 2);
                scene.coinsCollected = scene.coinsCollected + 1;
                scene.ToCreate.Add(coinUi);

            }

            if (scene.coinsCollected == scene.coinGoal && scene.gameOver == false)
            {
                var gameWinText = new GameObject(){
                    position = new Vector2(Constants.width/2,0),
                    sprite = new Sprite("GameWin.spr")
                };
                
                scene.ToCreate.Add(gameWinText);
                scene.gameOver = true;
            }

            if (Keyboard.IsKeyDown(Key.R) && scene.gameOver==true){
                scene = new Scene();
            }

            // update all game objects
            if (!scene.gameOver){
                foreach (var go in scene.gameObjects)
                {
                    go.Update();
                }
            }

            scene.gameObjects.AddRange(scene.ToCreate);
            scene.ToCreate.Clear();
            foreach (var toDestroy in scene.ToDestroy){
                scene.gameObjects.Remove(toDestroy);
            }
            scene.ToDestroy.Clear();  

            // render the canvas           
            foreach (var go in scene.gameObjects.OrderBy(go => go.depth))
            {
                canvas.Draw(go);
            }
            canvas.Render(); 

            Thread.Sleep(1000 / 10);
        }
    }

    
}