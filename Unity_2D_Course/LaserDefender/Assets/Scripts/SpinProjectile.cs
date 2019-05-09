using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinProjectile : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;

    private void Update() 
    {
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);    
    }
}
