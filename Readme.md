# Gardening Helper / Zahradníkův pomocník
This project is the result of learning REACT on maternity leave. 

It is simple web application for gardeners. It can be used for maintaning informations about planted crops such as:
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
Client is written in React using TypeScript. There are two Backend APIs. One is used for data access and another is used for generating Recipe ideas.
### Client - React
- MobX
- Axois
- Semantic UI for React
- FontAwesome
- Formik

### Backend - .Net C#
- .Net API for accessing SQLite Database using Entity Framework
- .Net API for creating recipes ideas
- OpenWeather API for generating weather warnings

## Project Description
Gardener Helper consists of four parts. Sewing plan, list of planted vegetables, bed creation and list of gardening tips and tasks. There are variety of notifications on main page such as:

![Missing Plants](/docs/missing.png) number of plants which can be sown this week and are not yet 

![To Do](/docs/todo.png) unfinished tasks for this week 

![Home Page](/docs/home.png)

### Sewing plan / Přehled výsevu

![Home Page](/docs/sewing_plan.png)

![Home Page](/docs/records.png)