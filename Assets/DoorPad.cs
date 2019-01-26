using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys {
    public  enum Type {
        NoKey
        ,RedKey
        ,GreenKey
    }
}

public class DoorPad : MonoBehaviour {

    AudioSource mAudioClunk;

    [SerializeField]
    Keys.Type ValidKey = Keys.Type.NoKey;

    public Door LinkedDoor;     //Door this Pad Links to 

	// Use this for initialization
	void Start () {
        Debug.Assert(LinkedDoor != null);   //Check we are linked to a door
        Debug.Assert((mAudioClunk = GetComponent<AudioSource>()) != null);  //Pad activation clunk
	}


    private void OnTriggerEnter(Collider vOther) {
        Entity tEntity = vOther.GetComponent<Entity>(); //Get entity which stepped on pad
        if(tEntity!=null) {     //Only allow Entities to trigger doors
            bool tHasCorrectKey = false;    //So we know if its unlocked
            if (ValidKey==Keys.Type.NoKey) {
                tHasCorrectKey = true;      //If no Key is needed then allow unlock regarless of keys
            } else {
                var tKeys = tEntity.GetKeys();      //get keys from player or null if none
                if(tKeys!=null) {
                    foreach( var tKey in tKeys) {   //Check if player offered the right key
                        if(tKey==ValidKey) {
                            tHasCorrectKey = true;  //We have valid unlock
                            break;  //Done, no need to check rest
                        }
                    }
                }
            }
            tEntity.PadTrigger(this, tHasCorrectKey);   //Tell player if unlock was a success
            if (tHasCorrectKey) {
                LinkedDoor.Open();  //Tell door to open
                mAudioClunk.Play();     //Sound for Pad activation
            }
        }
    }
}
