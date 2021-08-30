# Dotnet Tracing Instrumentation Sample

## Getting started

### OpenTelemetry

#### Demonstration

1. Run Jaeger
```
docker-compose up -d
```
2. Run code
```
dotnet run
```
3. Call https://localhost:5001/my/RandomUser
4. See result in Jaeger

### Adopt to your codebase

You can copy method `InstallOpenTelemetryTracing` into your Startup.cs

### XRay

#### Demonstration

1. Setup AWS account in AWS CLI
2. Download [Serverless framework](https://www.serverless.com/)
3. Deploy using `make deploy`
4. Invoke Lambda and see result in XRay

#### Adoption

You can copy method `InstallXRayTracing` into your Startup.cs
