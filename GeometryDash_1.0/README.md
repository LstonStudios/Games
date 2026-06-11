# Geometry Dash 1.0

A faithful recreation of Geometry Dash 1.0 in Unity/C#, featuring the original gameplay mechanics, levels, and customization options from the classic release.

## 🎮 Features

### Gameplay & Mechanics
- **Gamemodes**: Cube and Ship modes
- **Hazards**: Basic spikes
- **Physics Objects**: Yellow Jump Pads and Yellow Jump Orbs
- **Portals**: Upside-Down Portals
- **Practice Mode**: With checkpoints
- **Difficulties**: Easy, Normal, Hard, Harder, and Insane

### 🛠️ Level Editor
- **Object Limit**: 36 buildable objects (layout blocks and slabs)
- **Triggers**: Color Triggers (background/ground colors) and transition/fade triggers
- **Global Options**: Start position options and Trail toggle on/off

### 🎵 Main Levels (7 Original Tracks)
1. **Stereo Madness** by ForeverBound
2. **Back on Track** by DJVI
3. **Polargeist** by Step
4. **Dry Out** by DJVI
5. **Base After Base** by DJVI
6. **Can't Let Go** by DJVI
7. **Jumper** by Waterflame

### 👤 Customization & Extras
- **Player Icons**: Basic unlockable cube icons
- **Player Colors**: Unlockable primary and secondary colors
- **Progression**: Base stat tracking and achievement unlocks

## 📁 Project Structure

```
GeometryDash_1.0/
├── Assets/
│   ├── Scripts/
│   │   ├── Core/
│   │   │   ├── GameManager.cs
│   │   │   ├── PlayerController.cs
│   │   │   └── LevelManager.cs
│   │   ├── Gameplay/
│   │   │   ├── Player.cs
│   │   │   ├── Cube.cs
│   │   │   ├── Ship.cs
│   │   │   ├── Physics.cs
│   │   │   └── Collision.cs
│   │   ├── Objects/
│   │   │   ├── Hazards/
│   │   │   ├── Portals/
│   │   │   ├── JumpObjects/
│   │   │   └── Triggers/
│   │   ├── Editor/
│   │   │   ├── LevelEditor.cs
│   │   │   ├── ObjectPlacer.cs
│   │   │   └── TriggerSystem.cs
│   │   ├── UI/
│   │   │   ├── MainMenu.cs
│   │   │   ├── LevelSelect.cs
│   │   │   └── Customization.cs
│   │   └── Data/
│   │       ├── PlayerData.cs
│   │       ├── LevelData.cs
│   │       └── AchievementSystem.cs
│   ├── Levels/
│   ├── Prefabs/
│   ├── Scenes/
│   ├── Art/
│   └── Audio/
└── ProjectSettings/
```

## 🚀 Quick Start

1. Clone the repository
2. Open the project in Unity (2022.3 LTS or later recommended)
3. Navigate to `Assets/Scenes/MainMenu.unity`
4. Press Play to start

## 📝 License

This is a fan project created for educational purposes.

---

**Version**: 1.0  
**Platform**: PC (Windows/Mac/Linux)  
**Engine**: Unity 2022.3+  
**Language**: C#
