# Gardening Helper / Zahradníkův pomocník
This project is the result of learning REACT on maternity leave. 

It is simple web application for gardeners.It can be used for maintaning informations about planted crops such as:
- amount
- date planted
- place in raised bed 
 
It is source of useful facts about plants:
- companion and avoid plants
- pests and solution 

And has some cool features:
- gardening tips for every month
- weather warnings

## Technologies used
Client is written in React using TypeScript. There are two BackEnd APIs. One is used for data access and another is used for generating Recipe ideas.
### Client - React
- MobX
- Axois
- Semantic UI for React
- FontAwesome

### BackEnd
- .NET API for accessing SQLite Database
- .NET API for creating recipes ideas
- OpenWeather API for generating weather warnings

## Project Description
Gardener Helper consists of four parts. Sewing plan, list of planted vegetables, bed creation and list of gardening tips and tasks.

On main page you can see variety of notifications.

![Home Page](/docs/home.png)

### Sewing plan

![Home Page](/docs/sewing_plan.png)

![Home Page](/docs/records.png)