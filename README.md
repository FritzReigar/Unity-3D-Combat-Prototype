# 3D Character Controller & Combat Prototype (Unity)

![Gameplay Preview](Assets/gameplay_preview.gif)

## 📌 Project Overview
A **Third-Person Character Controller** implementation in **Unity 3D (2019 LTS)**. Originally conceived as a humoristic jam project ("Silkson't"), this repository serves as a technical demonstration of **physics-based movement**, **vector mathematics**, and **camera-relative controls** implemented in C#.

## ⚙️ Technical Features

### 🕹️ Physics-Based Controller
Unlike basic transform modifications, this controller leverages the **PhysX engine**:
* **Rigidbody Movement:** Character thrust and interaction forces are applied via `Rigidbody.AddForce` (as seen in `ProCharacterMovement.cs`) for realistic physics behavior.
* **Ground Detection:** Robust ground checking using `Physics.CheckBox` in `JumpScript.cs` to prevent "coyote time" bugs and ensure precise jumping mechanics on uneven terrain.

### 📐 Vector Math & Camera Logic
Implementation of vector mathematics for intuitive controls:
* **Camera-Relative Movement:** Input vectors are transformed relative to the camera's forward vector using `Vector3.Dot` products to calculate precise rotation and translation directions.
* **Orbital Camera:** Third-person camera system (`CameraMovement.cs`) with mouse input damping and target tracking in `LateUpdate` to prevent jitter.

### ⚔️ Combat System Prototype
* **Hitbox/Hurtbox Logic:** Basic collision detection system for enemy interaction.
* **State Management:** Simple state handling for attack animations and cooldowns.

## 🛠️ Tech Stack
* **Engine:** Unity 2019.4.30f1 (LTS).
* **Language:** C# (Scripting API).
* **Techniques:** Vector Arithmetic, Quaternions, Physics Raycasting/Boxcasting.

## 📂 Project Structure
* `/Assets/Scripts`: Core C# logic (ProCharacterMovement, CameraMovement, JumpScript).
* `/Assets/Scenes`: Demo sandbox scene.

---
*Developed by Fritz Reif - Unity Developer Portfolio.*