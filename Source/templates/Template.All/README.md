Some useful commands provided via NUKE to run solution:
./build.ps1 --target Run(by default runs Template.Api)
./build.ps1 --target Coverage
./build.ps1 --target Pack
./build.ps1 --target Publish(by default publish Template.Api)
./build.ps1 --target Compile
./build.ps1 --target Analysis(Resharper feature and need to be installed on machine)
Output of targets Coverage, Pack, Publish, Analysis will be folder artifacts in root folder.
And to stress test:
https://k6.io/
k6 run --vus 30 --duration 10s script.js

Stress test result:

    ✓ status was 200

    checks.....................: 100.00% ✓ 401  ✗ 0
    data_received..............: 208 kB  21 kB/s
    data_sent..................: 53 kB   5.3 kB/s
    http_req_blocked...........: avg=13.21ms  min=0s       med=0s       max=201.03ms p(90)=0s       p(95)=164.51ms
    http_req_connecting........: avg=77.32µs  min=0s       med=0s       max=2ms      p(90)=0s       p(95)=1ms
    http_req_duration..........: avg=712.71ms min=466.99ms med=671.12ms max=1.61s    p(90)=949.02ms p(95)=1.06s
    http_req_receiving.........: avg=108.87µs min=0s       med=0s       max=1ms      p(90)=971.6µs  p(95)=999.9µs
    http_req_sending...........: avg=64.5µs   min=0s       med=0s       max=1ms      p(90)=0s       p(95)=995.8µs
    http_req_tls_handshaking...: avg=13.06ms  min=0s       med=0s       max=197.03ms p(90)=0s       p(95)=163.51ms
    http_req_waiting...........: avg=712.54ms min=466.99ms med=671.12ms max=1.61s    p(90)=949.02ms p(95)=1.06s
    http_reqs..................: 401     40.092861/s
    iteration_duration.........: avg=726.06ms min=466.99ms med=676.45ms max=1.61s    p(90)=978.84ms p(95)=1.09s
    iterations.................: 401     40.092861/s
    vus........................: 30      min=30 max=30
    vus_max....................: 30      min=30 max=30


More infromation about MSBuild SDK I described here:
https://devstyle.pl/2019/10/01/wycisnij-z-msbuilda-ostatnie-soki/
https://devstyle.pl/2019/11/25/cake-jak-wdrazac-aby-sie-nie-zrazac/
https://devstyle.pl/2019/12/09/jak-zbudowac-samozarzadzalny-system-w-net/

This solution is more like a template for relational database.
Everything starts at contracts, they define what you can do, from API endpoints(Refit) or models that can be shared. The application part implement contracts. Services contain SPA(Template),
backend service(Template.Api), frontend service(Template.Presentation.Api) and ESB. To eliminate CORS Template.Api works as a proxy for Template.Presentation.Api to access data.
Tests follow an approach called test contracting which means we are testing only what we expose via contracts.

Functional tests test endpoints defined via Refit
Integration tests test application part
Tests(or unit tests) test domain.

In more advanced scenarios and systems, I don't use "Repositories", "Services" because everything follows
CQRS and SQL scripts(performance reasons). By not using Repositories I mean not creating a concrete implementation
for certain models but rather using the common, generic approach with basic methods load and save. Everything follows DDD
so aggregate root knows how to change themself.

If you want to stress test application I provided additional method GetUserRepositories with Authorization header.

I didn't implement a circuit breaker(for example with Polly) in API(20 RPS is a too small number), omitted loggers, exception handling.