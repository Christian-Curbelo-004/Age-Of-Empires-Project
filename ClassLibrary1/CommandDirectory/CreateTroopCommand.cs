using ClassLibrary1.BuildingsDirectory;
using ClassLibrary1.CivilizationDirectory;
using ClassLibrary1.LogicDirectory;
using CommandDirectory;

namespace ClassLibrary1.CommandDirectory
{
    public class CreateTroopCommand : IGameCommand
    {
        private readonly Map _map;
        private readonly UnitCreateCore _unitCreateCore;
        private readonly Civilization civilization;
        
        public CreateTroopCommand(
            Map map,
            Civilization civilization,
            UnitCreateCore unitCreateCore // ✅ lo pasás desde afuera
        )
        {
            _map = map;
            this.civilization = civilization;
            _unitCreateCore = unitCreateCore;
        }

        public async Task<string> ExecuteAsync(string buildingType, string troopType)
        {
            var building = _map.GetEntities<ITrainingBuilding>()
                .FirstOrDefault(b => b.GetType().Name.Equals(buildingType, StringComparison.OrdinalIgnoreCase));
            
            if (building == null)
                return $"No se encontró un edificio del tipo '{buildingType}'.";
            var concreteBuilding = building as Buildings;
            try
            {
                if (troopType.Equals("Villagers", StringComparison.OrdinalIgnoreCase))
                {
                    var villager = _unitCreateCore.TryCreateVillager<CivicCenter>(
                        concreteBuilding,
                        CreationCost.Villagers,
                        UnitFactory.CreateVillagers
                    );
                    if (villager == null)
                        return "No se pudo crear aldeano (recursos/población insuficiente).";
                    _map.AddEntity(villager);
                    return $"Aldeano creado en {buildingType}";
                }
                if (troopType.Equals("Archer", StringComparison.OrdinalIgnoreCase))
                {
                    var archer = _unitCreateCore.TryCreateUnit<ArcherCenter>(
                        concreteBuilding,
                        CreationCost.Archer,
                        civilization,
                        civ => true,
                        UnitFactory.CreateArcher
                    );
                    if (archer == null)
                        return "No se pudo crear archer (recursos/población insuficiente).";
                    _map.AddEntity(archer);
                    return $"Archer creado en {buildingType}";
                }
                if (troopType.Equals("Chivarly", StringComparison.OrdinalIgnoreCase))
                {
                    var chivarly = _unitCreateCore.TryCreateUnit<ChivarlyCenter>(
                        concreteBuilding,
                        CreationCost.Chivarly,
                        civilization,
                        civ => true,
                        UnitFactory.CreateChivarly
                    );
                    if (chivarly == null)
                        return "No se pudo crear chivarly (recursos/población insuficiente).";
                    _map.AddEntity(chivarly);
                    return $"Chivarly creado en {buildingType}";
                }
                if (troopType.Equals("Infantery", StringComparison.OrdinalIgnoreCase))
                {
                    var infantery = _unitCreateCore.TryCreateUnit<InfanteryCenter>(
                        concreteBuilding,
                        CreationCost.Infantery,
                        civilization,
                        civ => true,
                        UnitFactory.CreateInfantery
                    );
                    if (infantery == null)
                        return "No se pudo crear infantery (recursos/población insuficiente).";
                    _map.AddEntity(infantery);
                    return $"Infantery creado en {buildingType}";
                }
                if (troopType.Equals("Paladin", StringComparison.OrdinalIgnoreCase))
                {
                    var paladin = _unitCreateCore.TryCreateUnit<PaladinCenter>(
                        concreteBuilding,
                        CreationCost.Paladin,
                        civilization,
                        civ => civ is Templaries,
                        UnitFactory.CreatePaladin
                    );
                    if (paladin == null)
                        return "No se pudo crear paladin (recursos/población insuficiente).";
                    _map.AddEntity(paladin);
                    return $"Paladin creado en {buildingType}";
                }
                if (troopType.Equals("Raider", StringComparison.OrdinalIgnoreCase))
                {
                    var raider = _unitCreateCore.TryCreateUnit<RaiderCenter>(
                        concreteBuilding,
                        CreationCost.Raider,
                        civilization,
                        civ => civ is Viking,
                        UnitFactory.CreateRaider
                    );
                    if (raider == null)
                        return "No se pudo crear Raider (recursos/población insuficiente).";
                    _map.AddEntity(raider);
                    return $"Raider creado en {buildingType}";
                }
                if (troopType.Equals("Centuries", StringComparison.OrdinalIgnoreCase))
                {
                    var centuries = _unitCreateCore.TryCreateUnit<CenturiesCenter>(
                        concreteBuilding,
                        CreationCost.Centuries,
                        civilization,
                        civ => civ is Roman,
                        UnitFactory.CreateCenturies
                    );
                    if (centuries == null)
                        return "No se pudo crear Centuries (recursos/población insuficiente).";
                    _map.AddEntity(centuries);
                    return $"Centuries creado en {buildingType}";
                }
                return $"Tipo de tropa ´{troopType}´ no reconocido.";
            }
            catch (Exception ex)
            {
                return $"Error al crear la tropa: {ex.Message}";
            }
        }
    }
}