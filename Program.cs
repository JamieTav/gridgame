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
            position = new Vector2()
            {
                x = Constants.width - 2,
                y = 1
            },
            character = new ColorCharacter()
            {
                c = '1',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = 2,
                y = 0
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                x = Constants.width - 2,
                y = Constants.height - 3
            },
            character = new ColorCharacter()
            {
                c = '2',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = -2,
                y = 0
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                x = 5,
                y = Constants.height - 3
            },
            character = new ColorCharacter()
            {
                c = '3',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = 0,
                y = 2
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                y = 1,
                x = Constants.width - 2
            },
            character = new ColorCharacter()
            {
                c = '4',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = 0,
                y = -2
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                x = 1,
                y = 1
            },
            character = new ColorCharacter()
            {
                c = '5',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = 2,
                y = 2
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                y = Constants.height - 3,
                x = 1
            },
            character = new ColorCharacter()
            {
                c = '6',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = 4,
                y = -4
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                y = Constants.height / 2,
                x = 7
            },
            character = new ColorCharacter()
            {
                c = '7',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = 4,
                y = 0
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                x = Constants.width / 2,
                y = 7
            },
            character = new ColorCharacter()
            {
                c = '8',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = -4,
                y = 0
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                y = 12,
                x = 8
            },
            character = new ColorCharacter()
            {
                c = '9',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = 0,
                y = 1,
            }
        });
        enemies.Add(new GameObject()
        {
            position = new Vector2()
            {
                x = 60,
                y = 1,
            },
            character = new ColorCharacter()
            {
                c = '0',
                fg = ConsoleColor.DarkRed
            },
            velocity = new Vector2()
            {
                x = 0,
                y = -1
            }
        });
        for (int v = 10; v < 40; v++)
        {
            enemies.Add(new GameObject()
            {
                position = new Vector2()
                {
                    x = 1 + v * 2,
                    y = Constants.height - 3
                },
                character = new ColorCharacter()
                {
                    c = 'v',
                    fg = ConsoleColor.DarkRed
                },
                velocity = new Vector2()
                {
                    x = 0,
                    y = -1
                }
            });
        }

        var coin = new GameObject()
        {
            position = new Vector2()
            {
                x = Constants.width / 2,
                y = Constants.height / 2
            },
            character = new ColorCharacter()
            {
                c = 'o',
                fg = ConsoleColor.DarkYellow
            },
            velocity = new Vector2()
        };

        var player = new GameObject()
        {
            position = new Vector2()
            {
                x = 2,
                y = 2
            },
            character = new ColorCharacter()
            {
                c = '☺',
                fg = ConsoleColor.DarkGreen
            },
        };

        gameobjects.Add(player);
        gameobjects.Add(coin);
        gameobjects.AddRange(enemies);

        //game starts
        var gameOver = false;
        while (!gameOver)
        {

            player.velocity = new Vector2();

            if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
            {
                player.velocity.y = -1;
            }
            else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
            {
                player.velocity.x = -1;
            }
            else if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
            {
                player.velocity.y = 1;
            }
            else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
            {
                player.velocity.x = 1;
            }

            
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