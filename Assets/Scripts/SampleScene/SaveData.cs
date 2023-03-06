using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/// class that holds data we want to keep between sessions. used by the binary formatter in SaveAndLoad.
public class SaveData
{
    public int numberOfJumps;
    public int itemsBumped;

    public SaveData()
    {
        numberOfJumps = PlayerMover.numberOfJumps;
        itemsBumped = PlayerMover.itemsBumped;
    }

    // called at the end of the load function. sets the variables to the ones loaded from file.
    public void FinishLoad()
    {
        PlayerMover.numberOfJumps = numberOfJumps;
        PlayerMover.itemsBumped = itemsBumped;

        Debug.Log("Current stats: #Jumps - " + PlayerMover.numberOfJumps + ", #Bumps - " + PlayerMover.itemsBumped);
    }
}
