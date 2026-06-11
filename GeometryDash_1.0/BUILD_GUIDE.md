# Geometry Dash 1.0 - Build & Distribution Guide

## Building for PC (Windows/Mac/Linux)

### Step 1: Configure Build Settings
1. Go to `File` → `Build Settings`
2. Select target platform:
   - **Windows**: Select `Windows` → `x86_64`
   - **Mac**: Select `Mac OS X`
   - **Linux**: Select `Linux`
3. Click `Switch Platform` if needed

### Step 2: Verify Scene Order
Ensure scenes are in correct build order:
```
0. MainMenu
1. Level_0 (Stereo Madness)
2. Level_1 (Back on Track)
3. Level_2 (Polargeist)
4. Level_3 (Dry Out)
5. Level_4 (Base After Base)
6. Level_5 (Can't Let Go)
7. Level_6 (Jumper)
8. LevelSelect
```

### Step 3: Player Settings
1. In Build Settings, click `Player Settings`
2. Set:
   - **Product Name**: "Geometry Dash 1.0"
   - **Company Name**: "Your Company"
   - **Default Icon**: (upload your icon)
   - **Resolution**: 1280x720
   - **Fullscreen Mode**: Windowed

### Step 4: Build the Game
1. In Build Settings, click `Build`
2. Choose output folder (e.g., `Build/`)
3. Choose filename: `GeometryDash_1.0`
4. Wait for build to complete

### Step 5: Test the Build
1. Navigate to the build output folder
2. Run the executable
3. Test:
   - Game starts on main menu
   - Levels load correctly
   - All mechanics work
   - No console errors

---

## Performance Optimization

### Memory Optimization
- Use sprite atlasing (combine sprites into single texture)
- Remove unused assets
- Compress audio files to .ogg format

### Rendering Optimization
- Set target frame rate: 60 FPS
- Use OnDemand rendering if possible
- Limit particle effects

### Physics Optimization
- Minimize active Rigidbodies
- Use static colliders for ground
- Cache physics queries

### Build Size
- Typical build size: 50-150 MB
- Remove unnecessary packages (e.g., TextMesh Pro features)
- Use WebGL for web deployment

---

## Distribution

### Itch.io
1. Create account at https://itch.io
2. Create new game project
3. Upload Windows build
4. Add game description and screenshots
5. Set as free or paid
6. Publish

### GitHub Releases
1. Go to your GitHub repository
2. Click `Releases`
3. Click `Create a new release`
4. Tag version: `v1.0`
5. Upload build files
6. Add release notes
7. Publish

### Steam (Commercial)
- Register as developer
- Submit game for review
- Set pricing and store page
- Upload builds for distribution

---

## System Requirements

**Minimum:**
- OS: Windows 7 / Mac OS 10.11 / Ubuntu 16.04
- CPU: Intel Core i5 or equivalent
- RAM: 4 GB
- Graphics: Integrated graphics
- Storage: 200 MB available space

**Recommended:**
- OS: Windows 10+ / Mac OS 10.13+ / Ubuntu 18.04+
- CPU: Intel Core i7 or equivalent
- RAM: 8 GB
- Graphics: Dedicated GPU
- Storage: SSD recommended

---

## Version Management

Tag releases on GitHub:
```bash
git tag -a v1.0 -m "Initial Geometry Dash 1.0 Release"
git push origin v1.0
```

Update version in `ProjectSettings`:
- Bundle Version: 1.0.0
- Bundle Version Code: 1

