import { GameService } from './../game/game.service';
import { IPlayer } from 'player/models/player';
import { Component } from '@angular/core';
import { SharedService } from 'shared/shared-service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './create-player.component.html'
    // styleUrls: ['./app.component.css']
  })
  export class CreatePlayerComponent {
    title = 'Create a new player';
    //player: IPlayer;
    model: IPlayer;
    //router: Router;
    //router: any;
  
    constructor(private _sharedService: SharedService, private _gameService: GameService, private _router: Router){
      this.model = new IPlayer();
    }

    onSubmit(){
        this._gameService.createPlayer(this.model)
          .subscribe(player => this.updatePlayer(player), 
            error => this._sharedService.errorMessage = <any>error);
    }

    private updatePlayer(player){
      this._sharedService.player.Name = player.Name; 
      this._sharedService.setPlayer(player); 
      this._router.navigate([""]); 
    }
  }
  