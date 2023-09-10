using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumBox : MonoBehaviour
{
    QuickSort qs;
    public TextMeshPro text;
    public int index;
    public int spIndex;

    private SpriteRenderer sr;
    public Sprite[] sp = new Sprite[5];

    void Start()
    {
        qs = GameObject.FindObjectOfType<QuickSort>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (qs.arrNum[index] == qs.pivot)
            spIndex = 4;
        else if (qs.left == index && qs.right == index)
            spIndex = 2;
        else if (qs.right == index)
            spIndex = 1;
        else if(qs.left == index)
            spIndex = 3;
        else
            spIndex = 0;

        text.text = qs.arrNum[index].ToString();
        sr.sprite = sp[spIndex];
    }
}
