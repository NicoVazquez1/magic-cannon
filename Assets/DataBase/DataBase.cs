using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataBase : MonoBehaviour
{
    public DataBaseModel dataBase; // ScriptableObject

    // --------------------  Singleton
    private static DataBase Instances;
    private void Awake()
    {
        if (Instances == null){
            Instances = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    // --------------------  Singleton


    public static BulletModel GetCurrentBulletByID(int id) => Instances.dataBase.BulletList.FirstOrDefault((i) => i.ID == id);
    public static int AddBullet(int id, int ammo) => Instances.dataBase.BulletList.FirstOrDefault((i) => i.ID == id).ammo + ammo;
    public static int SubstractAmmo(int id) => Instances.dataBase.BulletList.FirstOrDefault((i) => i.ID == id).ammo--;
    public static ElementsToDestroy GetElementsToDestroysById(int id) => Instances.dataBase.ElementsToDestroyList.FirstOrDefault(i => i.ID == id); //null
    public static ElementsToDestroy GetElementsToDestroysByName(string name) => Instances.dataBase.ElementsToDestroyList.FirstOrDefault(i => i.name == name);

    private void Start()
    {
        foreach (BulletModel bullet in Instances.dataBase.BulletList) //null
        {
            bullet.ammo = bullet.defaultAmmo;
        }
    }

      

}
