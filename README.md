# Scalable Quest System using the Observer Pattern

A decoupled, modular quest system built in **Unity 6** using the **Observer Design Pattern** and **ScriptableObjects**. This repository is the complete companion project for the technical tutorial published on [Code & Architecture](https://codeandarchitecture.hashnode.dev/creating-a-robust-quest-system-in-unity-using-the-observer-pattern).

The architecture separates player and world actions (*Subjects*) from quest progression and UI tracking (*Observers*) using a centralized C# event bus, eliminating tight coupling between gameplay systems and quest logic.

> You are looking at the **finished, complete project**. Want to build it yourself step by step? Check out the [`StartingProject`](https://github.com/BerinMadzakCoding/ObserverPattern_QuestSystem/tree/StartingProject) branch and follow along with the tutorial.

## Key Features

* **Decoupled Architecture** - A centralized `EventManager` (itself a Singleton) exposes C# `Action` delegates, so gameplay systems like `EnemyController` or `Coin` never directly reference quest logic.
* **ScriptableObject-Driven Quests** - An abstract `QuestData` base class lets designers create new quest types (`KillQuestData`, `CollectQuestData`, `DealDamageQuestData`) natively inside the Unity Editor, no code changes required.
* **Runtime Data Isolation** - Active quests are runtime-instantiated clones of their source assets, so progress tracked during play never overwrites the on-disk `ScriptableObject`.
* **Concurrent Quest Tracking** - `QuestManager` maintains a list of multiple simultaneously active quests, capped at a configurable maximum.
* **Dynamic Unique IDs** - Each runtime quest instance is tagged with a `Guid`, preventing ID collisions even when duplicate quest types are active at once.

## Tech Stack & Version

* **Engine:** Unity 6000.3.17f1 (or newer)
* **Language:** C#

## Getting Started

1. Clone the repository and open it with Unity Hub (it will prompt you to install `6000.3.17f1` if needed).
2. Open the `RPG` scene under `Assets/Scenes`.
3. Press Play. Collect coins and pumpkins, fight enemies, and talk to the Questgiver to pick up quests - the Quest Board UI updates live as you make progress.

```bash
git clone https://github.com/BerinMadzakCoding/ObserverPattern_QuestSystem
cd ObserverPattern_QuestSystem
```

## Repository Branches

* **`main`** *(you are here)* - the finished project: full quest logic, UI panels, event handling, and three sample quest types.
* **[`StartingProject`](https://github.com/BerinMadzakCoding/ObserverPattern_QuestSystem/tree/StartingProject)** - the baseline sandbox containing only the character controller, basic enemies, and environmental interactables. Use this if you want to implement the quest system yourself by following the tutorial.