using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBurst : MonoBehaviour
{
    private InputHandler _inputHandler;
    private Camera _fpsCam;
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float launchForce;
    private Cloud _currentCloud;
    private bool _abilityInUse = false;
    void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        _fpsCam = GetComponentInChildren<Camera>();
        _inputHandler.abilityDelegate += ThrowCloud;
    }

    private void ThrowCloud(bool pressed, bool held, bool released)
    {
        if (_abilityInUse && held)
        {
            SwingCloud();
            return;
        }
        if (released && _currentCloud != null)
        {
            _abilityInUse = false;
            _currentCloud.CloudGravity = true;
            return;
        }
        if(!pressed) return;
        _abilityInUse = true;
        _currentCloud = Instantiate(cloudPrefab, spawnPosition.position, Quaternion.identity).GetComponent<Cloud>();
        _currentCloud.MoveCloud(_fpsCam.transform.forward.normalized, launchForce);
        _currentCloud.burstEnd.AddListener(ResetCloud);
    }

    private void ResetCloud()
    {
        _currentCloud.burstEnd.RemoveListener(ResetCloud);
        _currentCloud = null;
        _abilityInUse = false;
    }

    private void SwingCloud()
    {
        _currentCloud.MoveCloud(_fpsCam.transform.forward.normalized, launchForce);
    }
}
