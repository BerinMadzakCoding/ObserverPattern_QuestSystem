# Scalable Quest System using the Observer Pattern

A decoupled, modular quest system built in **Unity 6** utilizing the **Observer Design Pattern** and **ScriptableObjects**. This repository is the complete companion project for the technical tutorial published on TODO.

The architecture demonstrates how to separate player and world actions (*Subjects*) from quest progression and UI tracking (*Observers*) using centralized C# events, completely eliminating tight coupling.

## Key Features

* **Decoupled Architecture:** Features a centralized `EventManager` utilizing C# `Action` delegates so gameplay systems never directly depend on the quest logic.
* **ScriptableObject-Driven Quests:** Uses abstract `QuestData` architecture to allow designers to create new quest types (Kill, Collect, Deal Damage) natively inside the Unity Editor.
* **Runtime Data Isolation:** Implements runtime asset cloning (`Instantiate`) to prevent dynamic runtime variables (like current progress) from permanently modifying disk-based source assets.
* **Concurrent Quest Tracking:** A centralized `QuestManager` manages a dynamic list of multiple active concurrent quests simultaneously up to a configurable cap.
* **Dynamic Unique IDs:** Leverages system `Guid` generation to unique-index runtime instances, avoiding ID collisions even if duplicate quest types are accepted.

## Tech Stack & Version

* **Engine:** Unity 6000.3.17f1 (or newer)
* **Language:** C#

## Repository Branches

To make the learning experience seamless, this repository is split into two distinct states:
* **`main`**: The fully finished, polished project featuring the complete quest logic, UI panels, event handling, and sample quest types.
* **`StartingProject`**: The baseline sandbox setup containing only the character controller, basic enemies, and environmental interactables—ideal if you want to follow the tutorial step-by-step.

To clone the repository and switch to the starter branch to follow along:
```bash
git clone https://github.com/BerinMadzakCoding/ObserverPattern_QuestSystem
cd ObserverPattern_QuestSystem
git checkout StartingProject
```