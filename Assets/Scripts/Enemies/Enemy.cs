using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : ScriptableObject
{
    //DATA
    /*[SerializeField] protected EnemyData enemyData;
    [SerializeField] protected ScriptableFloat playerHealth;

    //REFERENCES
    [SerializeField] protected Transform touchCheck, projectileSpawn;
    [SerializeField] protected LayerMask whatIsPlayer;
    [SerializeField] protected GameObject projectilePf, deathBloodParticle;
    //protected GameObject alive;

    protected float currentHealth, lastShot, lastTouchDamageTime;
    [SerializeField] protected float touchCheckRadius, touchDamageCooldown;
    protected bool canShoot = true;

    protected virtual void Start()
    {
        currentHealth = enemyData.MaxHealth;
        //  alive = transform.Find("Alive").gameObject;
    }

    protected virtual void Update()
    {
        CheckPlayerHealth();
        CheckAttack();
        CheckTouchDamage();
    }
    protected virtual void CheckAttack()
    {
        if (CheckIfPlayerInRange())
        {
            //flip para o player
            if (canShoot)
            {
                if (Time.time - lastShot < enemyData.Projectile.Cooldown)
                {
                    return;
                }
                lastShot = Time.time;

                Instantiate(projectilePf, projectileSpawn.position, projectileSpawn.rotation);
            }
            else
            {
                //Debug.Log("CANT SHOOT");
            }
        }
    }

    protected virtual bool CheckIfPlayerInRange()
    {

        //criar uma caixa e ver se ta la o player
        return true;
    }
    protected virtual void CheckPlayerHealth()
    {
        if (playerHealth.Value < enemyData.MinHealthToShoot)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
    }

    public virtual void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.DamageAmount;
        Debug.Log("damage to enemy");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void CheckTouchDamage()
    {
        if (Time.time >= lastTouchDamageTime + touchDamageCooldown)
        {
            AttackDetails attackDetails = new AttackDetails();
            Collider2D hit = Physics2D.OverlapCircle(touchCheck.position, touchCheckRadius, whatIsPlayer);
            //Debug.Log(hit);
            if (hit != null && hit.tag == "Player")
            {
                //Debug.Log("damaged the player by " + enemyData.TouchDamage);

                lastTouchDamageTime = Time.time;
                attackDetails.DamageAmount = enemyData.TouchDamage;
                attackDetails.AttackDirection = transform.position.x;
                attackDetails.KnockbackAngle = enemyData.KnockbackForce;
                attackDetails.KnockbackDuration = enemyData.TouchKnockbackDuration;
                hit.SendMessage("Damage", attackDetails);

            }
        }
    }

    protected virtual void Die()
    {
        Debug.Log("ENEMY DIED");
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        Destroy(gameObject);
    }

    protected virtual void Flip()
    {
        Debug.Log("flip");
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(touchCheck.position, touchCheckRadius);
    }*/

    public abstract void Atack();
    public abstract void Die();
}
