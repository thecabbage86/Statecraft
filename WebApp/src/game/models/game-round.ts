import { Season } from "game/enums/season";
import { Phase } from "game/enums/phase";

export interface GameRound {
    Season: Season;
    Phase: Phase;
    Year: number;
}