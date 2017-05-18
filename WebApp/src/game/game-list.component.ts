import { GameService } from './game.service';
import { IGame } from './game';
import { Component, OnInit } from '@angular/core';

@Component({
    moduleId: module.id,
    templateUrl: 'game-list.component.html',
    styleUrls: ['game-list.component.css']
})
export class GameListComponent implements OnInit {
    games: IGame[];
    playerId: AAGUID = "1f29a1c0-f2f9-41b7-8c9d-17455e980d71"; //TODO: handle playerId properly
    errorMessage: string;

    constructor(private _gameService: GameService){}

    ngOnInit(): void {
        this._gameService.getGamesByPlayerId(this.playerId)
            .subscribe(games => this.games = games, error => this.errorMessage = <any>error);
    }

}