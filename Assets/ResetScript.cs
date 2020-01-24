// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class ResetScript : MonoBehaviour
{
    public void Awake()
    {
        GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0;
    }
    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            QuestItem.count = 0;
            QuestItem.total = 0;
            GetComponent<FirstPersonController>().enabled = true;
            Time.timeScale = 1;
            Destroy(GetComponent<ResetScript>());
            SceneManager.LoadScene(0);
        }
    }
}