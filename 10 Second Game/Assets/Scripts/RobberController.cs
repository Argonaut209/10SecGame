using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobberController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
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

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        scoreText.text = "Money Collected: " + scoreValue.ToString();
        
        SetWinText();
        winText.text = "";
       
        SetLoseText();
        loseText.text = "";
       
        backgroundMusic.SetActive(true);
       
        SetMoneyText();
        Money = 0;
    }

    public void SetMoneyText()
    {
        moneyText.text = "Money: " + Money.ToString();
        SetWinText();
    }

    private void SetWinText()
    {
        winText.text = "You win! Game created by Richard Cortez";
    }

    private void SetLoseText()
    {
        loseText.text = "Busted! Try again when you're out in 10 years!";
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 5.0f * horizontal * Time.deltaTime;
        position.y = position.y + 5.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
