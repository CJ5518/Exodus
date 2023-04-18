using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Boundries
{

    // Checks whether or not there can be more rooms generated than possible
    [Test]
    public void RoomsGeneratedCanFitInBoundries()
    {
        LevelGeneration levelGeneration = new LevelGeneration();
        int maxRooms = levelGeneration.MaxRooms();
        Assert.LessOrEqual(levelGeneration.numberOfRooms, maxRooms);
    }

    [Test]
    public void AtLeastFiveRooms() {
        LevelGeneration levelGeneration = new LevelGeneration();
        Assert.GreaterOrEqual(levelGeneration.numberOfRooms, 5);
    }

    // [Test]
    // public void LevelIsCompletable() {
    //     GameObject gameObject = new GameObject();
    //     LevelGeneration levelGeneration = gameObject.AddComponent(typeof(LevelGeneration)) as LevelGeneration;
    //     System.Threading.Thread.Sleep(1000);

    //     Assert.IsTrue(levelGeneration.IsCompletable());
    // }
}

