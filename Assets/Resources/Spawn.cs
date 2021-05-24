using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.WSA.Input;
public class Spawn : MonoBehaviour
{
    public GameObject prefabCube;
    public Transform spawnSpot;

    GestureRecognizer gest;
    // Start is called before the first frame update
    void Start()
    {
        gest = new GestureRecognizer ();

        gest.Tapped += Gest_Tapped;

        gest.StopCapturingGestures();
    }

    void Gest_Tapped (TappedEventArgs obj)
    {
        Instantiate(prefabCube, spawnSpot.position, spawnSpot.rotation);
    }
}
