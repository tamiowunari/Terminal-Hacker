/**
using System;
using System.Collections;
using System.Collections.Generic;
Removed these namespaces to stop unity from complain when using Random.Range(a, b);
**/
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private string greeting = "";

    //game configuration data
    private string[] level1Passwords = { "donkey", "comprehend", "skimming", "vooks", "aisle" };
    private string[] level2Passwords = { "jailer", "officer", "trial", "shotsfired", "bodycam" };
    private string[] level3Passwords = { "discovery", "hypothesis", "observatory", "critically" };

    //game state
    private int level;
    private string password;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentScreen = Screen.MainMenu;
        ShowMainMenu(greeting);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ShowMainMenu(string playerName)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + playerName);
        Terminal.WriteLine("What would you like to do?");
        Terminal.WriteLine("Press 1: Hack your Local library");
        Terminal.WriteLine("Press 2: Hack your Local Police station");
        Terminal.WriteLine("Press 3: Hack topsecret Research centre");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
       if(input == "menu")
        {
            Start();
        }
       else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
       else if(currentScreen == Screen.Password)
        {
            ProcessPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            startGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please pick a level Mr. Bond");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level");
        }
    }

    void startGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        if(level == 1)
        {
            password = level1Passwords[Random.Range(0, level1Passwords.Length)];
        }
        else if (level == 2)
        {
            password = level2Passwords[Random.Range(0, level2Passwords.Length)];
        }
        else if (level == 3)
        {
            password = level3Passwords[Random.Range(0, level3Passwords.Length)];
        }
        else
        {
            Debug.LogError("invalid level");
        }

        Terminal.WriteLine("You choose level " + level);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void ProcessPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            startGame();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("Type menu to return to main menu");
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
"                );
                break;
            case 2:
                Terminal.WriteLine("Prison doors are open...");
                Terminal.WriteLine(@"
          /|
         / |
  ______/  |   ___|\
 |      |  |  |___  )
 |      |  /      |/
 |      | /
 |______|/
"                );
                break;
            case 3:
                Terminal.WriteLine("You have accessed new discoveries...");
                Terminal.WriteLine(@"
         
          
  ______/    ~~~~
 |______|   /    \
 (______)   \0  0/
 (______)    \--/
 (______)     \/
"                );
                break;
            default:
                Debug.LogError("invalid level");
                break;
        }
    }
}

