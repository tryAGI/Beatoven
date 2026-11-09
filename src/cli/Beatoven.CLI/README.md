# Beatoven.CLI

Command-line interface for the Beatoven SDK generated with AutoSDK.

## Installation

```bash
dotnet tool install --global Beatoven.CLI --prerelease
```

## Usage

```bash
beatoven --help
beatoven tasks --help
```

## Shell completion

The `completion` command prints a script built from the live command tree, so
subcommands, option names and the values of enum-typed options stay correct after the
spec is refreshed and the CLI regenerated — there is no word list to maintain.

```bash
beatoven completion bash > /usr/local/etc/bash_completion.d/beatoven
beatoven completion zsh  > _beatoven   # then put it on your zsh fpath
beatoven completion fish > ~/.config/fish/completions/beatoven.fish
```

## Customization

Generated operation, tag, and API group command classes are partial. Implement
`static partial void CustomizeCommand(ref Command command)` in a separate source
file to add aliases or validators, change the action, or replace a command. The
hook runs after the generated command has been configured.