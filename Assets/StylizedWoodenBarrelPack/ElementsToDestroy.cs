using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ElementsToDestroy", menuName = "Elements/ElementsToDestroy")]
public class ElementsToDestroy : ScriptableObject
{
    public int ID;
    public new string name;
    public string description;
    public Sprite icon;
    public AudioClip DestructionSound;
    public GameObject model;
    public GameObject DestructionAnimation;
    public ParticleSystem particle;
}
