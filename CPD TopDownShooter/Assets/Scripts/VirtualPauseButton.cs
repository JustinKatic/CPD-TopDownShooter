using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Displays the touch pause button if the platform is mobile
/// </summary>
public class VirtualPauseButton : MonoBehaviour
{
    public bool onMobile = false;

    // Start is called before the first frame update
    void Start()
    {
#if (UNITY_ANDROID || UNITY_IOS || UNITY_WP8 || UNITY_WP8_1 || UNITY_WEBGL)
        onMobile = true;
#endif
        if (!onMobile)
        {
            gameObject.SetActive(false);
        }
    }

}
