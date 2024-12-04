public interface IEnterInteractableHandler:IInteraction
{
    /// <summary>
    /// 인터렉션이 가능 해질 때 호출되는 함수.
    /// </summary>
    public void EnterInteraction();
    
}

/*public interface IStayInterationHandler
{
    public void StayInteraction();
}*/

public interface IExitInteratableHandler:IInteraction
{
    /// <summary>
    /// 인터렉션을 불가능 해질 때 호출되는 함수
    /// </summary>
    public void ExitInteraction();
}


public interface IInteraction
{
    /// <summary>
    /// 구체적인 인터렉션의 구현
    /// </summary>
    public void Interact();
}
