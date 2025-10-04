# Personal Opinions & Suggestions

## 1. UI vs Gameplay Controls
- Everything should have been UI-based since all cells are directly interacted with the mouse instead of an in-game character.  
- This way, player controls would have been easier, and it would scale with canvas for different screen resolutions.

## 2. Prefab Usage
- Each item being its own prefab is unnecessary since they initially only have a `SpriteRenderer` component.  
- Unless each item has different animations or unique scripts, a single prefab is enough.  
- In fact, you may not need a prefab at all. Just add the sprite through code.

## 3. Scene Structure
- The demo is too short right now, but if extended, there should be a separate Main Menu and a Gameplay scene.  
