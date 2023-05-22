using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Ammo
{
    internal class Bullet : MonoBehaviour
    {
        public BulletModel bullet;
        GameObject explotionParticleEffect;
        public Material FrozeMaterial;

        private void Start()
        {
            explotionParticleEffect = bullet.explotionAnimation;
        }


        private void OnCollisionEnter(Collision collision)
        {
            // Perform raycast to verify accurate collision point
            RaycastForTerrainCollision(collision.contacts[0].point);
        }

        void RaycastForTerrainCollision(Vector3 collisionPoint)
        {
            Vector3 bulletDirection = GetComponent<Rigidbody>().velocity.normalized;
            RaycastHit hit;

            if (Physics.Raycast(collisionPoint, bulletDirection, out hit))
            {
                // Adjust bullet's position to the point of intersection
                transform.position = hit.point;
                // Handle collision with the terrain (e.g., apply damage, play effects, etc.)
                HandleTerrainCollision(hit);
            }
            else
            {
                StartExplosionAnimation();
            }
        }

        void HandleTerrainCollision(RaycastHit hit)
        {
            // Add logic to handle the collision with the terrain
            // You can apply damage, play effects, instantiate objects, etc.
            // Example:
            // Instantiate explosion particle effect at the hit point
            GameObject explosionInstance = Instantiate(explotionParticleEffect, hit.point, Quaternion.identity);
            Destroy(explosionInstance, 2f);
            Destroy(gameObject);
        }

        void StartExplosionAnimation()
        {
            Destroy(this.gameObject, 0.1f);
            explotionParticleEffect.transform.position = this.transform.position;
            GameObject explotionInstance = Instantiate(explotionParticleEffect) as GameObject;
            Destroy(explotionInstance, 1.5f);
            StartExplosionBodyEffect();
        }

        public void StartExplosionBodyEffect()
        {
            int timesHit = 0;
            Vector3 explosionPosition = explotionParticleEffect.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPosition, bullet.radius);

            if (bullet.name == "Bullet")
            {
                foreach (Collider hit in colliders)
                {
                    if (hit.CompareTag("target"))
                    {
                        Destroy(hit.gameObject);
                    }
                }
            }
            else if(bullet.name == "Shotgun")
            {
                foreach (Collider hit in colliders)
                {
                    
                    if (hit.CompareTag("target"))
                    {
                        Debug.Log("Veces hit:" + timesHit);
                        Destroy(hit.gameObject);
                    }
                }
            }
            else if (bullet.name == "Bomb")
            {
                
                foreach (Collider hit in colliders)
                {

                    if (hit.CompareTag("target"))
                    {
                        hit.gameObject.GetComponent<BarrelBehaviour>().speed = 0.1f;
                        hit.gameObject.GetComponent<MeshRenderer>().material = FrozeMaterial;
                    }
                }
            }
            else
            {
                Debug.Log("Nothing hit?");
            }

        }

    }
}
