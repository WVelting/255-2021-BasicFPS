using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Transform doorArt;

    private Camera cam;

    private float doorAngle = 0;
    // Start is called before the first frame update

    public float animLength = 0.5f;
    private float animTimer = 0;
    private bool animIsPlaying = false;


    // Update is called once per frame
    void Update()
    {
        

        if (animIsPlaying)
        {
            animTimer += Time.deltaTime;

            float percent = animTimer / animLength;

            if (percent < 0) percent = 0;
            if (percent > 1) percent = 1;

            doorAngle = percent * 90;
            doorArt.localRotation = Quaternion.Euler(0, doorAngle, 0);
        }
        
    }

    public void PlayerInteract()
    {
        animIsPlaying = true;
        animTimer = 0;

    }
}
