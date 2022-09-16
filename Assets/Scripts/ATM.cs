using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ATM : MonoBehaviour
{
    [SerializeField] GameObject _ok;
    [SerializeField] GameObject _sellCanvas;
    [SerializeField] GameObject _normalCanvas;
    private bool isOK = false;
    // Start is called before the first frame update
    void Start()
    {
        _ok.SetActive(false);
        _sellCanvas.SetActive(false);
        _normalCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOK)
        {
            _ok.SetActive(true);

            if(Input.GetButton("OK"))
            {
                _sellCanvas.SetActive(true);
                _normalCanvas.SetActive(false);
            }
            else if (Input.GetButton("NO"))
            {
                _sellCanvas.SetActive(false);
                _normalCanvas.SetActive(true);
            }
        }
        else
        {
            _ok.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isOK = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isOK = false;
    }
}
