using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject UI;
    public GameObject panel;
    
    public void CloseUI()
    {
        UI.SetActive(false);
        panel.SetActive(true);
    }

}
