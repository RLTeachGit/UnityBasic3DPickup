using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : Trigger {


    private WaypointFollower mFollower=null; //Link to Follower, set in code by WaypointFollower

    public WaypointFollower Follower {  //Setter for follower
        set {
            Debug.Assert(mFollower!=null,"Trying to reset follower");
            mFollower = value;
        }
        get {
            return mFollower;
        }
    }

    //Also Start() Base class first
    protected override void Start () {
        base.Start();
	}

    protected override void Triggered(Entity vEntity, bool vSteppedOn) {
        Debug.Assert(mFollower != null, "Invalid Follower");

    }
}
