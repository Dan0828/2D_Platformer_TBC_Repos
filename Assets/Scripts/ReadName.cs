using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadName : MonoBehaviour
{
    private string name;

    // Path of the file
    private string path;
    string[] lines;

    void Start()
    {
        CreateFile();
    }

    public void ReadNameInput(string n)
    {
        name = n;
    }

    void CreateFile()
    {
        path = Application.dataPath + "/PreviousPlayers.text";

        //Creates the file if it doesn't exist 
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
        
    }

    public void AddNames()
    {
        path = Application.dataPath + "/PreviousPlayers.text";
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
        File.AppendAllText(path, name + "\n");
    }

    public string LoadLastName()
    {
        path = Application.dataPath + "/PreviousPlayers.text";

        lines = File.ReadAllLines(path);
        if (lines.Length == 0)
        {
            return null;
        }

        return lines[lines.Length - 1];

    }

}
