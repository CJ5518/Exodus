# Info on the "arrows" prefab
---

# Features -
---

### The "arrows" prefab comes with a couple different objects attached to it so that it behaves more like an arrow that may be shot in the real world.

* On the "EnemyProjectiles.cs" script that is attached to the arrow, the developer is able to alter 3 different feilds. These feilds are Damage, Speed, and Reset Time. The Damage feild allows the developer to adjust the damage that each arrow hit to the player causes. The Speed feild is how fast each of the arrows will travel at once the arrow is shot at player. The Reset time field for the arrow is how long the arrow will stay active in the scene once the archer has shot the arrow, and the arrow has collided with another object.
* If the arrow hits the player, it will despawn and cause the damage to that player. 
* Each arrow is equipped with a box collider so that the arrow that is fired from the archer is able to detect if it has hit anything. The collider on the arrow prefab only takes up the tip of the arrow, as if the player jumps over the tip of the arrow then they will not take damage from the arrow since the point of the arrow didn't touch the player.
* Additionally there is a Rigidbody on the arrow to give it a weighted effect. This way the arrow will slowly fall after it has been fired from the archer so that it doesn't stay on a straight path the entire time.
---