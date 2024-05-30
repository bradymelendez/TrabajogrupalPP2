using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCycler : MonoBehaviour
{
    public TextMeshProUGUI[] texts;
    private int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(i == 0);
        }

        StartCoroutine(CycleTexts());
    }

    IEnumerator CycleTexts()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);


            texts[currentIndex].gameObject.SetActive(false);


            currentIndex = (currentIndex + 1) % texts.Length;


            texts[currentIndex].gameObject.SetActive(true);
        }
    }
}
