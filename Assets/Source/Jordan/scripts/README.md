<h1> BackgroundActor - Bird </h1>

To create a bird, use the instantiate function with a location and rotation.

`BackgroundActor bird = Instantiate(Bird, new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f)), Quaternion.identity).GetComponent<Bird>();`

Once created, the bird must be updated correctly. 
Every so many frames call the MakeDecisions function so that the bird can change directions if needed. This function also allows the bird to start or stop moving.<br>
`if (iTick % 50 == 0)`<br>
`  bird.MakeDecisions();`

Every frame the Move function must be called so that the bird may update its position.
`bird.Move();`

This is all that needs to be done to implement this prefab. The bird will now fully move and fly within camera view.
