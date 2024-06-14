param(
     [Parameter(Mandatory=$true)]
     [AllowEmptyString()]
     [string]$migration = ''
)

dotnet ef database update $migration --project ../..
