# Vehicle Tracker Application (Microservice)
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

# -------Exposed API with Ocelot-------
http://localhost:6543/swagger

```
![EventSourcingMetadata](https://github.com/MongkonEiadon/VehicleTracker/blob/master/img/vehicle-swagger.PNG)

### How Microservices can know each others
So when every single microservice emitting from them aggregate (aka. VehicleAggregate) them always produce single event and store to EventSourcing by itself. That mean other service didn't know what happend on that service, so we will communicate with RabbitMq following this simple work flow

![EventSourcingMetadata](https://github.com/MongkonEiadon/VehicleTracker/blob/master/img/rabbitmq_howits_works.png)

and we create another sample console application to consume the event (listening the events from queue at rabbitmq), when we publishing the event will be up to the exchange stream in rabbitmq, and we need to bining to the queue that we want to consume, so this is then result when we consume the event from vehicle service with another service

![EventSourcingMetadata](https://github.com/MongkonEiadon/VehicleTracker/blob/master/img/consume_event.png)

you can check the connections with rabbitmq management tools by go to (http://localhost:15672/#/) with test/test login/password here

![EventSourcingMetadata](https://github.com/MongkonEiadon/VehicleTracker/blob/master/img/rabbitmq_connections.PNG)




### Example Information
This is example of event sourcing metadata 
![EventSourcingMetadata](https://github.com/MongkonEiadon/VehicleTracker/blob/master/img/eventsourcing-example.PNG)

## Milestones
- [x] Get/Delete/Create a Vehicle
- [x] Add AgreegateSnapshot
- [x] Custom readstore called "EFSearchableReadstore"
- [ ] Complete API Gateway with Ocelot
- [ ] A Sample for AggregateSaga
- [ ] STS (Secured Token Service) with Redis and IdentityServer4
- [ ] Implement "[EventStore](https://eventstore.org/)" instead of using "EntityFramework" to store event sourcing
- [ ] Integrate with GoogleMap API to send near place location name

# Support Me
If you've got value from any of the content which I have created, but pull requests are not your thing, then I would also very much appreciate your support by buying me a coffee.

<a href="https://www.buymeacoffee.com/6VF3XHb" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/black_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>
