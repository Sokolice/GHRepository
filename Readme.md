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

![Missing Plants](/docs/missing.PNG) number of plants which can be sowed this week and are not yet \

![Repeated Planting](/docs/repeated.PNG) number of plants which can be sowed repeatedly for whole year harvest eg. dill, radish 

![Harvest](/docs/harvest.PNG) number of plants ready to harvest based on presumption 


![Rainy](/docs/rainy.PNG) notification in case of 6 and more rainy days in foreacast for user location

![Freeze](/docs/freeze.PNG) freeze alert

![To Do](/docs/todo.PNG) unfinished tasks for this week 

![Home Page](/docs/home.PNG)

### Sewing plan / Přehled výsevu

![Home Page](/docs/sewing_plan.PNG)

### Growing / Roste
![Home Page](/docs/records.PNG)

### Beds list / Seznam záhonů
![Home Page](/docs/beds.PNG)

### Adding plant into bed / Přidání rosltiny do záhonu
![Home Page](/docs/bed_plant_add.PNG)
### Suitable plants / Vhodnost rostlin
Plant options are updated based on added plant. You can see green, red or orange color which represents suitabality of plants due to already planted. 
![Home Page](/docs/bed_plants_hints.PNG)
### Completed bed / Dokončený záhon
![Home Page](/docs/completed_bed.PNG)
