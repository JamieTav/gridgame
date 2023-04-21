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
                if (scene.player.CollidesWith(scene.Enemies[h]))
                {
                    scene.lives = scene.lives - 1;
                }
            }

            if (scene.lives == 0 && scene.gameOver == false)
            {
                var gameOverText = new GameObject(){
                    position = new Vector2(Constants.width/2,0),
                    sprite = new Sprite("GameOver.spr")
                };
                scene.gameObjects.Add(gameOverText);
                scene.gameOver = true;
            }

            if (scene.player.CollidesWith(scene.coin))
            {
                scene.coin.position.x = rng.Next(1, Constants.width - 1);
                scene.coin.position.y = rng.Next(1, Constants.height - 2);
                scene.coinsCollected = scene.coinsCollected + 1;
            }

            if (scene.coinsCollected == scene.coinGoal && scene.gameOver == false)
            {
                var gameWinText = new GameObject(){
                    position = new Vector2(Constants.width/2,0),
                    sprite = new Sprite("GameWin.spr")
                };
                scene.gameObjects.Add(gameWinText);
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

            //draw the canvas
            // canvas.Clear();

            // for(int h=0; h<gameobjects.Count; h++){
            //     canvas.Set(gameobjects[h]);
            // }
           
            foreach (var go in scene.gameObjects.OrderBy(go => go.depth))
            {
                canvas.Draw(go);
            }

            scene.gameObjects.AddRange(scene.ToCreate);
            scene.ToCreate.Clear();
            canvas.Render();


            Thread.Sleep(1000 / 10);
        }
    }

    
}