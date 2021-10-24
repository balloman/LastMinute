using System;
using Entities;
using UnityEngine;
using UnityEngine.UI;
using static Tags;

namespace HUD
{
    public class HudDeathHandler : MonoBehaviour
    {
        public GameObject background;
        public GameObject gameOver;

        public float backgroundFadeSpeed = 1;
        public float textFadeSpeed = 1;

        private Image backgroundImage;
        private Text gameOverText;
        
        private bool animating = false;
        private float backgroundProgress = 0;
        private float textProgress = 0;

        private Color backgroundInitial;
        private Color backgroundFinal;
        private Color textInitial;
        private Color textFinal;
        
        // Start is called before the first frame update
        private void Start()
        {
            GameObject.FindGameObjectWithTag(GetTag[Tag.Body]).GetComponent<HealthHandler>().OnDeath += DeathHandler;

            backgroundImage = background.GetComponent<Image>();
            backgroundInitial = backgroundImage.color;
            backgroundFinal = backgroundInitial;
            backgroundFinal.a = 1;
            
            gameOverText = gameOver.GetComponent<Text>();
            textFinal = gameOverText.color;
            textInitial = textFinal;
            textInitial.a = 0;
            gameOverText.color = textInitial;
        }

        private void Update()
        {
            if (!animating) return;
            if (backgroundProgress < 1)
            {
                backgroundProgress += backgroundFadeSpeed * Time.deltaTime;
                backgroundImage.color = Color.Lerp(backgroundInitial, backgroundFinal, backgroundProgress);
            }
            else if(textProgress < 1)
            {
                textProgress += textFadeSpeed * Time.deltaTime;
                gameOverText.color = Color.Lerp(textInitial, textFinal, textProgress);
            }
        }
        
        private void DeathHandler(object sender, EventArgs eventArgs)
        {
            animating = true;
        }
    }
}
