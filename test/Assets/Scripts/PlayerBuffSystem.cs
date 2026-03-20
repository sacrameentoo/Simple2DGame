using UnityEngine;
using System.Collections;

public class PlayerBuffSystem : MonoBehaviour
{
    private int bonusDamage = 0;
    
    public ParticleSystem damageBuffEffect;
    public ParticleSystem poisonEffect;
    public ParticleSystem damageDebuffEffect;

    public int GetBonusDamage()
    {
        return bonusDamage;
    }

    public void AddDamage(int value, float duration)
    {
        StartCoroutine(DamageBuff(value, duration));
    }

    private IEnumerator DamageBuff(int value, float duration)
    {
        bonusDamage += value;
        if (damageBuffEffect != null)
        {
            Instantiate(damageBuffEffect, transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(duration);
        bonusDamage -= value;
        if (damageBuffEffect != null)
        {
            damageBuffEffect.Stop();
        }
    }

    public void ApplyPoison(int damage)
    {
        StartCoroutine(Poison(damage));
    }

    private IEnumerator Poison(int dmg)
    {
        if (damageDebuffEffect != null)
        {
            Instantiate(damageDebuffEffect, transform.position, Quaternion.identity);
        }
        for (int i = 0; i < 5; i++)
        {
            GetComponent<HealthSystem>().TakeDamage(dmg);
            yield return new WaitForSeconds(1f);
        }

        if (poisonEffect != null)
        {
            poisonEffect.Stop();
        }
    }
    
    public void ReduceDamage(int value, float duration)
    {
        StartCoroutine(DamageDebuff(value, duration));
    }
    
    private IEnumerator DamageDebuff(int value, float duration)
    {
        bonusDamage -= value;

        if (damageDebuffEffect != null)
        {
            Instantiate(damageDebuffEffect, transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(duration);

        bonusDamage += value;

        if (damageDebuffEffect != null)
        {
            damageDebuffEffect.Stop();
        }
    }
}