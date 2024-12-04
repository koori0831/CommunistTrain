using UnityEngine;

public class EnumFactory : MonoBehaviour
{

    private readonly string[] wrongIssuer = { "¹Ö½ÃÆ¼", "°ÌÀïÀÌµéÀÇ ½°ÅÍ", "ÇÑ°­¹°·Î°¡", "Æ¡ÀÕ", "¹Ö¸¼" };
    private readonly string[] wrongArea = { "¹Ö½ÃÆ¼", "°ÌÀïÀÌµéÀÇ ½°ÅÍ", "ÇÑ°­¹°·Î°¡", "Æ¡ÀÕ", "¹Ö¸¼" };
    public string GetIssuerName(Issuer issuer)
    {
        return issuer switch
        {
            Issuer.issuer1 => "º¸¹Ù´Ï¾Æ",
            Issuer.issuer2 => "Æ®·ÎÃ÷Å©",
            Issuer.issuer3 => "´©Ä«",
            Issuer.issuer4 => "º£³Ù",
            Issuer.issuer5 => "ÄÉÆ÷Ã÷",
            Issuer.issuer6 => "¿À¸®ÄÚÅä",
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
            Station.area1 => "¿ïÆæ",
            Station.area2 => "³ªÄÚ",
            Station.area3 => "ÅäÅä¹Ì",
            Station.area4 => "ÅÙÅä·Î",
            Station.area5 => "¸ðÅä¸®½º",
            Station.area6 => "¾ÈÆæµµ¹Ì",
            Station.area7 => "´ÏÆùÁ¦Äí",
            Station.wrong => GetRandomWrongArea()
        };
    }

    private string GetRandomWrongArea()
    {
        return wrongIssuer[Random.Range(0, wrongArea.Length)];
    }
}
