﻿
namespace EfCoreScaffoldMssql
{
    internal static class SchemaSql
    {
        internal static string TablesSql = @"SELECT s.name as SchemaName, t.name as EntityName FROM Sys.tables t
JOIN Sys.schemas s on s.schema_id = t.schema_id";

        internal static string ViewsSql = @"SELECT s.name as SchemaName, t.name as EntityName FROM Sys.views t
JOIN Sys.schemas s on s.schema_id = t.schema_id";

        internal static string TableColumnsSql = @"select 
	c.name as [Name], 
	s.name as SchemaName, 
	t.name as ObjectName,
	typ.name as [TypeName],
	c.max_length as [MaxLength],
	c.is_computed as IsComputed,
	c.is_nullable as IsNullable,
	c.is_identity as IsIdentity,
    object_definition(c.default_object_id) AS DefaultDefinition,
    cc.definition as ComputedColumnSql,
    c.column_id as ColumnId
from Sys.columns c
JOIN Sys.tables t on t.object_id = c.object_id
JOIN Sys.schemas s on s.schema_id = t.schema_id
JOIN Sys.types typ on c.user_type_id = typ.user_type_id
LEFT OUTER JOIN Sys.computed_columns cc on c.object_id = cc.object_id and c.column_id = cc.column_id";

        internal static string ViewColumnsSql = @"select 
	c.name as [Name], 
	s.name as SchemaName, 
	v.name as ObjectName,
	typ.name as [TypeName],
	c.max_length as [MaxLength],
	c.is_computed as IsComputed,
	c.is_nullable as IsNullable,
	c.is_identity as IsIdentity,
    object_definition(c.default_object_id) AS DefaultDefinition,
    cc.definition as ComputedColumnSql,
    c.column_id as ColumnId
from Sys.columns c
JOIN Sys.views v on v.object_id = c.object_id
JOIN Sys.schemas s on s.schema_id = v.schema_id
JOIN Sys.types typ on c.user_type_id = typ.user_type_id
LEFT OUTER JOIN Sys.computed_columns cc on c.object_id = cc.object_id and c.column_id = cc.column_id";

        internal static string ForeignKeysSql = @"SELECT RC.CONSTRAINT_NAME FkName
, KF.TABLE_SCHEMA FkSchema
, KF.TABLE_NAME FkTable
, KF.COLUMN_NAME FkColumn
, RC.UNIQUE_CONSTRAINT_NAME PkName
, KP.TABLE_SCHEMA PkSchema
, KP.TABLE_NAME PkTable
, KP.COLUMN_NAME PkColumn
, RC.MATCH_OPTION MatchOption
, RC.UPDATE_RULE UpdateRule
, RC.DELETE_RULE DeleteRule
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC
JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KF ON RC.CONSTRAINT_NAME = KF.CONSTRAINT_NAME
JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KP ON RC.UNIQUE_CONSTRAINT_NAME = KP.CONSTRAINT_NAME";

        internal static string KeyColumnsSql = @"select 
  s.name as TableSchema,
  t.name as TableName,
  c.name as ColumnName,
  i.name as KeyName
from sys.tables t
JOIN sys.schemas s on s.schema_id = t.schema_id
JOIN sys.columns c on c.object_id = t.object_id
JOIN sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id
JOIN sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id
WHERE i.is_primary_key = 1";

    }
}
