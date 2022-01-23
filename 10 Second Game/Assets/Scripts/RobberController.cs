using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RobberController : MonoBehaviour
{

    private bool finished = false;
    

    float countDownStartValue = 12;
    public Text timerUI;

    Rigidbody2D rigidbody2d;
    public float speed = 3.0f;
    float horizontal;
    float vertical;
    private int scoreValue;
    private Text scoreText;
    public Text winText;
    public Text loseText;
    public int Money;
    public Text moneyText;
    AudioSource audioSource;
    [SerializeField] private GameObject backgroundMusic;
    public GameObject MoneyEffectPrefab;
    
    public AudioClip MoneyClip;
    [SerializeField] private GameObject winMusic;
    [SerializeField] private GameObject loseMusic;
    
    

    // Start is called before the first frame update

    

    void Start()
    {
        countDownTimer();


        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        SetWinText();
        winText.text = "";

        

        backgroundMusic.SetActive(true);
        loseMusic.SetActive(false);
        winMusic.SetActive(false);

        SetMoneyText();
        Money = 0;

    }
    void countDownTimer()
    {
        if (countDownStartValue >= 0 )
        {
            
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            timerUI.text = "Timer : " + spanTime.Minutes + " : " + spanTime.Seconds;
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
            
        }
         

        else
        {

            timerUI.text = "You Lose!";
            backgroundMusic.SetActive(false);
            loseMusic.SetActive(true);
        }
    }
    


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


    public void SetMoneyText()
    {
        moneyText.text = "Money: " + Money.ToString();
        SetWinText();
    }

    public void SetWinText()
    {
        if (Money == 4 && countDownStartValue >= 0)
        {
            
            winText.text = "You Win! Game created by Richard Cortez";
            backgroundMusic.SetActive(false);
            winMusic.SetActive(true);
            finished = true;
            

        }
    }

   



    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rigidbody2d.AddForce(new Vector2(horizontal * speed, vertical));

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rigidbody2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            collision.gameObject.SetActive(false);
            Money = Money + 1;
            SetMoneyText();
            PlaySound(MoneyClip);
            GameObject MoneyEffectObject = Instantiate(MoneyEffectPrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        }









    }
}
