using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLoading : MonoBehaviour
{
    public void SaveState()
    {
        SaveAndLoad.Save();
    }

    public void LoadState()
    {
        SaveAndLoad.Load();
    }
}
