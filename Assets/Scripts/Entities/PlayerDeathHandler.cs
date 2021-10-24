using System;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities
{
    public class PlayerDeathHandler : MonoBehaviour
    {
        private float deathTimer = -1;
        
        // Start is called before the first frame update
        private void Start()
        {
            GetComponent<HealthHandler>().OnDeath += HandlePlayerDeath;
        }

        private void Update()
        {
            // Intentionally tight tolerance here
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (deathTimer == -1) return;
            deathTimer -= Time.deltaTime;
            if (deathTimer < 0) deathTimer = 0;
            if (deathTimer != 0) return;

            SceneManager.LoadScene("Room 1");
        }

        private void HandlePlayerDeath(object sender, EventArgs e)
        {
            deathTimer = 3;
        }
    }
}
