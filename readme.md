# Super Metroid: Redesign Randomizer

Makes a randomized Super Metroid: Redesign ROM to play. 

Latest Release can be found here: https://github.com/Komarulon/smrandomizer/releases/

I recommend using a map! Even better, an item tracker.
With EmoTracker: https://emotracker.net/ , you can download the tracker I made here: https://github.com/Komarulon/SuperMetroidRedesignRandomizerEmoTracker 

## Softlocks

**YOU CAN SOFTLOCK. MAKE LOTS OF SAVES.** 

Common softlocks usually involve going to places you can't get out of. For example:
- Going to Bomb Torizo/East Crateria without Bombs (even though bombs might be there)
- Going to West Norfair via the Brinstar Glass Tube
- Checking bomb-jump maze items without bombs or hi-jump (springball), like the item underneath the Brinstar entrance elevator
- Completing Tourian without killing Bomb Torizo


## Techniques you need to know
- How to beat Vanilla Redesign
- Wall-jumping
- Infinite Bomb Jumping (in Redesign of course)
- Redesign movement
- Patience, because Gravity is probably somewhere in some dumb spot you won't like

## Options
- Randomizer Algorithm - Dessyreqt Original - uses Dessyreqt's algorithm for choosing which items to place where
- Randomizer Algorithm - Komaru Progressive - uses Komaru's naive algorithm, intended to make it more likely that the item you pick up is needed for the next item. Very opinionated, has lots of hardcoded weighting, but, should work better for Redesign. "Naive" because he didn't do any research, just went and implemented an idea.
- More Likely Early Bombs - Redesign is very difficult without bombs early on (easy to softlock!). This makes it more likely to get bombs earlier
- Prevent Common Softlocks - Include a patch that prevents some easy softlocks, such as morph lock tunnels
- Fast Fanfares - Makes it so picking up items is faster. This does incentivise you to pick up 2-packs of missiles more often, which may not be desired
- Rotating Saves - When you save, it will save to the next "Samus" slot, (e.g. save in Samus A, Samus B, Samus C, then Samus A again). If enabled, when restarting, **make sure you select the correct file!** 

## Redesign Randomizer history
- Drewseph made Super Metroid: Redesign - https://drewseph.zophar.net/
- Dessyreqt made the base Super Metroid Randomizer
- Audraxys made the randomizer work for Super Metroid: Redesign, with patches for things like "start with wall-jump" some other nice things
- Audraxys programmed in all the item location addresses, named them, and wrote the logic for each item's pickup
- Audraxys' laptop was stolen :( and the randomizer tool was lost
- However, Audraxys uploaded RomLocationsSpeedrunner.cs with all the item locations and logic, so we could recover that. Still, the above patches were lost.
- The solution? One of the previous randomized roms would have all the patches! So, this randomizer now uses an old randomized redesign ROM Audraxys generated, then re-randomizes on top of that.

## Credits

Thank you so much Audraxys for everything you did for this project!

Thank you InsaneFirebat and the SMConst community for the save rotation patch!

Thank you ironrusty for fixes with the address locations!

Thank you neen for help and the short message boxes patch! neen has continued work on the Guardians-As-Items work as well!
