using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boxController : MonoBehaviour
{
    public GameObject self;
    public string identifier;
    public GameObject player;

    private Vector3 currentSize;
    [SerializeField] private Vector3 maxSize;
    [SerializeField] private Vector3 minSize;
    private float growthFactor;

    public bool isSelected = false;

    private void Start()
    {
        growthFactor = player.GetComponent<playerController>().scaleFactor;
    }

    private void Update()
    {
        currentSize = transform.localScale;

        // Check if the object can be upscaled
        if (currentSize.x < maxSize.x && currentSize.y < maxSize.y)
        {
            if (isSelected && Input.GetKey(KeyCode.E))
            {
                transform.localScale += new Vector3(0.01f * growthFactor, 0.01f * growthFactor, 0);
            }
        }

        // Check if the object can be downscaled
        if (currentSize.x > minSize.x && currentSize.y > minSize.y)
        {
            if (isSelected && Input.GetKey(KeyCode.Q))
            {
                transform.localScale -= new Vector3(0.01f * growthFactor, 0.01f * growthFactor, 0);
            }
        }
        
    }

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
