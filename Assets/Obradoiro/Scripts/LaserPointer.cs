using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [Header("LaserRay")]
    public GameObject rayGameObject;
    public LineRenderer laserBeam;

    [Header("Debug")]
    public GameObject debugBallprefab;
    public bool debug;
    private GameObject debugBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(rayGameObject.transform.position, transform.up, out hit)) {
            if (debug) {
                if (debugBall == null) {
                    debugBall = Instantiate(debugBallprefab);
                }
                debugBall.transform.position = hit.point;
            }

            laserBeam.SetPosition(laserBeam.positionCount-1, transform.InverseTransformPoint(hit.point));
        }
    }

    public void TriggerRay(bool enable)
    {
        rayGameObject.SetActive(enable);
    }
}
