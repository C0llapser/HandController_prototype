using UnityEngine;

public abstract class BodyControlState
{
    public abstract void EnterState(BodyStateManager bodyPart);

    public abstract void UptadeState(BodyStateManager bodyPart);
}
