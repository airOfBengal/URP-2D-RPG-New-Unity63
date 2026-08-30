using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{
    [SerializeField] Transform layer;
    [SerializeField] float speed;


    public void Move(float distanceToMove)
    {
        layer.position += distanceToMove * speed * layer.right;
    }
}
