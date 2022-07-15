using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitScreen : MonoBehaviour
{
    public Image waitScreen;
    public float waitToFade, fadeSpeed;

    void Update()
    {
        if (waitToFade > 0)
        {
            waitToFade -= Time.deltaTime;
        }
        else
        {
            waitScreen.color = new Color
                (waitScreen.color.r, waitScreen.color.g, waitScreen.color.b,
                Mathf.MoveTowards(waitScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (waitScreen.color.a == 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
