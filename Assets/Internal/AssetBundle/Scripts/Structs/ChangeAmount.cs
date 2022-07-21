public struct ChangeAmount
{
    public ChangeAmount(float oldValue, float newValue)
    {
        OldValue = oldValue;
        NewValue = newValue;
    }
    
    public float OldValue { get; private set; }
    public float NewValue { get; private set; }
    public float ChangeDelta => NewValue - OldValue;
}