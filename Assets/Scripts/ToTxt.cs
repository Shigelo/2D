using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ToTxt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Create a StreamWriter instance
        StreamWriter writer = new 
        StreamWriter(Application.persistentDataPath + "/texto.txt");

        // This using statement will ensure the writer will be closed when no longer used   
        using(writer)   
        {
            // Loop through the numbers from 1 to 20 and write them
            for (int i = 1; i <= 20; i++)
            {
                writer.WriteLine(i);
            }
        } 
    }

   
}
