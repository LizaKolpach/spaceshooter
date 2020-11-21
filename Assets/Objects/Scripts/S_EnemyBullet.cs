using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyBullet : MonoBehaviour
{
    public float bulletspeed;
    public bool right;
    public bool left;

    // Start is called before the first frame update
    void Start()
    {
        //right = false;
        //left = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (right) transform.position = new Vector3(transform.position.x - bulletspeed, 0, transform.position.z - bulletspeed);
        if (left) transform.position = new Vector3(transform.position.x + bulletspeed, 0, transform.position.z - bulletspeed);
        if (!left && !right) transform.position -= new Vector3 (0, 0, bulletspeed);
        if (transform.position.z <= -15)
        {
            Destruction();
        }
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collisionWith = other.gameObject;
        S_PlayerMovement player = collisionWith.GetComponent<S_PlayerMovement>();
        if (player != null)
        {
            player.Destruction();
            Destruction();
        }
        
    }
}
