import { SharedService } from './../shared/shared-service';
import { IPlayer } from './models/player';
import { GameFilterBy } from 'game/enums/game-filter-by';
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
    player: IPlayer;
    playerId: AAGUID = "AB858B6C-3D5E-4388-A49E-10ED3115800C"; //TODO: handle playerId properly
    errorMessage: string;

    finishedListName:string = "Finished Games";
    startedListName:string =  "Started Games";
    pendingListName:string =  "Pending Games";
    filterByFinished: GameFilterBy = GameFilterBy.IsFinished;
    filterByStarted: GameFilterBy = GameFilterBy.HasBegun;
    filterByPending: GameFilterBy = GameFilterBy.HasNotBegun;

    constructor(private _gameService: GameService, private _sharedService: SharedService){
        this.player = _sharedService.player;
    }

    ngOnInit(): void {
        this._gameService.getGamesByPlayerId(this.playerId)
            .subscribe(games => this.games = games, error => this.errorMessage = <any>error);
    }

}