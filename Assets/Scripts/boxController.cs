using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour
{
    public string selectedBox = "";

    public void SelectBox(string identifier)
    {
        selectedBox = identifier;
        Debug.Log("Currently Selected: " + identifier);
    }

    public void DeselectBox()
    {
        selectedBox = "";
    }
}
