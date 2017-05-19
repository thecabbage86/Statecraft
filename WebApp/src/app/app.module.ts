import { GameListComponent } from './../game/game-list.component';
import { GameModule } from './../game/game.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from "@angular/router";

import { AppComponent } from './app.component';
import { GameDisplayComponent } from "game/game-display.component";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    RouterModule.forRoot([
        { path: "mygames", component: GameListComponent },
        { path: "game", component: GameDisplayComponent }//, data: [{playerId: }] }
        // { path: "", redirectTo: "mygames", pathMatch: "full" },
        // { path: "**", redirectTo: "mygames", pathMatch: "full" }
    ]),
    BrowserModule,
    FormsModule,
    HttpModule,
    GameModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
