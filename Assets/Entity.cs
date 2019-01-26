using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public abstract class Entity : MonoBehaviour {      //Base class, used for players and NPCs

    public virtual List<Keys.Type> GetKeys() {     //Offer keys up
        return null;        //No keys
    }


    public virtual void PadTrigger(DoorPad vPad, bool vValidKey) {  //Default if not handled print message
        Debug.LogFormat("Default handler Entity {0:s} on pad {1:s} {2:s}", gameObject.name, vPad.name, (vValidKey) ? "Correct Key" : "Wrong Key");
    }
}
