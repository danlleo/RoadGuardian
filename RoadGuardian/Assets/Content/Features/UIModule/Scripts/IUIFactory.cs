namespace Content.Features.UIModule.Scripts
{
    public interface IUIFactory
    {
        void CreateUIRoot();
        IntroductionWindow CreateIntroductionWindow();
        GameOutcomeWindow CreateGameOutcomeWindow();
        DistanceWindow CreateDistanceDisplay();
        PlayerHealthBarWindow CreatePlayerHealthBar();
    }
}