import { Phase } from 'game/enums/phase';
import { Season } from 'game/enums/season';
import { IGame } from 'game/models/game';
import { PipeTransform } from '@angular/core';
import { Pipe } from '@angular/core';

@Pipe({name: "gameRound"})
export class GameRoundPipe implements PipeTransform{
    transform(game: IGame) {

        return game != null && game.CurrentGameState != null && game.CurrentGameState.Round != null ? 
            Season[game.CurrentGameState.Round.Season] + " " + game.CurrentGameState.Round.Year + ", " + Phase[game.CurrentGameState.Round.Phase]
            : "";
    }
}