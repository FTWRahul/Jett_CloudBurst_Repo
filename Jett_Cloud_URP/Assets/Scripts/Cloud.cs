using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Cloud : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private bool _hasExpanded;
    private float _burstTimer;
    [SerializeField]private float burstTimerThreshold;

    public bool HasExpanded
    {
        get => _hasExpanded;
        set => _hasExpanded = value;
    }

    public UnityEvent burstEnd;

    public Vector3 movementDirection => _rigidBody.velocity.normalized;
    
    
    public bool CloudGravity
    {
        get => _rigidBody.useGravity;
        set => _rigidBody.useGravity = value;
    }
    
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_hasExpanded)
        {
            return;
        }
        _burstTimer += Time.deltaTime;
        if (_burstTimer > burstTimerThreshold)
        {
            if(burstEnd != null) burstEnd.Invoke();
            //burstEnd?.Invoke();
        }
    }

    public void MoveCloud(Vector3 dir, float force)
    {
        //_rigidBody.AddForce(dir * force);
        _rigidBody.velocity = dir * force;
    }

    private void OnCollisionEnter(Collision other)
    {
        burstEnd?.Invoke();
    }
}
