using System;


namespace ClassLibrary1;
using CivicCenter;
using InfanteryCenter;


public class Facade
{
    //public Map map;
    public CivicCenter civiccenter;
    public InfanteryCenter infanerycenter;
    public Quary quary;
    public Civilization civilization;

    public Facade()
    {
        civiccenter = new CivicCenter(100, 5, "civic center", 5, 3);
        infanerycenter = new InfanteryCenter(100, 4, "infantery", 6, 4);
        quary = new Quary(20, 20);
        civilization = new Roman();
        civilization = new Templaries();
        civilization = new Viking();
    }
}