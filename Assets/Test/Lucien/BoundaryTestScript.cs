using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoundaryTestScript
{
    EnemyJumpAttack enemyJumpAttack = new GameObject().AddComponent<EnemyJumpAttack>();
    // A Test behaves as an ordinary method
    [Test]
    public void BoundaryTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    [Test]
    public void CheckEnemyTake10Damage()
    {
        //check to see if the enemy will take 10 damage
        int health = enemyJumpAttack.lightBanditTakeDamage(100, 10);
        Assert.AreEqual(90, health);
    }

    [Test]
    public void CheckEnemyTakeNegativeDamage()
    {
        //this will check to see if the enemy gains health when they take negative damage or not
        int health = enemyJumpAttack.lightBanditTakeDamage(100, -10);
        Assert.AreEqual(100, health);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BoundaryTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
