# CLAUDE.md -- Beatoven SDK

## Overview

Auto-generated C# SDK for [Beatoven.ai](https://www.beatoven.ai/) -- mood-aware
AI music generation for video scoring. Given a natural-language prompt, Beatoven
asynchronously composes a royalty-free track plus individual stems
(bass, chords, melody, percussion).

**No public OpenAPI spec exists** -- `openapi.yaml` was hand-written from the
official [Beatoven/public-api](https://github.com/Beatoven/public-api) repo
(`docs/api-spec.md`).

## Build & Test

```bash
dotnet build Beatoven.slnx
dotnet test src/tests/IntegrationTests/
```

## Auth

Bearer token auth (standard `Authorization: Bearer <token>`):

```csharp
var client = new BeatovenClient(apiKey); // BEATOVEN_API_KEY env var
```

Get an API key from https://sync.beatoven.ai/apiDashboard.

## Key Files

- `openapi.yaml` -- **Manually maintained** OpenAPI spec (repo root, copied by generate.sh)
- `src/libs/Beatoven/generate.sh` -- runs autosdk with `--security-scheme Http:Header:Bearer`
- `src/libs/Beatoven/Generated/` -- **never edit** auto-generated code
- `src/libs/Beatoven/Extensions/BeatovenClient.Tools.cs` -- MEAI AIFunction tools
- `src/tests/IntegrationTests/Tests.cs` -- test helper with API key auth
- `src/tests/IntegrationTests/Examples/` -- example tests (also generate docs)

## API Base URL

`https://public-api.beatoven.ai`

## Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/v1/tracks/compose` | POST | Start an asynchronous composition from a prompt; returns `task_id` |
| `/api/v1/tasks/{task_id}` | GET | Poll status; when `composed`, returns track + stem URLs |

Composition is asynchronous -- poll the task until `status` becomes `composed`
(or `failed`). Typical poll interval is ~5 seconds.

## Request / Response Shape

```jsonc
// POST /api/v1/tracks/compose
{
  "prompt": { "text": "30 seconds peaceful lo-fi chill hop track" },
  "format": "wav",          // optional: wav | mp3 | aac
  "looping": false          // optional
}

// GET /api/v1/tasks/{task_id} -> when composed:
{
  "status": "composed",
  "meta": {
    "project_id": "...",
    "track_id": "...",
    "prompt": { "text": "..." },
    "version": 1,
    "track_url": "<signed-url>",
    "stems_url": {
      "bass": "<signed-url>",
      "chords": "<signed-url>",
      "melody": "<signed-url>",
      "percussion": "<signed-url>"
    }
  }
}
```

## MEAI Tools

| Tool | Description |
|------|-------------|
| `AsComposeTrackTool()` | Start a composition from a prompt (returns task_id) |
| `AsGetTaskStatusTool()` | Get current status + URLs when finished |
| `AsWaitForTrackTool()` | Poll until status is `composed` or `failed` |
| `AsListMoodsTool()` | Curated list of mood/genre keywords for prompts |

Beatoven does not expose a moods/genres enumeration endpoint; prompts are
freeform text, so `AsListMoodsTool` returns a static curated list of
keywords (happy, peaceful, cinematic, lo-fi, etc.) that can be embedded in
compose prompts.

## Notes

- `TaskStatus` enum name collides with `System.Threading.Tasks.TaskStatus`.
  Inside `Beatoven` namespace it resolves to `Beatoven.TaskStatus`. In tests
  under `Beatoven.IntegrationTests`, reference it fully as `Beatoven.TaskStatus`
  to avoid ambiguity.
- Old deprecated endpoints (`POST /api/v1/tracks`, `POST /api/v1/tracks/compose/{track_id}`)
  are **not** exposed -- the current spec uses the single `POST /api/v1/tracks/compose`
  prompt-based endpoint.
