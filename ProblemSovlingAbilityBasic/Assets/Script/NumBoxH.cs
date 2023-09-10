using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumBoxH : MonoBehaviour
{
    HeapSort hs;
    public TextMeshPro text;
    public int index;
    //public int spIndex;

    //private SpriteRenderer sr;
    //public Sprite[] sp = new Sprite[5];

    void Start()
    {
        hs = GameObject.FindObjectOfType<HeapSort>();
        //sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = hs.arrNum[index].ToString();
        //sr.sprite = sp[spIndex];
    }
}
