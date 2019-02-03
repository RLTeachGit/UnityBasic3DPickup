using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Trigger class can describe anything with triggers an action
public abstract class Trigger : MonoBehaviour {     //Will only act as base class

    Collider mCollider;     //Cached collider
	// Use this for initialization
    protected virtual void    Start () {        //Allow start to be overriden
		Debug.Assert((mCollider=GetComponent<Collider>())!=null,"Collider Missing");       //Ensure we have at least one collider
        mCollider.isTrigger = true; //turn on trigger in case we forgot
	}
    //Handle trigger enter, redirect to Triggered() which can be overridden
    private void OnTriggerEnter(Collider vCollider) {
        var tEntity = vCollider.gameObject.GetComponent<Entity>();
        if(tEntity!=null) {
            Triggered(tEntity, true);   //Step on
        } else {    //Could be an error as its not handled unless and Enity derived class
            Debug.LogWarningFormat("Non Enity {0:s} on Trigger", vCollider.name);
        }
    }
    //Handle trigger exit, redirect to Triggered() which can be overridden
    private void OnTriggerExit(Collider vCollider) {
        var tEntity = vCollider.gameObject.GetComponent<Entity>();
        if (tEntity != null) {
            Triggered(tEntity, false); //Step off
        } else {
            Debug.LogWarningFormat("Non Enity {0:s} off Trigger", vCollider.name);
        }
    }
    //Default Trigger handler, should be overridden, for pickups & locks
    protected virtual void Triggered(Entity vEntity,bool vSteppedOn) {
        Debug.LogFormat("Default Triggered() handler:{0:s} Entity:{1:s} {2:s}", gameObject.name, vEntity.name, (vSteppedOn) ? "SteppedOn" : "SteppedOff");
    }
}
