using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bullet", menuName = "Elements/bullet")]
public class BulletModel : ScriptableObject
{
    public int ID;
    public new string name;
    public int ammo;
    public int defaultAmmo;
    public float power;
    public float radius;
    public float upForce;   
    public int RateOfFire;
    public float spread;
    public float reloadTime;
    public Sprite icon;
    public AudioClip shootingSound;
    public GameObject explotionAnimation;
    public AudioClip explotionSound;
    public GameObject model;
}
