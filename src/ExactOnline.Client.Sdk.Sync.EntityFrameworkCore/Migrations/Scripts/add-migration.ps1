param(
     [Parameter(Mandatory=$true)]
     [ValidateNotNullOrEmpty()]
     [string]$migration  
)

dotnet ef migrations add $migration --project ../..
