using UnityEngine;

public class EnumFactory : MonoBehaviour
{

    private readonly string[] wrongIssuer = { "�ֽ�Ƽ", "�����̵��� ����", "�Ѱ����ΰ�", "ơ��", "�ָ�" };
    private readonly string[] wrongArea = { "�ֽ�Ƽ", "�����̵��� ����", "�Ѱ����ΰ�", "ơ��", "�ָ�" };
    public string GetIssuerName(Issuer issuer)
    {
        return issuer switch
        {
            Issuer.issuer1 => "���ٴϾ�",
            Issuer.issuer2 => "Ʈ����ũ",
            Issuer.issuer3 => "��ī",
            Issuer.issuer4 => "����",
            Issuer.issuer5 => "������",
            Issuer.issuer6 => "��������",
            Issuer.wrong => GetRandomWrongIssuer()
        };
    }

    private string GetRandomWrongIssuer()
    {
        return wrongIssuer[Random.Range(0, wrongIssuer.Length)];
    }

    public string GetAreaString(Station station)
    {
        return station switch
        {
            Station.area1 => "����",
            Station.area2 => "����",
            Station.area3 => "�����",
            Station.area4 => "�����",
            Station.area5 => "���丮��",
            Station.area6 => "���浵��",
            Station.area7 => "��������",
            Station.wrong => GetRandomWrongArea()
        };
    }

    private string GetRandomWrongArea()
    {
        return wrongIssuer[Random.Range(0, wrongArea.Length)];
    }
}
