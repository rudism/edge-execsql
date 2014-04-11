edge = require 'edge'

_connectionString = "YOUR-CONNECTION-STRING"

_bulkInsert = edge.func
	assemblyFile: './NoMoDb.dll'
	typeName: 'NoMoDb.SqlExecutor'
	methodName: 'BulkInsert'

_executeScript = edge.func
	assemblyFile: './NoMoDb.dll'
	typeName: 'NoMoDb.SqlExecutor'
	methodName: 'ExecuteScript'

exports.bulkInsert = (table, file) ->
	console.log "Inserting #{file} into table #{table}"
	data =
		connectionString: _connectionString
		table: table
		file: file
	_bulkInsert data, true

exports.executeScript = (file) ->
	console.log "Executing script #{file}"
	data =
		connectionString: _connectionString
		scriptPath: file
	_executeScript data, true
