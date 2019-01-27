using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using   UnityStandardAssets.Characters.ThirdPerson;


public class WaypointFollower : Entity {

    ThirdPersonCharacter mCharacter;        //Cached Controllers
    AICharacterControl mAIController;

    [Header("Set Options Here")]
    [Tooltip("Include waypoints in patrol order")]
    [SerializeField]
    List<Waypoint> WaypointList = new List<Waypoint>(); //List of Waypoints in IDE

    int mWaypointIndex = -1;    //Makes sure first one works

    MindReader mMindReader = null;  //Not set

    //Lazily initalised setter, get component on first demand
    string  SetDebugText {
        set {
                if(mMindReader == null) {       //Lazy initialisation
                    mMindReader = GetComponent<MindReader>();
                }
                Debug.Assert(mMindReader != null, "No Mindreader attached");
            if(mMindReader!=null) {
                mMindReader.Text = value;
            }
        }
    }

    // Use this for initialization
    void Start () {
        //Get links to controllers, we can do this as they start first
        Debug.Assert((mCharacter = GetComponent<ThirdPersonCharacter>()) != null, "No ThirdPersonCharacter");
        Debug.Assert((mAIController = GetComponent<AICharacterControl>()) != null, "No AICharacterControl");
        Debug.Assert(WaypointList.Count >= 0, "No Waypoints");  //Not much use havogn a follower without Waypoints
        NextWaypoint();     //Works as its -1 to start with
    }

    void    NextWaypoint() {
        mWaypointIndex++;
        if (mWaypointIndex >= WaypointList.Count) mWaypointIndex = 0;       //Loop list if at the end
        SetDebugText = string.Format("Off to WP:{0:d}", mWaypointIndex);
        mAIController.target = WaypointList[mWaypointIndex].transform;      //Set new waypoint
    }

    public virtual void AtWaypoint(Waypoint vWP, bool vSteppedOn) {
        if (WaypointList[mWaypointIndex]==vWP) {    //Have we arrived at designated waypoint
            NextWaypoint();
        } else {
            Debug.Log("WP not next in sequence");
        }
    }
}
