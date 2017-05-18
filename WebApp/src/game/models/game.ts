import { GameState } from './game-state';

export interface IGame {
    Id: AAGUID;
    CreatorPlayerId: AAGUID;
    //Options: GameOptions;
    CurrentGameState: GameState;
    HasBegun: boolean;
    IsFinished: boolean;
    EnglandPlayerId: AAGUID;
    FrancePlayerId: AAGUID; 
    ItalyPlayerId: AAGUID; 
    RussiaPlayerId: AAGUID; 
    AustriaPlayerId: AAGUID; 
    TurkeyPlayerId: AAGUID; 
    GermanyPlayerId: AAGUID; 
    //Winners: Country[];
}