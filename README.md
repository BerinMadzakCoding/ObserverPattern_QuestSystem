# Scalable Quest System using the Observer Pattern - Starting Project

This is the **starting branch** for the companion project to the tutorial [Creating a Robust Quest System in Unity Using the Observer Pattern](https://codeandarchitecture.hashnode.dev/creating-a-robust-quest-system-in-unity-using-the-observer-pattern). It's a bare-bones RPG sandbox with **no quest system yet** - you'll build one from scratch by following the tutorial, using the Observer pattern and C# events to keep it fully decoupled from existing gameplay code.

> Want to see the finished result first, or just grab the working code? Switch to the [`main`](https://github.com/BerinMadzakCoding/ObserverPattern_QuestSystem) branch instead.

## What's Already Here

The sandbox is intentionally simple so you can focus on the quest system itself:

* **`PlayerController.cs`** - movement and attacking
* **`EnemyController.cs`** + **`EnemyHealthUI.cs`** - basic enemy AI; `EnemyHealthUI` already demonstrates the Observer pattern by listening to the enemy's health changes, and is used as a reference example in the tutorial
* **`EnemySpawner.cs`** - respawns enemies after they die
* **`Coin.cs`** / **`Pumpkin.cs`** - two collectible types, picked up differently (walk-over vs. interact)
* **`InteractManager.cs`** / **`IInteractable.cs`** - a basic interaction system
* **`Questgiver.cs`** - present in the scene but intentionally unimplemented; this is where you'll wire up quest assignment

## What You'll Build

Following the tutorial, you'll add:

* An `EventManager` (Singleton) to centralize gameplay events
* A `CollectibleType` enum and events for enemy kills, damage dealt, and collectibles picked up
* An abstract `QuestData` architecture with concrete quest types (Kill, Collect, Deal Damage)
* A `QuestManager` to track active quests
* `QuestUI` / `QuestBoardUI` to display quest progress on screen

## Tech Stack & Version

* **Engine:** Unity 6000.3.17f1 (or newer)
* **Language:** C#

## Getting Started

```bash
git clone https://github.com/BerinMadzakCoding/ObserverPattern_QuestSystem
cd ObserverPattern_QuestSystem
git checkout StartingProject
```

Open the project with Unity Hub, open the `RPG` scene under `Assets/Scenes`, and follow along with the [tutorial](https://codeandarchitecture.hashnode.dev/creating-a-robust-quest-system-in-unity-using-the-observer-pattern) from the top.

## Repository Branches

* **`StartingProject`** *(you are here)* - the baseline sandbox: character controller, basic enemies, and environmental interactables only.
* **[`main`](https://github.com/BerinMadzakCoding/ObserverPattern_QuestSystem)** - the fully finished project with complete quest logic, UI panels, event handling, and sample quest types.