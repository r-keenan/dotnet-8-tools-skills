using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http;
using NBomber.Http.CSharp;
using NBomber.Plugins.Network.Ping;

// Use System.Http.HttpClient to make HTTP requests.
using HttpClient client = new();

LoadSimulation[] loads =
[
    // Ramp up to 50 RPS during one minute
    Simulation.RampingInject(
        rate: 50,
        interval: TimeSpan.FromSeconds(1),
        during: TimeSpan.FromMinutes(1)
    ),
    // Maintain 50 RPS for another minute
    Simulation.Inject(rate: 50, interval: TimeSpan.FromSeconds(1), during: TimeSpan.FromMinutes(1)),
    // Ramp down to 0 RPS during one minute
    Simulation.RampingInject(
        rate: 0,
        interval: TimeSpan.FromSeconds(1),
        during: TimeSpan.FromMinutes(1)
    ),
];

ScenarioProps scenario = Scenario
    .Create(
        name: "http_scenario",
        run: async context =>
        {
            HttpRequestMessage request = Http.CreateRequest(
                    "GET",
                    "http://localhost:5255/weatherforecast"
                )
                .WithHeader("Accept", "application/json");

            // Use WithHeader and WithBody to send a JSON payload
            Response<HttpResponseMessage> response = await Http.Send(client, request);

            return response;
        }
    )
    .WithoutWarmUp()
    .WithLoadSimulations(loads);

NBomberRunner
    .RegisterScenarios(scenario)
    .WithWorkerPlugins(
        new PingPlugin(PingPluginConfig.CreateDefault("nbomber.com")),
        new HttpMetricsPlugin([HttpVersion.Version1])
    )
    .Run();
