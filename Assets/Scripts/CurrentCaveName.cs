using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentCaveName : MonoBehaviour
{
    public TextMeshProUGUI caveName;
    public SwipeMenu.Menu menu;

    // Update is called once per frame
    void Update()
    {
        if (menu._currentMenuPosition <= 14)
            caveName.SetText("Ice Cave");
        if (menu._currentMenuPosition > 15 && menu._currentMenuPosition<=27)
            caveName.SetText("Jungle Cave");
        if (menu._currentMenuPosition > 29 && menu._currentMenuPosition <= 40)
            caveName.SetText("Lava Cave");
    }
}
