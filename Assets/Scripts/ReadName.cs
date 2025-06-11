using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadName : MonoBehaviour
{
    private string input;

    // Path of the file
    private string path;
    string[] lines;

    void Start()
    {
        CreateFile();
    }

    public void ReadNameInput(string n)
    {
        input = n;   
    }

    void CreateFile()
    {
        path = Application.dataPath + "/Legends.text";

        //Creates the file if it doesn't exist 
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
        
    }

    public void AddNames()
    {
        path = Application.dataPath + "/Legends.text";
        lines = File.ReadAllLines(path);

        if (lines.Length == 5)
        {
            File.WriteAllText(path, "");

            for (int i = 1; i < lines.Length; i++)
            {
                File.AppendAllText(path, lines[i] + "\n");
            }
        } 

        //Adds the name that the player enters to the file.
        File.AppendAllText(path, input + "\n");
    }
}
