# Info on the "Archer" Prefab
---

# Features
---
### The "Archer" prefab comes with the following things attached to it.

* Animations that can be called for states such as idle, attack, death, and several more.
* Sounds for the different actions that the archer is able to preform while in game. These are things such as when the archer shoots an arrow, when the archer's arrow collides with the player, and when the archer is hit by the player or when the archer is killed by the player.
* The archer comes equipped with a "RangedEnemy.cs" script which allows the archer to flip in the direction that the player is, so that the archer is facing the player, and so that the archer shoots its arrows at the player. This also has the capabilities to have the damage that the archer deals be incramented so that the damage variable is easily changed.
* The Archer also comes with a health script that allows the player to recognize when the player takes damage with call to the players gametag "Player".
* Lastly the archer is equipped with the "SFXEnemies script that will allow the archer to play the designated sounds that are loaded into the archer prefab at the correct times that the programmer would like them to be called at.
---

# Calling the archer prefab into the game
---
### The archer prefab can be called into the game with the "EnemySpawnPointR" - shorthand for enemy spawn point ranged - prefab which will properly instantiate the archer where the developer is attempting to call the archer prefab in to be used by the game.