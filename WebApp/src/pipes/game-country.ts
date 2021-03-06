import { Pipe } from '@angular/core';
import { IGame } from './../game/models/game';
import { PipeTransform } from '@angular/core';

@Pipe({name: "gameCountry"})
export class GameCountryPipe implements PipeTransform{
    transform(game: IGame, playerId: AAGUID) { 
        let playerCountry:string = "";

        if(game != null)
        {
            if (playerId == game.AustriaPlayerId)
            {
                playerCountry = "Austria";
            }
            else if (playerId == game.GermanyPlayerId)
            {
                playerCountry = "Germany";
            }
            else if (playerId == game.EnglandPlayerId)
            {
                playerCountry = "England";
            }
            else if (playerId == game.FrancePlayerId)
            {
                playerCountry = "France";
            }
            else if (playerId == game.ItalyPlayerId)
            {
                playerCountry = "Italy";
            }
            else if (playerId == game.RussiaPlayerId)
            {
                playerCountry = "Russia";
            }
            else
            {
                playerCountry = "Turkey";
            }
        }

        return playerCountry;
    }

}