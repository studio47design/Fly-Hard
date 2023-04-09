using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_InputField inputName;
    public TextMeshProUGUI highScoreText;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetCurPlayerName() => MainManager.Instance.SetName(inputName.text);

    private void Start()
    {
        highScoreText.text = MainManager.Instance.GetHighScoreString();
    }

}
