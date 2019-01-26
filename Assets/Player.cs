using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    [SerializeField]
    List<Keys.Type> MyKeys=new List<Keys.Type>();

    private void Start() {
        MyKeys.Add(Keys.Type.RedKey);   //Give player Red Key
    }

    //Called from Pad with Unlock date
    public override void PadTrigger(DoorPad vPad, bool vValidKey) {
        //Don't call base class, as it just prints debug if not handled
        Debug.LogFormat("Player {0:s} on pad {1:s} {2:s}", gameObject.name, vPad.name, (vValidKey)? "Correct Key" : "Wrong Key");
    }

    public override List<Keys.Type>  GetKeys() {     //Offer player keys up, called from Pad
        return MyKeys;
    }
}
