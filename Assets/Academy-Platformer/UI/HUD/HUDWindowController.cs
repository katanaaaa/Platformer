namespace UI.HUD
{
    public class HUDWindowController
    {
        private readonly UIService.UIService _uiService;
        private HUDWindow _hudWindow;

        public HUDWindowController(UIService.UIService uiService)
        {
            _uiService = uiService;
            _hudWindow = _uiService.Get<HUDWindow>();

            SetParameters();
        }

        public void ChangeHealthPoint(float healthPoint)
        {
            healthPoint = CheckHPPoint(healthPoint, _hudWindow.CurrentHealth);
            _hudWindow.ChangeHealthBar(healthPoint);
        }

        private void SetParameters(int score = 0, float healthPoint = 100f)
        {
            ChangeScore(score);

            healthPoint = CheckHPPoint(healthPoint);
            _hudWindow.ChangeHealthBar(healthPoint);
        }

        private float CheckHPPoint(float healthPoint, float currentHP = 0)
        {
            healthPoint /= 100;
            currentHP /= 100;

            if (healthPoint + currentHP > 1)
            {
                currentHP = 1;
            }
            else if (healthPoint + currentHP < 0)
            {
                currentHP = 0;
            }
            else
            {
                currentHP += healthPoint;
            }

            return currentHP;
        }

        private void ChangeScore(int score)
        {
            _hudWindow.ChangeScoreText(score);
        }
    }
}