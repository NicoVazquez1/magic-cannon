using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataBase", menuName = "DataBase")]
public class DataBaseModel : ScriptableObject
{
    public List<BulletModel> BulletList;
    public List<ElementsToDestroy> ElementsToDestroyList;

}
