using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System;

public class Question
{
    public int no;
    public string word;
    public string[] answers;
    public int correct_answer;
}

public class QuizController : MonoBehaviour
{
    public Text A_Text1, A_Text2, A_Text3, A_Text4, A_Text5;
    public Text word;
    public Text question;
    public int noOfQuestions;
    static public string fileName = "Questions.json";
    public string filePath = Path.Combine("/home/sandra/saol/Assets/", fileName);
    public System.Random random = new System.Random();
    public int randomNo;
    public List<Question> questions;
    public int rightAnswer;
    public int correctQuestions;
    public GameController gameCon;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    private ShootController shootCon;

    void Start()
    {
        GameObject tmp = GameObject.FindWithTag("GameController");
        gameCon = tmp.GetComponent<GameController>();

        GameObject tmp2 = GameObject.FindWithTag("ShootCon");
        shootCon = tmp2.GetComponent<ShootController>();

        loadGameData();
        loadNewQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void loadNewQuestion()
    {
        question.text = "Vad betyder..\n\n\n\n\n?";
        randomNo = random.Next(1, (noOfQuestions + 1));

        foreach (var question in questions)
        {
            if (question.no == randomNo)
            {
                word.text = question.word;
                A_Text1.text = question.answers[0];
                A_Text2.text = question.answers[1];
                A_Text3.text = question.answers[2];
                A_Text4.text = question.answers[3];
                A_Text5.text = question.answers[4];
                rightAnswer = question.correct_answer;

            }

        }


        shootCon.hasClickedOnce = false;
        

    }

    private void loadGameData()
    {
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            questions = JsonConvert.DeserializeObject<List<Question>>(json);
            noOfQuestions = questions.Count;

            foreach (var question in questions)
            {
                Debug.Log("gårbra");

            }

        }

        if (!File.Exists(filePath))
        {
            Debug.LogError("Can not fetch game data file");

        }
    }

    public void checkAnswer(int answer)
    {

        StartCoroutine(waiter(answer));

    }

    IEnumerator waiter(int answer)
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Kollar på svar..");
        if (answer == rightAnswer)
        {
            correctSound.Play(0);
            word.text = "Rätt!";
            question.text = "Du sköt rätt!";
            correctQuestions++;

        }
        else
        {
            wrongSound.Play(0);
            word.text = "Fel!";
            question.text = "Nu försöker vi med ett nytt ord..";
        }


        Debug.Log("Tja");

        Debug.Log("Försöker vänta");
        yield return new WaitForSeconds(3);

        gameCon.restoreLayout();
        loadNewQuestion();




    }

}
