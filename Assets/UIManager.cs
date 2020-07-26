using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private InstructionsManager instructionsManager;

    [SerializeField]
    private GameObject DebugCanvas;
    private bool debug = false;

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
}

