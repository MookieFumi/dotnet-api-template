# dotnet-api-template

`dotnet new` template for a Minimal API solution: vertical slices, governance files (`Directory.Build.props`,
`Directory.Packages.props`, `.editorconfig`, `global.json`), one example test and GitHub Actions workflows.

```bash
dotnet new install Acme.Api.Template
dotnet new acme-api -n Orders            # Orders.Api, Orders.Api.Tests
dotnet new acme-api -n Orders --aspire   # + AppHost and ServiceDefaults
dotnet new acme-api -n Orders --worker   # + background worker
```

## Layout

| Path | What it is |
|---|---|
| `Acme.Api.Template.csproj` | Packs the template into a NuGet package. |
| `templates/api/.template.config/` | Template definition (`template.json`, CLI host options). |
| `templates/api/` | The files copied into the new solution. |
| `.github/workflows/ci.yml` | Packs, installs and builds every parameter combination. |
| `.github/workflows/release.yml` | Publishes the package to GitHub Packages on a `v*` tag. |
