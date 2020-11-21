using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMovement : MonoBehaviour    
{
    public float xPosition;
    public float InitialSpeed;
    public float FieldBorders;
    float acceleration;
    public GameObject bulletPrefab;
    Quaternion newRotation = Quaternion.Euler(0, 0, 0);
    public bool canShoot;
    float shootCooldown;
    public float initialShootCooldown;
    public GameObject Explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        xPosition = 0;
        Quaternion newRotation = Quaternion.Euler(0, 0, 0);
        canShoot = true;
        shootCooldown = initialShootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        float MovementSpeed = InitialSpeed * Time.deltaTime;
        Vector3 GunPosition = new Vector3 (transform.position.x, transform.position.y, (transform.position.z + 1f));
        if (Input.GetKey(KeyCode.A))
        {
            acceleration -= MovementSpeed;

            gameObject.transform.rotation = Quaternion.Euler (0, 0, 25);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            acceleration += MovementSpeed;
            gameObject.transform.rotation = gameObject.transform.rotation = Quaternion.Euler(0, 0, -25);
        }
        else
        {
            gameObject.transform.rotation = gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        acceleration *= 0.98f;
        xPosition += acceleration;

        if (xPosition > FieldBorders) xPosition = FieldBorders;
        if (xPosition < (FieldBorders * (-1))) xPosition = FieldBorders*(-1);

        transform.position = new Vector3(xPosition, 0, -5f);

        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            GameObject newBullet = Instantiate(bulletPrefab, GunPosition, newRotation);
            newBullet.GetComponent<S_PlayerBullet>().ParentSpaceship = gameObject; 
            canShoot = false;

        }

        if(canShoot == false)
        {
            shootCooldown -= Time.deltaTime;
            if (shootCooldown <= 0)
            {
                canShoot = true;
                shootCooldown = initialShootCooldown;
            }
        }
    }

    public void Destruction()
    {
        Instantiate(Explosion, transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }

    public void SpecialBullets()
    {
        Vector3 GunPosition = new Vector3(transform.position.x, transform.position.y, (transform.position.z + 1f));
        Instantiate(bulletPrefab, GunPosition, Quaternion.identity);

        GameObject bulletright = Instantiate(bulletPrefab, GunPosition, Quaternion.identity);
        bulletright.gameObject.GetComponent <S_PlayerBullet>().right = true;
        bulletright.gameObject.GetComponent<S_PlayerBullet>().InitialSpeed /= 3;

        GameObject bulletLeft = Instantiate(bulletPrefab, GunPosition, Quaternion.identity);
        bulletLeft.gameObject.GetComponent<S_PlayerBullet>().left = true;
        bulletLeft.gameObject.GetComponent<S_PlayerBullet>().InitialSpeed /= 3;
    }

}
