# BuildLab API Endpoints

Base URL for local development:

```txt
http://localhost:5153
```

BuildLab exposes a simple REST API for managing game build plans, team setups and strategy notes.

## Build Plan model

Example response object:

```json
{
  "id": 1,
  "name": "Jinx ADC Crit Build",
  "game": "League of Legends",
  "contentType": "Ranked",
  "role": "ADC",
  "scale": "5v5",
  "status": "Testing",
  "coreElements": "Kraken Slayer, Infinity Edge, Runaan's Hurricane, Bloodthirster",
  "notes": "Focus on safe laning, scaling and front-to-back teamfights.",
  "createdAt": "2026-05-26T21:30:00Z"
}
```

## Endpoints

### Get all build plans

```http
GET /api/buildplans
```

Returns all saved build plans.

### Get build plan by ID

```http
GET /api/buildplans/{id}
```

Example:

```http
GET /api/buildplans/1
```

### Create build plan

```http
POST /api/buildplans
```

Example request body:

```json
{
  "name": "Albion ZvZ Engage Tank",
  "game": "Albion Online",
  "contentType": "ZvZ",
  "role": "Engage Tank",
  "scale": "50-100 players",
  "status": "Draft",
  "coreElements": "Grovekeeper, Judicator Armor, Knight Helmet, Hunter Shoes",
  "notes": "Wait for the caller's command and engage only after enemy defensives are forced."
}
```

### Update build plan

```http
PUT /api/buildplans/{id}
```

Updates an existing build plan.

### Delete build plan

```http
DELETE /api/buildplans/{id}
```

Deletes a build plan by ID.

## Current MVP limitations

- Data is stored in memory.
- Data resets after restarting the backend.
- There is no authentication yet.
- There is no database yet.
- Game-specific templates are planned for future versions.