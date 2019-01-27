using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    Animator mAnimator; //Cached Animator


    // Use this for initialization
    void Start () {
        Debug.Assert((mAnimator = GetComponent<Animator>()) != null);   //Grab animator and store
    }


    public  void    Open() {
        mAnimator.SetTrigger("DoOpen"); //Play open animation
    }
}
