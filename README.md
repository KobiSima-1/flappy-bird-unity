name:kobi Sima

ID: 209063742

A Flappy Bird–style arcade game built from scratch in Unity 6.3 with the 2D Built-In Render Pipeline.

You control a small plane that gravity constantly pulls downward. Every tap pushes it back up, while the world scrolls past from right to left. Endless pairs of green pipes come toward you, each pair separated by a gap. Steering the plane through a gap scores one point. Touching a pipe or falling off the bottom of the screen ends the run immediately.

## How to play

| Action | Input |
| --- | --- |
| Start a run | Left mouse click or `Space` |
| Fly upward | Left mouse click or `Space` |
| Restart after a crash | Click the **Restart** button |
| Close the game | Click the **Quit** button |

The plane never moves horizontally — the world moves instead. Your only control is *when* to flap, and the whole challenge comes from timing those taps so the plane lines up with the next gap.

## The start screen

![Start screen](images/start-screen.png)

The screen shows your all-time **High Score**, which is written to disk when you beat it and survives closing the game entirely. A **Quit** button closes the application.

Clicking anywhere on the screen — or pressing `Space` — starts the run. Clicking the Quit button does *not* start the run; the game checks whether the pointer is over a UI element before treating a click as a flap.

## Core gameplay: flying through the pipes

![Flying between the pipes](images/gameplay.png)

This is the heart of the game. Pipes arrive in pairs: one hanging from the top of the screen, one rising from the bottom, with a gap between them. The vertical position of that gap is randomised for every pair, so no two runs are the same. A new pair spawns on a fixed timer just off the right edge of the screen and is destroyed once it scrolls out of view on the left.

Your objective is to guide the plane cleanly through each gap without touching anything. The run ends the moment the plane touches the body or lip of any pipe, or falls below the bottom of the screen.

Clouds drift across the background at a slower speed than the pipes. They are purely decorative and carry no collider, so the plane passes straight through them — the speed difference creates a simple parallax effect that adds depth to the scene.

## The score counter

The number at the top of the screen is your live score: how many pipe pairs you have cleared in the current run. In the screenshot above the plane has cleared three pairs, so it reads `3`.

A point is awarded by an invisible trigger zone placed just past the right edge of each pipe pair. Positioning it there rather than in the centre of the gap means the point is only credited once the plane has fully passed the obstacle — if a crash and a scoring event would otherwise land on the same physics frame, the crash always wins.

## Crashing: the explosion

![Explosion on impact](images/gameover.png)

When the plane hits a pipe or falls off the bottom of the screen, it does not simply stop. The sprite is hidden and a burst of explosion particles erupts from the point of impact, as shown above.

At the same moment the whole world freezes: pipes and clouds stop scrolling, physics stops simulating, and the game over panel fades in over the top with your final score and a **Restart** button. The explosion is configured to animate on unscaled time, so it still plays out fully even though the rest of the game is paused.

If the run beat your previous record, the new high score is saved right then, and will be waiting on the start screen next time you play.

## Running the game

**Prebuilt (Windows):** run `Build/My Flappy Bird.exe`.

**From source:** open the project in **Unity 6.3 LTS (6000.3.22f1)** via Unity Hub, load `Assets/Scenes/SampleScene`, and press Play.

## Project structure

```
Assets/
├── Scripts/     Bird, GameManager, PipeSpawner, PipeMover,
│                ScoreZone, ScoreDisplay, HighScoreDisplay,
│                CloudSpawner, CloudMover
├── Prefabs/     PipePair, ExplosionEffect, Cloud
├── Sprites/     Game art
└── Scenes/      SampleScene
```

Built with C#, TextMeshPro for the UI, and Unity's Particle System for the explosion.

## Asset credits

All art is CC0 licensed:

- Plane, ground — [Tappy Plane](https://kenney.nl/assets/tappy-plane) by Kenney
- Clouds — [Background Elements](https://kenney.nl/assets/background-elements) by Kenney
- Explosion particles — [Smoke Particles](https://kenney.nl/assets/smoke-particles) by Kenney
- Pipes — [Flappy Bird Style Sprites](https://opengameart.org/content/flappy-bird-style-sprites) by Ian Peter
