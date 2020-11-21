using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ForwardMovement : MonoBehaviour
{
    public float InitialSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = InitialSpeed * Time.deltaTime;
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
    }
}
