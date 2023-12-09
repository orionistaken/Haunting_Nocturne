using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingAnimation : MonoBehaviour
{
    public float fequency;
    public float magnitude;
    public Vector3 direction;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position = initialPosition + direction * Mathf.Sin(Time.time*fequency)*magnitude;
    }
}
