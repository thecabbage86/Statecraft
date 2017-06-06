import { Country } from 'game/enums/country';

export interface Territory{
    Id: number;
    //Name: TerritoryName;
    //TerritoryCode: string; -- add this to model from API?
    IsSupplyCenter: boolean;
    //Type: TerritoryType; 
    //OccupyingUnit: Unit;
    Owner: Country;
}