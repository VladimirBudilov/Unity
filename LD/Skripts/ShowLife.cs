using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLife : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshProUGUI.text = _player.GetHealth().ToString();
    }
}
