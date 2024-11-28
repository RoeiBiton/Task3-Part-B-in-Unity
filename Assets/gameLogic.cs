using UnityEngine;
using UnityEngine.UI;
public class gameLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerScore;
    public Text scoreText;

    [ContextMenu("Increase Score")]
    public void addScore(){
        playerScore +=1;
        scoreText.text = playerScore.ToString();
    }
}
