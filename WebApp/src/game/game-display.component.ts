import { MapService } from './map.service';
import { IGame } from './models/game';
import { OnInit, Component, ElementRef } from '@angular/core';
import { GameService } from "game/game.service";
import { ActivatedRoute, Params } from "@angular/router";
import { D3, D3Service, Selection } from "d3-ng2-service";

@Component({
    templateUrl: 'game-display.component.html'
    // styleUrls: ['game-list.component.css']
})
export class GameDisplayComponent implements OnInit{
    private d3: D3;
    private parentNativeElement: any;
    private gameId: AAGUID;
    private playerId: AAGUID;
    private game: IGame;
    private errorMessage: string;

    constructor(private _gameService: GameService, private activatedRoute: ActivatedRoute, private _mapService: MapService, d3Service: D3Service, element: ElementRef){
        this.activatedRoute.queryParams.subscribe((params: Params) => {
            this.gameId = params['gameId'];
            this.playerId = params['playerId'];
            console.log(this.gameId);
        });

        this.d3 = d3Service.getD3();
        this.parentNativeElement = element.nativeElement;
    }

    ngOnInit(): void {
        this._gameService.getGameById(this.gameId)
            .subscribe(games => this.game = games.Games[0], error => this.errorMessage = <any>error);

        this._mapService.getMap().subscribe(
            data => this.createMap(this.d3, data), 
            error => this.errorMessage = <any>error );
    }

    private createMap(d3: D3, mapData: any){
        let d3ParentElement: Selection<any, any, any, any> = this.d3.select(this.parentNativeElement);
        let w: number = 600;
        let h: number = 500;

        var projection = d3.geoMercator().translate([w/2-100, h/2+500]).scale(400);
        var path = d3.geoPath(projection);

        let svg: Selection<SVGSVGElement, any, null, undefined> = d3ParentElement.append<SVGSVGElement>("svg").attr("width", w).attr("height", h);
        //var color = d3.scaleLinear().range([7,7,0,0]);//'rgb(241,238,246)', 'rgb(208,209,230)', 'rgb(166,189,219)', 'rgb(116,169,207)', 'rgb(43,140,190)', 'rgb(4,90,141)']);
        
        //create map
        svg.selectAll("path").data(mapData.features).enter().append("path")
            .attr("d", path)
            .attr("class", "territory")
            .attr("fill", "blue"); //function(d:JSON) { 
                // if(d["properties"]["GEO_ID"] === "0400000US23" || d["properties"]["GEO_ID"] === "0400000US53" || d["properties"]["GEO_ID"] === "0400000US06"
                //     || d["properties"]["GEO_ID"] === "0400000US41") {
                //     return "blue";
                // }
                // else{
                //     return "red";
                // }
            //});

        //populate map with units/ownership
        // svg.selectAll("image").data(mapData.features)//.filter(function(d){ return d["capital"].length > 0; })
        //     .enter()
        //     .append("image")
        //     //.attr("d", path)
        //     .attr("class", "landmark")
        //     .attr("xlink:href", function(d) {
        //         //if(d["properties"]["GEO_ID"] === "0400000US41"){
        //             return "../assets/goldstar.png";
        //         //}
        //     })
        //     .attr("height", 10).attr("width", 10)
        //     .attr("x", function(d){
        //         return d["capital"][0];
        //     })
        //     .attr("y", function(d){
        //         return d["capital"][1];
        //     })
        //     .attr("visibility", function(d){
        //         if(d["capital"].length === 0){
        //             return "hidden"
        //         }
        //         return "visible";
        //     })
    }
}