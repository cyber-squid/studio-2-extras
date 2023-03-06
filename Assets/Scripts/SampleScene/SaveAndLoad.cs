using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveAndLoad
{
    static SaveData saveData; // object to hold the data we want saved

    static string filePath = Application.persistentDataPath + "/playersave.dat";
    // persistentDataPath is a directory path Unity has that remains consistent between
    // play sessions and devices, so we don't have to guess where the save file is.


    public static void Save()
    {
        Debug.Log("Current stats: #Jumps - " + PlayerMover.numberOfJumps + ", #Bumps - " + PlayerMover.itemsBumped);

        // we need to open a file stream in order to access data in the file.
        // with the "using" keyword we only temporarily use and open the file stream, and it closes afterward.
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            saveData = new SaveData();
            formatter.Serialize(stream, saveData);
        }
    }

    public static void Load()
    {
        // check if the file exists first before we try to write to it.
        // if it doesn't, return and exit out of the function.
        if (!File.Exists(filePath))
        {
            Debug.LogError("Save file couldn't be found!");
            return;
        }

        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            saveData = (SaveData)formatter.Deserialize(stream); // cast stream data back to the class type, then set the
                                                                // object we have (and its values) to it.

            saveData.FinishLoad();  // sets the variables in game to the data that we've loaded from the file. 
        }
    }

}
