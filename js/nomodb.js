var edge, _bulkInsert, _connectionString, _executeScript;

edge = require('edge');

_connectionString = "YOUR-CONNECTION-STRING";

_bulkInsert = edge.func({
  assemblyFile: './NoMoDb.dll',
  typeName: 'NoMoDb.SqlExecutor',
  methodName: 'BulkInsert'
});

_executeScript = edge.func({
  assemblyFile: './NoMoDb.dll',
  typeName: 'NoMoDb.SqlExecutor',
  methodName: 'ExecuteScript'
});

exports.bulkInsert = function(table, file) {
  var data;
  console.log("Inserting " + file + " into table " + table);
  data = {
    connectionString: _connectionString,
    table: table,
    file: file
  };
  return _bulkInsert(data, true);
};

exports.executeScript = function(file) {
  var data;
  console.log("Executing script " + file);
  data = {
    connectionString: _connectionString,
    scriptPath: file
  };
  return _executeScript(data, true);
};
