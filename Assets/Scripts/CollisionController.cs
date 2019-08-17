using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public float speed;
    static public QuizController quiz;
    public GameObject bulletPrefab;
    public AudioSource colSound;
    private ShootController shootCon;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
        GameObject tmp = GameObject.FindWithTag("QCont");
        quiz = tmp.GetComponent<QuizController>();

        GameObject tmp2 = GameObject.FindWithTag("ShootCon");
        shootCon = tmp2.GetComponent<ShootController>();
        colSound = GetComponent<AudioSource>();

    }


    void OnCollisionEnter(Collision other)
    {
        string answerString = other.gameObject.tag;
        Debug.Log("Debug: " + answerString);
        int answerNo = int.Parse(answerString);
        quiz.checkAnswer(answerNo);

        GameObject obj = GameObject.FindWithTag(other.gameObject.tag);

        Destroy(shootCon.bulletClone);

        //obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        //obj.GetComponent<Rigidbody>().position = new Vector3(0, 0, 0);

    }

    IEnumerator destroyBullet()
    {
        colSound.Play(0);
        yield return new WaitForSeconds(1);
        Destroy(shootCon.bulletClone);

    }









    // Update is called once per frame
}
