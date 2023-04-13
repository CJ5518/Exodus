using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossDecorator
{
    abstract class MeleeAttack  //decorartor design pattern
    {
        public abstract int Attack(); 

		public Animator animator;
		public Transform attackPoint;
        public float attackRange = .5f;

		void OnDrawGizmosSelected() 
		{
            if(attackPoint == null)
            {
                return;
            }

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }

    class baseMelee: MeleeAttack
    {
        public override int Attack() //(TakeDamage/damage)
        {
            int damage = 10;
            animator.SetTrigger("Attack");

            return damage;
        }
    }

    abstract class MeleeDecorator : MeleeAttack // base decorator
    {
        MeleeAttack ma;

        public override int Attack()
        {
            if(ma != null)
            {
                return ma.Attack();
            }
            else
            {
                return 0;
            }
        }

        public void setMeleeAttack(MeleeAttack ma)
        {
            this.ma = ma;
        }
    }

    class runMeleeAttack : MeleeDecorator
    {
        public override int Attack()
        {
            return base.Attack() + 5;
        }
    }

    class ProjectileAttack : MeleeDecorator
    {
        GameObject projectile;
        Transform ProjectilePos;

		private float timer, count;

		void Start()
		{
		    count = 0;
		}

		void Update() 
		{
			timer += Time.deltaTime;

            while( timer > count)
            {
                //Instantiate(projectile, ProjectilePos.position, Quaternion.identity);
                count += 20f;
            }
		}

        public ProjectileAttack(GameObject projectile)
        {
            if(projectile == null)
            {
                throw new ("Projectile object is null");
            }

            this.projectile = projectile;
        }

        public override int Attack()
        {
            //chargedProjectile();
            return base.Attack() * 2;
        }

       /* void chargedProjectile()
        {
            // needs work for on collision with the player
        }*/
    }

    //base interface

    //concrete implementation

    //base decorator

    //concrete decorator
}
