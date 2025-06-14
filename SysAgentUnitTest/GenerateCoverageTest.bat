dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings
reportgenerator -reports:"TestResults\*\coverage.cobertura.xml" -targetdir:coveragereport