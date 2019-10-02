﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBin : InteractableObjectBase
{
    public bool hasRubbish = true;
    public int rubbishLevel = 3;

    public override ItemTypes OnInteract()
    {
        rubbishLevel--;
        Debug.Log("lowering rubbish level: " + rubbishLevel);
        if(rubbishLevel == 0)
        {
            hasRubbish = false;
        }

        // Randomly decide on rubbish type
        int rand = Random.Range(1,3);
        if(rand == 0)
        {
            return ItemTypes.RubbishBag;
        }
        else if(rand == 1)
        {
            return ItemTypes.Recyclables;
        }
        else
        {
            return ItemTypes.BananaSkin;
        }
        
    }

    public override bool CanInteract(ItemTypes heldItem)
    {   
        if(heldItem == ItemTypes.NONE && hasRubbish)
        {
            InteractText = "Press J to collect rubbish";
            return true;
        }
        return false;
    }

    public void fillBin()
    {
        rubbishLevel = 3;
        hasRubbish = true;
    }
}
