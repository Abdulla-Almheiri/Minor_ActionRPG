using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirectionScript : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed = 1f;
    public float RotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(Direction*Speed*Time.deltaTime);
        gameObject.transform.Rotate(Direction*Time.deltaTime*RotationSpeed*50);
    }
}
