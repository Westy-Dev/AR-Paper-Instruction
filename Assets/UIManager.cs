using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public InstructionsManager instructionsManager;

    public void loadNextInstruction()
    {
        instructionsManager.loadNextInstruction();
    }

    public void loadPreviousInstruction()
    {
        instructionsManager.loadPreviousInstruction();
    }
}

