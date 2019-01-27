using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script to add debug into on top of any gameobject, also track camera for easy reading

public class MindReader : MonoBehaviour {

    [Header("Set Options Here")]
    [SerializeField]
    [Tooltip("Set to have Debug Text face main camera")]
    bool TrackMainCamera =true;

    Text mText;

    Camera mCamera;

    GameObject mDebugCanvasGO;

    // Make World space UP and up it above character, to display their "thoughts"
    void Start () {

        if (TrackMainCamera) {
            Debug.Assert((mCamera = Camera.main) != null, "No main Camera");
        }

        mDebugCanvasGO = new GameObject("DebugCanvas");     //Make a Canvas in code
        var mDebugTextGO = new GameObject("DebugText");         //Make UI Text in space
        mDebugCanvasGO.transform.SetParent(transform);
        mDebugTextGO.transform.SetParent(mDebugCanvasGO.transform);

        var tCanvas = mDebugCanvasGO.AddComponent<Canvas>();        //Make a Canvas in code and add text
        var tScaler = mDebugCanvasGO.AddComponent<CanvasScaler>();
        tCanvas.renderMode = RenderMode.WorldSpace;
        var tCanvasRT = mDebugCanvasGO.GetComponent<RectTransform>();
        tCanvasRT.sizeDelta = new Vector2(256, 128);            //Make Text fill Canvas
        tCanvasRT.localScale = new Vector3(0.01f, 0.01f, 1);
        tCanvasRT.localPosition = Vector3.up*2;         //Move Canvas up a bit

        mText = mDebugTextGO.AddComponent<Text>();
        var tTextRT = mDebugTextGO.GetComponent<RectTransform>();
        mText.fontSize = 30;
        tTextRT.offsetMax = Vector2.zero;           //Strech text into Canvas and center top
        tTextRT.offsetMin = Vector2.zero;
        tTextRT.anchorMin = new Vector2(0, 0);
        tTextRT.anchorMax = new Vector2(1, 1);

        mText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");   //Default font
        mText.alignment = TextAnchor.UpperCenter;
        Text = "Debug";

	}


    //Allow Colour be set
    public  Color   Colour {
        set {
            mText.color = value;
        }
        get {
            return mText.color;
        }
    }

    //Allow text be set
    public string  Text {  //Set Debug text
        set {
            if(mText!=null) {
                mText.text = value;
            }
        }
        get {
            if (mText != null) {
                return mText.text;
            }
            return "NotSet";
        }
    }


    //Aim world canvas at main Camera
    private void LateUpdate() {
        if(TrackMainCamera && mCamera!=null) {
            mDebugCanvasGO.transform.LookAt(mDebugCanvasGO.transform.position + mCamera.transform.rotation * Vector3.forward, mCamera.transform.rotation * Vector3.up);
        }
    }
}
