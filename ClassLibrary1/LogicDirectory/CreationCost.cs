namespace ClassLibrary1.LogicDirectory;

public class CreationCost
{
    public static readonly Cost Archer = new Cost(60,0,0,20);
    public static readonly Cost Centuries = new Cost(60, 0, 10, 20);
    public static readonly Cost Chivarly = new Cost(60, 0, 0, 20);
    public static readonly Cost Paladin = new Cost(120,0,10,20);
    public static readonly Cost Raider = new Cost(120, 0, 10, 20);
    public static readonly Cost Infantery = new Cost(60, 0, 0, 20);
    public static readonly Cost Villagers = new Cost(80,30,0,0);
    public static readonly Cost GoldDeposit = new Cost(30, 80, 10, 30);
    public static readonly Cost Home = new Cost(100, 0, 0, 20);
    public static readonly Cost WoodDeposit = new Cost(100,0,0,0);
    public static readonly Cost StoneDeposit = new Cost(0, 80, 0, 10);
    public static readonly Cost WindMill = new Cost(0, 80, 0, 20);
    public static readonly Cost ArcherCenter = new Cost(0, 100, 0, 30);
    public static readonly Cost RaiderCenter = new Cost(0, 100, 10, 30);
    public static readonly Cost InfanteryCenter = new Cost(0, 100, 0, 30);
    public static readonly Cost ChivarlyCenter = new Cost(0, 100, 0, 30);
    public static readonly Cost PaladinCenter = new Cost(0, 100, 10, 30);
    public static readonly Cost CenturiesCenter = new Cost(0, 100, 10, 30);
    public static readonly Cost CivicCenter = new Cost(100, 200, 30, 10);
}