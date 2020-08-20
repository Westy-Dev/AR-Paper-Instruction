using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private InstructionsManager instructionsManager;

    [SerializeField]
    private GameObject debugCanvas;

    [SerializeField]
    private GameObject instructionBackground;

    [SerializeField]
    private Text StepNumber;

    [SerializeField]
    private Button backgroundButton;
    [SerializeField]
    private Button debugButton;

    public GameObject prevButton;

    public GameObject nextButton;

    private bool debug = false;
    private bool showInstructionBackground = false;
    private Color32 toggleColor = new Color32(159, 159, 159, 255);
    private Color defaultColor = Color.white;

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

        debugCanvas.SetActive(debug);

        if (debug)
        {
            debugButton.image.color = toggleColor;
        }
        else
        {
            debugButton.image.color = defaultColor;
        }
    }

    public void toggleInstructionBackground()
    {
        showInstructionBackground = !showInstructionBackground;

        instructionBackground.SetActive(showInstructionBackground);

        if (showInstructionBackground)
        {
            backgroundButton.image.color = toggleColor;
        }
        else
        {
            backgroundButton.image.color = defaultColor;
        }
    }

    public void resetPosition()
    {
        instructionsManager.resetPosition();
    }

    public void UpdateStepNumber(int stepNumber)
    {
        StepNumber.text = "Step Number: " + stepNumber;
    }
}

