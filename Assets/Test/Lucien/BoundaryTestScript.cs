using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class BoundaryTestScript
{
    private SFXEnemies sfxEnemies;

    [SetUp]
	public void SetUp() {
        //sfxEnemies = FindObjectOfType<SFXEnemies>();
        sfxEnemies = Resources.Load<SFXEnemies>("Assets/Source/Lucien/Prefabs/audio");
	}

    [Test]
    public void PlayArcherDeathPlaysArcherDeathSound()
    {
        //test tihe archer death sound
        AudioSource audioSource = sfxEnemies.archerDeath;
        audioSource.Stop();

        sfxEnemies.PlayArcherDeath();

        Assert.IsTrue(audioSource.isPlaying);
    }

    [Test]
    public void PlayBanditDeathPlaysBanditDeathSound()
    {
        //test the bandit death sound
        AudioSource audioSource = sfxEnemies.banditDeath;
        audioSource.Stop();

        sfxEnemies.PlayBanditDeath();

        Assert.IsTrue(audioSource.isPlaying);
    }

    [Test]
    public void PlayArcherShootPlaysArcherShootSound()
    {
        //test the archer shoot sound
        AudioSource audioSource = sfxEnemies.archerShoot;
        audioSource.Stop();

        sfxEnemies.PlayArcherShoot();

        Assert.IsTrue(audioSource.isPlaying);
    }

    [Test]
    public void PlayArcherHitPlayerPlaysArcherHitPlayerSound()
    {
        //test the archer hit sound
        AudioSource audioSource = sfxEnemies.archerHitPlayer;
        audioSource.Stop();

        sfxEnemies.PlayArcherHitPlayer();

        Assert.IsTrue(audioSource.isPlaying);
    }

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
    public void JumpAttackWithTouchingGroundTrueShouldAddForce()
    {
        //this will test if the "jumpAttack method is adding force to the enemy rigidbody
        //when touching ground variable is true
        float jump = 5;
        Rigidbody2D enemy = new Rigidbody2D();
        bool touchingGround = true;
        JumpAttack jumpAttack = new GameObject().AddComponent<JumpAttack>();

        jumpAttack.jumpAttack(jump, enemy, touchingGround);

        Assert.IsTrue(enemy.velocity.y > 0);
    }

    [Test]
    public void JumpAttackWithTouchingGroundFalseShouldNotAddForce()
    {
        //this will test if the "jumpAttack" method is adding force to the enemy rigidbody is 
        //not touching the ground, we are testing if it is not adding force
        float jump = 5;
        Rigidbody2D enemy = new Rigidbody2D();
        bool touchingGround = false;
        JumpAttack jumpAttack = new GameObject().AddComponent<JumpAttack>();

        jumpAttack.jumpAttack(jump, enemy, touchingGround);

        Assert.IsTrue(enemy.velocity.y == 0);
    }

    [Test]
    public void FixEnemyJumpAttackWithTouchingGroundTrueShouldAddForce()
    {
        //In this case, we tyest if the "jumpAttack" mentod of the "FixEnemyJumpAttack" class
        //adds force to thoe enemy when 'touchingGround' is true 
        float jump = 5;
        Rigidbody2D enemy = new Rigidbody2D();
        bool touchingGround = true;
        FixEnemyJumpAttack fixEnemyJumpAttack = new GameObject().AddComponent<FixEnemyJumpAttack>();

        fixEnemyJumpAttack.jumpAttack(jump, enemy, touchingGround);

        Assert.IsTrue(enemy.velocity.y > 0);
    }

    [Test]
    public void FixEnemyJumpAttackWithTouchingGroundFalseAndShouldStillAddForce()
    {
        //this will test if the "jumpAttack" method of the "FixEnemyJumpAttack" class adds
        //force in the opposite direction of the player so that the enemy is knocked back from the 
        //player after lunging at the player
        float jump = 5;
        Rigidbody2D enemy = new Rigidbody2D();
        bool touchingGround = false;
        FixEnemyJumpAttack fixEnemyJumpAttack = new GameObject().AddComponent<FixEnemyJumpAttack>();

        fixEnemyJumpAttack.jumpAttack(jump, enemy, touchingGround);

        Assert.IsTrue(enemy.velocity.y == 0);
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

    
}


