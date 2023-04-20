using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class NoahFinalTests
{
    // A Test behaves as an ordinary method
    [UnityTest]
    public void NoahFinalTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NoahFinalTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator StartEvent_Hail()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 1;
        int difficulty = 1;
        int time = 5;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(1);

        // the event should not be null only one second into it
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(HailEvent), eventManager.currentEvent.GetComponent<HailEvent>());
    }

    [UnityTest]
    public IEnumerator StartEvent_Frog()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 2;
        int difficulty = 2;
        int time = 5;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(time);

        // the event should not be null only 5 seconds into it
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(FrogEvent), eventManager.currentEvent.GetComponent<FrogEvent>());
    }

    [UnityTest]
    public IEnumerator StartEvent_DarkEvent()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 3;
        int difficulty = 3;
        int time = 5;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(1);

        // the event should not be null only one second into it
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(DarkEvent), eventManager.currentEvent.GetComponent<DarkEvent>());
    }

    [UnityTest]
    public IEnumerator HailEventIsOver()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 1;
        int difficulty = 1;
        int time = 3;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(time+3);

        // The event should be null 3 seconds after its time
        Assert.IsNull(eventManager.getCurrEvent());
    }

    [UnityTest]
    public IEnumerator FrogEventIsOver()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 2;
        int difficulty = 1;
        int time = 1;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(10);

        // the event should be null 10 seconds after it started
        Assert.IsNull(eventManager.getCurrEvent());
    }

    [UnityTest]
    public IEnumerator DarkEventIsOver()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 3;
        int difficulty = 3;
        int time = 5;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(time+4);

        // the event should be null 4 seconds after its allotted time
        Assert.IsNull(eventManager.getCurrEvent());
    }

    [UnityTest]
    public IEnumerator SemaphoreKeepOut()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 2;
        int difficulty = 2;
        int time = 5;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(1);
        eventManager.startEvent(type-1, difficulty, time);
        yield return new WaitForSeconds(1);

        // the type 2 frog event should still be going on because its time didnt run out after 2 seconds
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(FrogEvent), eventManager.currentEvent.GetComponent<FrogEvent>());
    }

    [UnityTest]
    public IEnumerator SemaphoreReset()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        //eventManager.endEvent();
        int type = 2;
        int difficulty = 1;
        int time = 2;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(10);
        eventManager.startEvent(type + 1, difficulty, time);
        yield return new WaitForSeconds(1);

        // a new event (darkness) should now be active in the semaphore
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(DarkEvent), eventManager.currentEvent.GetComponent<DarkEvent>());
    }

    [UnityTest]
    public IEnumerator StableTime()
    {
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 1;
        int difficulty = 2;
        int time = 5;

        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(1);
        eventManager.startEvent(type-1, difficulty, time + 1);
        yield return new WaitForSeconds(1);

        // the time limit should not have have changed since first call
        // the time elapsed should have continued without being affected
        Assert.AreEqual(EventManager.maxTime, time);
        Assert.Less(EventManager.timeElapsed, 3.5f);
    }
}

