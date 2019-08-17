using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public Text time;
    public UnityEngine.UI.Toggle musicToggle;

    //Variabler för textpositioner
    Vector3 A1_TextPosition;
    Vector3 A2_TextPosition;
    Vector3 A3_TextPosition;
    Vector3 A4_TextPosition; 
    Vector3 A5_TextPosition;

    public Text A1_Text;
    public Text A2_Text;
    public Text A3_Text;
    public Text A4_Text;
    public Text A5_Text;

    // Start is called before the first frame update
    void Start()
    {
        musicToggle.isOn = PlayerPrefs.GetInt("toggleKey") == 1;
        A1_TextPosition = new Vector3(-54.5f, 0.1f, 98.5f);
        A2_TextPosition = new Vector3(-27.0f, 0.1f, 98.2f);
        A3_TextPosition = new Vector3(0.3f, 0.1f, 98.2f);
        A4_TextPosition = new Vector3(27.7f, 0.1f, 98.2f);
        A5_TextPosition = new Vector3(55.0f, 0.1f, 98.2f);

    }

    // Update is called once per frame
    void Update()
    {
        int seconds = (int)Time.time;
        time.text = seconds + " sekunder";

    }

    void Music()
    {
        if (musicToggle.isOn)
        {
            PlayerPrefs.SetInt("toggleKey", 1);
            Debug.Log("Den är på");
            Camera.main.GetComponent<AudioSource>().Stop();
        }

        else
        {
            PlayerPrefs.SetInt("toggleKey", 0);
            Debug.Log("Den är av");
        }
    }

    public void restoreLayout()
    {
        Debug.Log("Försöker återställa");
        A1_Text.transform.position = A1_TextPosition;
        A1_Text.GetComponent<Rigidbody>().velocity = Vector3.zero;

        A2_Text.transform.position = A2_TextPosition;
        A2_Text.GetComponent<Rigidbody>().velocity = Vector3.zero;

        A3_Text.transform.position = A3_TextPosition;
        A3_Text.GetComponent<Rigidbody>().velocity = Vector3.zero;

        A4_Text.transform.position = A4_TextPosition;
        A4_Text.GetComponent<Rigidbody>().velocity = Vector3.zero;

        A5_Text.transform.position = A5_TextPosition;
        A5_Text.GetComponent<Rigidbody>().velocity = Vector3.zero;

        Debug.Log("A1 pos: " + A1_TextPosition);


    }



}
