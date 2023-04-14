# Player.prefab

## Events
`UnityEvent onDamageTaken`
Invoked when the player takes damage

`UnityEvent onDamageRemoved`
Invoked when the dealDamage function is called with a negative value

`UnityEvent onDeath`
Called when the player dies (health is <= 0)

## Functions
`void dealDamage(int damage)`
Deal damage to the player, negative values are allowed and will heal the player


`void resetHealth()`
Reset health to full

## Properties
`int health` get the player health

`PlayerController` get or set the player controller

`PlayerState` get or set the player state, not meant for public use

`Rigidbody2D rigidBody`

`SpriteRenderer spriteRenderer`

`AudioSource audioSource`

## Informational functions
`bool isGrounded`
Is the player grounded?

`bool isTouchingCeiling`
Is the player touching the ceiling?


`int isTouchingWall(float distance = 0.05f)`
Is the player touching a wall?
Returns 1 for the right wall, -1 for the left, or 0 for not touching a wall. The default value is good for direct wall contact bigger values are basically "near wall"

`bool isFalling` 
Is the player falling?
