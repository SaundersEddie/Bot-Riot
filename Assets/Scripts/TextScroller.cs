using UnityEngine;
using TMPro;
using System;

public class TextScroller : MonoBehaviour
{
    public RectTransform textToScroll;
    public TMP_Text scrollText;
    public float scrollSpeed = 50f;
    public float resetBuffer = 50f;

    private float endX;
    private float startX;
    private float textWidth;

    void Start()
    {
        string scores = ScoreManager.GetFormattedScores();
        scrollText.text = $"{scores}  BOT-RIOT by Brindle Besties   Inspired by Uridium   www.botriot.dev";

        float scrollAreaWidth = ((RectTransform)transform).rect.width;
        textWidth = textToScroll.rect.width;

        // Start offscreen to the right
        startX = scrollAreaWidth + resetBuffer;
        endX = -textWidth - resetBuffer;

        textToScroll.anchoredPosition = new Vector2(startX, textToScroll.anchoredPosition.y);
    }

    void Update()
    {
        float newX = textToScroll.anchoredPosition.x - scrollSpeed * Time.deltaTime;

        if (newX <= endX)
        {
            newX = startX;
        }

        textToScroll.anchoredPosition = new Vector2(newX, textToScroll.anchoredPosition.y);
    }
}
