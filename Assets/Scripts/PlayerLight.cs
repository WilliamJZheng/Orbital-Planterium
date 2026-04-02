using UnityEngine;
using UnityEngine.Rendering.Universal; // Required for Light2D

public class PlayerLight : MonoBehaviour
{
    public Light2D myLight; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}