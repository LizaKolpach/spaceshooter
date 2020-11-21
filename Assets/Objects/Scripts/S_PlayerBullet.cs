using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerBullet : MonoBehaviour
{
    public float InitialSpeed;
    public float killerZ;
    public GameObject ParentSpaceship;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = InitialSpeed * Time.deltaTime; 
        transform.position += new Vector3(0, 0, speed);

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
            
            enemy.Destruction();
            Destruction();
        }
        
    }

}
