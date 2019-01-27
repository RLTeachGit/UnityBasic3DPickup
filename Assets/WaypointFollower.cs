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
        Debug.Assert(WaypointList.Count >= 0, "No Waypoints");  //Not much use havogn a follower without Waypoints
        mAIController.target = WaypointList[0].transform;      //Set first waypoint
    }

    public virtual void AtWaypoint(Waypoint vWP, bool vSteppedOn) {
        int tWaypointIndex = WaypointList.FindIndex(tWP => tWP == vWP); //Find the index of the Wp we just reached
        if(tWaypointIndex>=0) {
            tWaypointIndex++;
            if (tWaypointIndex >= WaypointList.Count) tWaypointIndex = 0;       //Loop list if at the end
            mAIController.target = WaypointList[tWaypointIndex].transform;      //Set new waypoint
        } else {
            Debug.Log("WP not found in list");
        }
    }
}
