cd ./
$build = $Env:APPVEYOR_BUILD_NUMBER
dotnet build
dotnet test
