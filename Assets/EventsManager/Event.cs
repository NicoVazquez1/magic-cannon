using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scrips.EventsManager
{
    internal class Event
    {
        /*private delegate void ObjectDestructionHandler();
        private event ObjectDestructionHandler Destructed;*/

        public event Action _Action;

        public void Invoke()
        {
            _Action?.Invoke();
        }

        public void AddListener(Action Listener)
        {
            _Action += Listener;
        }

        public void RemoveListener(Action Listener)
        {
            _Action -= Listener;
        }

    }
}
