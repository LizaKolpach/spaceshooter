using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    public GameObject Explosion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= -15)
        {
            Destruction();
        }
    }

    public void Destruction()
    {
        Instantiate(Explosion, transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }
}
