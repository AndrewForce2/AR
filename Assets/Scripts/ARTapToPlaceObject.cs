using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;

    private ARRaycastManager rayManager;

    // Start is called before the first frame update
    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
        placementIndicator = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitpoint, TrackableType.Planes);
        if(hitpoint.Count > 0)
        {
            transform.position = hitpoint[0].pose.position;
            transform.rotation = hitpoint[0].pose.rotation;
            if(!placementIndicator)
            {
                placementIndicator.SetActive(true);
            }
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Instantiate(objectToPlace, transform.position, transform.rotation);
        }
    }

    void UpdatePlacementIndicator()
    {
    
    }
    void UpdatePlacementPose()
    {
        
    }
}
