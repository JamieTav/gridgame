using System;
using System.Windows.Input;

internal class Program
{
    [STAThread]
    private static void Main()
    {
        var rng = new Random();
        var canvas = new Canvas();

        //initialize game state
        int coinsCollected = 0;
        int coinGoal = 3;
        int lives = 3;

        Console.WriteLine($"Coins Collected: {coinsCollected}/{coinGoal}");
        Console.WriteLine($"Lives: {lives}");
        Console.WriteLine();

        //create all game objects
        var gameobjects = new List<GameObject>();
        var enemies = new List<GameObject>();

        enemies.Add(new GameObject()
        {
            position = new Vector2(Constants.width - 2, 1),
            character = new ColorCharacter('1', ConsoleColor.DarkRed),
            velocity = new Vector2(2, 0),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(Constants.width - 2, Constants.height - 3),
            character = new ColorCharacter('2', ConsoleColor.DarkRed),
            velocity = new Vector2(-2, 0),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(5, Constants.height - 3),
            character = new ColorCharacter('3', ConsoleColor.DarkRed),
            velocity = new Vector2(0, 2),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(1, Constants.width - 2),
            character = new ColorCharacter('4', ConsoleColor.DarkRed),
            velocity = new Vector2(0, -2),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(1, 1),
            character = new ColorCharacter('5', ConsoleColor.DarkRed),
            velocity = new Vector2(2, 2),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(1, Constants.height - 3),
            character = new ColorCharacter('6', ConsoleColor.DarkRed),
            velocity = new Vector2(4, -4),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(7, Constants.height / 2),
            character = new ColorCharacter('7',ConsoleColor.DarkRed),
            velocity = new Vector2(4, 0),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(Constants.width / 2, 7),
            character = new ColorCharacter('8', ConsoleColor.DarkRed),
            velocity = new Vector2(-4, 0),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(8, 12),
            character = new ColorCharacter('9', ConsoleColor.DarkRed),
            velocity = new Vector2(0, 1),
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2(60, 1),
            character = new ColorCharacter('0', ConsoleColor.DarkRed),
            velocity = new Vector2(0, -1),
        });
        
        for (int v = 10; v < 40; v++)
        {
            enemies.Add(new GameObject()
            {
                position = new Vector2(1 + v * 2, Constants.height - 3),
                character = new ColorCharacter('v', ConsoleColor.DarkRed),
                velocity = new Vector2(0, -1)
            });
        }

        var coin = new GameObject()
        {
            position = new Vector2(Constants.width / 2, Constants.height / 2),
            character = new ColorCharacter('o', ConsoleColor.DarkYellow),
            velocity = new Vector2()
        };

        var player = new Player()
        {
            position = new Vector2(2.1f, 2.1f),
            sprite = new Sprite()
            {
                texture = new ColorCharacter[,]{
                    {
                        new ColorCharacter(),
                        new ColorCharacter('ㅇ', ConsoleColor.DarkGreen),
                        new ColorCharacter()
                    },
                    {
                        new ColorCharacter(),
                        new ColorCharacter('|', ConsoleColor.DarkGreen),
                        new ColorCharacter()
                    },
                    {
                        new ColorCharacter(),
                        new ColorCharacter('ㅅ', ConsoleColor.DarkGreen),
                        new ColorCharacter()
                    }
                },

            },
        };

        var follower = new Follower()
        {
            speed = 0.3f,
            position = new Vector2(40, 5),
            character = new ColorCharacter('F', ConsoleColor.DarkBlue),
            following = player
        };

        gameobjects.Add(player);
        gameobjects.Add(coin);
        gameobjects.AddRange(enemies);
        gameobjects.Add(follower);

        //game starts
        var gameOver = false;
        while (!gameOver)
        {
            //game over
            for (int h = 0; h < enemies.Count; h++)
            {
                if (player.CollidesWith(enemies[h]))
                {
                    lives = lives - 1;
                }
            }
            if (lives == 0)
            {
                Console.Write("GAME OVER LOSER!!!!!");
                gameOver = true;
            }

            if (player.CollidesWith(coin))
            {
                coin.position.x = rng.Next(1, Constants.width - 1);
                coin.position.y = rng.Next(1, Constants.height - 2);
                coinsCollected = coinsCollected + 1;
            }

            if (coinsCollected == coinGoal)
            {
                Console.Write("YYYYYIIIIIIIIIIIIIIIIPPPPPPPPPPPPPEEEEEEEEEEEEEEEEEE!!!!!!!!!!!!");
                gameOver = true;
            }

            // update all game objects
            foreach (var go in gameobjects)
            {
                go.Update();
            }

            //draw the canvas
            // canvas.Clear();

            // for(int h=0; h<gameobjects.Count; h++){
            //     canvas.Set(gameobjects[h]);
            // }
            foreach (var go in gameobjects)
            {
                canvas.Draw(go);
            }

            canvas.Render();


            Thread.Sleep(1000 / 10);
        }
    }
}