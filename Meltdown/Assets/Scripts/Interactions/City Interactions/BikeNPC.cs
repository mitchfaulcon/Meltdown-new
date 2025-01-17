﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeNPC : InteractableObjectBase
{
    public CityTaskController taskController;
    CityBikeNPC npc;

    public CityScoreController scoring;

    public override bool CanInteract(ItemTypes item)
    {
        if(item == ItemTypes.Bike)
        {
            return true;
        }
        return false;
    }

    public override ItemTypes OnInteract()
    {
        //get NPC to change course and leave off screen
        //Complete Bike task
        npc = this.GetComponent<CityBikeNPC>();
        npc.GiveBike();
        CompleteTask();
        PlayInteractSound();

        //Decrease score & display popup
        scoring.taskScored(CityScoreController.Tasks.BIKE);

        return ItemTypes.NONE;
    }

    public void CompleteTask() {
        taskController.taskComplete(TaskTypes.Bike);
    }

    public void FailTask() {
        taskController.removeTask(TaskTypes.Bike);
        scoring.taskFailed(CityScoreController.Tasks.BIKE_FAILED, transform);
    }

    public void setBikeStatus()
    {
        taskController.readyForBike();
    }
}
