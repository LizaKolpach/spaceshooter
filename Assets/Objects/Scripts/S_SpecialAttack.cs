using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpecialAttack : MonoBehaviour
{
    bool canShootSpec;
    public float InitialCooldown;
    float cooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        canShootSpec = true;
        cooldown = InitialCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShootSpec == false)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                canShootSpec = true;
                cooldown = InitialCooldown;
            }
        }
        if (Input.GetKey(KeyCode.Mouse1) && canShootSpec)
        {
            gameObject.GetComponent<S_PlayerMovement>().SpecialBullets();
            canShootSpec = false;
        }

        
    }
}
