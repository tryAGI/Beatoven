install_autosdk_cli() {
  dotnet tool update --global autosdk.cli --prerelease >/dev/null 2>&1 || \
    dotnet tool install --global autosdk.cli --prerelease
}

install_autosdk_cli
rm -rf Generated
cp ../../../openapi.yaml openapi.yaml

autosdk generate openapi.yaml \
  --namespace Beatoven \
  --clientClassName BeatovenClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations \
  --security-scheme Http:Header:Bearer

rm -rf ../../cli/Beatoven.CLI

autosdk cli-project openapi.yaml \
  --output ../../cli/Beatoven.CLI \
  --sdk-project ../../libs/Beatoven/Beatoven.csproj \
  --targetFramework net10.0 \
  --namespace Beatoven \
  --clientClassName BeatovenClient \
  --package-id Beatoven.CLI \
  --tool-command-name beatoven \
  --user-secrets-id Beatoven.CLI \
  --api-key-env-var BEATOVEN_API_KEY \
  --base-url-env-var BEATOVEN_BASE_URL \
  --cli-credential-file \
  --exclude-deprecated-operations \
  --security-scheme Http:Header:Bearer
