# Health Potion Prefab Documentation
* Health Potion Prefab has the rigid body and 2D Collider components attached to it
* This allows it to be picked up by the an Object with the "Player" Tag and have physical attributes in the scene
* If the inventory has been setup (Inventory Prefab and Inventory Canvas Prefab) it will also be added to the invnentory

# Using the prefab
* The prefab will spawn wherever "HealthPotSpawnPoint"is placed into the scene
* The prefab can also be placed manually if the associated SpawnPoint script has been removed
* If the user has the inventory system setup, User can press "I" to verify that the health potion has been added to their inventory
* In addition, pressing "H" will use that health potion use and discard a health potion
* This Prefab utilzies an Object Pool to initially generate the health potion objects that are then recycled throughout the game

# Who is it for
* Users getting started with Unity (interacting with rigid body and colliders) and making an RPG using potions
* Users curious about sprites from the Unity Assets store
* Users interested in the Object Pool design pattern. 
