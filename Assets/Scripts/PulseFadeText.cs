using UnityEngine;
using TMPro;

public class PulseFadeText : MonoBehaviour
{
    public float fadeSpeed = 2f;
    private TMP_Text tmp;
    private Color baseColor;
    private float alpha;
    private bool fadingOut = true;

    void Start()
    {
        tmp = GetComponent<TMP_Text>();
        baseColor = tmp.color;
        alpha = baseColor.a;
    }

    void Update()
    {
        if (fadingOut)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            if (alpha <= 0.1f)
            {
                alpha = 0.1f;
                fadingOut = false;
            }
        }
        else
        {
            alpha += Time.deltaTime * fadeSpeed;
            if (alpha >= 1f)
            {
                alpha = 1f;
                fadingOut = true;
            }
        }

        tmp.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
    }
}
