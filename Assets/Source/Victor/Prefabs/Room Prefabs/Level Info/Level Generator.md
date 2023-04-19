# Info for the "Level Generator" prefab
---
## Funcitonality
* Generates a Level
* Manages individual Rooms, Demo-Mode AI, AStar Pathfinding, Player Location, Exit Location, and Camera Position

## Prefab Components
* Level Generation script
  - \[Setting 1] **Generator**: A reference to the *Map Room Selector* script
  - \[Setting 2] **Number Of Rooms**: Set this to the number of rooms you want to generate
  - \[Setting 3] **World Size**: This is the area where the rooms can spawn.
  - \[Setting 4] **Player Spawn**: A reference to the Player or Demo-Mode Player to set its spawn position and instantiate it.
  - \[Setting 5] **Exit Door**: A reference to the Exit Door to instantiate an exit to the level at the end of the map.
  - \[Setting 6] **Cam**: A reference to the *Camera Move* script to follow the player in each room the player goes to.
  - \[Setting 7] **Demo Mode**: Check this if you are running in Demo-Mode. It will activate Pathfinding for the Demo-Mode Player.
  - \[Setting 8] **A Star Path**: A reference to an *AStarPath* script that generates a path for the Demo-Mode Player. 
    - There is an already set up prefab in Assets/Source/Victor/Prefabs/Room Prefabs/Level Info/AStar.prefab
* Map Room Selector script
  - [Settings 1 - 15] **Pf [Direction]**: References to individual rooms organized by which direction of doors they have.
    - [Direction] U: Up
    - [Direction] D: Down
    - [Direction] L: Left
    - [Direction] R: Right

## How to use
1. Add the "Level Generator" prefab to your scene
2. Add the *Move Camera* script onto the Main Camera
3. Add the Level Background as a child to the Main Camera, located in Assets/Source/Victor/Sprites/Exodus Assets/Background.png
4. Fill out the settings in each component to your liking (as outlined above)
5. Run the scene and enjoy the level.
6. [Optional] For saving a specific room: Once Level is generated, copy all the rooms generated **"Room\[Direction](clone)"**, the Player **"Player"**, 
   the Exit Room **"Target(clone)"**, 
