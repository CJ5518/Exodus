# Carson Rueber's Section of the Project

I am responsible for creating the player character

# On controlling the player via programming code

To control the player programatically (without using the keyboard) then do something like this:

```cs
Player player = PlayerSingleton.Player;
PlayerComputer controller = new PlayerComputer();
player.controller = controller;

// Now to control it
controller.PressHorizontal(1);

//Wait a frame
yield return null;

controller.ReleaseHorizontal(1);

```

An example of this in action can be found in `Tests/CarsonBoundaryTests.cs`

For more information, check out `PlayerController.cs`

# On Tests

There are a couple boundary tests.

There is a stress test as well.
