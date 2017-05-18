import { Pipe, PipeTransform } from "@angular/core";
import { IGame } from "game/models/game";

@Pipe({ name: "finishedGames" })
export class FinishedGamesPipe implements PipeTransform{
    transform(games: IGame[]) : IGame[] {
        return games.filter((game: IGame) => game.IsFinished);
    }

}