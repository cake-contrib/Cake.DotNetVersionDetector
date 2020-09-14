$ErrorActionPreference = 'Stop'

function Run([string[]]$arguments) {
    $proc = Start-Process "dotnet" $arguments -PassThru
    Wait-Process -InputObject $proc

    if ($proc.ExitCode -ne 0) {
        "Non-Zero exit code ($($proc.ExitCode)), exiting..."
        exit $proc.ExitCode
    }
}

Run tool, restore

Run cake, recipe.cake, --bootstrap

$arguments = @("cake"; "recipe.cake")
$arguments += @($args)

Run $arguments