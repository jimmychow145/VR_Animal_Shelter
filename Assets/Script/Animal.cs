using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour, IInteractable
{
    public string prompt;
    public GameObject uiPanel;

    public string InteractionPrompt => prompt;
    
    public bool Interact (Interactor interactor)
    {
        uiPanel.SetActive(true);
        return true;
    }
}
