using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))] // Tells unity that this script NEEDS a Camera Component to work
public class RayCaster : MonoBehaviour
{

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast is like a laser pointer

        // Did the uder click on this game tick?
        if (cam != null && Input.GetButtonDown("Fire1"))
        {
            // Shoot a ray into the scene

            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;

            // Draw ray:
            //Debug.DrawRay(ray.origin, ray.direction, Color.black, .5f);

            if (Physics.Raycast(ray, out hit))
            {
                // raycast hit a collider in the scene.

                DoorController door = hit.transform.GetComponentInParent<DoorController>();
                if (door != null)
                {
                    door.PlayerInteract(transform.parent.position);
                }

            }
        }
    }
}
