StartR
=====

# About
S.t.a.r.t.R is a sample project that shows how to leverage SignalR/ServiceStack, TopShelf, Asp.Net MVC, RabbitMQ, and Twitter Bootstrap to build highly scalable real-time web sites using Command Queues and Event Driven Architecture.  Or as I like to call it a Queued Services Architecture. 

My goal is to have a working example to show fellow developers about how web applications today are really composite applications made up of at least 3 pieces: Web UI, REST API, Windows Services. The days of large monolithic web apps are over (or at least should be in my opinion).

My other goal is to show how to leverage a Queued Services Architecture to achieve super scalability and show how an application should be built for failure from the ground up. Or what I like to call Self Healing. Meaning if one or more dependencies are down the app still works. When those dependencies come back online things will still get processed and not lost.  Plus, really the system becomes super simple to think about. Everything is a message and is one of two types: a command or an event. A command being a unit of work that must occur and an event that is created after a unit of work. 

The awesomeness of async messaging is how large web sites scale. StartR shows how this is done on the .NET platform.

# Technologies
* SignalR
* TopShelf
* Asp.Net MVC
* RabbitMQ
* ServiceStack
* Swagger
* XSerializer 

# Setup and Project Structure

## Setup RabbitMQ
You'll need to install and setup RabbitMQ locally before trying to run StartR. When you run the application the first time the proper queues will be created. StartR uses two queues right now:

*StartR - this queue is where commands and events are written to either from the UI or the services
*StartR.SignalR - this queue processes push notification by the StartR.PushNoticationService project.

## Database
No setup required it is baked into project.

## Running the application
When you start the application from Visual Studio (press F5) four projects will start. 

*The Web UI which will load the first 20 client records in the database via the REST API. 
*StartR.MessageCreator - windows application to help in debugging, it can simulate messages being sent to the queue for the services to process
*StartR.MessageProcessorService - this is a console app but configured to use TopShelf so it can be deployed as a Windows Service. It processes Command and Event messages from the StartR queue in RabbitMQ. 
*StartR.PushNotificationService - this is a console app but configured to use TopShelf so it can be deployed as a Windows Service. It processes messages that are to be pushed to Web UI. 

# How To Run
Press F5 in Visual Studio and wait for the home page to load. Once it loads press the create client button on the home page. Fill in all the data fields and press create. The REST API will be called to save the client and the UI redirects to the details page for the client and waits for the long running business process of client qualification to complete. 

In the backend, after the client is persisted a ClientCreatedEvent message is sent to the StartR queue. The StartR.MessagProcessorService picks up the message and routes to the PoorMansRouter (which is a super simple router because I haven't had time to finish the real one yet). The router routes either events/commands to the proper event/command handler. In this case the router will route the ClientCreatedEvent to the ClientCreatedEventHandler and invoke its Handle() method. 

A new message is created and put back onto the queue called QualifyClientCommand. This command runs qualification (it is all hard coded for the moment until I finish it to be broken up into more commands to showcase transactional http calls). 

The QualifyClientCommand generates the ClientQualification and then sends that data to the StartR.SignalR queue. That data is then picked up by the StartR.PushNotificationService and using SignalR pushes the information back into Web UI. There is currently a Thread.Sleep of 3 seconds so it should take about 3 seconds after the client is created for it to show up in the Web UI page. 

# What's Coming
First let me say that I'm no where near done with this as it is a work in progress. The goal is to build out a full fledged little app that can showcase a variety of technologies all coming together in a unique and interesting way using a Queued Services Architecture. 

If anyone finds a bug or better way to do something go for it. Get those Pull Requests in.
