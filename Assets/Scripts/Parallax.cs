﻿using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;         // Array (list) of all the back- and foregrounds to be parallaxed
    private float[] parallaxScales;         // The proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1f;            // How smooth the parallax is going to be. Make sure to set this above 0

    public Transform cam;                  // reference to the main cameras transform
    private Vector3 previousCamPos;         // the position of the camera in the previous frame

    // Is called before Start(). Great for references.
    void Awake()
    {
        // set up camera the reference
        //cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start()
    {
        // The previous frame had the current frame's camera position
        previousCamPos = cam.position;

        // asigning coresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallaxX = (previousCamPos.x - cam.position.x) * parallaxScales[i];
           // float parallaxY = (previousCamPos.y - cam.position.y) * parallaxScales[i];
            float backgroundTargetPositionX = backgrounds[i].position.x + parallaxX;
           // float backgroundTargetPositionY = backgrounds[i].position.y + parallaxY;
            Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX,/*ackgroundTargetPositionY*/ backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
        }

            // set the previousCamPos to the camera's position at the end of the frame
            previousCamPos = cam.position;
    }
}
