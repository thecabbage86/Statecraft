import { MapService } from './map.service';
import { IGame } from './models/game';
import { OnInit, Component } from '@angular/core';
import { GameService } from "game/game.service";
import { ActivatedRoute, Params } from "@angular/router";
@Component({
    templateUrl: 'game-display.component.html'
    // styleUrls: ['game-list.component.css']
})
export class GameDisplayComponent implements OnInit{
    gameId: AAGUID;
    playerId: AAGUID;
    game: IGame;
    errorMessage: string;

    constructor(private _gameService: GameService, private activatedRoute: ActivatedRoute, private _mapService: MapService){
        this.activatedRoute.queryParams.subscribe((params: Params) => {
            this.gameId = params['gameId'];
            this.playerId = params['playerId'];
            console.log(this.gameId);
        });
    }

    ngOnInit(): void {
        this._gameService.getGameById(this.gameId)
            .subscribe(games => this.game = games.Games[0], error => this.errorMessage = <any>error);

        this._mapService.getMap().subscribe(
            data => this.createMap(data), 
            error => this.errorMessage = <any>error );
    }

    private createMap(mapJsonData: any){
        
    }
}