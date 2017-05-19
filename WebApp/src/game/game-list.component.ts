import { IGameResponse } from './models/game-response';
import { GameService } from './game.service';
import { IGame } from './models/game';
import { Component, OnInit } from '@angular/core';

@Component({
    moduleId: module.id,
    templateUrl: 'game-list.component.html',
    styleUrls: ['game-list.component.css']
})
export class GameListComponent implements OnInit {
    games: IGameResponse;
    playerId: AAGUID = "3d63cafe-48b7-4254-a837-96094440e70e"; //TODO: handle playerId properly
    errorMessage: string;
    finishedListName: "Finished Games";

    constructor(private _gameService: GameService){}

    ngOnInit(): void {
        this._gameService.getGamesByPlayerId(this.playerId)
            .subscribe(games => this.games = games, error => this.errorMessage = <any>error);
    }

}