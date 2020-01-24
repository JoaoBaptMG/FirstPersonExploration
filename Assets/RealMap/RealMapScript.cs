// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class RealMapScript : MonoBehaviour
{
    public static bool collected = false;
    public static bool DisplayMap()
    {
        return Time.timeScale == 1 && collected && Input.GetButton("Map");
    }

    public void Awake()
    {
        RaycastHit hitInfo;
        if (GetComponent<Collider>().Raycast(new Ray(transform.position, -Vector3.up), out hitInfo, 500))
        {
            var pos = transform.position;
            pos.y = hitInfo.point.y + 20;
            transform.position = pos;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collected = true;
            Destroy(gameObject);
        }
    }
}