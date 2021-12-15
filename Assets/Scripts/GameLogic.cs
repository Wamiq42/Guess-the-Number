using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public InputField userInput;
    public Text outputText;
    public Button guessButton;
    private int randomNum;
    private int min, max;
    private bool wonGame = false;
    private int a = 0, i = 3;


    // Start is called before the first frame update
    void Start()
    {
        gameFinish();

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnButtonClick()
    {
        string input = userInput.text;


        if (i != a)
        {
            if (input != "")
            {
                int guessedNumber = int.Parse(input);
                if (guessedNumber == randomNum)
                {
                    wonGame = true;
                    gameFinish();

                }
                else if (guessedNumber > randomNum)
                {
                    outputText.text = "Try Lower\n Remaining Lives = "+i;

                }
                else
                {
                    outputText.text = "Try Higher\n Remaining Lives = " + i;
                }
            }
            else
            {
                outputText.text = "Invalid Number";
            }
        }
        else if (i == a)
        {
            gameFinish();
        }
        i--;

    }

    private int minGenerator()
    {
        int minNum = Random.Range(0, 15);
        return minNum;

    }
    private int maxGenerator()
    {
        int maxNum = Random.Range(16, 30);
        return maxNum;
    }


    private int randomNumGenerator()
    {
        min = minGenerator();
        max = maxGenerator();
        int random = Random.Range(min,max);
        return random;
    }

    private void gameFinish()
    {
        randomNum = randomNumGenerator();
        userInput.text = "Enter a Number...";
        if (wonGame)
        {
            outputText.text = "You Guessed the number! Try Another One\n"+ "Guess the number in range of " + min + " to " + max;
            wonGame = false;
            i = 3;

        }
        else if (wonGame == false && i == 0)
        {
            outputText.text = "No lives Remaining! Try Again!\n"+ "Guess the number in range of " + min + " to " + max;
            i = 3;
        }
        else
        {
            outputText.text = "Guess the number in range of " + min + " to " + max;
        }
        //randomNum = randomNumGenerator();
        //userInput.text = "Enter a Number...";
    }
}
