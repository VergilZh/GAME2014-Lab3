using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        _Move();    
        _CheckBounds();
    }

    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed);
    }

    private void _Reset()
    {
        transform.position = new Vector3(0.0f,verticalBoundary);
    }

    private void _CheckBounds()
    {
        if(transform.position.y <= -verticalBoundary)
        {
            _Reset();
        }
    }
}
