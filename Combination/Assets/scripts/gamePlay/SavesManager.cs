using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    public readonly string DIFFICULITY_KEY = "difficulty";

    public void SaveDifficulty(string difficulty){
        PlayerPrefs.SetString(DIFFICULITY_KEY, difficulty);
    }

    public string LoadDifficulty(){
        return PlayerPrefs.GetString(DIFFICULITY_KEY);       
    }
}
