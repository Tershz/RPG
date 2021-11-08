using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private TextMeshProUGUI uiText;
    private string textToWriter;
    private int characterIndex;
    private float timerPerCharacter;
    private float timer;

    public void AddWriter(TextMeshProUGUI uiText,string textToWriter,float timerPerCharacter)
    {
        this.uiText = uiText;
        this.textToWriter =textToWriter;
        this.timerPerCharacter = timerPerCharacter;
        characterIndex = 0;
    }

    void Update()
    {
        if(uiText != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                //Display nest Character
                timer += timerPerCharacter;
                characterIndex++;
                uiText.text = textToWriter.Substring(0, characterIndex);
            }

            if(characterIndex >= textToWriter.Length)
            {
                //entire String Display
                uiText = null;
                return;
            }
        }
    }
}
