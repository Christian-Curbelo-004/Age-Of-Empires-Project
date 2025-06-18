namespace ClassLibrary1.LogicDirectory;

public class PopulationManager
{
    public int MaxVillagers = 3;
    public int MaxSoldiers = 0;
    public int CurrentVillagers = 3;
    public int CurrentSoldiers = 0;

    public void AddHomeVillagersCapacity()
    {
        MaxVillagers += 5;
    }

    public void AddHomeSoldiersCapacity()
    {
        MaxSoldiers += 5;
    }

    public bool CanCreateVillagers()
    {
        if (CurrentVillagers < MaxVillagers)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanCreateSoldiers()
    {
        if (CurrentSoldiers < MaxSoldiers)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CreateVillagers()
    {
        if (CanCreateVillagers())
        {
            CurrentVillagers++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CreateSoldiers()
    {
        if (CanCreateSoldiers())
        {
            CurrentSoldiers++;
            return true;
        }
        else
        {
            return false;
        }
    }
}