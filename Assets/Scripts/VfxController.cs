using UnityEngine;

public class VfxController : MonoBehaviour
{
    [SerializeField] bool autoDestroy = true;
    [SerializeField] float autoDestroyDelay = 1f;
    [SerializeField] Color effectColor;
    [SerializeField] Vector2 minSpawnXY = new(-0.3f, -0.3f);
    [SerializeField] Vector2 maxSpawnXY = new(0.3f, 0.3f);
    SpriteRenderer spriteRenderer;

    void Start()
    {
        transform.localPosition += new Vector3(Random.Range(minSpawnXY.x, maxSpawnXY.x), Random.Range(minSpawnXY.y, maxSpawnXY.y));
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = effectColor;
        if (autoDestroy)
        {
            Destroy(gameObject, autoDestroyDelay);
        }
    }
}
