using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TESTS
{
    HealthManager HM = new GameObject().AddComponent<HealthManager>();

    [Test]
    public void BoundaryTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    [Test]
    public void testNegativeHealth()
    {
        //check to see if the enemy will take 10 damage
        //float healthAmt = 20;
        //int damage = 30;
        HM.takeDamage(110);
        Assert.That(HM.healthAmt, Is.LessThan(0));
    }

    [Test]
    public void testOverloadHealth()
    {
        //this will check to see if the enemy gains health when they take negative damage or not
        HM.healthAmt = 100f;
        HM.takeDamage(-20f);
        Assert.That(HM.healthAmt, Is.GreaterThan(100f));
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
