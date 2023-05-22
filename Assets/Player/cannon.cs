using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using System.Collections.Generic;

public class cannon : MonoBehaviour
{   
    public Transform muzzle;
    [Range(1000, 4000)] public float forceShooting;
    [SerializeField] public bool readyToShoot, reloading, isDirty;
    [SerializeField] public int current = 0; 
    //public GameObject smallEsplotion;
    // ---------------------------------- from Bullet
    [SerializeField] BulletModel currentBullet;
    [SerializeField] float reloadTime;
    [SerializeField] float spread;
    [SerializeField] int ammo;
    [SerializeField] int rateOfFire;
    [SerializeField] GameObject BulletModel;
    public Animator animator;
    // ---------------------------------- from Bullet

    void Start()
    {
        GetBulletInfo(DataBase.GetCurrentBulletByID(current));
        readyToShoot = true;       
        reloading = false;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {        
        MyInput();        
    }

    void MyInput()
    {
        
        if (Input.GetMouseButtonDown(0) && readyToShoot && !reloading) Shoot();
        
        if (Input.GetKeyDown(KeyCode.E)) // probar con mouse
        {
            current++;
            GetBulletInfo(DataBase.GetCurrentBulletByID(current));
            FindObjectOfType<AudioManager>().Play("bulletChange");
        }
        if (Input.GetKeyDown(KeyCode.Q)) // probar con mouse
        {
            current--;
            GetBulletInfo(DataBase.GetCurrentBulletByID(current));
            FindObjectOfType<AudioManager>().Play("bulletChange");
        }
    }

    // -------------  disparo ---------------------- //
    void Shoot()
    {
        Debug.Log("has shot");
        if (currentBullet.ammo <= 0)
        {
            FindObjectOfType<AudioManager>().Play("noAmmo");
        }
        else
        {
            //Destroy(Instantiate(smallEsplotion, muzzle.position, Quaternion.identity), 1.5f);
            //FindObjectOfType<AudioManager>().Play("shooting1");
            //animator.SetBool("HasShoot", true);
            for (int i = 0; i < rateOfFire; i++)
            {
                float x = Random.Range(-spread, spread);
                float y = Random.Range(-spread, spread);
                GameObject Clone = Instantiate(BulletModel, muzzle.position + new Vector3(x, y), muzzle.rotation);
                Clone.GetComponent<Rigidbody>().AddForce(muzzle.forward * forceShooting);
                DataBase.SubstractAmmo(current);
                Destroy(Clone, 4);
            }
            readyToShoot = false;
            Reload();
        }       
    }

    void Reload()
    {        
        reloading = true;
        //Invoke("TriggerReloadAudio", .8f);
        Invoke("FinishedReload", reloadTime);
    }
    
    void TriggerReloadAudio() => FindObjectOfType<AudioManager>().Play("reload");
    void FinishedReload()
    {
        //animator.SetBool("HasShoot", false);
        Debug.Log("Reloading:" + reloading + " and Ready to shoot: " + readyToShoot);
        reloading = false;
        readyToShoot = true;
    }

    void GetBulletInfo(BulletModel bullet)
    {
        currentBullet = bullet;
        spread = bullet.spread;
        ammo = bullet.ammo;
        rateOfFire = bullet.RateOfFire;
        BulletModel = bullet.model;
        reloadTime = bullet.reloadTime;
    }
}