using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField, Tooltip("The Target")]
    private Transform _target;
    [SerializeField, Tooltip("The Offset")]
    private Vector3 _offset;
    [SerializeField]
    private float _smoothTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _offset = _target.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, _target.position - _offset, ref velocity, _smoothTime);
    }
}
