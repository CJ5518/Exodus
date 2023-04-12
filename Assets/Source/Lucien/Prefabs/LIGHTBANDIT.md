# Info on the "LightBandit" prefab
---

# Features
---
### The "LightBandit" prefab comes with the following things attached to it.

* Animations that can be called for states such as idle, attack, death, and several more.
* Sounds for the different actions that the light bandit is able to preform while in game. These sounds are when the player hits the light bandit, or when the light bandit is killed.
* The archer comes equipped with a "EnemyJumpAttack.cs" script which allows the light bandit to flip in the direction that the player is, so that the light bandit is facing the player. This enemy will jump at the player and cause damage to them when they collide with the player. The light bandit will also bounce off of the player when it comes into contact with the player so it isn't infinetly jumping at the player. This prefab also has the capabilities to have the damage that the light bandit deals be incrimented so that the damage variable is easily changed.
* The light bandit also comes with a health script that allows the player to recognize when the player takes damage with call to the players gametag "Player".
* Lastly the light bandit is equipped with the "SFXEnemies" script that will allow the light bandit to play the designated sounds that are loaded into the audio prefab at the correct times that the programmer would like them to be called at.
---

# Calling the light bandit prefab into the game
---
### The light bandit prefab can be called into the game with the "EnemySpawnPointM" - shorthand for enemy spawn point melee - prefab which will properly instantiate the light bandit where the developer is attempting to call the light bandit prefab in to be used by the game.

### Additionally the light bandit is instantiated into the game through utilization of the "LightBanditObjectPool" script. This is where the light bandit will be held in the heirarchy so the game doesn't need to instansiate and/or destroy the prefab every time it is called. This will also take load time off of the game in total as the assets will be loaded at the beginning of the game or they will be allocated when the CPU is not in use.