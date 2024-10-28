public interface IEnterInteractionHandler:IInteractable
{
    /// <summary>
    /// 인터렉션을 시작할때 호출되는 함수.
    /// </summary>
    public void EnterInteraction();
    
}

/*public interface IStayInterationHandler
{
    public void StayInteraction();
}*/

public interface IExitInterationHandler:IInteractable
{
    /// <summary>
    /// 인터렉션을 종료할 때 호출되는 함수
    /// </summary>
    public void ExitInteraction();
}


public interface IInteractable
{

}
