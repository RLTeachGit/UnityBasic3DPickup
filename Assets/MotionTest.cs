using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//https://tinyurl.com/ydhkce8d


using UnityStandardAssets.Characters.ThirdPerson;

public class MotionTest : MonoBehaviour {


    [SerializeField]
    Transform[] Waypoints;


    AICharacterControl mController;
    NavMeshAgent mAgent;

    int mIndex = -1;

	// Use this for initialization
	void Start () {
        Debug.Assert(Waypoints != null & Waypoints.Length > 0, "No Waypoints");
        Debug.Assert((mController = GetComponent<AICharacterControl>())!=null,"No AI Controller");
        Debug.Assert((mAgent = GetComponent<NavMeshAgent>()) != null,"No NavAgent");
        mAgent.destination = NextWaypoint().position;
	}

    Transform    NextWaypoint() {
        if(++mIndex>= Waypoints.Length) {
            mIndex = 0;
        }
        return Waypoints[mIndex];
    }

    // Update is called once per frame
    void Update () {
        if(mAgent.remainingDistance<2.0f) {
            mController.target = NextWaypoint();
        }
    }
}
