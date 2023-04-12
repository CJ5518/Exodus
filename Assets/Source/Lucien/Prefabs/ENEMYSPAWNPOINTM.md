# Info on the "EnemySpawnPointM" prefab
---

### The "EnemySpawnPointM" (Enemy Spawn Point Melee) prefab is able to be placed anywhere on the scene and is an empty game object.

### The script that is attached to it will find the position of the empty game object prefab that it is attached to, and when the player gets close enough to it it will invoke the "LightBandit" prefab from the "LightBanditObjectPool" prefab that should also exist in the scene heirarchy.

### This will create one instance of the enemy at the designated point and when the enemy has been defeated, it will not spawn another one.

### This is so the game doesn't have as much strain on it at all times during the game, and every enemy that is included in the game will not be loaded into the game until the player is close enough to the enemy.
---