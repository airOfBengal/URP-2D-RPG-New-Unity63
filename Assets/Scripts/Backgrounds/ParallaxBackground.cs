using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] ParallaxLayer[] parallaxLayers;
    float currentCameraDistanceX;
    float lastCameraDistanceX;

    private void Awake() 
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        currentCameraDistanceX = mainCamera.transform.position.x;
        float distanceToMove = currentCameraDistanceX - lastCameraDistanceX;
        lastCameraDistanceX = currentCameraDistanceX;

        foreach(ParallaxLayer layer in parallaxLayers)
        {
            layer.Move(distanceToMove);
        }
    }
}
