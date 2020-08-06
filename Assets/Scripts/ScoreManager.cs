using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Net;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private string url = "https://checkmate2020.herokuapp.com";
    private string scoreUrl = "https://checkmate2020.herokuapp.com/score";
    private string buildUrl = "https://checkmate2020.herokuapp.com/game";
    public int currentScore;
    public Text scoreText;

    void Start()
    {
        /*PlayerScore scoreClass = new PlayerScore();
        scoreClass.score = 100;
        Debug.Log(JsonUtility.ToJson(scoreClass));
        string JSONScore = JsonUtility.ToJson(scoreClass);
        StartCoroutine(postRequest(scoreUrl, JSONScore));*/
        currentScore = 0;
        TransmitToUI();
    }

    public IEnumerator postRequest(string scoreUrl, string JSONScore)
    {

        UnityWebRequest request = new UnityWebRequest(scoreUrl, "POST");
        byte[] encodedScore = new System.Text.UTF8Encoding().GetBytes(JSONScore);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(encodedScore);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
        request.SetRequestHeader("Cache-Control", "no-cache");
        request.SetRequestHeader("Access-Control-Allow-Credentials", "true");
        request.SetRequestHeader("Access-Control-Allow-Headers", "Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time");
        request.SetRequestHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
        request.SetRequestHeader("Access-Control-Allow-Origin", "*");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
    }

    public class PlayerScore
    {
        public int score;
    }

    public void ScoreUpdater(int scoreToAdd)
    {
        PlayerScore playerScore = new PlayerScore();
        playerScore.score = scoreToAdd;
        Debug.Log(JsonUtility.ToJson(playerScore));
        string JSONScore = JsonUtility.ToJson(playerScore);
        StartCoroutine(postRequest(scoreUrl, JSONScore));
        currentScore += scoreToAdd;
        Debug.Log(currentScore);
        TransmitToUI();
    }

    void TransmitToUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}


