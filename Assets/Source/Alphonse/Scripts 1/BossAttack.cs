using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BossAttack
{   
    float objectSpeed{get;}
    int Damage{get;}
    
    int getDamage()
    {
        return Damage;
    }
    float getSpeed()
    {
        return objectSpeed;
    }
}

public class Melee: BossAttack
{
    public int Damage{
        get
        {
            return 3;
        }
    }

    public float objectSpeed{
        get
        {
            return 0;
        }
    }
}

public class Projectile: BossAttack
{
    public int Damage{
        get
        {
            return 5;
        }
    }

    public float objectSpeed{
        get
        {
            return 7;
        }
    }
}