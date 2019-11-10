using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{
    public PlayerStats playerStats; 
    public Button[] ba;

    private void Start()
    {
        for (int i = 1; i < ba.Length; i++)
        {
            if (playerStats.lvls[0, i-1] == 0)
                ba[i].interactable = false;
        }
    }

    public SceneFader fader;
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}