using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private InstructionsManager instructionsManager;

    [SerializeField]
    private GameObject DebugCanvas;

    [SerializeField]
    private GameObject instructionBackground;

    private bool debug = false;
    private bool showInstructionBackground = true;

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

    public void toggleInstructionBackground()
    {
        showInstructionBackground = !showInstructionBackground;

        instructionBackground.SetActive(showInstructionBackground);
    }

    public void resetPosition()
    {
        instructionsManager.resetPosition();
    }
}

