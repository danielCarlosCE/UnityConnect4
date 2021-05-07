using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    public Button button;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnClick);
        if (SessionGameState.playerWon == -1) {
            winText.text = "Something went wrong";
            return;
        }
        winText.text = "Player " + SessionGameState.playerWon + " won";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick() {
        SceneManager.LoadScene("SampleScene");
    }
}
