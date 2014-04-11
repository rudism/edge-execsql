edge-execsql
============

Simple class to execute sql scripts and perform bulk inserts using Node and Edge.js.

To use, copy NoMoDb.dll and nomodb.js to your project, update the connection string in nomodb.js, and:

    var nomodb = require('./nomodb');
    nomodb.bulkInsert('table-name', 'c:\\path\\to\\csv.txt');
    nomodb.executeScript('c:\\path\\to\\script.sql');
