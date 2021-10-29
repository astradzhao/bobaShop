using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sealer : MonoBehaviour
{
    public float delta = 3.0f;   // Amount to move left and right from the start point
    public float speed = 2.0f; 
    // public float scoreValue = 0.0f;
    private bool isSealed;
    private Vector3 startPos;
    public Button sealButton;
    // public Text score;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Button btn = sealButton.GetComponent<Button>();
        btn.onClick.AddListener(SealDrink);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSealed) 
        {
            Vector3 v = startPos;
            v.x += delta * Mathf.Sin(Time.time * speed);
            transform.position = v; 
        } 
    }

    public void SealDrink()
    {
        isSealed = true;
        Vector3 v = transform.position;
        v.y -= 0.25f;
        transform.position = v;
        Debug.Log(v.x);
        sealButton.interactable = false;
        // gameObject.GetComponent<Button>().interactable = false;
        Score.scoreValue = (int) ((1 - Mathf.Abs(v.x)) * 100);
    }
}
