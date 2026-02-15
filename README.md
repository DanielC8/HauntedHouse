# Haunted House

A narrative-driven horror game built in Unity. The player explores a haunted house environment, progressing through dialogue while the environment reacts around them — furniture bounces off walls, lights flicker, a ghost bobs up and down, and a grave rocks back and forth. The final dialogue triggers a jumpscare. Built during CMU's NHSGA in the summer of 2025.

## Features

- **Dialogue System:** Player-paced narrative progression with previous/next controls, scene transitions on completion, and a jumpscare trigger on the final line.
- **Ghost Movement:** A ghost that bobs vertically within a set range, with an animation that plays during the jumpscare.
- **Furniture Physics:** Bed, table, and sofa move in random directions, bounce off walls using reflection vectors, and flash red on collision with the house.
- **Light Flickering:** Lights randomly turn on and off at variable intervals using coroutines, with matching emissive material changes.
- **Grave Animation:** A grave that rocks back and forth along the Z-axis.
- **Roof Control:** Player can raise and lower the roof using arrow keys.
- **Free Camera:** WASD + Space/Shift movement with middle-mouse-button look rotation.
- **Audio Management:** Singleton `SoundManager` that persists across scenes, handling button SFX, jumpscare SFX, heartbeat, and background music.

## Project Structure

```
Assets/
├── Scenes/
│   ├── StartScene.unity          # Menu screen (Play/Exit buttons)
│   ├── MainScene.unity           # Main haunted house gameplay
│   └── ExitScene.unity           # End screen after dialogue completes
├── Scripts/
│   ├── ButtonController.cs       # Play and Exit button handlers
│   ├── CameraMovement.cs         # Free camera movement and rotation
│   ├── DialogueUI.cs             # Dialogue progression and scene transitions
│   ├── FurnitureMovement.cs      # Random movement and bounce physics for furniture
│   ├── GhostMovement.cs          # Vertical bobbing motion for the ghost
│   ├── GraveMovement.cs          # Rocking rotation for the grave
│   ├── LightController.cs        # Random light flickering with coroutines
│   ├── RoofMovement.cs           # Player-controlled roof movement
│   └── SoundManager.cs           # Singleton audio manager (persists across scenes)
├── Animation/
│   ├── Ghost.controller          # Ghost animation controller
│   └── GhostScare.anim           # Jumpscare animation clip
├── Audio/
│   ├── Bell.wav                  # Button click SFX
│   ├── Jumpscare.wav             # Jumpscare SFX
│   ├── Heartbeat.wav             # Heartbeat ambience
│   └── Music.wav                 # Background music
├── Prefabs/
│   ├── Ghost.prefab
│   ├── Grave.prefab
│   ├── Bed.prefab
│   ├── Table.prefab
│   └── Sofa.prefab
├── Materials/                    # Wall, Floor, Roof, Door, Ghost, furniture materials, etc.
├── Fonts/                        # Horror and fantasy themed fonts
└── Imported Assets/              # External FBX models (windows, frames, grave, street lights)
```

## How It Works

1. **StartScene:** The player is presented with Play and Exit buttons. Clicking Play loads the MainScene.
2. **MainScene:** The haunted house environment is active. Furniture moves randomly and bounces off walls. Lights flicker. The ghost bobs up and down. The grave rocks side to side. The player navigates the scene with free camera controls.
3. **Dialogue:** The player clicks through dialogue lines. On the second line, a heartbeat audio starts playing. On the final line, the ghost jumpscare animation and sound trigger.
4. **ExitScene:** After advancing past the last dialogue line, the ExitScene loads.

## Controls

| Key | Action |
|-----|--------|
| W / A / S / D | Move camera forward / left / back / right |
| Space | Move camera up |
| Left Shift | Move camera down |
| Middle Mouse + Mouse | Rotate camera |
| Up Arrow | Raise roof |
| Down Arrow | Lower roof |
| Left / Right UI Buttons | Navigate dialogue |

## Scripts

### `ButtonController.cs`
- `StartScene()`: Plays button SFX and loads MainScene.
- `ExitGame()`: Plays button SFX and quits the application.

### `CameraMovement.cs`
- Reads WASD/Space/Shift input for directional movement.
- `CamOrbit()`: Rotates camera based on mouse input when middle mouse button is held.

### `DialogueUI.cs`
- `PrevDialogue()`: Decrements dialogue index and updates displayed text.
- `NextDialogue()`: Increments dialogue index, updates text, triggers heartbeat at index 1, triggers jumpscare on the last line, and loads ExitScene when dialogue is exhausted.

### `FurnitureMovement.cs`
- Starts with a random normalized direction vector.
- Moves each frame using `Translate`.
- `OnCollisionEnter()`: Reflects direction off collision normal. Starts `TurnRed` coroutine on house collisions.
- `TurnRed()`: Briefly flashes all child renderers red with 0.7 alpha, then restores original colors.

### `GhostMovement.cs`
- Moves the ghost vertically between Y 1.3 and Y 3.4.
- Reverses direction at bounds.

### `GraveMovement.cs`
- Rotates the grave on the Z-axis between -40 and +30 degrees.
- `FixAngle()`: Converts angles above 180 to negative equivalents for proper comparison.

### `LightController.cs`
- `FlickeringLight()`: Coroutine that toggles the Light component and emission color on/off at random intervals (0.01s to 1s).

### `RoofMovement.cs`
- Moves the roof up/down based on Up/Down arrow key input.
- Clamps minimum Y position to prevent the roof from clipping below the house.

### `SoundManager.cs`
- Singleton pattern with `DontDestroyOnLoad`.
- `PlayButton()`, `PlayJumpscare()`: One-shot audio clips.
- `PlayMusic()`, `StopMusic()`: Background music controls.
- `PlayHeartbeat()`, `StopHeartbeat()`: Heartbeat audio controls via a separate AudioSource.

## Requirements

- Unity 6 (6000.0.51f1)
- Universal Render Pipeline (URP)

## Setup

1. Clone the repository.
2. Open the project in Unity 6.
3. Open `Assets/Scenes/StartScene.unity`.
4. Press Play.
