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
    game: IGame;
    errorMessage: string;

    constructor(private _gameService: GameService, private activatedRoute: ActivatedRoute){
        this.activatedRoute.queryParams.subscribe((params: Params) => {
            this.gameId = params['id'];
            console.log(this.gameId);
        });
    }

    ngOnInit(): void {
        this._gameService.getGameById(this.gameId)
            .subscribe(games => this.game = games.Games[0], error => this.errorMessage = <any>error);
    }
}