using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ATM : MonoBehaviour
{
    [SerializeField] Image _ok;
    [SerializeField] Text _okText;
    [SerializeField] Canvas _sellCanvas;
    private bool isOK = false;
    // Start is called before the first frame update
    void Start()
    {
        _ok.enabled = false;
        _okText.enabled = false;
        
        _sellCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOK)
        {
            _ok.enabled = true;
            _okText.enabled=true;

            if(Input.GetButton("OK"))
            {
                _sellCanvas.enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isOK = true;
        }
    }
}
