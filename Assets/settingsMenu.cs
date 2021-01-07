using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsMenu : MonoBehaviour
{
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
