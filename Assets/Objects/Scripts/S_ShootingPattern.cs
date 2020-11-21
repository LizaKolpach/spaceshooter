using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ShootingPattern : MonoBehaviour
{
    public enum Pattern {SingleForward, MultipleForward, Spray};
    float shootCooldown;
    public float InitialCooldown;
    public GameObject bullet;
    public Pattern ShootingMode;
    
    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = InitialCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        else
        {
            switch (ShootingMode)
            {
                case Pattern.SingleForward:
                    {
                        SingleForward(shootCooldown);
                        break;
                    }
                case Pattern.MultipleForward:
                    {
                        MultipleForward(shootCooldown);
                        break;
                    }
                case Pattern.Spray:
                    {
                        Spray(shootCooldown);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            shootCooldown = InitialCooldown;
        }

    }

    void SingleForward(float cooldown)
    {
        Vector3 gunPosition = gameObject.transform.position - new Vector3(0, 0, -3f);
        
        Instantiate(bullet, gunPosition, Quaternion.identity);
    }

    void MultipleForward(float cooldown)
    {
        Vector3 gunPosition = gameObject.transform.position - new Vector3(0, 0, -3f);
        Instantiate(bullet, gunPosition, Quaternion.identity);
        Instantiate(bullet, gunPosition + new Vector3(2, 0, 0), Quaternion.identity);
        Instantiate(bullet, gunPosition - new Vector3(2, 0, 0), Quaternion.identity);
    }

    void Spray(float cooldown)
    {
        Vector3 gunPosition = gameObject.transform.position - new Vector3(0, 0, +3f);
        Instantiate(bullet, gunPosition, Quaternion.identity);    
        
        GameObject bulletright = Instantiate(bullet, gunPosition + new Vector3(0, 0, 0), Quaternion.identity);
        bulletright.gameObject.GetComponent<S_EnemyBullet>().right = true;
        bulletright.gameObject.GetComponent<S_EnemyBullet>().InitialSpeed /= 3;

        GameObject bulletLeft = Instantiate(bullet, gunPosition - new Vector3(0, 0, 0), Quaternion.identity);
        bulletLeft.gameObject.GetComponent<S_EnemyBullet>().left = true;
        bulletLeft.gameObject.GetComponent<S_EnemyBullet>().InitialSpeed /= 3;
    }

}
