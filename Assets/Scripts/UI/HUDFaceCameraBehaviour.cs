using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDFaceCameraBehaviour : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        Transform cam = Camera.main.transform;
        //Vector3 directionFromCamera = transform.position - cam.position;
        transform.LookAt(transform.position + cam.forward);
    }
}
