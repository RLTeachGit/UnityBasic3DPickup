using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using   UnityStandardAssets.Characters.ThirdPerson;


public class WaypointFollower : Entity {

    ThirdPersonCharacter mCharacter;        //Cached Controllers
    AICharacterControl mAIController;

    [SerializeField]
    List<Waypoint> WaypointList = new List<Waypoint>(); //List of Waypoints in IDE

	// Use this for initialization
	void Start () {
        foreach (var tWP in WaypointList) {
            tWP.Follower = this;        //Link all the waypoints in the list to this follower
        }
        //Get links to controllers, we can do this as they start first
        Debug.Assert((mCharacter = GetComponent<ThirdPersonCharacter>()) != null, "No ThirdPersonCharacter");
        Debug.Assert((mAIController = GetComponent<AICharacterControl>()) != null, "No AICharacterControl");
    }

    public virtual void AtWaypoint(Waypoint vWP) {

    }
}
