# Multiplayer map load / unload
A GTA V mod that allows to load and unload the multiplayer map on singleplayer mode.
To customize the key and the initial state (MP map loaded/unloaded when starting the savegame), use the MP_MapSwitch.ini file.
You can also decide if you want to use a key or the contacts in the phone with use_phone and use_key in the .ini file.

## Installation
Place the MP_MapSwitch.dll and MP_MapSwitch.ini in the /scripts folder.

## Dependencies
- ScriptHookV
- ScriptHookVDotNet3 3.6.0 (V2.0+ of the mod)
- iFruitAddonv2 (V2.0+ of the mod)
- ScriptHookVDotNet2 (only V1.0 of the mod)

## Use
By default the script can be enabled by going to the contacts list in the phone and selecting the mod (located at the bottom of the list or near it).
If use_phone is set to true, then press the designated key in MP_MapSwitch.ini ("k" by default) to alternate between singleplayer or multiplayer map.

## Compatibility Issues
Other mods that load the MP map can cause minor bugs (like desynchronize the load variable, nothing too serious).

When MP map is loaded, it can cause visual glitches with map modifications (such as Forests of San Andreas). 
These will persist until you restart the game with the multiplayer map unloaded (in single player map mode).

Versions above 3.6.0 of ScriptHookDotNetv3 may or may not work properly, as newer versions might unload the mod when loading the map.
If that happens, version 1.0 of this mod does not have that problem, as it only uses ScriptHookVDotNet2 and can be used with newer versions of ScriptHookVDotNet3
