import { IGame } from './models/game';
import { OnInit, Component } from '@angular/core';
import { GameService } from "game/game.service";
@Component({
    templateUrl: 'game-display.component.html'
    // styleUrls: ['game-list.component.css']
})
export class GameDisplayComponent implements OnInit{
    gameId: AAGUID;
    game: IGame;
    errorMessage: string;

    constructor(private _gameService: GameService){}
    ngOnInit(): void {
         this._gameService.getGameById(this.gameId)
            .subscribe(games => this.game = games[0], error => this.errorMessage = <any>error);
    }
}