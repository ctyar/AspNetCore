function Test-Template($templateName, $templateArgs, $templateNupkg, $isSPA) {
    $tmpDir = "$PSScriptRoot/$templateName"
    Remove-Item -Path $tmpDir -Recurse -ErrorAction Ignore

    #& "$PSScriptRoot/../build.ps1" /t:Package
    Run-DotnetNew "--install", "$PSScriptRoot/../../../artifacts/Debug/packages/product/$templateNupkg"

    New-Item -ErrorAction Ignore -Path $tmpDir -ItemType Directory
    Push-Location $tmpDir
    try {
        Run-DotnetNew $templateArgs, "--no-restore"

        if ($templateArgs -match 'F#') {
            $extension = "fsproj"
        }
        else {
            $extension = "csproj"
        }

        $proj = "$tmpDir/$templateName.$extension"
        $projContent = Get-Content -Path $proj -Raw
        $projContent = $projContent -replace ('<Project Sdk="Microsoft.NET.Sdk.Web">', "<Project Sdk=""Microsoft.NET.Sdk.Web"">
  <Import Project=""$PSScriptRoot/../test/Templates.Test/bin/Debug/netcoreapp3.0/TemplateTests.props"" />
  <ItemGroup>
    <PackageReference Include=""Microsoft.NET.Sdk.Razor"" Version=""`$(MicrosoftNETSdkRazorPackageVersion)"" />
  </ItemGroup>")
        $projContent | Set-Content $proj

        dotnet publish --configuration Release
        dotnet bin\Release\netcoreapp3.0\publish\$templateName.dll
    }
    finally {
        Pop-Location
        Run-DotnetNew "--debug:reinit"
    }
}

function Run-DotnetNew($arguments) {
    $expression = "dotnet new $arguments"
    Invoke-Expression $expression
}
