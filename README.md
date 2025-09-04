# Minecraft Server Wrapper

A powerful desktop application for running, managing, and enhancing vanilla Minecraft (Java Edition) servers. This will be done using C# (.NET 8.0) with WPF, and strict adherence to the Model-View-ViewModel (MVVM) pattern.  

---

## ✨ Features (Completed and Pending) 

- [x] JSON message support (fluent API + tellraw compatibility)
- [ ] Wrapping Minecraft server (.jar) process so the wrapper can:
  - Redirect the I/O from the server process.
  - Execute commands, i.e. stop, save-all, ban, etc...
- [ ] Create UI window for:
  - [ ] Editing `server.properties` file so the user can:
      - Change difficulty, seed, world name, IP, port, etc...
  - [ ] Managing automatic and manual backups.
  - [ ] Managing custom command, enable, disable custom commands.
- [ ] Implement On-Screen keyboard for ease of use.

---

## ✅ Goal of the project

- Create clean, modular architecture (View / ViewModel / Model).  
- Ensure type-safe, well-documented code.  
- Demonstrate knowledge and usage of proper MVVM pattern.

---

## 📦 Project Structure (high-level)

- TBD

---

## 🧩 JSON Message Utilities — usage

This project includes a fluent API for building Minecraft chat JSON (ready for `/tellraw`). Example usage:

Sample Calls:
```csharp
JsonMessage oTest =
    "One"
        .Color(eTextColor.Aqua)
        .Italicize()
        .Bold()
        .Obfuscate()
        .Strikethrough()
        .Underline()
        .NewLine(3)
    + "Two"
        .Color(eTextColor.Red)
    + "Three"
        .Color(eTextColor.Gray)
    + sName
        .Color(eTextColor.Black)
        .Obfuscate()
        .HoverEvent(JsonHoverEvent.ShowText("Test".Text()));
```

Sample Output:
```json
{
  "text": "",
  "extra": [
    {"text":"One\n\n\n","color":"aqua","bold":true,"italic":true,"underlined":true,"strikethrough":true,"obfuscated":true},
    {"text":"Two","color":"red"},
    {"text":"Three","color":"gray"},
    {"text":"playerName","color":"black","obfuscated":true,"hoverEvent":{"action":"show_text","contents":{"text":"Test"}}}
  ]
}
```

**Notes & implementation details**
- Minecraft JSON format requires root property `"text": ""` and `"extra": [...]` to allow for multi-color/nested messages.  
- When building segment text, use `"\n"` for newlines (not verbatim `@"\n"`).  
- Serialization options are configured to omit default values, to reduce clutter and improve performance.

---

## 🛠 Suggestions

Suggestions are welcome, feel free to add issues/feature requests as you see fit.

---
