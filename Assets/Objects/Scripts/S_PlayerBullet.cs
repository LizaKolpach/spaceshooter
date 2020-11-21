using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerBullet : MonoBehaviour
{
    public float InitialSpeed;
    public float killerZ;
    public GameObject ParentSpaceship;
    public bool right;
    public bool left;
    public S_CameraShake CameraShake;



    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        CameraShake = camera.GetComponent<S_CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (transform.position.z > killerZ) Destruction();
    }

    private void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collisionWith = other.gameObject;
        S_Enemy enemy = collisionWith.GetComponent<S_Enemy>();
        if (enemy != null)
        {
            ParentSpaceship.GetComponent<S_PlayerMovement>().score += 100;
            float score = ParentSpaceship.GetComponent<S_PlayerMovement>().score;
            Debug.Log(score);
            enemy.Destruction();
            StartCoroutine(CameraShake.Shake(.2f, .1f));
            Destruction();
        }
        
    }

    void Move()
    {
        float bulletspeed = InitialSpeed * Time.deltaTime;
        if (right) transform.position = new Vector3(transform.position.x - bulletspeed, 0, transform.position.z + bulletspeed);
        if (left) transform.position = new Vector3(transform.position.x + bulletspeed, 0, transform.position.z + bulletspeed);
        if (!left && !right) transform.position += new Vector3(0, 0, bulletspeed);
    }

}
