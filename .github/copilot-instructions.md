# GitHub Copilot Instructions for Fuel Economy (Continued) Mod

## Mod Overview and Purpose

Fuel Economy (Continued) is a mod for the game RimWorld that enhances the efficiency of Transport Pods based on their cargo load. It provides players an improved system to manage fuel consumption in relation to the weight of transported goods, thereby offering more strategic gameplay options. This mod pays homage to the original creator, Uuugggg, and continues the development of their work.

## Key Features and Systems

- **Dynamic Fuel Consumption:** Transport pods consume fuel based on their load. An empty pod uses 50% less fuel compared to a fully loaded one, enabling farther travel with lighter loads.
- **Adjustable Pod Weight:** Customize the pod's weight limits for a less or more challenging experience.
- **Extended Range Option:** Allows further travel by consuming additional fuel, effectively expanding the vanilla game’s maximum range of 66 tiles.
- **Small Transport Pod:** This alternative pod holds up to 20kg, ideal for transporting lighter cargos more efficiently, using 1/5 of the fuel, and requiring 1/4 of the steel compared to a standard pod.
- **Vanilla Range Limitation:** This feature limits the range to match vanilla settings for balance.

## Coding Patterns and Conventions

When contributing to this mod, follow these conventions:

- **Namespace Organization:** Use meaningful namespaces relevant to the mod’s features.
- **Class Design:** Employ static classes for utility functions and public classes for mod settings.
- **Method Naming:** Methods should be descriptive, using PascalCase for public methods and camelCase for private methods.
- **Commenting:** Provide detailed comments for complex logic, and consider XML documentation for public methods.

## XML Integration

The mod uses XML for defining various game mechanics, such as transport pod specifications. When creating or updating XML files, ensure:

- Use correct XML syntax and RimWorld’s schema for defining elements.
- Maintain consistency with existing XML files for ease of integration.
- If modifying existing data, make incremental changes and test thoroughly.

## Harmony Patching

Harmony patches are central to modding in RimWorld, enabling controlled changes to the game’s core mechanics:

- **Create static patch classes** to isolate different Harmony patches.
- Use targeted postfix and prefix methods to alter execution flow without breaking base game functionality.
- Document patches with comments explaining the purpose and expected outcome of the patch.

## Suggestions for Copilot

To leverage GitHub Copilot effectively for this project, consider these suggestions:

- **Function Definitions:** Use Copilot to generate boilerplate code for patch classes and methods based on existing patterns.
- **XML Elements:** Prompt Copilot to create new XML structure when extending mod features.
- **Cross-File Refactoring:** Use Copilot’s suggestions to refactor code and maintain consistency across the codebase.
- **Automated Testing:** Employ Copilot to help with writing unit tests for custom logic, especially in `Settings` and `LaunchableFuel` classes.

Following these guidelines ensures that the Fuel Economy (Continued) mod remains consistent, with a clean and maintainable codebase for future updates.
