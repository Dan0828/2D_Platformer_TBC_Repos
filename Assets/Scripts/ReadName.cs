using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Reads the name the user enters at the start of the game and inputs it into a file.
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

    /* Called to add the name the player enters to the file. If the file length is 5 meaning if there are 5 names before the new name is added,
     * the name at the first index is removed since that name is the oldest of the 5. It is removed by saving all the lines in the file to an array 
     * then fully clearing the file. Once cleared, the items in the array are reprinted into the file starting at the second index. This removes the name
     * at the first index allowing the new one to be entered. */

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

    // Used to display the name of the current player in the combat scene. The name in the last index will be the name of the current player.
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
