public interface IEnterInteractionHandler:IInteractable
{
    /// <summary>
    /// ���ͷ����� �����Ҷ� ȣ��Ǵ� �Լ�.
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
    /// ���ͷ����� ������ �� ȣ��Ǵ� �Լ�
    /// </summary>
    public void ExitInteraction();
}


public interface IInteractable
{

}
