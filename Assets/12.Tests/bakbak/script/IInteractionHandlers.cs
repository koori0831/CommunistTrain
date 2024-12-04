public interface IEnterInteractableHandler:IInteraction
{
    /// <summary>
    /// ���ͷ����� ���� ���� �� ȣ��Ǵ� �Լ�.
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
    /// ���ͷ����� �Ұ��� ���� �� ȣ��Ǵ� �Լ�
    /// </summary>
    public void ExitInteraction();
}


public interface IInteraction
{
    /// <summary>
    /// ��ü���� ���ͷ����� ����
    /// </summary>
    public void Interact();
}
