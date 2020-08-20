using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    public Texture[] InstructionPages;
    public GameObject InstructionPanel;
    private Vector3 instructionPanelInitialPosition;
    private Vector3 instructionPanelInitialScale;
    private int currentPageIndex;
    private int lastPageIndex;
    private Renderer instructionPanelRenderer;

    [SerializeField]
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        instructionPanelInitialPosition = InstructionPanel.transform.localPosition;
        instructionPanelInitialScale = InstructionPanel.transform.localScale;
        lastPageIndex = InstructionPages.Length - 1;
        currentPageIndex = 0;

        uiManager.prevButton.SetActive(false);

        instructionPanelRenderer = InstructionPanel.GetComponent<Renderer>();
        instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];

        updateUIText();
    }

    public void loadNextInstruction()
    {
        if (currentPageIndex != lastPageIndex)
        {
            currentPageIndex++;
            instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];
        }

        updateUIButtons();
    }

    public void loadPreviousInstruction()
    {
        if(currentPageIndex != 0)
        {
            currentPageIndex--;
            instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];
        }

        updateUIButtons();
    }

    private void updateUIButtons()
    {

        if (currentPageIndex == 0)
        {
            uiManager.prevButton.SetActive(false);
        }
        else if (!uiManager.prevButton.activeSelf)
        {
            uiManager.prevButton.SetActive(true);
        }

        if (currentPageIndex == lastPageIndex)
        {
            uiManager.nextButton.SetActive(false);
        }
        else if (!uiManager.nextButton.activeSelf)
        {
            uiManager.nextButton.SetActive(true);
        }

    }

    private void updateUIText()
    {
        uiManager.UpdateStepNumber(currentPageIndex + 1);
    }

    public void resetPosition()
    {
        InstructionPanel.transform.localPosition = instructionPanelInitialPosition;
        InstructionPanel.transform.localScale = instructionPanelInitialScale;
    }
}
