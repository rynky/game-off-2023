using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scaleController : MonoBehaviour
{
    public string identifier;
    private bool isSelected = false;
    public GameObject player;
    private boxController bc;
    
    void Start()
    {
        // Access the player's box controller
        bc = player.GetComponent<boxController>();
    }

    private void OnMouseDown()
    {
        if (!isSelected)
        {
            isSelected = true;
            
            bc.SelectBox(identifier);
        }
        else
        {
            isSelected = false;
            bc.DeselectBox();
        }
    }
}
