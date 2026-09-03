using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBarStatusParent;
    [SerializeField] GameObject healthBarStatus;
    [SerializeField] bool lazyLoad;
    [SerializeField] EntityHealth entityHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (lazyLoad)
        {
            healthBarStatusParent.SetActive(false);
        }
    }

    private void OnEnable() 
    {
        entityHealth.OnHealthUpdate += HandleHealthBar; 
    }

    private void Update() 
    {
        transform.rotation = Quaternion.identity;    
    }

    private void HandleFlip()
    {
        transform.rotation = Quaternion.identity;
    }

    private void HandleHealthBar()
    {
        if(lazyLoad)
        {
            healthBarStatusParent.SetActive(true);
        }

        healthBarStatus.transform.localScale = new Vector3(entityHealth.currentHp / entityHealth.stats.GetMaxHealth(), 1f, 1f);
    }

    private void OnDisable() 
    {
        entityHealth.OnHealthUpdate -= HandleHealthBar;    
    }
}
