# Platformer Small Test

A two-player, same-keyboard cooperative 2D platformer built in Unity. One of you is small and can slip through gaps the other can't. The other can grow big and strong enough to move heavy objects. Neither of you can finish the level alone.

> **Genre:** Cooperative puzzle-platformer | **Players:** 2 (local) | **Engine:** Unity 6 (Input System) | **Target resolution:** 1920×1080


---

## The Idea

Two players share a world built around a simple tension: **size matters**. A single mushroom in the level makes whoever grabs it grow big. The big player can shove heavy crates and weigh down heavy-duty pressure plates. The small player can squeeze through narrow passages that the big player can't fit through, and reach areas that open things up for the pair. Deciding who grows, and when, is the first thing you'll argue about.

There is no combat. The worst you can do to your partner is stand in their way.

## How to Play

### Goal
Collect every pickup in the level, then get **both** players to the exit. The exit won't open for one player. You both have to be standing in it.

### Losing
Fall into a hazard and you're sent back to the last checkpoint you (or your partner) activated, so nobody loses much progress. Checkpoints are shared: once either player touches one, it becomes the respawn point for everyone.

### Controls

| Action | Player 1 | Player 2 |
|--------|----------|----------|
| Move   | `W` `A` `S` `D` | Arrow keys |
| Jump   | `Space` | `Enter` |

Movement is a plain run and a single jump. There are no double jumps and no wall tricks, so every challenge comes from the level and from cooperating.

## The Two Roles

- **The small player** can pass through tight gaps and narrow tunnels that the big player can't. They scout ahead, reach hidden spots, and trigger anything a big player can't get to.
- **The big player** (whoever eats the mushroom) can push heavy boxes and activate heavy pressure plates, clearing the way for both of you.

## Cooperative Mechanics

- **Mushroom (growth):** Touching it makes a player grow to 1.5× size. It can only be taken once, so the pair has to choose who becomes the big one.
- **Heavy boxes:** These stay locked in place until a *big* player pushes against them. Small players can't budge them, but they can use them as stepping stones once they're in position.
- **Narrow passages:** Gaps sized for the small player let them reach switches, pickups and routes the big player can't.
- **Small pressure plates:** Any player standing on one activates it. The linked moving platform runs while it's held and returns when you step off.
- **Big pressure plates:** These only respond to the big player's weight. The small player has to wait, or find another way around.
- **Moving platforms:** Triggered by plates, so one player often has to stay behind to keep a route open for the other.
- **Shared checkpoints:** Progress is saved for the team, not the individual.
- **Two-player door:** The exit only triggers once both players are inside.

## Features

- Local two-player co-op with separate input maps for each player
- Tilemap-based level design spanning multiple screens, with a camera that follows the action
- Animated characters (idle, run, jump, fall) driven by Unity's Animator
- On-screen UI for pickups, status, and the win message
- Checkpoint and respawn system
- Pressure plates that visibly sink, plus moving platforms and pushable physics objects
- Scene management for restarting and moving between levels

## Project Structure

```
Assets/
└── Scripts/
    ├── PlayerController_Script.cs   # Movement, jumping, growth, respawn
    ├── GroundCheck.cs               # Trigger-based ground detection
    ├── Mushroom (MushRoomGrowm.cs)  # Growth pickup
    ├── PushableBox (HeavyBox.cs)    # Box only the big player can push
    ├── SmallPressurePlate.cs        # Activated by any player
    ├── BigPressurePlate.cs          # Activated only by the big player
    ├── MovingPlatform.cs            # Moves between start and end points
    ├── Checkpoint.cs                # Checkpoint visuals and activation
    ├── CheckpointManager.cs         # Tracks the latest checkpoint
    ├── KillVolume.cs                # Hazard zones that trigger respawn
    ├── Door.cs                      # Level exit requiring both players
    ├── EndGameWin.cs                # Final win trigger and message
    └── LevelManager.cs              # Reload / next / previous scene
```

## Running the Project

1. Install **Unity 6** (or a version that supports `Rigidbody2D.linearVelocity`) with the **Input System** package.
2. Clone the repo:
   ```bash
   git clone https://github.com/[your-username]/[your-repo].git
   ```
3. Open the project folder in Unity Hub.
4. Open `Assets/Scenes/[YourFirstScene].unity` and press **Play**.

For the intended layout, set the Game view to **1920×1080**.

## Technical Notes

- Both players use the same `PlayerController_Script`. The `isPlayer2` flag selects which generated input class (`PlayerInput` or `PlayerInput2`) drives that character.
- Ground detection uses a child trigger that counts overlapping contacts, so jumping stays reliable on uneven tiles and moving platforms.
- Pressure plates keep a count of occupants, so a plate stays down while at least one player is still standing on it.
- Interactables filter out trigger-only colliders, so sensors like the ground check don't trigger plates or doors by mistake.
- A singleton `CheckpointManager` stores the latest checkpoint so any hazard can send a player to the right place.
