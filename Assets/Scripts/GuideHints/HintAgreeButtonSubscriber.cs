using UnityEngine;

public class HintAgreeButtonSubscriber : ButtonSubscriber
{
    [SerializeField] private Hint nextHint;
    [SerializeField] private Hint currentHint;
    
    protected override void SubscribeOnClickEvent()
    {
        Button.onClick.AddListener(currentHint.DeactivateHint);

        if (nextHint)
        {
            Button.onClick.AddListener(nextHint.ActivateHint);
        }
        else
        {
            Button.onClick.AddListener(() => GameStateData.TrySetNewGameState(GameState.Running));
        }
    }
}
