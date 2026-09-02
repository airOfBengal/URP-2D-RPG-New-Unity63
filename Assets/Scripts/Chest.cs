using UnityEngine;

public class Chest : MonoBehaviour, IDamagable
{
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    Animator anim => GetComponentInChildren<Animator>();
    EntityVfx vfx => GetComponent<EntityVfx>();

    [Header("Open Details")]
    [SerializeField] Vector2 knockback;


    public void TakeDamage(float damage, Transform damageDealer)
    {
        vfx.ShowHitVfx();
        anim.SetBool("chestOpen", true);
        rb.linearVelocity = knockback;
        rb.angularVelocity = Random.Range(-200f, 200f);
    }
}
