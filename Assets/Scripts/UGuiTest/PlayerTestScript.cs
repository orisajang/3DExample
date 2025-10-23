using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTestScript : MonoBehaviour
{
    private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _button;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetScore();
        }
    }
    private void GetScore()
    {
        _score++;
        Debug.Log($"현재점수: {_score}");
        _scoreText.text = _score.ToString();
    }
    public void OnButtonClick()
    {
        Debug.Log("btn");
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }
}
