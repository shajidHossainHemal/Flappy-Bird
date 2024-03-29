﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdUnlocked;
    private bool isRedBirdUnlocked;

    void Awake() {
        MakeInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
        CheckIfBirdsAreUnlocked();    
    }

    private void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    private void CheckIfBirdsAreUnlocked() {
        if(GameController.instance.IsGreenBirdUnlocked() == 1) {
            isGreenBirdUnlocked = true;
        }

        if(GameController.instance.IsRedBirdUnlocked() == 1) {
            isRedBirdUnlocked = true;
        }
    }

    public void PlayGame() {
        SceneFader.instance.FadeIn("2_Game");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ChangeBird() {
        if(GameController.instance.GetSelectedBird() == 0) {
            if(isGreenBirdUnlocked) {
                birds[0].SetActive(false);
                GameController.instance.SetSelectedBird(1);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
        } else if(GameController.instance.GetSelectedBird() == 1) {
            if(isRedBirdUnlocked) {
                birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(2);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
            } else {
                birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(0);
                birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
        } else if(GameController.instance.GetSelectedBird() == 2) {
            birds[2].SetActive(false);
            GameController.instance.SetSelectedBird(0);
            birds[GameController.instance.GetSelectedBird()].SetActive(true);
        }
    }
}
