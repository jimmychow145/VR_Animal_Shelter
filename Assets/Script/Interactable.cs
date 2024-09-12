using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    public Transform interactionPoint;
    public float interactionPointRadius = 0.5f;
    public LayerMask interactableMask;
    public InteractionPromptUI interactionPromptUI;

    public Collider[] colliders = new Collider[3];
    public int numFound;
    
    public IInteractable interactable;

    // Update is called once per frame
    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);

        if(numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();

            if(interactable != null)
            {
                if(!interactionPromptUI.IsDisplayed)
                {
                    interactionPromptUI.Setup(interactable.InteractionPrompt);
                }
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(this);
                }
            }
        }
        else
        {
            if(interactable != null)
            {
                interactable = null;
            }
            if(interactionPromptUI.IsDisplayed)
            {
                interactionPromptUI.Close(); 
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
