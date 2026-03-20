using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum Type { Heal, DamageBuff, DamageDebuff }

    public Type type;
    public int value = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var health = other.GetComponent<HealthSystem>();
        var buffs = other.GetComponent<PlayerBuffSystem>();

        switch (type)
        {
            case Type.Heal:
                health.Heal(value);
                break;

            case Type.DamageBuff:
                buffs.AddDamage(20, 5f);
                break;

            case Type.DamageDebuff:
                buffs.ReduceDamage(20, 5f);
                break;
        }

        Destroy(gameObject);
    }
}