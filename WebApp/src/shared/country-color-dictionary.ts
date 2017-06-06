import { Country } from 'game/enums/country';

interface ICountryColorDictionary {
}

export class CountryColorDictionary implements ICountryColorDictionary {
    constructor(){
        this[Country.Austria] = "orange";
        this[Country.England] = "blue";
        this[Country.France] = "purple";
        this[Country.Germany] = "pink";
        this[Country.Italy] = "green";
        this[Country.Russia] = "red";
        this[Country.Turkey] = "magenta";


        //this.countryColors[Country.England] = "blue";
    }
}