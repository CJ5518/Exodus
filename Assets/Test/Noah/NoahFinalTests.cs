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
        // Arrange
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 1;
        int difficulty = 1;
        int time = 5;

        // Act
        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(1);

        // Assert
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(HailEvent), eventManager.currentEvent.GetComponent<HailEvent>());
    }

    [UnityTest]
    public IEnumerator StartEvent_Frog()
    {
        // Arrange
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 2;
        int difficulty = 2;
        int time = 5;

        // Act
        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(time);

        // Assert
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(FrogEvent), eventManager.currentEvent.GetComponent<FrogEvent>());
    }

    [UnityTest]
    public IEnumerator StartEvent_DarkEvent()
    {
        // Arrange
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 3;
        int difficulty = 3;
        int time = 5;

        // Act
        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(1);

        // Assert
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(DarkEvent), eventManager.currentEvent.GetComponent<DarkEvent>());
    }

    [UnityTest]
    public IEnumerator HailEventIsOver()
    {
        // Arrange
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 1;
        int difficulty = 1;
        int time = 3;

        // Act
        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(time+3);

        // Assert
        Assert.IsNull(eventManager.getCurrEvent());
    }

    [UnityTest]
    public IEnumerator FrogEventIsOver()
    {
        // Arrange
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 2;
        int difficulty = 1;
        int time = 1;

        // Act
        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(10);

        // Assert
        Assert.IsNull(eventManager.getCurrEvent());
    }

    [UnityTest]
    public IEnumerator DarkEventIsOver()
    {
        // Arrange
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 3;
        int difficulty = 3;
        int time = 5;

        // Act
        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(time+1);

        // Assert
        Assert.IsNull(eventManager.getCurrEvent());
    }

    [UnityTest]
    public IEnumerator SemaphoreKeepOut()
    {
        // Arrange
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        eventManager.endEvent();
        int type = 2;
        int difficulty = 2;
        int time = 5;

        // Act
        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(1);
        eventManager.startEvent(type-1, difficulty, time);
        yield return new WaitForSeconds(1);

        // Assert
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(FrogEvent), eventManager.currentEvent.GetComponent<FrogEvent>());
    }

    [UnityTest]
    public IEnumerator SemaphoreReset()
    {
        // Arrange
        GameObject eventManagerObject = new GameObject();
        EventManager eventManager = eventManagerObject.AddComponent<EventManager>();
        //eventManager.endEvent();
        int type = 2;
        int difficulty = 1;
        int time = 2;

        // Act
        eventManager.startEvent(type, difficulty, time);
        yield return new WaitForSeconds(10);
        eventManager.startEvent(type + 1, difficulty, time);
        yield return new WaitForSeconds(1);

        // Assert
        Assert.IsNotNull(eventManager.getCurrEvent());
        Assert.IsInstanceOf(typeof(HailEvent), eventManager.currentEvent.GetComponent<FrogEvent>());
    }
}

