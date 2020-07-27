﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private InstructionsManager instructionsManager;
    [SerializeField]
    private ARCameraManager arCameraManager;

    [SerializeField]
    private GameObject DebugCanvas;
    private bool debug = false;
    private bool cameraEnabled = true;

    public void loadNextInstruction()
    {
        instructionsManager.loadNextInstruction();
    }

    public void loadPreviousInstruction()
    {
        instructionsManager.loadPreviousInstruction();
    }

    public void toggleDebug()
    {
        debug = !debug;

        DebugCanvas.SetActive(debug);
    }

    public void resetPosition()
    {
        instructionsManager.resetPosition();
    }

    public void disableCamera()
    {
        cameraEnabled = !cameraEnabled;

        arCameraManager.enabled = cameraEnabled;
        Debug.Log("Camera = " + arCameraManager.enabled);
    }
}
