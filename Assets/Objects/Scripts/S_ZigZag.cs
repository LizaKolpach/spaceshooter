using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ZigZag : MonoBehaviour
{
    public float amplitude;
    public Vector3 speed;
    Vector3 InitialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float subtraction = Mathf.Abs(gameObject.transform.position.x - InitialPosition.x);
        
        if (subtraction < amplitude)
        {
            gameObject.transform.position = new Vector3(transform.position.x + speed.x, transform.position.y, transform.position.z - speed.z);
        }
        else
        {
            speed.x *= -1;
            InitialPosition = gameObject.transform.position;
        }
            
    }
}
