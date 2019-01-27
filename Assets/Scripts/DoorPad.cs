using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys {     //Types of key we can use
    public  enum Type {
        NoKey
        ,RedKey
        ,GreenKey
    }
}

public class DoorPad : Trigger {

    AudioSource mAudioClunk;    //Pressure plate also has a sound

    [SerializeField]
    Keys.Type ValidKey = Keys.Type.NoKey;   //Key to unlock

    public Door LinkedDoor;     //Door this Pad Links to 

	// Use this for initialization
	protected override void Start () {
        base.Start();       //Init base class
        Debug.Assert(LinkedDoor != null,"No linked Door");   //Check we are linked to a door
        Debug.Assert((mAudioClunk = GetComponent<AudioSource>()) != null,"No AudioSource");  //Pad activation clunk
	}


    protected override void Triggered(Entity vEntity, bool vSteppedOn) {
        bool tHasCorrectKey = false;    //So we know if its unlocked
        if (ValidKey==Keys.Type.NoKey) {    //Is it the universal key?
            tHasCorrectKey = true;      //If no Key is needed then allow unlock regarless of keys
        } else {
            var tKeys = vEntity.GetKeys();      //get keys from player or null if none
            if(tKeys!=null) {
                foreach( var tKey in tKeys) {   //Check if player offered the right key
                    if(tKey==ValidKey) {
                        tHasCorrectKey = true;  //We have valid unlock
                        break;  //Done, no need to check rest
                    }
                }
            }
        }
        vEntity.OnPadAction(this, tHasCorrectKey);   //Tell player if unlock was a success
        if (tHasCorrectKey) {
            LinkedDoor.Open();      //Tell door to open
            mAudioClunk.Play();     //Sound for Pad activation
        }
    }
}
