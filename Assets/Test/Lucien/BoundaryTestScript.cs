using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class BoundaryTestScript
{
    [Test]
    public void BoundaryTestScriptSimplePasses()
    {
        //Use the Assert class to test conditions
    }   

    [Test]
    public void GetObjectReturnNoObjectsAreAvailableGrowIsFalse()
    {
        //this will check to see if the grow function is workinpg properly and all the objects are used
        //this one the grow function is set to off and the assets are all used
        ObjectPool objectPool = new GameObject().AddComponent<ObjectPool>();
        objectPool.prefab = new GameObject();
        objectPool.poolSize = 1;
        objectPool.willGrow = false;
        objectPool.Awake();

        GameObject obj = objectPool.GetObject();
        Assert.IsNotNull(obj);

        obj = objectPool.GetObject();
        Assert.IsNotNull(obj);
    }

    [Test]
    public void GetObjectReturnNoObjectsAreAvailableGrowIsTrue()
    {
        //this will check to see if the grow function works when grow in enabled and all objects
        //are currently in use and the pool needs to create more for use in the game
        //this will check to see if the grow function is workinpg properly and all the objects are used
        //this one the grow function is set to off and the assets are all used
        ObjectPool objectPool = new GameObject().AddComponent<ObjectPool>();
        objectPool.prefab = new GameObject();
        objectPool.poolSize = 1;
        objectPool.willGrow = true;
        objectPool.Awake();

        GameObject obj = objectPool.GetObject();
        Assert.IsNotNull(obj);

        obj = objectPool.GetObject();
        
        Assert.IsNotNull(obj);
    }

    [Test]
    public void GetObjectReturnsGameObject()
    {
        //this checks to make sure that we can get objects from the object pool correctly
        //and the pool make sobjectys that can be used later in the scene
        ObjectPool objectPool = new GameObject().AddComponent<ObjectPool>();
        objectPool.prefab = new GameObject();
        objectPool.poolSize = 5;
        objectPool.willGrow = false;
        objectPool.Awake();
        GameObject obj = objectPool.GetObject();

        Assert.NotNull(obj);
    }

    [Test]
    public void ReleaseObjectSetsGameObjectInactive()
    {
        //this checks to make sure that thje object pool object is able to be set back
        //to inactive after the object has already been initialized in the scene
        ObjectPool objectPool = new GameObject().AddComponent<ObjectPool>();
        objectPool.prefab = new GameObject();
        objectPool.poolSize = 5;
        objectPool.willGrow = false;
        objectPool.Awake();
        GameObject obj = objectPool.GetObject();

        objectPool.ReleaseObject(obj);

        Assert.IsFalse(obj.activeInHierarchy);
    }

    [Test]
    public void GetCurrentValueForProcessorUsage()
    {
        //this is to make sure that the proccessor is being properly monitored in the game
        //and always returns a value between 0 and 100
        ProcessorUsage processorUsage = new ProcessorUsage();
        float currentValue = processorUsage.GetCurrentValue();

        Assert.GreaterOrEqual(currentValue, 0);
        Assert.LessOrEqual(currentValue, 100);
    }    

    [Test]
    public void GetCurrentValueForProcessorUsageAndHaveItReturnSameValueWithinSampleFrequency()
    {
        //this tests to make sure that the values don't change when the sample frequency is the same
        //this way we know that the processor is being read properly
        ProcessorUsage processorUsage = new ProcessorUsage();
        float firstValue = processorUsage.GetCurrentValue();
        System.Threading.Thread.Sleep(500);
        float secondValue = processorUsage.GetCurrentValue();

        Assert.AreEqual(firstValue, secondValue, 5);
    }

    [Test]
    public void CheckIfMeleeEnemyIsDead()
    {
        //is the melee enemy dead if their health is 0?
        GameObject enemy = new GameObject();
        EnemyJumpAttack enemyJumpAttack = enemy.AddComponent<EnemyJumpAttack>();
        float health = 0;
        bool result = enemyJumpAttack.CheckIfMeleeEnemyIsDead(health);

        Assert.IsTrue(result);
    }

    [Test]
    public void CheckIfMeleeEnemyIsAlive()
    {
        //is the melee enemy dead if their health is not 0?
        GameObject enemy = new GameObject();
        EnemyJumpAttack enemyJumpAttack = enemy.AddComponent<EnemyJumpAttack>();
        float health = 50;
        bool result = enemyJumpAttack.CheckIfMeleeEnemyIsDead(health);

        Assert.IsFalse(result);
    }

    
}


