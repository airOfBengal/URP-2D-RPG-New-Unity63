using System;
using System.Collections;
using UnityEngine;

public class EntityVfx : MonoBehaviour
{
    [Header("On Damage Vfx")]
    [SerializeField] Material damageMaterial;
    [SerializeField] float damageVfxDuration = 0.2f;
    Material originalMaterial;
    SpriteRenderer spriteRenderer;
    Coroutine damageVfxCoroutine;

    private void Awake() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;    
    }

    public void ShowHitVfx()
    {
        if(damageVfxCoroutine != null) StopCoroutine(damageVfxCoroutine);
        damageVfxCoroutine = StartCoroutine(RoutineHitVfx());
    }

    private IEnumerator RoutineHitVfx()
    {
        spriteRenderer.material = damageMaterial;
        yield return new WaitForSeconds(damageVfxDuration);
        spriteRenderer.material = originalMaterial;
    }
}
