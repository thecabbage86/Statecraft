import { GameService } from 'game/game.service';
import { IPlayer } from './../player/models/player';
import { SharedService } from './../shared/shared-service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Statecraft';
  player: IPlayer;

  constructor(private _sharedService: SharedService, private _gameService: GameService){
    this._gameService.getPlayerById(_sharedService.playerId)
            .subscribe(player => { _sharedService.setPlayer(player); this.player = _sharedService.player; }, error => _sharedService.errorMessage = <any>error);
    // this._gameService.getPlayerById(_sharedService.playerId)
    //         .subscribe(player => this.player = player, error => _sharedService.errorMessage = <any>error);
    //this.player = _sharedService.player;
  }
}
