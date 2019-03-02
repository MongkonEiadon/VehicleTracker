# Vehicle Tracking Application (Microservice)
Vehicle Tracking sample microservice designed by CQRS Architechture, and ES (Event Sourcing) based on [EventFlow](https://github.com/eventflow/EventFlow), and .NET Core framework on the EntityFramework with SQL Server also Dockerize Linux supported

[![Build Status](https://dev.azure.com/mongkoneiadon/VehicleTracker/_apis/build/status/MongkonEiadon.VehicleTracker?branchName=master)](https://dev.azure.com/mongkoneiadon/VehicleTracker/_build/latest?definitionId=2&branchName=master)

# Introduction
This is example for running various microservice in case of Vehicle Tracking. The plateform ran on .NET Core framework with Linux compatible. And designed along the dockerize concept with convenince way to use. And the core concept of CQRS that brought up by [EventFlow](https://github.com/eventflow/EventFlow) that I spent a lot of time to learning it. 


## The Architecture
I'm not know well about Microservices concept, while you can help me to make it better way, however when I've look back to the starting.. It's very painful to re-thinking what CQRS is, 
![OverallArchitecture](https://github.com/MongkonEiadon/VehicleTracker/blob/master/img/architecture.PNG)

## How to up the services
Now every services setting up on docker compose file, you can easier run it by simple steps;
``` javascript

$ cd src
$ docker-compose up

```

### Swagger supported
You can have a look exposed endpoint by calling:
``` javascript

# -------Vehicle API-------
https://localhost:32772/swagger

```

### Example Information
This is example of event sourcing metadata 
![EventSourcingMetadata](https://github.com/MongkonEiadon/VehicleTracker/blob/master/img/eventsourcing-example.PNG)

## Milestones
- [x] Get/Delete/Create a Vehicle
- [x] Add AgreegateSnapshot
- [x] Custom readstore called "EFSearchableReadstore"
- [ ] A Sample for AggregateSaga
- [ ] STS (Secured Token Service) with Redis and IdentityServer4
- [ ] Implement "ReadStore" instead of using "EntityFramework" to store event sourcing
- [ ] Integrate with GoogleMap API to send near place location name
