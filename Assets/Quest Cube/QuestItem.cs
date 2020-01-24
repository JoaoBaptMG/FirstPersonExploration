// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class QuestItem : MonoBehaviour
{
    public static int total = 0;
    public static int count = 0;
    public static GameObject player;

    public GameObject locator;
    private GameObject loc;

    public void Awake()
    {
        loc = Instantiate(locator, new Vector3(transform.position.x, 500, transform.position.z), Quaternion.identity);

        RaycastHit hitInfo;
        if (GetComponent<Collider>().Raycast(new Ray(transform.position, -Vector3.up), out hitInfo, 500))
        {
            var pos = transform.position;
            pos.y = hitInfo.point.y + 15;
            transform.position = pos;
        }

        total += 1;
    }

    public void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 150);

        GetComponent<Renderer>().enabled = !RealMapScript.DisplayMap();
        GetComponent<Light>().enabled = GetComponent<Renderer>().enabled;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            count += 1;
            Destroy(gameObject);
            Destroy(loc);

            if (count == total) player.AddComponent<ResetScript>();
        }
    }
}