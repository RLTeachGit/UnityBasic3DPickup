using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : Trigger {


    //Also Start() Base class first
    protected override void Start () {
        base.Start();
	}

    //If this trigger is a Way
    protected override void Triggered(Entity vEntity, bool vSteppedOn) {
        var tWP = vEntity.GetComponent<WaypointFollower>(); //Waypoints only relevant to WaypointFollowers, so find component
        if(tWP!=null) { //Looking up Components at runtime is slow, however this does not happen very often, and its an ellegant way to do this
            tWP.AtWaypoint(this, vSteppedOn);   //Tell WP follower we have arrived
        }
    }
}
