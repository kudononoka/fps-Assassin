using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    public bool isCanvas;
    [SerializeField] GameObject MainCanvas;
    [SerializeField] GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(false);
        MainCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(isCanvas)
        {
            if(Input.GetButton("NO"))
            {
                Canvas.SetActive(false);
                MainCanvas.SetActive(true);
                isCanvas = false;
            }
        }
    }

    public void Rule()
    {
        Canvas.SetActive(true);
        MainCanvas.SetActive(false);
        isCanvas = true;
    }
}
