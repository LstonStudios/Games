# Geometry Dash 1.0 - Level Creation Guide

## Creating Your First Level

### Step 1: Create a New Scene
1. Right-click in `Assets/Scenes/`
2. Select `Create` → `Scene`
3. Name it `Level_0` (for Stereo Madness)
4. Save it

### Step 2: Add Core Components

#### Add a Ground Platform
1. Right-click in the scene hierarchy → `2D Object` → `Sprites` → `Square`
2. Rename it to `Ground`
3. In the Inspector:
   - **Transform**: Position (0, -3), Scale (20, 1)
   - **Tag**: Set to `Ground`
   - **Layer**: Set to `Ground`
4. Add Component → `Box Collider 2D`
5. Add Component → `Sprite Renderer`
   - Set color to gray or brown

#### Add the Player (Cube)
1. Right-click in hierarchy → `2D Object` → `Sprites` → `Square`
2. Rename to `Player`
3. In the Inspector:
   - **Transform**: Position (0, -2), Scale (0.5, 0.5)
   - **Tag**: Set to `Player`
   - **Layer**: Set to `Player`
4. Add Component → `Rigidbody 2D`
   - Body Type: `Dynamic`
   - Gravity Scale: `2`
   - Constraints: Check `Freeze Rotation Z`
5. Add Component → `Box Collider 2D`
6. Add Component → `PlayerController` script
7. Set color to cyan or your preferred color

#### Add GameManager
1. Right-click in hierarchy → `Create Empty`
2. Rename to `GameManager`
3. Add Component → `GameManager` script
4. Drag it into `Assets/Prefabs/` to create a prefab

### Step 3: Add Level Objects

#### Add Spikes (Hazards)
1. Create a new sprite (2D Object → Sprites → Square)
2. Rename to `Spike`
3. Configure:
   - **Tag**: `Hazard`
   - **Layer**: `Hazards`
   - Scale: (0.3, 0.5) to make it pointy
   - Add `BoxCollider 2D` (Is Trigger: ✓)
   - Add `Spike` script
   - Color: Red
4. Position along the level path
5. Create multiple spikes as needed

#### Add Jump Pads
1. Create sprite (2D Object → Sprites → Circle)
2. Rename to `JumpPad`
3. Configure:
   - Scale: (0.5, 0.5)
   - Add `CircleCollider 2D` (Is Trigger: ✓)
   - Add `JumpPad` script
   - Set Jump Force: `15` in Inspector
   - Color: Yellow
4. Position where you want the jump mechanic

#### Add Portals
1. Create sprite (Rectangle or custom)
2. For **Upside-Down Portal**:
   - Rename to `UpsideDownPortal`
   - Add `BoxCollider 2D` (Is Trigger: ✓)
   - Add `UpsideDownPortal` script
   - Color: Purple
3. For **Ship Portal**:
   - Rename to `ShipPortal`
   - Add `BoxCollider 2D` (Is Trigger: ✓)
   - Add `ShipPortal` script
   - Check "Activate Ship Mode" in Inspector
   - Color: Orange
4. For **Cube Portal** (exit ship mode):
   - Rename to `CubePortal`
   - Add `BoxCollider 2D` (Is Trigger: ✓)
   - Add `CubePortal` script
   - Color: Blue

#### Add Checkpoints (Practice Mode)
1. Create sprite (2D Object → Sprites → Circle)
2. Rename to `Checkpoint_1`
3. Configure:
   - Scale: (0.3, 0.3)
   - Add `CircleCollider 2D` (Is Trigger: ✓)
   - Add `Checkpoint` script
   - In Inspector: Set Checkpoint Index: `1`
   - Color: White
4. Repeat for multiple checkpoints

#### Add Level Finish
1. Create sprite (2D Object → Sprites → Star or custom)
2. Rename to `LevelFinish`
3. Configure:
   - Scale: (1, 1)
   - Add `BoxCollider 2D` (Is Trigger: ✓)
   - Add `LevelFinish` script
   - Color: Gold/Yellow
4. Place at the end of the level

### Step 4: Add Color Triggers (Optional)
1. Create empty GameObject
2. Rename to `ColorTrigger`
3. Add `BoxCollider 2D` (Is Trigger: ✓)
4. Add `ColorTrigger` script
5. In Inspector, set:
   - Background Color: (choose a color)
   - Ground Color: (choose a color)
6. Position where color should change

### Step 5: Layout Design Tips

**Easy Levels (1-2):**
- Straight paths with basic platforms
- Few hazards
- Large jumps between sections
- Simple spike placement

**Normal Levels (3-4):**
- Curved paths
- More hazards
- Introduction to portals
- More challenging jumps

**Hard Levels (5-6):**
- Complex layouts
- Frequent hazard placement
- Multiple portal transitions
- Tight precision jumps

**Insane Levels (7):**
- Intricate patterns
- Minimal safe zones
- Portal sequences
- Extreme precision required

### Step 6: Test Your Level
1. Set this scene as the active scene
2. Press Play
3. Test all mechanics:
   - Player movement
   - Spike collision
   - Jump pads
   - Portals
   - Checkpoints
   - Level finish trigger
4. Adjust difficulty as needed

### Step 7: Add to Build Settings
1. Go to `File` → `Build Settings`
2. Drag `Level_0` into the Scenes In Build list
3. Ensure scenes are in correct order:
   - Scene 0: MainMenu
   - Scene 1: Level_0
   - Scene 2: Level_1
   - etc.

---

## Level Structure Template

```
Level_0 (Stereo Madness)
├── Ground
├── Player
├── GameManager
├── Obstacles
│   ├── Spike_1
│   ├── Spike_2
│   ├── Spike_3
│   └── JumpPad_1
├── Portals
│   └── UpsideDownPortal_1
├── Triggers
│   └── ColorTrigger_1
├── Checkpoints
│   ├── Checkpoint_1
│   ├── Checkpoint_2
│   └── Checkpoint_3
└── LevelFinish
```

---

## Quick Reference: Object Colors

| Object | Color | RGB |
|--------|-------|-----|
| Ground | Gray | (128, 128, 128) |
| Player | Cyan | (0, 255, 255) |
| Spike | Red | (255, 0, 0) |
| Jump Pad | Yellow | (255, 255, 0) |
| Upside-Down Portal | Purple | (128, 0, 128) |
| Ship Portal | Orange | (255, 165, 0) |
| Cube Portal | Blue | (0, 0, 255) |
| Checkpoint | White | (255, 255, 255) |
| Level Finish | Gold | (255, 215, 0) |

---

## Debugging Level Issues

| Problem | Solution |
|---------|-----------|
| Player falls through floor | Add BoxCollider 2D to ground, ensure Is Trigger is OFF |
| Spikes don't kill player | Ensure Is Trigger is ON and Spike.cs is attached |
| Jump pads don't work | Set Is Trigger to ON, adjust Jump Force value |
| Portals don't activate | Check collider is set to Is Trigger: ON |
| Level won't load | Verify scene name matches Level_X format |
| Checkpoints not saving | Attach Checkpoint.cs script and set Checkpoint Index |

