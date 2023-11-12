using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boxController : MonoBehaviour
{
    public GameObject self;
    public string identifier;
    public GameObject player;

    public bool isSelected = false;

    private void OnMouseDown()
    {
        // Access the player controller to select THIS object
        player.GetComponent<playerController>().SelectBox(
            self.GetComponent<boxController>()
        );
    }

    public void Scale(bool isScaling)
    {
        isSelected = isScaling;
        if ( isSelected )
        {
            Debug.Log("Currently Scaling " + identifier);
        }
        else
        {
            Debug.Log("No Longer Scaling " + identifier);
        }
    }
}
