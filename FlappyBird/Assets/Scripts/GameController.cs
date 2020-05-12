using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Will allow to access the SceneManager in which will use to load scenes.
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public bool is_gameOver; //To save the state.
    public float scrollingSpeed = -2f;
    private int score;
    /*
     *'public' so it is visible to other classes and visible in Unity editor it self.
     * Will be assigned to the gameOverText inside the editor. By dragging and dropping.
     */
    public GameObject gameOverText;
    public static GameController instance;
    public Text scoreText;

    /*
     * This method is called before the "start" method.
     * It is used in order to make everything ready before all the objects start functioning.
     */
    void Awake()
    {
        is_gameOver = false;
        score = 0;

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);    //The game object that this component is attached to.
    }

    void Update()
    {
        if(is_gameOver && Input.GetMouseButtonDown(0))
        {   
            //load(the scene with buildIndex of this current scene).
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored()
    {
        if (is_gameOver)
            return;
        score++;
        scoreText.text = "Score: " + score.ToString();

    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        is_gameOver = true;
    }
}
