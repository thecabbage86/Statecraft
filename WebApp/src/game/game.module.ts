import { GameSubListComponent } from './game-sublist.component';
import { GameRoundPipe } from './../pipes/game-round';
import { FinishedGamesPipe } from "pipes/finished-games";
import { BrowserModule } from '@angular/platform-browser';
import { GameListComponent } from './game-list.component';
import { GameService } from './game.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';  

@NgModule({
    declarations: [GameListComponent, GameSubListComponent, GameRoundPipe, FinishedGamesPipe], 
    imports: [CommonModule],
    providers: [
        GameService
    ],
    exports: [GameListComponent]
})

export class GameModule {}