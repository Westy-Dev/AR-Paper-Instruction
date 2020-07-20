using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    public Texture[] InstructionPages;
    public GameObject InstructionPanel;
    private int currentPageIndex;
    private int lastPageIndex;
    private Renderer instructionPanelRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lastPageIndex = InstructionPages.Length;
        currentPageIndex = 0;
        instructionPanelRenderer = InstructionPanel.GetComponent<Renderer>();
        instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];
    }

    public void loadNextInstruction()
    {
        if (currentPageIndex != lastPageIndex)
        {
            currentPageIndex++;
            instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];
        }
   
    }

    public void loadPreviousInstruction()
    {
        if(currentPageIndex != 0)
        {
            currentPageIndex--;
            instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];
        }  
    }
}
