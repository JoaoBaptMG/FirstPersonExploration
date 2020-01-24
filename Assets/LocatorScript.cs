// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class LocatorScript : MonoBehaviour
{
    public Transform player;

    public void Update()
    {
        var pos = player.position;
        pos.y = 600;
        transform.position = pos;
        GetComponent<Renderer>().enabled = RealMapScript.DisplayMap();
    }
}