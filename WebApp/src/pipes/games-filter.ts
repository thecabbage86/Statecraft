import { Pipe, PipeTransform } from "@angular/core";
import { IGame } from "game/models/game";
import { GameFilterBy } from "game/enums/game-filter-by";

@Pipe({ name: "gamesFilter" })
export class GamesFilterPipe implements PipeTransform{
    transform(games: IGame[], args?) : IGame[] {
        let [filterBy] = args; // GameFilterBy
        let filteredGames: IGame[];
console.log(args + filterBy);
        switch (args) {
            case GameFilterBy.IsFinished:
                filteredGames = games.filter((game: IGame) => game.IsFinished);
                break;
            case GameFilterBy.HasBegun:
                filteredGames = games.filter(game => game.HasBegun);
                break;
            case GameFilterBy.HasNotBegun:
                filteredGames = games.filter(game => !game.HasBegun);
                break;
            default:
                filteredGames = games;
                break;
        }
        return filteredGames;
    }

}