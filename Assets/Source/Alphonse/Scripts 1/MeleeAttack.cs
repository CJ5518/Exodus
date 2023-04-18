using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MeleeAttack: BossAttack //decorartor design pattern
{
    protected BossAttack attack1;

    public MeleeAttack(BossAttack attack1)
    {
        this.attack1 = attack1;
    }

    public virtual int Damage
    {
        get
        { 
            return this.attack1.Damage;
        }
    }
}
/*
public class baseMelee: MeleeAttack
{
    public baseMelee()
    {
        Debug.Log("Entered, baseMelee");
    }

    public override int Damage
    {
       get
       {return 10;}
    }
}*/

public class runMeleeAttack: MeleeAttack
{
    public runMeleeAttack(BossAttack attack1): base(attack1)
    {

    }

    public override int Damage
    {
        get
        {
            return 2+attack1.Damage;
            //return 6;
        }
    }
}

public class damageBoost: MeleeAttack
{
    public damageBoost(BossAttack attackBoost): base(attackBoost)
    {

    }

    public override int Damage
    {
        get
        {
            return 3 + attack1.Damage;
            //return 6;
        }
    }
}
