// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Report : MonoBehaviour
{
    private Texture2D bluish;
    private GUIStyle style;

    public void Awake()
    {
        QuestItem.player = gameObject;

        bluish = new Texture2D(1, 1);
        bluish.SetPixel(0, 0, new Color(.1f, .1f, .1f, .8f));
        bluish.Apply();

        style = new GUIStyle();
        style.normal.background = bluish;
    }

    public void Update()
    {
        if (Time.timeScale == 1 && Input.GetButtonDown("Pause"))
            gameObject.AddComponent<PauseScript>();
    }

    void OnGUI()
    {
        if (!RealMapScript.DisplayMap())
        {

            int width = 160;
            int height = 40;

            if (RealMapScript.collected)
            {
                if (width < 275) width = 275;
                height += 20;
            }
            if (HighJumpScript.collected)
            {
                if (width < 320) width = 320;
                height += 20;
            }
            if (CubeMapScript.collected)
            {
                if (width < 345) width = 345;
                height += 20;
            }
            if (QuestItem.count == QuestItem.total)
            {
                if (width < 335) width = 335;
                height = 120;
            }

            GUI.Box(new Rect(10, 10, width, height), "", style);
            GUI.BeginGroup(new Rect(20, 10, 500, 150));

            if (QuestItem.count == QuestItem.total)
            {
                GUI.color = Color.green;
                GUI.Label(new Rect(0, 100, 500, 30), "All cubes collected!!! Press SPACE to reset the game!");
            }
            GUI.Label(new Rect(0, 20, 500, 30), "Collected cubes: " + QuestItem.count + " / " + QuestItem.total);

            int time = (int)Time.timeSinceLevelLoad;
            string timestr = string.Format("Time: {0:D2}:{1:D2}", time / 60, time % 60);
            if (GetComponent<PauseScript>())
            {
                GUI.color = Color.gray;
                timestr += " (PAUSED)";
            }
            GUI.Label(new Rect(0, 00, 500, 30), timestr);

            int y = 40;

            if (RealMapScript.collected)
            {
                GUI.color = Color.red;
                GUI.Label(new Rect(0, y, 500, 30), "Map acquired! Press E to view the map.");
                y += 20;
            }

            if (HighJumpScript.collected)
            {
                GUI.color = new Color(.5f, .5f, 1, 1);
                GUI.Label(new Rect(0, y, 500, 30), "High jump acquired! You can now jump much higher.");
                y += 20;
            }

            if (CubeMapScript.collected)
            {
                GUI.color = Color.yellow;
                GUI.Label(new Rect(0, y, 500, 30), "Cube map acquired! You can view the cubes in the map.");
                y += 20;
            }
            GUI.EndGroup();

        }
    }
}