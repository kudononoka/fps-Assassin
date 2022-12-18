using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    [SerializeField] string _text;
    [SerializeField] char[] _char;
    [SerializeField] GameObject _UI;
    [SerializeField] GameObject _UI2s;
    Text _textUI;
    Text _textUI2;
    RectTransform _textPos;
    RectTransform _textPos2;
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _textUI = _UI.GetComponent<Text>();
        _textUI2 = _UI2s.GetComponent<Text>(); 
        _textPos = _UI.GetComponent<RectTransform>();
        _textPos2 = _UI2s.GetComponent<RectTransform>();
        _textUI2.text = "|";
        _anim = _UI2s.GetComponent<Animator>();
        _textPos2.localPosition = _textPos.localPosition;
        _char = _text.ToCharArray();
        StartCoroutine(TextActive());
    }

    // Update is called once per frame
    void Update()
    {
        if(_textUI.text == _text)
        {
            _anim.SetTrigger("ON");
        }
    }

    IEnumerator TextActive()
    {
        foreach(char c in _char)
        {
            if (c == 'n')
            {
                _textUI.text += "\n";
            }
            else
            {
                _textUI.text += c;
            }
            Vector3 pos = _textPos2.localPosition;
            pos.x += 50.5f;
            _textPos2.localPosition = pos;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
