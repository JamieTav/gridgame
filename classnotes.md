2023-03-31
===

inheritance

our goal is to make Program.cs has as little game logic as possible,
we want it to just start and run the core of the game, but how the game works should be distributed on other files

```cs


//
// update all game objects
foreach (var go in gameobjects)
{
    go.Update();
}

foreach (var go in gameobjects)
{
    canvas.Draw(go);
}
```

so when you want a Child class to inherit from a Base class, it means that Child behaves pretty much like Base, but with some specifics

Player is a GameObject

```cs
public class Player : GameObject {
  // 
}
```

when inheriting, you can only modify methods (functions) that are marked `virtual`, and you can modify them by writing `override`