namespace Assets.Scripts.UI
{
    public class PlayerInfoScreen : Window
    {
        public override void Close()
        {
            CanvasGroup.interactable = false;
            CanvasGroup.alpha = 0;
        }

        public override void Open()
        {
            CanvasGroup.interactable = true;
            CanvasGroup.alpha = 1;
        }

        protected override void OnButtonClick()
        {
        }
    }
}