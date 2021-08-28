deploy:
	dotnet lambda package --configuration Release --framework netcoreapp3.1 --output-package bin/Release/netcoreapp3.1/TodoApiWithTrace.zip
	sls deploy
