﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public TaskController controller = FindObjectOfType<TaskController>();
    public abstract void setupTask();

    public abstract void completeTask();
}

//Task to remove rubbish from main bin into the 3 special bins
public class RubbishTask : Task
{
    public RubbishBin bin;
    private HomeOutDoorBinNPC npc;
    public int rubbishStatus = 0;

    //gets npc to walk to rubbish bin, at which point it will fill the bin
    public override void setupTask()
    {
        npc = FindObjectOfType<HomeOutDoorBinNPC>();
        npc.StartTask(this);
    }

    //get bin to fill with rubbish, and track how much rubbish it has
    public void FillBin() {
        bin = FindObjectOfType<RubbishBin>();
        bin.fillBin();
        rubbishStatus = 3;
    }

    public override void completeTask()
    {
        rubbishStatus--;
        if (rubbishStatus == 0)
        {
            controller.removeTask(TaskTypes.Rubbish);
        }
    }
}

//Task for planting and watering the different seed types
public class SeedTask : Task
{
    private SeedBox seedBox;
    private TaskTypes seedType;
    public SeedTask(SeedBox seedBox, TaskTypes type)
    {
        this.seedBox = seedBox;
        seedType = type;
    }

    public override void setupTask()
    {
        seedBox.fillSeedBox();
    }

    public override void completeTask()
    {
        controller.removeTask(seedType);
    }


}

// Light switch toggle task
public class LightSwitchTask : Task
{
    private ToggleItem lightSwitch;
    private TaskTypes whichSwitch;

    public LightSwitchTask(ToggleItem lightSwitch, TaskTypes whichSwitch)
    {
        this.lightSwitch = lightSwitch;
        this.whichSwitch = whichSwitch;
    }

    public override void setupTask()
    {
        //in future call npc to move here
        lightSwitch.Activate();
    }

    public override void completeTask()
    {
        controller.removeTask(whichSwitch);
    }
}

// Tap toggle task
public class TapTask : Task
{
    private ToggleItem tap;

    public TapTask()
    {
        tap = GameObject.FindGameObjectWithTag("Tap").GetComponent<ToggleItem>();
    }

    public override void setupTask()
    {
        //Call npc to go turn on tap here
        tap.Activate();
    }

    public override void completeTask()
    {
        controller.removeTask(TaskTypes.Tap);
    }
}

// Salad creation task
public class SaladTask : Task
{
    private SaladItem Avocado;
    private SaladItem Tomato;
    private SaladItem Lettuce;

    public SaladTask()
    {
        Avocado = GameObject.FindGameObjectWithTag("Avocado").GetComponent<SaladItem>();
        Tomato = GameObject.FindGameObjectWithTag("Tomato").GetComponent<SaladItem>();
        Lettuce = GameObject.FindGameObjectWithTag("Lettuce").GetComponent<SaladItem>();
    }

    public override void setupTask()
    {
        Avocado.fill();
        Tomato.fill();
        Lettuce.fill();
    }

    public override void completeTask()
    {
        controller.removeTask(TaskTypes.Salad);
    }
}


public class BikeTask : Task
{
    BikeShop bikeShop;
    CityBikeNPC npc;
    CityTaskController taskController;

    public BikeTask(BikeShop bikeShop, CityTaskController controller)
    {
        this.bikeShop = bikeShop;
        taskController = controller;
    }

    public override void setupTask()
    {
        npc = FindObjectOfType<CityBikeNPC>();
        npc.StartTask();
        taskController.readyForBike();
        
        bikeShop.fill();
    }

    public override void completeTask()
    {
        controller.removeTask(TaskTypes.Bike);
    }
}

public class SignTask : Task
{
    ResourceCollector signShop;

    public SignTask(ResourceCollector signShop)
    {
        this.signShop = signShop;
    }

    public override void setupTask()
    {
       signShop.fill();
    }

    public override void completeTask()
    {
        controller.removeTask(TaskTypes.Sign);
    }
}

public class SolarTask : Task
{
    
    ResourceCollector solarShop;

    public SolarTask(ResourceCollector solarShop)
    {
        this.solarShop = solarShop;
    }

    public override void setupTask()
    {
       solarShop.fill();
    }

    public override void completeTask()
    {
        controller.removeTask(TaskTypes.Solar);
    }
}