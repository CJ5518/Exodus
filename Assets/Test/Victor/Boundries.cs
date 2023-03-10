using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Boundries
{
    SpawnPoint spawnPoint = new GameObject().AddComponent<SpawnPoint>();


    // A Test behaves as an ordinary method
    [Test]
    public void BoundriesSimplePasses()
    {
        // Use the Assert class to test conditions
    }


    //
    public void CheckNumRoomsGreaterThanFour()
    {
        int roomNum = spawnPoint.CountRooms();
        Assert.Greater(roomNum, 4);
    }

    public void CheckNumRoomsLessThanThirtyOne()
    {
        int roomNum = spawnPoint.CountRooms();
        Assert.Less(roomNum, 31);
    }



    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BoundriesWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
