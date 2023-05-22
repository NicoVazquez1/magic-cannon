using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Chicken : MonoBehaviour
{
    public BulletModel bullet;

    private void Start()
    {
        StartCoroutine("CountDownToExplode");
        
    }

    void Update()
    {
     
    }

    void OnCollisionEnter(Collision other)
    {
        
    }
   
    IEnumerator CountDownToExplode()
    {
        GameObject e;
        FindObjectOfType<AudioManager>().Play("beep");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("beep");
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("beep");
        yield return new WaitForSeconds(1);        
        
        e = Instantiate(bullet.explotionAnimation) as GameObject;
        e.transform.position = transform.position;
        Destroy(e, 2);
        Vector3 explosionPosition = e.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, bullet.radius);
        FindObjectOfType<AudioManager>().Play("explotion3");
        FindObjectOfType<AudioManager>().Play("explotion1");
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(bullet.power, explosionPosition, bullet.radius, bullet.upForce, ForceMode.Impulse);
                
            }
        }
        
    }
}

