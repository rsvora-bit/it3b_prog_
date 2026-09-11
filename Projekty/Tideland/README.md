# Tideland

> **School-repository snapshot — v0.2.2 / EA-02.2.** This copy is intentionally kept here as the latest school-repo snapshot. Active development has moved to [`rsvora-bit/RUST---clon`](https://github.com/rsvora-bit/RUST---clon).

Tideland is an original procedural first-person island survival sandbox built with TypeScript, Vite, Three.js, Rapier 3D, and a DOM-based interface. It uses no extracted game assets or branding.

## Run

```bash
npm install
npm run dev
```

Production checks:

```bash
npm test
npm run build
```

## Controls

- `WASD` move, mouse look, `Shift` sprint, `Space` jump, `C` or `Ctrl` crouch
- `E` interact, left click gather/use, `1–6` select the quick belt
- `Tab` inventory and crafting, `B` building plan, `Q` piece, `R` rotate
- Left click places a building piece, right click cancels, `Esc` pauses
- `F3` opens development telemetry and test controls

Worlds, settings, inventory, crafting, structures, doors, dropped items, and depleted resource nodes persist locally in the browser.

## Snapshot status

This repository stays on **v0.2.2 / EA-02.2** as a stable school-project snapshot. It includes the staged loading/warm-up flow, frame-coalesced mouse input with burst protection, expanded settings, version history, the corrected yaw-based movement path, and the current world FOV implementation.

Further fixes, features and releases should be made in [`RUST---clon`](https://github.com/rsvora-bit/RUST---clon), not in this school-repository copy.

Development history up to this snapshot is recorded in [`CHANGELOG.md`](./CHANGELOG.md) and is also visible from the in-game **HISTORY** menu.
