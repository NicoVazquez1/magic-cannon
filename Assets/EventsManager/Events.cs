using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EventsManager
{
     class Events : MonoBehaviour
     {

        public static Events current;

        private void Awake()
        {
            current = this;
        }

        //Study DataStructure

        public static readonly Event OnBulletDestroying = new Event();
        public static readonly Event OnChickenBulletTouching = new Event();

        public void GetEventName(string name)
        {
            
        }
     }
}
