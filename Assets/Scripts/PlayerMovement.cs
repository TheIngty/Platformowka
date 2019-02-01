using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 30f;

    //private int count = 0;
    //public Text countText;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public int lifes = 5;
    public Text lifesText;

    void Start()
    {
        setLifesCount();

        //if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    count = 0;
        //    countText.text = "Points: " + count.ToString();
        //}
    }

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //if (SceneManager.GetActiveScene().buildIndex == 2 && count >=12)
        //{
        //    SceneManager.LoadScene("Level2");
        //}

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (lifes <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void PlayerDeath()
    {
        var player = GameObject.Find("Player");
        player.transform.position = new Vector3(1, 1, 0);
        lifes -= 1;
        setLifesCount();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("PickUp"))
        //{
        //    other.gameObject.SetActive(false);
        //    count = count + 1;
        //    SetCountText();
        //}
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerDeath();
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (other.gameObject.CompareTag("Lava"))
        {
            PlayerDeath();   
        }
    }

    //void SetCountText()
    //{
    //    countText.text = "Points: " + count.ToString();
    //}

    public void setLifesCount()
    {
        lifesText.text = "Lifes: " + lifes.ToString();
    }
}