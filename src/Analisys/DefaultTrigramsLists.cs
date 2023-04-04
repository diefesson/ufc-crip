namespace Diefesson.Cryptool.Analisys;

public static class DefaultTrigramsLists
{
    public static readonly TrigramList ENUSTrigrams = new TrigramList(
        Languages.ENUS,
        new string[]
        {
            "the",
            "and",
            "tha",
            "ent",
            "ing",
            "ion",
            "tio",
            "for",
            "nde",
            "has",
            "nce",
            "edt",
            "tis",
            "oft",
            "sth",
            "men",
        }
    );
    public static readonly TrigramList PTBRTrigrams = new TrigramList(
        Languages.PTBR,
        new string[]{
            "que",
            "ent",
            "com",
            "nte",
            "est",
            "ava",
            "ndo",
            "ado",
            "ara",
            "par",
            "and",
            "men",
            "uma",
            "con",
            "ada",
            "res",
            "inh",
            "ant",
            "des"
        }
    );
}