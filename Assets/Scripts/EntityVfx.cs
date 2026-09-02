
using System.Collections;
using UnityEngine;

public class EntityVfx : MonoBehaviour
{
    [Header("On Damage Vfx")]
    [SerializeField] GameObject hitVfx;
    [SerializeField] Material damageMaterial;
    [SerializeField] float damageVfxDuration = 0.2f;
    protected Material originalMaterial;
    protected SpriteRenderer spriteRenderer;
    Coroutine damageVfxCoroutine;

    protected virtual void Awake() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;    
    }

    public void ShowHitVfx()
    {
        if(damageVfxCoroutine != null) StopCoroutine(damageVfxCoroutine);
        damageVfxCoroutine = StartCoroutine(RoutineHitVfx());

        if(hitVfx != null)
        {
            GameObject vfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
            vfx.transform.parent = transform;
        }
    }

    private IEnumerator RoutineHitVfx()
    {
        spriteRenderer.material = damageMaterial;
        yield return new WaitForSeconds(damageVfxDuration);
        spriteRenderer.material = originalMaterial;
    }
}
