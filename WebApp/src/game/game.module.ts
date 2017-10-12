import { FormsModule } from '@angular/forms';
import { CreatePlayerComponent } from './../player/create-player.component';
import { SharedService } from './../shared/shared-service';
import { MapService } from './map.service';
import { GameCountryPipe } from './../pipes/game-country';
import { GameDisplayComponent } from './game-display.component';
import { GamesFilterPipe } from './../pipes/games-filter';
import { GameSubListComponent } from './game-sublist.component';
import { GameRoundPipe } from './../pipes/game-round';
import { BrowserModule } from '@angular/platform-browser';
import { GameListComponent } from './game-list.component';
import { GameService } from './game.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { D3Service } from 'd3-ng2-service'; 

@NgModule({
    declarations: [GameListComponent, GameSubListComponent, GameDisplayComponent, GameRoundPipe, GamesFilterPipe, GameCountryPipe, CreatePlayerComponent], 
    imports: [CommonModule, FormsModule],
    providers: [
        D3Service, GameService, MapService
    ],
    exports: [GameListComponent]
})

export class GameModule {}