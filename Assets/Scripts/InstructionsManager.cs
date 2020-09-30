//Created By Ben Westcott, 2020
using UnityEngine;
/// <summary>
/// Manages the display and positioning and scale of the <c>InstructionPanel</c> and 
/// the display of <c>InstructionPages</c> textures
/// </summary>
public class InstructionsManager : MonoBehaviour
{
    [Tooltip("Images in PNG Format for each instruction page")]
    // Instruction textures for instruction panel
    public Texture[] InstructionPages;

    [Tooltip("The GameObject to texture instructions onto")]
    // GameObject which represents the instructions in the AR space
    public GameObject InstructionPanel;

    private Vector3 instructionPanelInitialPosition;
    private Vector3 instructionPanelInitialScale;
    private int currentPageIndex;
    private int lastPageIndex;
    private Renderer instructionPanelRenderer;

    // Manages the interface elements
    [SerializeField]
    private UIManager uiManager;

    /// <summary>
    /// Start is called before the first frame update.
    /// Sets the initial values
    /// </summary>
    void Start()
    {
        //Save the initial position and scale for the reset function
        instructionPanelInitialPosition = InstructionPanel.transform.localPosition;
        instructionPanelInitialScale = InstructionPanel.transform.localScale;
        
        //Initialise last and current index
        lastPageIndex = InstructionPages.Length - 1;
        currentPageIndex = 0;

        //Hide previous button on UI
        uiManager.prevButton.SetActive(false);

        //Apply the first instruction page texture to the texture panel
        instructionPanelRenderer = InstructionPanel.GetComponent<Renderer>();
        instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];

        updateStepNumber();
    }

    /// <summary>
    /// Loads the next instruction texture from <c>InstructionPages</c> 
    /// and applies it to the <c>InstructionPanel</c>
    /// </summary>
    public void loadNextInstruction()
    {
        if (currentPageIndex != lastPageIndex)
        {
            currentPageIndex++;
            instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];
        }

        updateUIButtons();
        updateStepNumber();
    }

    /// <summary>
    /// Loads the previous instruction texture from <c>InstructionPages</c> and applies it to the <c>InstructionPanel</c>
    /// </summary>
    public void loadPreviousInstruction()
    {
        if(currentPageIndex != 0)
        {
            currentPageIndex--;
            instructionPanelRenderer.material.mainTexture = InstructionPages[currentPageIndex];
        }

        updateUIButtons();
        updateStepNumber();
    }

    /// <summary>
    /// Controls the visibility of the previous and next buttons on the UI
    /// </summary>
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

    /// <summary>
    /// Updates the step number on the UI
    /// </summary>
    private void updateStepNumber()
    {
        uiManager.UpdateStepNumber(currentPageIndex + 1);
    }

    /// <summary>
    /// Resets the position and scale of the AR instructions using <c>instructionPanelInitialPosition</c> and <c>instructionPanelInitialScale</c>
    /// </summary>
    public void resetPosition()
    {
        InstructionPanel.transform.localPosition = instructionPanelInitialPosition;
        InstructionPanel.transform.localScale = instructionPanelInitialScale;
    }
}
