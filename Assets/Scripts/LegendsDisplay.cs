using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class LegendsDisplay : MonoBehaviour
{
    public TextMeshProUGUI legends;
    private string path;
    string[] lines;

    private void Start()
    {
        displayLegends();
    }
    void displayLegends()
    {
        path = Application.dataPath + "/Legends.text";

        lines = File.ReadAllLines(path);

        for (int i = lines.Length - 1; i >= 0; i--)
        {
            legends.text += lines[i] + "\n";
        }
    }
}
