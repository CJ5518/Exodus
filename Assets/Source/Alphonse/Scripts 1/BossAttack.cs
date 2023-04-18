using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BossAttack
{
    int Damage{get;}

    int getDamage()
    {
        return Damage;
    }
}

public class Melee: BossAttack
{
    public int Damage{
        get
        {
            return 5;
        }
    }
}

public class Projectile: BossAttack
{
    float objectSpeed;

    public int Damage{
        get
        {
            return 7;
        }
    }
}