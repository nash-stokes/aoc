namespace AoCProblemSolvers._2015Day21;

public class RoundData
{
    public int weaponIndex;
    public int armorIndex;
    public int ringOneIndex;
    public int ringTwoIndex;
    public int goldValue;
    public bool matchOutcome;

    public RoundData(int weaponIndex, int armorIndex, int ringOneIndex, int ringTwoIndex, int goldValue, bool matchOutcome)
    {
        this.weaponIndex = weaponIndex;
        this.armorIndex = armorIndex;
        this.ringOneIndex = ringOneIndex;
        this.ringTwoIndex = ringTwoIndex;
        this.goldValue = goldValue;
        this.matchOutcome = matchOutcome;
    }
}