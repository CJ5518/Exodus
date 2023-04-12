# Info on the "LightBanditPool" prefab
---

### The LightBanditPool prefab is how the LightBandit enemies are stored in the game heirarchy and is the asset pool that the game calls from in order to place LightBandit enemies in front of the player.

# Features:
---
* The LightBanditPool prefab has the ability to drag another sprite into the prefab slot, this is the prefab that will get stored in the object pool.
* There is also two more parameters on the LightBanditPool prefab, and these are "Pool Size" as well as "Will Grow." The Pool Size is the starting size of the pool, and this is how many objects will be stored into the Object Pool to start with. This means that if "Pool Size" is set to 10, then there will be 10 of the designated prefab set into the arrow pool. The "Will Grow" boolean check allows the developer to create more of the designated objects if they so choose to. This means if all of the objects that are currently in the pool are all in use then the "Will Grow" boolean will trigger, which makes more of the prefabs in the pool so that they can also be called into the scene. The newly created number of objects that are added to the pool mirrors the "Pool Size" variable.
* Additionally this prefab is equipped with a LightBanditPool.cs script. This script manages all of the different variables that can be inputted into the script, as well as instansiates more objects in the pool when the CPU use is below 65%. 
---

### This prefab will begin to generate enemies at runtime when the Start() method is called from the main "LightBanditPool.cs" script begins to run.
---