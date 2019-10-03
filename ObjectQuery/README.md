# Object Query

## Problem

We have an object instance (say type 'Person'). We want to run computations on that object (say calculate person's display name, weight in grams, etc). Each of those computations is an query that is run on that object (with possibility to use external data). 

## Requirements
* Each query is atomic and can be run independently from others
* Each query can be testible individually 
* Queries can be combined together to produce complex query scenarios 
* Each query can be re-used (multiple complex queries can call the same query)




