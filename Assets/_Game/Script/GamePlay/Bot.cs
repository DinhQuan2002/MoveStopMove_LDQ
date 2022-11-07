using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    public GameObject targetSprite;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_TARGET))
        {
            targetSprite.SetActive(true);
        }
        else
        {
            targetSprite.SetActive(false);
        }
    }
}
