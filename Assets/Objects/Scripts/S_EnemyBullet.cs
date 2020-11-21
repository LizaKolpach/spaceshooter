using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyBullet : MonoBehaviour
{
    public float InitialSpeed;
    public bool right;
    public bool left;
    public S_CameraShake CameraShake;

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        CameraShake = camera.GetComponent<S_CameraShake>(); 

        //right = false;
        //left = false;
    }

    // Update is called once per frame
    void Update()
    {
        float bulletspeed = InitialSpeed * Time.deltaTime;
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
            StartCoroutine(CameraShake.Shake(1f, 1f));
            Destruction();
        }
        
    }
}
