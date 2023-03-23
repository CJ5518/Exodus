using System.Collections;       
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Boundaries
{
    EventManager em = new GameObject().AddComponent<EventManager>();
    // A Test behaves as an ordinary method
    [Test]
    public void BoundaryTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    [Test]
    public void CheckNotStartedYet()
    {
        em.endEvent();
        //check to see that event has not yet started
        //int? currentEvent = em.currentEvent;
        Assert.IsNull(em.currentEvent);
    }

    [Test]
    public void CheckStarted()
    {
        //this will check to see that an event has infact started
        em.startEvent(1, 5, 5);
        Assert.IsNotNull(em.currentEvent);
        em.endEvent();
    }

    [Test]
    public void CheckNormDifficulty()
    {
        //this will check to see that the spawn rate has been set correctly according to parameter
        em.startEvent(1, 5, 5);
        HailEvent he =  GameObject.FindWithTag("HailEvent").GetComponent<HailEvent>();
        Assert.AreEqual(he.spawninterval, 32);
        em.endEvent();
    }

    [Test]
    public void CheckMaxDifficulty()
    {
        //this will check to see that the spawn rate has been set correctly according to parameter
        em.startEvent(1, 10, 5);
        HailEvent he =  GameObject.FindWithTag("HailEvent").GetComponent<HailEvent>();
        Assert.AreEqual(he.spawninterval, 1);
        em.endEvent();
    }

    [Test]
    public void CheckTooHighDifficulty()
    {
        //this will check to see that the spawn rate has been set to the highest difficulty parameter
        em.startEvent(1, 11, 5);
        HailEvent he =  GameObject.FindWithTag("HailEvent").GetComponent<HailEvent>();
        Assert.AreEqual(he.spawninterval, 1);
        em.endEvent();
    }

    [Test]
    public void CheckNegTime()
    {
        //this will check to see what happens given a negative time
        //the event should be null
        em.startEvent(1, 5, -5);
        Assert.IsNull(em.currentEvent);
        em.endEvent();
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
//    [UnityTest]
//    public IEnumerator BoundaryTestScriptWithEnumeratorPasses()
//    {
//        // Use the Assert class to test conditions.
//        // Use yield to skip a frame.
//        yield return null;
//    }
}