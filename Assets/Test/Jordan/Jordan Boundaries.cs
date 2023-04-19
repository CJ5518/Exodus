using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class JordanBoundaries
{
    HealthBar goHHealthBar = new GameObject().AddComponent<HealthBar>();
    BackgroundActor bird = GameObject.Instantiate((GameObject) Resources.Load("prefabs/Jordan/Bird", typeof(GameObject)), new Vector3(Random.Range(-10f, 10f), Random.Range(-4f, 1f)), Quaternion.identity).GetComponent<Bird>();

    [Test]
    public void CanSetHealth()
    {
        //check to see if the enemy will take 10 damage
        goHHealthBar.SetHealth(50);
        Assert.AreEqual(50, goHHealthBar.GetHealth());
    }

    [Test]

    public void CanSetHealthOutOfRange()
    {
        //check to see if the enemy will take 10 damage'
        goHHealthBar.SetHealth(100);
        goHHealthBar.SetMaxHealth(100);
        goHHealthBar.SetHealth(101);
        Assert.AreEqual(100, goHHealthBar.GetHealth());
    }

    [Test]

    public void CanChangeMaxHealth()
    {
        //check to see if the enemy will take 10 damage'
        goHHealthBar.SetHealth(100);
        goHHealthBar.SetMaxHealth(50);
        Assert.AreEqual(50, goHHealthBar.GetHealth());
    }

    [Test]
    public void BirdFlyOffScreen()
    {

        for (int i = 0; i < 10000; i++)
        {
            if (i % 50 == 0)
                bird.MakeDecisions();


            bird.Move();

        }
        if (bird.transform.position.x > 10 || bird.transform.position.x < -10 || bird.transform.position.y > 5 || bird.transform.position.y < -5)
        {
            Assert.Fail();
        }
        Assert.Pass();
    }
}
