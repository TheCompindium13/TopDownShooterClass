using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementBehaviour : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    private NavMeshPath _navPath;
    [Tooltip("The object the enemy will be seeking towards.")]
    [SerializeField]
    private GameObject _target;
    [Tooltip("The force that will be applied to object to move it.")]
    [SerializeField]
    private float _moveForce;
    [Tooltip("The maximum magnitude this enemy's velocity can have.")]
    [SerializeField]
    private float _maxVelocity;

    public GameObject Target
    {
        get
        {
            return _target;
        }
        set 
        {
            _target = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the attached _navAgent
        _navAgent = GetComponent<NavMeshAgent>();
        _navPath = GetComponent<NavMeshPath>();
    }

    private void FixedUpdate()
    {
        //If a target hasn't been set return
        if (!_target)
            return;
        _navAgent.SetDestination(_target.transform.position);

        //If the velocity goes over the max magnitude, clamp it
        if (_navAgent.velocity.magnitude > _maxVelocity)
            _navAgent.velocity = _navAgent.velocity.normalized * _maxVelocity;
    }
}
