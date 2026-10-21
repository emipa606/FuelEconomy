# Copilot Instructions: Fuel Economy (Continued) Mod

## Overview and Purpose
The "Fuel Economy (Continued)" mod is a continuation of the original Fuel Economy mod created by Uuugggg, now maintained in their memory. The primary goal of this mod is to enhance the fuel efficiency mechanics of Transport Pods in RimWorld by taking into account the mass of the cargo being transported. This mod aims to provide players with more strategic choices concerning the logistics and fuel management of Transport Pods.

## Key Features and Systems

- **Dynamic Fuel Consumption**: Transport Pods now use fuel relative to the mass of the cargo. An empty pod consumes only 50% of the fuel required for a full pod, allowing for further travel on less fuel.
- **Customizable Pod Weight**: Players can adjust the pod's weight and fuel consumption settings to balance the game to their liking or create unique challenges.
- **Extended Maximum Range Option**: The default maximum travel range in vanilla RimWorld is 66 tiles. The mod allows players to extend this range by adjusting fuel consumption parameters.
- **Small Transport Pod**: Introduces a new, smaller pod with a carrying capacity of 20kg—ideal for transporting small amounts of cargo more efficiently. It consumes 1/5 of the fuel and requires 1/4 of the steel compared to regular pods.
- **Built-in Error Checking**: The mod includes mechanisms to check for compatibility with other mods and detect configuration errors.

## Coding Patterns and Conventions

- **C# Coding Standards**: The mod follows standard C# conventions such as PascalCase for class names and methods, and camelCase for variables. Clear and concise method naming enhances code readability.
- **Modular Code Structure**: Each functionality aspect is encapsulated in separate C# files and classes to promote maintainable and extendable code.
- **Error Handling**: Includes error detection and helpful logs to aid debugging.

## XML Integration

- **XML Defining**: The mod leverages XML for defining new game assets and adjusting existing properties, particularly for ThingDefs such as the small transport pod.
- **Compatibility Definitions**: XML files contain dependencies like `brrainz.harmony` to ensure mod compatibility and integration with RimWorld’s modding infrastructure.
- **Transparency**: XML configuration files are clear and well-documented to facilitate easy adjustments by modders or players interested in tweaking definitions.

## Harmony Patching

- **Harmony Integration**: The mod uses Harmony to patch RimWorld’s base methods. This allows for seamless integration with existing game mechanics without altering core files.
- **Postfix Methods**: Harmony patches frequently include postfix methods to append or modify the behavior of game functions related to fuel consumption and transport pod logic.
- **Maintainability**: By using Harmony, the mod remains flexible and easier to update alongside new versions of RimWorld or other mods.

## Suggestions for Copilot

- **Error Detection**: Suggest code snippets for extended error detection in transport logic to prevent crashes when multiple mods are active.
- **Fuel Calculation**: Provide algorithms to efficiently calculate dynamic fuel usage based on a pod's cargo mass.
- **XML Tools**: Recommend tools or extensions for easy editing of the XML definitions to simplify adjustment and testing processes.
- **Optimization Tips**: Offer code optimization tips to help improve performance, especially when calculating transport pod routes and resource allocation.

By adhering to these guidelines, Copilot can effectively assist in maintaining, expanding, and refining the Fuel Economy (Continued) mod to enhance player experience and maintain stability across various game setups.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

