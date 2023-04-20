FrogREADME.md
Noah Rieth
The instantiated frog prefab is a single frog by itself that is an enemy to the Player.

The frog script which is attached to it makes it so that the frog is always pointed towards the player, and will randomly jump towards the player with a variable direction and velocity.
The "difficulty" of the frog can be adjusted via its receiveSpeed() method. It takes an integer argument that will set the X velocity that the frog leaves the ground with.
If the velocity is higher, the player will have a much harder time avoiding the attack. 

The frog is also animated, going into a jump state when it is not on the ground, and going back to its original form when it returns to the ground. 

The frog has the capability to deal damage to the player. 
Currently, it deals damage when it is in the jump state, and cannot deal damage when it is not in the jump state,
providing an oppartunity for the player to kill it. 
