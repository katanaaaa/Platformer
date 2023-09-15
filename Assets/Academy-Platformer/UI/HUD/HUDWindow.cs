using UI.UIWindows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD
{
    public class HUDWindow : UIAnimationWindow
    {
        [SerializeField] private Text text;
        [SerializeField] private Transform healthBar;

        public float CurrentHealth => healthBar.localScale.x;

        public void ChangeHealthBar(float healthPoint)
        {
            var healthBarLocalScale = healthBar.localScale;
            healthBarLocalScale.x = healthPoint;
            healthBar.localScale = healthBarLocalScale;
        }

        public void ChangeScoreText(int score)
        {
            text.text = score.ToString();
        }
    }
}