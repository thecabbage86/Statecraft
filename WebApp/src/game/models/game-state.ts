import { GameMap } from './game-map';
import { GameRound } from './game-round';

export interface GameState{
    Round: GameRound;
    Map: GameMap; 
}