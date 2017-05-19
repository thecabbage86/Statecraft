import { PipeTransform } from '@angular/core';
import { Component, OnInit, Input } from '@angular/core';
import { IGameResponse } from "game/models/game-response";

@Component({
    selector: "game-sublist",
    templateUrl: 'game-sublist.component.html'
    // styleUrls: ['game-list.component.css']
})
export class GameSubListComponent {
    @Input() listName: string;
    @Input() gameResponse: IGameResponse;
    @Input() filter: PipeTransform;
}