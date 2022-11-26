using System;
using System.Threading;
using UnityEngine;

namespace Main_Game.Script
{
    public class UIManager : MonoBehaviour
    {
        
        public GameObject homePanel;
        public GameObject difficultyPanel;
        public GameObject tutPanel;
        public GameObject tutObject;

        public bool fromHome = true;
        public void ShowPanel(String nameUI)
        {
            homePanel.SetActive(false);
            difficultyPanel.SetActive(false);
            tutPanel.SetActive(false);
            tutObject.SetActive(false);
            switch (nameUI)
            {
                case "Home":
                    homePanel.SetActive(true);
                    fromHome = true;
                    break;
                
                case "Difficulty":
                    difficultyPanel.SetActive(true);
                    fromHome = false;
                    break;
                
                case "Tut":
                    tutPanel.SetActive(true);
                    tutObject.SetActive(true);
                    break;
            }
        }

        public void CloseTut()
        {
            if (fromHome)
            {
                ShowPanel("Home");
            }
            else
            {
                ShowPanel("Difficulty");
            }
        }
    }
}